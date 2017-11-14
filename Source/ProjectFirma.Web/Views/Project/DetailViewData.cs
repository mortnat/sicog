﻿/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.ProjectUpdate;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.ProjectFunding;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;

namespace ProjectFirma.Web.Views.Project
{
    public class DetailViewData : ProjectViewData
    {
        public bool UserHasProjectAdminPermissions { get; }
        public bool UserHasEditProjectPermissions { get; }
        public bool UserHasPerformanceMeasureActualManagePermissions { get; }

        public string EditProjectUrl { get; }
        public string EditProjectOrganizationsUrl { get; }
        public string EditClassificationsUrl { get; }
        public string EditWatershedsUrl { get; }
        public string EditSimpleProjectLocationUrl { get; }
        public string EditDetailedProjectLocationUrl { get; }
        public string EditPerformanceMeasureExpectedsUrl { get; }
        public string EditPerformanceMeasureActualsUrl { get; }
        public string EditReportedExpendituresUrl { get; }
        public string EditExternalLinksUrl { get; }
        public string EditExpectedFundingUrl { get; }

        public ProjectBasicsViewData ProjectBasicsViewData { get; }
        public ProjectLocationSummaryViewData ProjectLocationSummaryViewData { get; }
        public PerformanceMeasureExpectedSummaryViewData PerformanceMeasureExpectedSummaryViewData { get; }
        public PerformanceMeasureReportedValuesGroupedViewData PerformanceMeasureReportedValuesGroupedViewData { get; }
        public ProjectExpendituresDetailViewData ProjectExpendituresDetailViewData { get; }
        public ImageGalleryViewData ImageGalleryViewData { get; }
        public EntityNotesViewData EntityNotesViewData { get; }
        public EntityExternalLinksViewData EntityExternalLinksViewData { get; }

        public ProjectBasicsTagsViewData ProjectBasicsTagsViewData { get; }

        public List<ProjectStage> ProjectStages { get; }
        public List<Models.ProjectOrganization> AllProjectOrganizations { get; }
        public string MapFormID { get; }

        public ProjectUpdateBatchGridSpec ProjectUpdateBatchGridSpec { get; }
        public string ProjectUpdateBatchGridName { get; }
        public string ProjectUpdateBatchGridDataUrl { get; }

        public AuditLogsGridSpec AuditLogsGridSpec { get; }
        public string AuditLogsGridName { get; }
        public string AuditLogsGridDataUrl { get; }

        public ProjectNotificationGridSpec ProjectNotificationGridSpec { get; }
        public string ProjectNotificationGridName { get; }
        public string ProjectNotificationGridDataUrl { get; }

        public string ClassificationDisplayName { get; }
        public string ClassificationDisplayNamePluralized { get; }
        public string EditProjectWatershedFormID { get; }
        public string ProjectStewardCannotEditUrl { get; }
        public string ProjectStewardCannotEditPendingApprovalUrl { get; }
        public ProjectFundingDetailViewData ProjectFundingDetailViewData { get; }

        public string ProjectUpdateButtonText { get; }
        public bool CanLaunchProjectOrProposalWizard { get; }
        public string ProjectWizardUrl { get; }
        public string ProjectListUrl { get; }
        public string BackToProjectsText { get; }


        public DetailViewData(Person currentPerson, Models.Project project, List<ProjectStage> projectStages,
            ProjectBasicsViewData projectBasicsViewData, ProjectLocationSummaryViewData projectLocationSummaryViewData,
            ProjectFundingDetailViewData projectFundingDetailViewData,
            PerformanceMeasureExpectedSummaryViewData performanceMeasureExpectedSummaryViewData,
            PerformanceMeasureReportedValuesGroupedViewData performanceMeasureReportedValuesGroupedViewData,
            ProjectExpendituresDetailViewData projectExpendituresDetailViewData,
            ImageGalleryViewData imageGalleryViewData, EntityNotesViewData entityNotesViewData,
            EntityExternalLinksViewData entityExternalLinksViewData,
            ProjectBasicsTagsViewData projectBasicsTagsViewData, bool userHasProjectAdminPermissions,
            bool userHasEditProjectPermissions, bool userHasProjectUpdatePermissions,
            bool userHasPerformanceMeasureActualManagePermissions, string mapFormID,
            string editSimpleProjectLocationUrl, string editDetailedProjectLocationUrl,
            string editProjectOrganizationsUrl, string editPerformanceMeasureExpectedsUrl,
            string editPerformanceMeasureActualsUrl, string editReportedExpendituresUrl, string editClassificationsUrl,
            string editWatershedsUrl, AuditLogsGridSpec auditLogsGridSpec, string auditLogsGridDataUrl,
            string editExternalLinksUrl, ProjectNotificationGridSpec projectNotificationGridSpec,
            string projectNotificationGridName, string projectNotificationGridDataUrl, bool userCanEditProposal)
            : base(currentPerson, project)
        {
            PageTitle = project.DisplayName.ToEllipsifiedStringClean(110);
            BreadCrumbTitle = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Detail";

            ProjectStages = projectStages;

            EditProjectUrl = project.GetEditUrl();
            UserHasProjectAdminPermissions = userHasProjectAdminPermissions;
            UserHasEditProjectPermissions = userHasEditProjectPermissions;
            UserHasPerformanceMeasureActualManagePermissions = userHasPerformanceMeasureActualManagePermissions;

            if (project.IsProposal())
            {
                var projectApprovalStatus = project.ProjectApprovalStatus;
                ProjectUpdateButtonText =
                    projectApprovalStatus == ProjectApprovalStatus.Draft ||
                    projectApprovalStatus == ProjectApprovalStatus.Returned
                        ? "Edit Proposal"
                        : "Review Proposal";
                ProjectWizardUrl =
                    SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditBasics(project.ProjectID));
                CanLaunchProjectOrProposalWizard = userCanEditProposal;
                ProjectListUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.Proposed());
                BackToProjectsText = "Back to all Proposals";

            }
            else
            {
                var latestUpdateState = project.GetLatestUpdateState();
                ProjectUpdateButtonText =
                    latestUpdateState == ProjectUpdateState.Submitted ||
                    latestUpdateState == ProjectUpdateState.Returned
                        ? "Review Update"
                        : "Update Project";
                ProjectWizardUrl = project.GetProjectUpdateUrl();
                CanLaunchProjectOrProposalWizard = userHasProjectUpdatePermissions;
                ProjectListUrl = FullProjectListUrl;
                BackToProjectsText = "Back to all Projects";
            }

            ProjectBasicsViewData = projectBasicsViewData;
            ProjectBasicsTagsViewData = projectBasicsTagsViewData;

            ProjectLocationSummaryViewData = projectLocationSummaryViewData;
            MapFormID = mapFormID;
            EditSimpleProjectLocationUrl = editSimpleProjectLocationUrl;
            EditDetailedProjectLocationUrl = editDetailedProjectLocationUrl;

            AllProjectOrganizations = project.ProjectOrganizations.ToList();
            EditProjectOrganizationsUrl = editProjectOrganizationsUrl;

            PerformanceMeasureExpectedSummaryViewData = performanceMeasureExpectedSummaryViewData;
            EditPerformanceMeasureExpectedsUrl = editPerformanceMeasureExpectedsUrl;

            PerformanceMeasureReportedValuesGroupedViewData = performanceMeasureReportedValuesGroupedViewData;
            EditPerformanceMeasureActualsUrl = editPerformanceMeasureActualsUrl;

            ProjectFundingDetailViewData = projectFundingDetailViewData;
            EditExpectedFundingUrl =
                SitkaRoute<ProjectFundingSourceRequestController>.BuildUrlFromExpression(c =>
                    c.EditProjectFundingSourceRequestsForProject(project));

            ProjectExpendituresDetailViewData = projectExpendituresDetailViewData;
            EditReportedExpendituresUrl = editReportedExpendituresUrl;
            EditClassificationsUrl = editClassificationsUrl;
            EditWatershedsUrl = editWatershedsUrl;
            EditExternalLinksUrl = editExternalLinksUrl;
            ImageGalleryViewData = imageGalleryViewData;

            EntityNotesViewData = entityNotesViewData;
            EntityExternalLinksViewData = entityExternalLinksViewData;

            ProjectUpdateBatchGridSpec = new ProjectUpdateBatchGridSpec
            {
                ObjectNameSingular = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Update",
                ObjectNamePlural = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Updates",
                SaveFiltersInCookie = true
            };
            ProjectUpdateBatchGridName = "projectUpdateBatch";
            ProjectUpdateBatchGridDataUrl =
                SitkaRoute<ProjectController>.BuildUrlFromExpression(x =>
                    x.ProjectUpdateBatchGridJsonData(project.ProjectID));

            AuditLogsGridSpec = auditLogsGridSpec;
            AuditLogsGridName = "projectAuditLogsGrid";
            AuditLogsGridDataUrl = auditLogsGridDataUrl;

            ProjectNotificationGridSpec = projectNotificationGridSpec;
            ProjectNotificationGridName = projectNotificationGridName;
            ProjectNotificationGridDataUrl = projectNotificationGridDataUrl;

            ClassificationDisplayNamePluralized =
                Models.FieldDefinition.Classification.GetFieldDefinitionLabelPluralized();
            ClassificationDisplayName = Models.FieldDefinition.Classification.GetFieldDefinitionLabel();

            EditProjectWatershedFormID = ProjectWatershedController.GetEditProjectWatershedsFormID();

            ProjectStewardCannotEditUrl =
                SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.ProjectStewardCannotEdit());
            ProjectStewardCannotEditPendingApprovalUrl =
                SitkaRoute<ProjectController>.BuildUrlFromExpression(c =>
                    c.ProjectStewardCannotEditPendingApproval(project));
        }
    }
}
