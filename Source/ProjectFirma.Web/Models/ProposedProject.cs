﻿/*-----------------------------------------------------------------------
<copyright file="ProposedProject.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using LtInfo.Common;
using LtInfo.Common.GeoJson;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class ProposedProject : IAuditableEntity, IProject
    {
        public int EntityID => ProposedProjectID;

        public string AuditDescriptionString => ProjectName;

        public string DisplayName => ProjectName;

        public HtmlString DisplayNameAsUrl => UrlTemplate.MakeHrefString(this.GetDetailUrl(), DisplayName);

        public static bool IsProjectNameUnique(IEnumerable<ProposedProject> projects, string projectName, int currentProposedProjectID)
        {
            if (string.IsNullOrWhiteSpace(projectName))
            {
                return false;
            }

            var project = projects.SingleOrDefault(x => x.ProposedProjectID != currentProposedProjectID && string.Equals(x.ProjectName.Trim(), projectName.Trim(), StringComparison.InvariantCultureIgnoreCase));
            return project == null;
        }

        public Person GetPrimaryContactPerson => PrimaryContactPerson ?? LeadImplementerOrganization.PrimaryContactPerson;

        public decimal? UnfundedNeed => EstimatedTotalCost - SecuredFunding;

        public bool HasProjectLocationPoint => ProjectLocationPoint != null;

        //TODO: This could be moved to ProjectLocationSimpleType and made smarter
        public string ProjectLocationTypeDisplay
        {
            get
            {
                if (ProjectLocationAreaID.HasValue && ProjectLocationArea.ProjectLocationAreaGroup.ProjectLocationAreaGroupType == ProjectLocationAreaGroupType.MappedRegion)
                {
                    return ProjectLocationArea.ProjectLocationAreaDisplayName;
                }
                return ViewUtilities.NaString;
            }
        }

        private string _projectLocationStateProvince;
        private bool _hasSetProjectLocationStateProvince;
        public string ProjectLocationStateProvince
        {
            get
            {
                if (_hasSetProjectLocationStateProvince)
                {
                    return _projectLocationStateProvince;
                }
                SetProjectLocationStateProvince(HttpRequestStorage.DatabaseEntities.StateProvinces.ToList());
                return _projectLocationStateProvince;
            }
            set
            {
                _projectLocationStateProvince = value;
                _hasSetProjectLocationStateProvince = true;
            }
        }

        public void SetProjectLocationStateProvince(IEnumerable<StateProvince> stateProvinces)
        {

            if (HasProjectLocationPoint)
            {
                var stateProvince = stateProvinces.FirstOrDefault(x => x.StateProvinceFeatureForAnalysis.Intersects(ProjectLocationPoint));
                ProjectLocationStateProvince = stateProvince != null ? stateProvince.StateProvinceAbbreviation : ViewUtilities.NaString;
            }
            else if (ProjectLocationAreaID.HasValue)
            {
                ProjectLocationStateProvince = string.Join(", ", ProjectLocationArea.ProjectLocationAreaStateProvinces.Select(x => x.StateProvince.StateProvinceAbbreviation));
            }
            else
            {
                ProjectLocationStateProvince = ViewUtilities.NaString;
            }
        }

        private string _projectLocationWatershed;
        private bool _hasSetProjectLocationWatershed;
        public string ProjectLocationWatershed
        {
            get
            {
                if (_hasSetProjectLocationWatershed)
                {
                    return _projectLocationWatershed;
                }
                SetProjectLocationWatershed(HttpRequestStorage.DatabaseEntities.Watersheds.GetWatershedsWithGeospatialFeatures());
                return _projectLocationWatershed;
            }
            set
            {
                _projectLocationWatershed = value;
                _hasSetProjectLocationWatershed = true;
            }
        }

        public void SetProjectLocationWatershed(IEnumerable<Watershed> watersheds)
        {
            if (HasProjectLocationPoint)
            {
                var watershed = watersheds.FirstOrDefault(x => x.WatershedFeature.Intersects(ProjectLocationPoint));
                ProjectLocationWatershed = watershed != null ? watershed.WatershedName : ViewUtilities.NaString;
            }
            else if (ProjectLocationAreaID.HasValue)
            {
                ProjectLocationWatershed = string.Join(", ", ProjectLocationArea.ProjectLocationAreaWatersheds.Select(x => x.Watershed.WatershedName));
            }
            else
            {
                ProjectLocationWatershed = ViewUtilities.NaString;
            }
        }

        public bool IsMyProposedProject(Person person)
        {
            return IsPersonThePrimaryContact(person) || DoesPersonBelongToProposedProjectLeadImplementingOranization(person) || person.PersonID == ProposingPersonID;
        }

        public bool IsEditableToThisPerson(Person person)
        {
            return IsMyProposedProject(person) || new ProposedProjectApproveFeature().HasPermissionByPerson(person);
        }

        public bool IsVisibleToThisPerson(Person person)
        {
            return IsMyProposedProject(person) || new ProposedProjectApproveFeature().HasPermissionByPerson(person) || new FirmaAdminFeature().HasPermissionByPerson(person);
        }

        public bool IsPersonThePrimaryContact(Person person)
        {
            return PrimaryContactPerson != null && person != null && person.PersonID == PrimaryContactPerson.PersonID;
        }

        public bool DoesPersonBelongToProposedProjectLeadImplementingOranization(Person person)
        {
            return person != null && LeadImplementerOrganizationID == person.OrganizationID;
        }

        public PermissionCheckResult CanDelete()
        {
            return new PermissionCheckResult();
        }

        public ProjectStage ProjectStage => ProjectStage.PlanningDesign;

        public ProjectType ProjectType => ProjectType.ProposedProject;

        public IEnumerable<IQuestionAnswer> GetQuestionAnswers()
        {
            return ProposedProjectAssessmentQuestions;
        }

        public IEnumerable<IProjectLocation> GetProjectLocationDetails()
        {
            return ProposedProjectLocations.ToList();
        }

        public GeoJSON.Net.Feature.FeatureCollection DetailedLocationToGeoJsonFeatureCollection()
        {
            return ProposedProjectLocations.ToGeoJsonFeatureCollection();
        }

        public GeoJSON.Net.Feature.FeatureCollection SimpleLocationToGeoJsonFeatureCollection(bool addProjectProperties)
        {
            var featureCollection = new GeoJSON.Net.Feature.FeatureCollection();
            if (ProjectLocationSimpleType == ProjectLocationSimpleType.PointOnMap)
            {
                featureCollection.Features.Add(DbGeometryToGeoJsonHelper.FromDbGeometry(ProjectLocationPoint));
            }
            else if (ProjectLocationSimpleType == ProjectLocationSimpleType.NamedAreas)
            {
                featureCollection.Features.Add(DbGeometryToGeoJsonHelper.FromDbGeometry(ProjectLocationArea.GetGeometry()));
            }
            return featureCollection;
        }

        public string Duration =>
            $"{(ImplementationStartYear.HasValue ? ImplementationStartYear.Value.ToString(CultureInfo.InvariantCulture) : "?")} - {(CompletionYear.HasValue ? CompletionYear.Value.ToString(CultureInfo.InvariantCulture) : "?")}";

        public Project PromoteToProject(ProposedProject proposedProject)
        {
            var projectName = proposedProject.ProjectName;

            var project = new Project(proposedProject.TaxonomyTierOneID.Value,
                ProjectStage.PlanningDesign.ProjectStageID,
                projectName,
                proposedProject.ProjectDescription,
                false,
                ProjectLocationSimpleType.ProjectLocationSimpleTypeID,
                FundingType.FundingTypeID,
                proposedProject.LeadImplementerOrganizationID)
            {
                PlanningDesignStartYear =  proposedProject.PlanningDesignStartYear,
                ImplementationStartYear =  proposedProject.ImplementationStartYear,
                CompletionYear = proposedProject.CompletionYear,
                EstimatedTotalCost =  proposedProject.EstimatedTotalCost,
                EstimatedAnnualOperatingCost = proposedProject.EstimatedAnnualOperatingCost,
                SecuredFunding= proposedProject.SecuredFunding,
                ProjectLocationPoint = proposedProject.ProjectLocationPoint,
                ProjectLocationAreaID = proposedProject.ProjectLocationAreaID,
                ProjectLocationNotes = proposedProject.ProjectLocationNotes,
            };
            project.ProjectNotes = proposedProject.ProposedProjectNotes.Select(x => new ProjectNote(project, x.Note, x.CreateDate)).ToList();
            project.ProjectClassifications = proposedProject.ProposedProjectClassifications.Select(x => new ProjectClassification(project.ProjectID, x.ClassificationID, x.ProposedProjectClassificationNotes)).ToList();

            if (proposedProject.PrimaryContactPerson != null)
            {
                project.PrimaryContactPerson = proposedProject.PrimaryContactPerson;
            }
            
            project.ProjectAssessmentQuestions = proposedProject.ProposedProjectAssessmentQuestions.OrderBy(x => x.AssessmentQuestionID).Select(x => new ProjectAssessmentQuestion(project.ProjectID, x.AssessmentQuestionID) {Answer = x.Answer}).ToList();

            foreach (var performanceMeasureExpectedProposed in proposedProject.PerformanceMeasureExpectedProposeds)
            {
                var performanceMeasureExpected = new PerformanceMeasureExpected(project.ProjectID, performanceMeasureExpectedProposed.PerformanceMeasureID);
                performanceMeasureExpected.ExpectedValue = performanceMeasureExpectedProposed.ExpectedValue;
                foreach (
                    var performanceMeasureExpectedSubcategoryOptionProposed in
                        performanceMeasureExpectedProposed.PerformanceMeasureExpectedSubcategoryOptionProposeds)
                {
                    var performanceMeasureExpectedSubcategoryOption = new PerformanceMeasureExpectedSubcategoryOption(performanceMeasureExpected,
                        performanceMeasureExpectedSubcategoryOptionProposed.PerformanceMeasureSubcategoryOption,
                        performanceMeasureExpectedSubcategoryOptionProposed.PerformanceMeasure,
                        performanceMeasureExpectedSubcategoryOptionProposed.PerformanceMeasureSubcategory);

                    performanceMeasureExpected.PerformanceMeasureSubcategoryOptions.Add(performanceMeasureExpectedSubcategoryOption);
                }
                project.PerformanceMeasureExpecteds.Add(performanceMeasureExpected);
            }

            foreach (var proposedProjectLocation in proposedProject.ProposedProjectLocations)
            {
                var projectLocation = new ProjectLocation(project, proposedProjectLocation.DbGeometry, proposedProjectLocation.Annotation);
                project.ProjectLocations.Add(projectLocation);
            }

            foreach (var proposedProjectImage in proposedProject.ProposedProjectImages)
            {
                var newFileResource = new FileResource(proposedProjectImage.FileResource.FileResourceMimeType, proposedProjectImage.FileResource.OriginalBaseFilename, proposedProjectImage.FileResource.OriginalFileExtension, Guid.NewGuid(), proposedProjectImage.FileResource.FileResourceData, proposedProjectImage.FileResource.CreatePerson, proposedProjectImage.FileResource.CreateDate);
                var newProjectImage = new ProjectImage(newFileResource, project, ProjectImageTiming.Before, proposedProjectImage.Caption, proposedProjectImage.Credit, false, false);
                project.ProjectImages.Add(newProjectImage);
            }

            return project;
        }

        private DateTime _lastUpdateDate;
        private bool _hasCheckedLastUpdateDate;
        
        public DateTime LastUpdateDate
        {
            get
            {
                if (!_hasCheckedLastUpdateDate)
                {
                    LastUpdateDate = HttpRequestStorage.DatabaseEntities.AuditLogs.GetAuditLogEntriesForProposedProject(this).Max(x => x.AuditLogDate);
                }
                return _lastUpdateDate;
            }
            set
            {
                _lastUpdateDate = value;
                _hasCheckedLastUpdateDate = true;
            }
        }
        public bool AreProjectBasicsValid { get; set; }
        public bool ArePerformanceMeasuresValid { get; set; }
        public bool AreExpendituresValid { get; set; }
        public bool AreBudgetsValid { get; set; }
        public bool IsProjectLocationSimpleValid { get; set; }
    }
}
