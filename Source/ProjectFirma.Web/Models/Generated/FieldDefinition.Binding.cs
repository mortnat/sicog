//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FieldDefinition]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public abstract partial class FieldDefinition : IHavePrimaryKey
    {
        public static readonly FieldDefinitionActionPriority ActionPriority = FieldDefinitionActionPriority.Instance;
        public static readonly FieldDefinitionActionPriorityName ActionPriorityName = FieldDefinitionActionPriorityName.Instance;
        public static readonly FieldDefinitionLocalAndRegionalPlanName LocalAndRegionalPlanName = FieldDefinitionLocalAndRegionalPlanName.Instance;
        public static readonly FieldDefinitionExpectedValue ExpectedValue = FieldDefinitionExpectedValue.Instance;
        public static readonly FieldDefinitionFocusArea FocusArea = FieldDefinitionFocusArea.Instance;
        public static readonly FieldDefinitionFocusAreaName FocusAreaName = FieldDefinitionFocusAreaName.Instance;
        public static readonly FieldDefinitionFunder Funder = FieldDefinitionFunder.Instance;
        public static readonly FieldDefinitionFundingSource FundingSource = FieldDefinitionFundingSource.Instance;
        public static readonly FieldDefinitionFundingSourceDescription FundingSourceDescription = FieldDefinitionFundingSourceDescription.Instance;
        public static readonly FieldDefinitionFundingSourceName FundingSourceName = FieldDefinitionFundingSourceName.Instance;
        public static readonly FieldDefinitionImplementer Implementer = FieldDefinitionImplementer.Instance;
        public static readonly FieldDefinitionLeadImplementer LeadImplementer = FieldDefinitionLeadImplementer.Instance;
        public static readonly FieldDefinitionOldEIPNumber OldEIPNumber = FieldDefinitionOldEIPNumber.Instance;
        public static readonly FieldDefinitionOrganization Organization = FieldDefinitionOrganization.Instance;
        public static readonly FieldDefinitionOrganizationAbbreviation OrganizationAbbreviation = FieldDefinitionOrganizationAbbreviation.Instance;
        public static readonly FieldDefinitionOrganizationName OrganizationName = FieldDefinitionOrganizationName.Instance;
        public static readonly FieldDefinitionPassword Password = FieldDefinitionPassword.Instance;
        public static readonly FieldDefinitionEIPPerformanceMeasure EIPPerformanceMeasure = FieldDefinitionEIPPerformanceMeasure.Instance;
        public static readonly FieldDefinitionIndicatorDefinition IndicatorDefinition = FieldDefinitionIndicatorDefinition.Instance;
        public static readonly FieldDefinitionIndicatorDisplayName IndicatorDisplayName = FieldDefinitionIndicatorDisplayName.Instance;
        public static readonly FieldDefinitionMeasurementUnit MeasurementUnit = FieldDefinitionMeasurementUnit.Instance;
        public static readonly FieldDefinitionPhotoCaption PhotoCaption = FieldDefinitionPhotoCaption.Instance;
        public static readonly FieldDefinitionPhotoCredit PhotoCredit = FieldDefinitionPhotoCredit.Instance;
        public static readonly FieldDefinitionPhotoTiming PhotoTiming = FieldDefinitionPhotoTiming.Instance;
        public static readonly FieldDefinitionPrimaryContact PrimaryContact = FieldDefinitionPrimaryContact.Instance;
        public static readonly FieldDefinitionProgram Program = FieldDefinitionProgram.Instance;
        public static readonly FieldDefinitionProgramName ProgramName = FieldDefinitionProgramName.Instance;
        public static readonly FieldDefinitionCompletionYear CompletionYear = FieldDefinitionCompletionYear.Instance;
        public static readonly FieldDefinitionProjectDescription ProjectDescription = FieldDefinitionProjectDescription.Instance;
        public static readonly FieldDefinitionProjectName ProjectName = FieldDefinitionProjectName.Instance;
        public static readonly FieldDefinitionProjectNote ProjectNote = FieldDefinitionProjectNote.Instance;
        public static readonly FieldDefinitionImplementationStartYear ImplementationStartYear = FieldDefinitionImplementationStartYear.Instance;
        public static readonly FieldDefinitionReportedValue ReportedValue = FieldDefinitionReportedValue.Instance;
        public static readonly FieldDefinitionSector Sector = FieldDefinitionSector.Instance;
        public static readonly FieldDefinitionSecuredFunding SecuredFunding = FieldDefinitionSecuredFunding.Instance;
        public static readonly FieldDefinitionStage Stage = FieldDefinitionStage.Instance;
        public static readonly FieldDefinitionSubcategories Subcategories = FieldDefinitionSubcategories.Instance;
        public static readonly FieldDefinitionProjectIsAProgram ProjectIsAProgram = FieldDefinitionProjectIsAProgram.Instance;
        public static readonly FieldDefinitionThresholdCategoryName ThresholdCategoryName = FieldDefinitionThresholdCategoryName.Instance;
        public static readonly FieldDefinitionEstimatedTotalCost EstimatedTotalCost = FieldDefinitionEstimatedTotalCost.Instance;
        public static readonly FieldDefinitionUnfundedNeed UnfundedNeed = FieldDefinitionUnfundedNeed.Instance;
        public static readonly FieldDefinitionUsername Username = FieldDefinitionUsername.Instance;
        public static readonly FieldDefinitionWatershedName WatershedName = FieldDefinitionWatershedName.Instance;
        public static readonly FieldDefinitionProject Project = FieldDefinitionProject.Instance;
        public static readonly FieldDefinitionProjectNumber ProjectNumber = FieldDefinitionProjectNumber.Instance;
        public static readonly FieldDefinitionThresholdCategory ThresholdCategory = FieldDefinitionThresholdCategory.Instance;
        public static readonly FieldDefinitionLocalAndRegionalPlan LocalAndRegionalPlan = FieldDefinitionLocalAndRegionalPlan.Instance;
        public static readonly FieldDefinitionWatershed Watershed = FieldDefinitionWatershed.Instance;
        public static readonly FieldDefinitionSubcategory Subcategory = FieldDefinitionSubcategory.Instance;
        public static readonly FieldDefinitionSubcategoryOption SubcategoryOption = FieldDefinitionSubcategoryOption.Instance;
        public static readonly FieldDefinitionSubcategoryOptions SubcategoryOptions = FieldDefinitionSubcategoryOptions.Instance;
        public static readonly FieldDefinitionIsPrimaryProgram IsPrimaryProgram = FieldDefinitionIsPrimaryProgram.Instance;
        public static readonly FieldDefinitionIndicatorCriticalDefinitions IndicatorCriticalDefinitions = FieldDefinitionIndicatorCriticalDefinitions.Instance;
        public static readonly FieldDefinitionIndicatorAccountingPeriodAndScale IndicatorAccountingPeriodAndScale = FieldDefinitionIndicatorAccountingPeriodAndScale.Instance;
        public static readonly FieldDefinitionIndicatorProjectReporting IndicatorProjectReporting = FieldDefinitionIndicatorProjectReporting.Instance;
        public static readonly FieldDefinitionFundedAmount FundedAmount = FieldDefinitionFundedAmount.Instance;
        public static readonly FieldDefinitionProjectLocation ProjectLocation = FieldDefinitionProjectLocation.Instance;
        public static readonly FieldDefinitionIndicatorBackground IndicatorBackground = FieldDefinitionIndicatorBackground.Instance;
        public static readonly FieldDefinitionNumberOfReportedPMRecords NumberOfReportedPMRecords = FieldDefinitionNumberOfReportedPMRecords.Instance;
        public static readonly FieldDefinitionNumberOfReportedExpenditureRecords NumberOfReportedExpenditureRecords = FieldDefinitionNumberOfReportedExpenditureRecords.Instance;
        public static readonly FieldDefinitionProjectLocationState ProjectLocationState = FieldDefinitionProjectLocationState.Instance;
        public static readonly FieldDefinitionProjectLocationJurisdiction ProjectLocationJurisdiction = FieldDefinitionProjectLocationJurisdiction.Instance;
        public static readonly FieldDefinitionProjectLocationWatershed ProjectLocationWatershed = FieldDefinitionProjectLocationWatershed.Instance;
        public static readonly FieldDefinitionExcludeFromFactSheet ExcludeFromFactSheet = FieldDefinitionExcludeFromFactSheet.Instance;
        public static readonly FieldDefinitionTransportationStrategy TransportationStrategy = FieldDefinitionTransportationStrategy.Instance;
        public static readonly FieldDefinitionTransportationObjective TransportationObjective = FieldDefinitionTransportationObjective.Instance;
        public static readonly FieldDefinitionTransportationStrategyName TransportationStrategyName = FieldDefinitionTransportationStrategyName.Instance;
        public static readonly FieldDefinitionTransportationObjectiveName TransportationObjectiveName = FieldDefinitionTransportationObjectiveName.Instance;
        public static readonly FieldDefinitionProjectIsATransportationProject ProjectIsATransportationProject = FieldDefinitionProjectIsATransportationProject.Instance;
        public static readonly FieldDefinitionIsTransportationFundingSource IsTransportationFundingSource = FieldDefinitionIsTransportationFundingSource.Instance;
        public static readonly FieldDefinitionFundingType FundingType = FieldDefinitionFundingType.Instance;
        public static readonly FieldDefinitionProjectCostInYearOfExpenditure ProjectCostInYearOfExpenditure = FieldDefinitionProjectCostInYearOfExpenditure.Instance;
        public static readonly FieldDefinitionTransportationGlobalInflationRate TransportationGlobalInflationRate = FieldDefinitionTransportationGlobalInflationRate.Instance;
        public static readonly FieldDefinitionReportingYear ReportingYear = FieldDefinitionReportingYear.Instance;
        public static readonly FieldDefinitionTagName TagName = FieldDefinitionTagName.Instance;
        public static readonly FieldDefinitionTagDescription TagDescription = FieldDefinitionTagDescription.Instance;
        public static readonly FieldDefinitionTags Tags = FieldDefinitionTags.Instance;
        public static readonly FieldDefinitionReportedExpenditure ReportedExpenditure = FieldDefinitionReportedExpenditure.Instance;
        public static readonly FieldDefinitionProposedProject ProposedProject = FieldDefinitionProposedProject.Instance;
        public static readonly FieldDefinitionProjectOnFTIPList ProjectOnFTIPList = FieldDefinitionProjectOnFTIPList.Instance;
        public static readonly FieldDefinitionLocalAndRegionalPlanDocumentUrl LocalAndRegionalPlanDocumentUrl = FieldDefinitionLocalAndRegionalPlanDocumentUrl.Instance;
        public static readonly FieldDefinitionLocalAndRegionalPlanDocumentLinkText LocalAndRegionalPlanDocumentLinkText = FieldDefinitionLocalAndRegionalPlanDocumentLinkText.Instance;
        public static readonly FieldDefinitionSpendingAssociatedWithPM SpendingAssociatedWithPM = FieldDefinitionSpendingAssociatedWithPM.Instance;
        public static readonly FieldDefinitionPlanningDesignStartYear PlanningDesignStartYear = FieldDefinitionPlanningDesignStartYear.Instance;
        public static readonly FieldDefinitionAssociatedPrograms AssociatedPrograms = FieldDefinitionAssociatedPrograms.Instance;
        public static readonly FieldDefinitionExternalLinks ExternalLinks = FieldDefinitionExternalLinks.Instance;
        public static readonly FieldDefinitionEstimatedAnnualOperatingCost EstimatedAnnualOperatingCost = FieldDefinitionEstimatedAnnualOperatingCost.Instance;
        public static readonly FieldDefinitionCalculatedTotalRemainingOperatingCost CalculatedTotalRemainingOperatingCost = FieldDefinitionCalculatedTotalRemainingOperatingCost.Instance;
        public static readonly FieldDefinitionCurrentRTPYearForPVCalculations CurrentRTPYearForPVCalculations = FieldDefinitionCurrentRTPYearForPVCalculations.Instance;
        public static readonly FieldDefinitionLifecycleOperatingCost LifecycleOperatingCost = FieldDefinitionLifecycleOperatingCost.Instance;
        public static readonly FieldDefinitionIndicatorSystemName IndicatorSystemName = FieldDefinitionIndicatorSystemName.Instance;
        public static readonly FieldDefinitionIndicatorSimpleDescription IndicatorSimpleDescription = FieldDefinitionIndicatorSimpleDescription.Instance;
        public static readonly FieldDefinitionIndicatorPrimarySource IndicatorPrimarySource = FieldDefinitionIndicatorPrimarySource.Instance;
        public static readonly FieldDefinitionIndicatorType IndicatorType = FieldDefinitionIndicatorType.Instance;
        public static readonly FieldDefinitionChartTitle ChartTitle = FieldDefinitionChartTitle.Instance;
        public static readonly FieldDefinitionProposedProjectState ProposedProjectState = FieldDefinitionProposedProjectState.Instance;
        public static readonly FieldDefinitionUserLastName UserLastName = FieldDefinitionUserLastName.Instance;
        public static readonly FieldDefinitionUserFirstName UserFirstName = FieldDefinitionUserFirstName.Instance;
        public static readonly FieldDefinitionUserEmail UserEmail = FieldDefinitionUserEmail.Instance;
        public static readonly FieldDefinitionUserPhone UserPhone = FieldDefinitionUserPhone.Instance;
        public static readonly FieldDefinitionEIPRoleID EIPRoleID = FieldDefinitionEIPRoleID.Instance;
        public static readonly FieldDefinitionSiteArea SiteArea = FieldDefinitionSiteArea.Instance;
        public static readonly FieldDefinitionRoleName RoleName = FieldDefinitionRoleName.Instance;
        public static readonly FieldDefinitionRegion Region = FieldDefinitionRegion.Instance;
        public static readonly FieldDefinitionLatitude Latitude = FieldDefinitionLatitude.Instance;
        public static readonly FieldDefinitionLongitude Longitude = FieldDefinitionLongitude.Instance;
        public static readonly FieldDefinitionOrganizationUrl OrganizationUrl = FieldDefinitionOrganizationUrl.Instance;
        public static readonly FieldDefinitionChartCaption ChartCaption = FieldDefinitionChartCaption.Instance;
        public static readonly FieldDefinitionMonitoringProgram MonitoringProgram = FieldDefinitionMonitoringProgram.Instance;
        public static readonly FieldDefinitionMonitoringApproach MonitoringApproach = FieldDefinitionMonitoringApproach.Instance;
        public static readonly FieldDefinitionMonitoringProgramPartner MonitoringProgramPartner = FieldDefinitionMonitoringProgramPartner.Instance;
        public static readonly FieldDefinitionMonitoringProgramUrl MonitoringProgramUrl = FieldDefinitionMonitoringProgramUrl.Instance;
        public static readonly FieldDefinitionThresholdCategoryDescription ThresholdCategoryDescription = FieldDefinitionThresholdCategoryDescription.Instance;
        public static readonly FieldDefinitionThresholdCategoryGoalStatement ThresholdCategoryGoalStatement = FieldDefinitionThresholdCategoryGoalStatement.Instance;
        public static readonly FieldDefinitionThresholdCategoryNarrative ThresholdCategoryNarrative = FieldDefinitionThresholdCategoryNarrative.Instance;

        public static readonly List<FieldDefinition> All;
        public static readonly ReadOnlyDictionary<int, FieldDefinition> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static FieldDefinition()
        {
            All = new List<FieldDefinition> { ActionPriority, ActionPriorityName, LocalAndRegionalPlanName, ExpectedValue, FocusArea, FocusAreaName, Funder, FundingSource, FundingSourceDescription, FundingSourceName, Implementer, LeadImplementer, OldEIPNumber, Organization, OrganizationAbbreviation, OrganizationName, Password, EIPPerformanceMeasure, IndicatorDefinition, IndicatorDisplayName, MeasurementUnit, PhotoCaption, PhotoCredit, PhotoTiming, PrimaryContact, Program, ProgramName, CompletionYear, ProjectDescription, ProjectName, ProjectNote, ImplementationStartYear, ReportedValue, Sector, SecuredFunding, Stage, Subcategories, ProjectIsAProgram, ThresholdCategoryName, EstimatedTotalCost, UnfundedNeed, Username, WatershedName, Project, ProjectNumber, ThresholdCategory, LocalAndRegionalPlan, Watershed, Subcategory, SubcategoryOption, SubcategoryOptions, IsPrimaryProgram, IndicatorCriticalDefinitions, IndicatorAccountingPeriodAndScale, IndicatorProjectReporting, FundedAmount, ProjectLocation, IndicatorBackground, NumberOfReportedPMRecords, NumberOfReportedExpenditureRecords, ProjectLocationState, ProjectLocationJurisdiction, ProjectLocationWatershed, ExcludeFromFactSheet, TransportationStrategy, TransportationObjective, TransportationStrategyName, TransportationObjectiveName, ProjectIsATransportationProject, IsTransportationFundingSource, FundingType, ProjectCostInYearOfExpenditure, TransportationGlobalInflationRate, ReportingYear, TagName, TagDescription, Tags, ReportedExpenditure, ProposedProject, ProjectOnFTIPList, LocalAndRegionalPlanDocumentUrl, LocalAndRegionalPlanDocumentLinkText, SpendingAssociatedWithPM, PlanningDesignStartYear, AssociatedPrograms, ExternalLinks, EstimatedAnnualOperatingCost, CalculatedTotalRemainingOperatingCost, CurrentRTPYearForPVCalculations, LifecycleOperatingCost, IndicatorSystemName, IndicatorSimpleDescription, IndicatorPrimarySource, IndicatorType, ChartTitle, ProposedProjectState, UserLastName, UserFirstName, UserEmail, UserPhone, EIPRoleID, SiteArea, RoleName, Region, Latitude, Longitude, OrganizationUrl, ChartCaption, MonitoringProgram, MonitoringApproach, MonitoringProgramPartner, MonitoringProgramUrl, ThresholdCategoryDescription, ThresholdCategoryGoalStatement, ThresholdCategoryNarrative };
            AllLookupDictionary = new ReadOnlyDictionary<int, FieldDefinition>(All.ToDictionary(x => x.FieldDefinitionID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected FieldDefinition(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName)
        {
            FieldDefinitionID = fieldDefinitionID;
            FieldDefinitionName = fieldDefinitionName;
            FieldDefinitionDisplayName = fieldDefinitionDisplayName;
        }

        [Key]
        public int FieldDefinitionID { get; private set; }
        public string FieldDefinitionName { get; private set; }
        public string FieldDefinitionDisplayName { get; private set; }
        public int PrimaryKey { get { return FieldDefinitionID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(FieldDefinition other)
        {
            if (other == null)
            {
                return false;
            }
            return other.FieldDefinitionID == FieldDefinitionID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as FieldDefinition);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return FieldDefinitionID;
        }

        public static bool operator ==(FieldDefinition left, FieldDefinition right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FieldDefinition left, FieldDefinition right)
        {
            return !Equals(left, right);
        }

        public FieldDefinitionEnum ToEnum { get { return (FieldDefinitionEnum)GetHashCode(); } }

        public static FieldDefinition ToType(int enumValue)
        {
            return ToType((FieldDefinitionEnum)enumValue);
        }

        public static FieldDefinition ToType(FieldDefinitionEnum enumValue)
        {
            switch (enumValue)
            {
                case FieldDefinitionEnum.ActionPriority:
                    return ActionPriority;
                case FieldDefinitionEnum.ActionPriorityName:
                    return ActionPriorityName;
                case FieldDefinitionEnum.AssociatedPrograms:
                    return AssociatedPrograms;
                case FieldDefinitionEnum.CalculatedTotalRemainingOperatingCost:
                    return CalculatedTotalRemainingOperatingCost;
                case FieldDefinitionEnum.ChartCaption:
                    return ChartCaption;
                case FieldDefinitionEnum.ChartTitle:
                    return ChartTitle;
                case FieldDefinitionEnum.CompletionYear:
                    return CompletionYear;
                case FieldDefinitionEnum.CurrentRTPYearForPVCalculations:
                    return CurrentRTPYearForPVCalculations;
                case FieldDefinitionEnum.EIPPerformanceMeasure:
                    return EIPPerformanceMeasure;
                case FieldDefinitionEnum.EIPRoleID:
                    return EIPRoleID;
                case FieldDefinitionEnum.EstimatedAnnualOperatingCost:
                    return EstimatedAnnualOperatingCost;
                case FieldDefinitionEnum.EstimatedTotalCost:
                    return EstimatedTotalCost;
                case FieldDefinitionEnum.ExcludeFromFactSheet:
                    return ExcludeFromFactSheet;
                case FieldDefinitionEnum.ExpectedValue:
                    return ExpectedValue;
                case FieldDefinitionEnum.ExternalLinks:
                    return ExternalLinks;
                case FieldDefinitionEnum.FocusArea:
                    return FocusArea;
                case FieldDefinitionEnum.FocusAreaName:
                    return FocusAreaName;
                case FieldDefinitionEnum.FundedAmount:
                    return FundedAmount;
                case FieldDefinitionEnum.Funder:
                    return Funder;
                case FieldDefinitionEnum.FundingSource:
                    return FundingSource;
                case FieldDefinitionEnum.FundingSourceDescription:
                    return FundingSourceDescription;
                case FieldDefinitionEnum.FundingSourceName:
                    return FundingSourceName;
                case FieldDefinitionEnum.FundingType:
                    return FundingType;
                case FieldDefinitionEnum.ImplementationStartYear:
                    return ImplementationStartYear;
                case FieldDefinitionEnum.Implementer:
                    return Implementer;
                case FieldDefinitionEnum.IndicatorAccountingPeriodAndScale:
                    return IndicatorAccountingPeriodAndScale;
                case FieldDefinitionEnum.IndicatorBackground:
                    return IndicatorBackground;
                case FieldDefinitionEnum.IndicatorCriticalDefinitions:
                    return IndicatorCriticalDefinitions;
                case FieldDefinitionEnum.IndicatorDefinition:
                    return IndicatorDefinition;
                case FieldDefinitionEnum.IndicatorDisplayName:
                    return IndicatorDisplayName;
                case FieldDefinitionEnum.IndicatorPrimarySource:
                    return IndicatorPrimarySource;
                case FieldDefinitionEnum.IndicatorProjectReporting:
                    return IndicatorProjectReporting;
                case FieldDefinitionEnum.IndicatorSimpleDescription:
                    return IndicatorSimpleDescription;
                case FieldDefinitionEnum.IndicatorSystemName:
                    return IndicatorSystemName;
                case FieldDefinitionEnum.IndicatorType:
                    return IndicatorType;
                case FieldDefinitionEnum.IsPrimaryProgram:
                    return IsPrimaryProgram;
                case FieldDefinitionEnum.IsTransportationFundingSource:
                    return IsTransportationFundingSource;
                case FieldDefinitionEnum.Latitude:
                    return Latitude;
                case FieldDefinitionEnum.LeadImplementer:
                    return LeadImplementer;
                case FieldDefinitionEnum.LifecycleOperatingCost:
                    return LifecycleOperatingCost;
                case FieldDefinitionEnum.LocalAndRegionalPlan:
                    return LocalAndRegionalPlan;
                case FieldDefinitionEnum.LocalAndRegionalPlanDocumentLinkText:
                    return LocalAndRegionalPlanDocumentLinkText;
                case FieldDefinitionEnum.LocalAndRegionalPlanDocumentUrl:
                    return LocalAndRegionalPlanDocumentUrl;
                case FieldDefinitionEnum.LocalAndRegionalPlanName:
                    return LocalAndRegionalPlanName;
                case FieldDefinitionEnum.Longitude:
                    return Longitude;
                case FieldDefinitionEnum.MeasurementUnit:
                    return MeasurementUnit;
                case FieldDefinitionEnum.MonitoringApproach:
                    return MonitoringApproach;
                case FieldDefinitionEnum.MonitoringProgram:
                    return MonitoringProgram;
                case FieldDefinitionEnum.MonitoringProgramPartner:
                    return MonitoringProgramPartner;
                case FieldDefinitionEnum.MonitoringProgramUrl:
                    return MonitoringProgramUrl;
                case FieldDefinitionEnum.NumberOfReportedExpenditureRecords:
                    return NumberOfReportedExpenditureRecords;
                case FieldDefinitionEnum.NumberOfReportedPMRecords:
                    return NumberOfReportedPMRecords;
                case FieldDefinitionEnum.OldEIPNumber:
                    return OldEIPNumber;
                case FieldDefinitionEnum.Organization:
                    return Organization;
                case FieldDefinitionEnum.OrganizationAbbreviation:
                    return OrganizationAbbreviation;
                case FieldDefinitionEnum.OrganizationName:
                    return OrganizationName;
                case FieldDefinitionEnum.OrganizationUrl:
                    return OrganizationUrl;
                case FieldDefinitionEnum.Password:
                    return Password;
                case FieldDefinitionEnum.PhotoCaption:
                    return PhotoCaption;
                case FieldDefinitionEnum.PhotoCredit:
                    return PhotoCredit;
                case FieldDefinitionEnum.PhotoTiming:
                    return PhotoTiming;
                case FieldDefinitionEnum.PlanningDesignStartYear:
                    return PlanningDesignStartYear;
                case FieldDefinitionEnum.PrimaryContact:
                    return PrimaryContact;
                case FieldDefinitionEnum.Program:
                    return Program;
                case FieldDefinitionEnum.ProgramName:
                    return ProgramName;
                case FieldDefinitionEnum.Project:
                    return Project;
                case FieldDefinitionEnum.ProjectCostInYearOfExpenditure:
                    return ProjectCostInYearOfExpenditure;
                case FieldDefinitionEnum.ProjectDescription:
                    return ProjectDescription;
                case FieldDefinitionEnum.ProjectIsAProgram:
                    return ProjectIsAProgram;
                case FieldDefinitionEnum.ProjectIsATransportationProject:
                    return ProjectIsATransportationProject;
                case FieldDefinitionEnum.ProjectLocation:
                    return ProjectLocation;
                case FieldDefinitionEnum.ProjectLocationJurisdiction:
                    return ProjectLocationJurisdiction;
                case FieldDefinitionEnum.ProjectLocationState:
                    return ProjectLocationState;
                case FieldDefinitionEnum.ProjectLocationWatershed:
                    return ProjectLocationWatershed;
                case FieldDefinitionEnum.ProjectName:
                    return ProjectName;
                case FieldDefinitionEnum.ProjectNote:
                    return ProjectNote;
                case FieldDefinitionEnum.ProjectNumber:
                    return ProjectNumber;
                case FieldDefinitionEnum.ProjectOnFTIPList:
                    return ProjectOnFTIPList;
                case FieldDefinitionEnum.ProposedProject:
                    return ProposedProject;
                case FieldDefinitionEnum.ProposedProjectState:
                    return ProposedProjectState;
                case FieldDefinitionEnum.Region:
                    return Region;
                case FieldDefinitionEnum.ReportedExpenditure:
                    return ReportedExpenditure;
                case FieldDefinitionEnum.ReportedValue:
                    return ReportedValue;
                case FieldDefinitionEnum.ReportingYear:
                    return ReportingYear;
                case FieldDefinitionEnum.RoleName:
                    return RoleName;
                case FieldDefinitionEnum.Sector:
                    return Sector;
                case FieldDefinitionEnum.SecuredFunding:
                    return SecuredFunding;
                case FieldDefinitionEnum.SiteArea:
                    return SiteArea;
                case FieldDefinitionEnum.SpendingAssociatedWithPM:
                    return SpendingAssociatedWithPM;
                case FieldDefinitionEnum.Stage:
                    return Stage;
                case FieldDefinitionEnum.Subcategories:
                    return Subcategories;
                case FieldDefinitionEnum.Subcategory:
                    return Subcategory;
                case FieldDefinitionEnum.SubcategoryOption:
                    return SubcategoryOption;
                case FieldDefinitionEnum.SubcategoryOptions:
                    return SubcategoryOptions;
                case FieldDefinitionEnum.TagDescription:
                    return TagDescription;
                case FieldDefinitionEnum.TagName:
                    return TagName;
                case FieldDefinitionEnum.Tags:
                    return Tags;
                case FieldDefinitionEnum.ThresholdCategory:
                    return ThresholdCategory;
                case FieldDefinitionEnum.ThresholdCategoryDescription:
                    return ThresholdCategoryDescription;
                case FieldDefinitionEnum.ThresholdCategoryGoalStatement:
                    return ThresholdCategoryGoalStatement;
                case FieldDefinitionEnum.ThresholdCategoryName:
                    return ThresholdCategoryName;
                case FieldDefinitionEnum.ThresholdCategoryNarrative:
                    return ThresholdCategoryNarrative;
                case FieldDefinitionEnum.TransportationGlobalInflationRate:
                    return TransportationGlobalInflationRate;
                case FieldDefinitionEnum.TransportationObjective:
                    return TransportationObjective;
                case FieldDefinitionEnum.TransportationObjectiveName:
                    return TransportationObjectiveName;
                case FieldDefinitionEnum.TransportationStrategy:
                    return TransportationStrategy;
                case FieldDefinitionEnum.TransportationStrategyName:
                    return TransportationStrategyName;
                case FieldDefinitionEnum.UnfundedNeed:
                    return UnfundedNeed;
                case FieldDefinitionEnum.UserEmail:
                    return UserEmail;
                case FieldDefinitionEnum.UserFirstName:
                    return UserFirstName;
                case FieldDefinitionEnum.UserLastName:
                    return UserLastName;
                case FieldDefinitionEnum.Username:
                    return Username;
                case FieldDefinitionEnum.UserPhone:
                    return UserPhone;
                case FieldDefinitionEnum.Watershed:
                    return Watershed;
                case FieldDefinitionEnum.WatershedName:
                    return WatershedName;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum FieldDefinitionEnum
    {
        ActionPriority = 1,
        ActionPriorityName = 2,
        LocalAndRegionalPlanName = 3,
        ExpectedValue = 4,
        FocusArea = 5,
        FocusAreaName = 6,
        Funder = 7,
        FundingSource = 8,
        FundingSourceDescription = 9,
        FundingSourceName = 10,
        Implementer = 11,
        LeadImplementer = 12,
        OldEIPNumber = 13,
        Organization = 14,
        OrganizationAbbreviation = 15,
        OrganizationName = 16,
        Password = 17,
        EIPPerformanceMeasure = 18,
        IndicatorDefinition = 19,
        IndicatorDisplayName = 20,
        MeasurementUnit = 21,
        PhotoCaption = 22,
        PhotoCredit = 23,
        PhotoTiming = 24,
        PrimaryContact = 25,
        Program = 26,
        ProgramName = 27,
        CompletionYear = 28,
        ProjectDescription = 29,
        ProjectName = 30,
        ProjectNote = 31,
        ImplementationStartYear = 32,
        ReportedValue = 33,
        Sector = 34,
        SecuredFunding = 35,
        Stage = 36,
        Subcategories = 37,
        ProjectIsAProgram = 38,
        ThresholdCategoryName = 39,
        EstimatedTotalCost = 40,
        UnfundedNeed = 41,
        Username = 42,
        WatershedName = 43,
        Project = 44,
        ProjectNumber = 45,
        ThresholdCategory = 46,
        LocalAndRegionalPlan = 47,
        Watershed = 48,
        Subcategory = 49,
        SubcategoryOption = 50,
        SubcategoryOptions = 51,
        IsPrimaryProgram = 52,
        IndicatorCriticalDefinitions = 53,
        IndicatorAccountingPeriodAndScale = 54,
        IndicatorProjectReporting = 55,
        FundedAmount = 56,
        ProjectLocation = 57,
        IndicatorBackground = 58,
        NumberOfReportedPMRecords = 59,
        NumberOfReportedExpenditureRecords = 60,
        ProjectLocationState = 61,
        ProjectLocationJurisdiction = 62,
        ProjectLocationWatershed = 63,
        ExcludeFromFactSheet = 64,
        TransportationStrategy = 65,
        TransportationObjective = 66,
        TransportationStrategyName = 67,
        TransportationObjectiveName = 68,
        ProjectIsATransportationProject = 69,
        IsTransportationFundingSource = 72,
        FundingType = 73,
        ProjectCostInYearOfExpenditure = 74,
        TransportationGlobalInflationRate = 75,
        ReportingYear = 76,
        TagName = 77,
        TagDescription = 78,
        Tags = 79,
        ReportedExpenditure = 80,
        ProposedProject = 81,
        ProjectOnFTIPList = 82,
        LocalAndRegionalPlanDocumentUrl = 83,
        LocalAndRegionalPlanDocumentLinkText = 84,
        SpendingAssociatedWithPM = 85,
        PlanningDesignStartYear = 86,
        AssociatedPrograms = 87,
        ExternalLinks = 88,
        EstimatedAnnualOperatingCost = 89,
        CalculatedTotalRemainingOperatingCost = 90,
        CurrentRTPYearForPVCalculations = 91,
        LifecycleOperatingCost = 92,
        IndicatorSystemName = 93,
        IndicatorSimpleDescription = 94,
        IndicatorPrimarySource = 95,
        IndicatorType = 96,
        ChartTitle = 97,
        ProposedProjectState = 98,
        UserLastName = 173,
        UserFirstName = 174,
        UserEmail = 175,
        UserPhone = 176,
        EIPRoleID = 177,
        SiteArea = 181,
        RoleName = 182,
        Region = 184,
        Latitude = 185,
        Longitude = 186,
        OrganizationUrl = 188,
        ChartCaption = 228,
        MonitoringProgram = 236,
        MonitoringApproach = 237,
        MonitoringProgramPartner = 238,
        MonitoringProgramUrl = 239,
        ThresholdCategoryDescription = 240,
        ThresholdCategoryGoalStatement = 241,
        ThresholdCategoryNarrative = 242
    }

    public partial class FieldDefinitionActionPriority : FieldDefinition
    {
        private FieldDefinitionActionPriority(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionActionPriority Instance = new FieldDefinitionActionPriority(1, @"ActionPriority", @"Action Priority");
    }

    public partial class FieldDefinitionActionPriorityName : FieldDefinition
    {
        private FieldDefinitionActionPriorityName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionActionPriorityName Instance = new FieldDefinitionActionPriorityName(2, @"ActionPriorityName", @"Action Priority Name");
    }

    public partial class FieldDefinitionLocalAndRegionalPlanName : FieldDefinition
    {
        private FieldDefinitionLocalAndRegionalPlanName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionLocalAndRegionalPlanName Instance = new FieldDefinitionLocalAndRegionalPlanName(3, @"LocalAndRegionalPlanName", @"Local and Regional Plan Name");
    }

    public partial class FieldDefinitionExpectedValue : FieldDefinition
    {
        private FieldDefinitionExpectedValue(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionExpectedValue Instance = new FieldDefinitionExpectedValue(4, @"ExpectedValue", @"Expected Value");
    }

    public partial class FieldDefinitionFocusArea : FieldDefinition
    {
        private FieldDefinitionFocusArea(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionFocusArea Instance = new FieldDefinitionFocusArea(5, @"FocusArea", @"Focus Area");
    }

    public partial class FieldDefinitionFocusAreaName : FieldDefinition
    {
        private FieldDefinitionFocusAreaName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionFocusAreaName Instance = new FieldDefinitionFocusAreaName(6, @"FocusAreaName", @"Focus Area Name");
    }

    public partial class FieldDefinitionFunder : FieldDefinition
    {
        private FieldDefinitionFunder(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionFunder Instance = new FieldDefinitionFunder(7, @"Funder", @"Funder");
    }

    public partial class FieldDefinitionFundingSource : FieldDefinition
    {
        private FieldDefinitionFundingSource(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionFundingSource Instance = new FieldDefinitionFundingSource(8, @"FundingSource", @"Funding Source");
    }

    public partial class FieldDefinitionFundingSourceDescription : FieldDefinition
    {
        private FieldDefinitionFundingSourceDescription(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionFundingSourceDescription Instance = new FieldDefinitionFundingSourceDescription(9, @"FundingSourceDescription", @"Funding Source Description");
    }

    public partial class FieldDefinitionFundingSourceName : FieldDefinition
    {
        private FieldDefinitionFundingSourceName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionFundingSourceName Instance = new FieldDefinitionFundingSourceName(10, @"FundingSourceName", @"Funding Source Name");
    }

    public partial class FieldDefinitionImplementer : FieldDefinition
    {
        private FieldDefinitionImplementer(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionImplementer Instance = new FieldDefinitionImplementer(11, @"Implementer", @"Implementer");
    }

    public partial class FieldDefinitionLeadImplementer : FieldDefinition
    {
        private FieldDefinitionLeadImplementer(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionLeadImplementer Instance = new FieldDefinitionLeadImplementer(12, @"LeadImplementer", @"Lead Implementer");
    }

    public partial class FieldDefinitionOldEIPNumber : FieldDefinition
    {
        private FieldDefinitionOldEIPNumber(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionOldEIPNumber Instance = new FieldDefinitionOldEIPNumber(13, @"OldEIPNumber", @"Old EIP #");
    }

    public partial class FieldDefinitionOrganization : FieldDefinition
    {
        private FieldDefinitionOrganization(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionOrganization Instance = new FieldDefinitionOrganization(14, @"Organization", @"Organization");
    }

    public partial class FieldDefinitionOrganizationAbbreviation : FieldDefinition
    {
        private FieldDefinitionOrganizationAbbreviation(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionOrganizationAbbreviation Instance = new FieldDefinitionOrganizationAbbreviation(15, @"OrganizationAbbreviation", @"Abbreviation");
    }

    public partial class FieldDefinitionOrganizationName : FieldDefinition
    {
        private FieldDefinitionOrganizationName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionOrganizationName Instance = new FieldDefinitionOrganizationName(16, @"OrganizationName", @"Organization Name");
    }

    public partial class FieldDefinitionPassword : FieldDefinition
    {
        private FieldDefinitionPassword(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionPassword Instance = new FieldDefinitionPassword(17, @"Password", @"Password");
    }

    public partial class FieldDefinitionEIPPerformanceMeasure : FieldDefinition
    {
        private FieldDefinitionEIPPerformanceMeasure(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionEIPPerformanceMeasure Instance = new FieldDefinitionEIPPerformanceMeasure(18, @"EIPPerformanceMeasure", @"EIP Performance Measure");
    }

    public partial class FieldDefinitionIndicatorDefinition : FieldDefinition
    {
        private FieldDefinitionIndicatorDefinition(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionIndicatorDefinition Instance = new FieldDefinitionIndicatorDefinition(19, @"IndicatorDefinition", @"Indicator Definition");
    }

    public partial class FieldDefinitionIndicatorDisplayName : FieldDefinition
    {
        private FieldDefinitionIndicatorDisplayName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionIndicatorDisplayName Instance = new FieldDefinitionIndicatorDisplayName(20, @"IndicatorDisplayName", @"Indicator Name");
    }

    public partial class FieldDefinitionMeasurementUnit : FieldDefinition
    {
        private FieldDefinitionMeasurementUnit(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionMeasurementUnit Instance = new FieldDefinitionMeasurementUnit(21, @"MeasurementUnit", @"Measurement Unit");
    }

    public partial class FieldDefinitionPhotoCaption : FieldDefinition
    {
        private FieldDefinitionPhotoCaption(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionPhotoCaption Instance = new FieldDefinitionPhotoCaption(22, @"PhotoCaption", @"Photo Caption");
    }

    public partial class FieldDefinitionPhotoCredit : FieldDefinition
    {
        private FieldDefinitionPhotoCredit(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionPhotoCredit Instance = new FieldDefinitionPhotoCredit(23, @"PhotoCredit", @"Photo Credit");
    }

    public partial class FieldDefinitionPhotoTiming : FieldDefinition
    {
        private FieldDefinitionPhotoTiming(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionPhotoTiming Instance = new FieldDefinitionPhotoTiming(24, @"PhotoTiming", @"Photo Timing");
    }

    public partial class FieldDefinitionPrimaryContact : FieldDefinition
    {
        private FieldDefinitionPrimaryContact(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionPrimaryContact Instance = new FieldDefinitionPrimaryContact(25, @"PrimaryContact", @"Primary Contact");
    }

    public partial class FieldDefinitionProgram : FieldDefinition
    {
        private FieldDefinitionProgram(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProgram Instance = new FieldDefinitionProgram(26, @"Program", @"Program");
    }

    public partial class FieldDefinitionProgramName : FieldDefinition
    {
        private FieldDefinitionProgramName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProgramName Instance = new FieldDefinitionProgramName(27, @"ProgramName", @"Program Name");
    }

    public partial class FieldDefinitionCompletionYear : FieldDefinition
    {
        private FieldDefinitionCompletionYear(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionCompletionYear Instance = new FieldDefinitionCompletionYear(28, @"CompletionYear", @"Completion Year");
    }

    public partial class FieldDefinitionProjectDescription : FieldDefinition
    {
        private FieldDefinitionProjectDescription(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProjectDescription Instance = new FieldDefinitionProjectDescription(29, @"ProjectDescription", @"Project Description");
    }

    public partial class FieldDefinitionProjectName : FieldDefinition
    {
        private FieldDefinitionProjectName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProjectName Instance = new FieldDefinitionProjectName(30, @"ProjectName", @"Project Name");
    }

    public partial class FieldDefinitionProjectNote : FieldDefinition
    {
        private FieldDefinitionProjectNote(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProjectNote Instance = new FieldDefinitionProjectNote(31, @"ProjectNote", @"Project Note");
    }

    public partial class FieldDefinitionImplementationStartYear : FieldDefinition
    {
        private FieldDefinitionImplementationStartYear(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionImplementationStartYear Instance = new FieldDefinitionImplementationStartYear(32, @"ImplementationStartYear", @"Implementation Start Year");
    }

    public partial class FieldDefinitionReportedValue : FieldDefinition
    {
        private FieldDefinitionReportedValue(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionReportedValue Instance = new FieldDefinitionReportedValue(33, @"ReportedValue", @"Reported Value");
    }

    public partial class FieldDefinitionSector : FieldDefinition
    {
        private FieldDefinitionSector(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionSector Instance = new FieldDefinitionSector(34, @"Sector", @"Sector");
    }

    public partial class FieldDefinitionSecuredFunding : FieldDefinition
    {
        private FieldDefinitionSecuredFunding(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionSecuredFunding Instance = new FieldDefinitionSecuredFunding(35, @"SecuredFunding", @"Secured Funding");
    }

    public partial class FieldDefinitionStage : FieldDefinition
    {
        private FieldDefinitionStage(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionStage Instance = new FieldDefinitionStage(36, @"Stage", @"Stage");
    }

    public partial class FieldDefinitionSubcategories : FieldDefinition
    {
        private FieldDefinitionSubcategories(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionSubcategories Instance = new FieldDefinitionSubcategories(37, @"Subcategories", @"Subcategories");
    }

    public partial class FieldDefinitionProjectIsAProgram : FieldDefinition
    {
        private FieldDefinitionProjectIsAProgram(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProjectIsAProgram Instance = new FieldDefinitionProjectIsAProgram(38, @"ProjectIsAProgram", @"This project is a program that implements multiple projects");
    }

    public partial class FieldDefinitionThresholdCategoryName : FieldDefinition
    {
        private FieldDefinitionThresholdCategoryName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionThresholdCategoryName Instance = new FieldDefinitionThresholdCategoryName(39, @"ThresholdCategoryName", @"Threshold Category Name");
    }

    public partial class FieldDefinitionEstimatedTotalCost : FieldDefinition
    {
        private FieldDefinitionEstimatedTotalCost(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionEstimatedTotalCost Instance = new FieldDefinitionEstimatedTotalCost(40, @"EstimatedTotalCost", @"Estimated Total Cost");
    }

    public partial class FieldDefinitionUnfundedNeed : FieldDefinition
    {
        private FieldDefinitionUnfundedNeed(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionUnfundedNeed Instance = new FieldDefinitionUnfundedNeed(41, @"UnfundedNeed", @"Unfunded Need");
    }

    public partial class FieldDefinitionUsername : FieldDefinition
    {
        private FieldDefinitionUsername(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionUsername Instance = new FieldDefinitionUsername(42, @"Username", @"User name");
    }

    public partial class FieldDefinitionWatershedName : FieldDefinition
    {
        private FieldDefinitionWatershedName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionWatershedName Instance = new FieldDefinitionWatershedName(43, @"WatershedName", @"Watershed Name");
    }

    public partial class FieldDefinitionProject : FieldDefinition
    {
        private FieldDefinitionProject(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProject Instance = new FieldDefinitionProject(44, @"Project", @"Project");
    }

    public partial class FieldDefinitionProjectNumber : FieldDefinition
    {
        private FieldDefinitionProjectNumber(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProjectNumber Instance = new FieldDefinitionProjectNumber(45, @"ProjectNumber", @"Project #");
    }

    public partial class FieldDefinitionThresholdCategory : FieldDefinition
    {
        private FieldDefinitionThresholdCategory(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionThresholdCategory Instance = new FieldDefinitionThresholdCategory(46, @"ThresholdCategory", @"Threshold Category");
    }

    public partial class FieldDefinitionLocalAndRegionalPlan : FieldDefinition
    {
        private FieldDefinitionLocalAndRegionalPlan(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionLocalAndRegionalPlan Instance = new FieldDefinitionLocalAndRegionalPlan(47, @"LocalAndRegionalPlan", @"Local and Regional Plan");
    }

    public partial class FieldDefinitionWatershed : FieldDefinition
    {
        private FieldDefinitionWatershed(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionWatershed Instance = new FieldDefinitionWatershed(48, @"Watershed", @"Watershed");
    }

    public partial class FieldDefinitionSubcategory : FieldDefinition
    {
        private FieldDefinitionSubcategory(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionSubcategory Instance = new FieldDefinitionSubcategory(49, @"Subcategory", @"Subcategory");
    }

    public partial class FieldDefinitionSubcategoryOption : FieldDefinition
    {
        private FieldDefinitionSubcategoryOption(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionSubcategoryOption Instance = new FieldDefinitionSubcategoryOption(50, @"SubcategoryOption", @"Subcategory Option");
    }

    public partial class FieldDefinitionSubcategoryOptions : FieldDefinition
    {
        private FieldDefinitionSubcategoryOptions(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionSubcategoryOptions Instance = new FieldDefinitionSubcategoryOptions(51, @"SubcategoryOptions", @"Subcategory Options");
    }

    public partial class FieldDefinitionIsPrimaryProgram : FieldDefinition
    {
        private FieldDefinitionIsPrimaryProgram(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionIsPrimaryProgram Instance = new FieldDefinitionIsPrimaryProgram(52, @"IsPrimaryProgram", @"Is Primary Program");
    }

    public partial class FieldDefinitionIndicatorCriticalDefinitions : FieldDefinition
    {
        private FieldDefinitionIndicatorCriticalDefinitions(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionIndicatorCriticalDefinitions Instance = new FieldDefinitionIndicatorCriticalDefinitions(53, @"IndicatorCriticalDefinitions", @"Critical Definitions");
    }

    public partial class FieldDefinitionIndicatorAccountingPeriodAndScale : FieldDefinition
    {
        private FieldDefinitionIndicatorAccountingPeriodAndScale(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionIndicatorAccountingPeriodAndScale Instance = new FieldDefinitionIndicatorAccountingPeriodAndScale(54, @"IndicatorAccountingPeriodAndScale", @"Accounting Period and Scale");
    }

    public partial class FieldDefinitionIndicatorProjectReporting : FieldDefinition
    {
        private FieldDefinitionIndicatorProjectReporting(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionIndicatorProjectReporting Instance = new FieldDefinitionIndicatorProjectReporting(55, @"IndicatorProjectReporting", @"Project Reporting");
    }

    public partial class FieldDefinitionFundedAmount : FieldDefinition
    {
        private FieldDefinitionFundedAmount(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionFundedAmount Instance = new FieldDefinitionFundedAmount(56, @"FundedAmount", @"Funded Amount");
    }

    public partial class FieldDefinitionProjectLocation : FieldDefinition
    {
        private FieldDefinitionProjectLocation(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProjectLocation Instance = new FieldDefinitionProjectLocation(57, @"ProjectLocation", @"Project Location");
    }

    public partial class FieldDefinitionIndicatorBackground : FieldDefinition
    {
        private FieldDefinitionIndicatorBackground(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionIndicatorBackground Instance = new FieldDefinitionIndicatorBackground(58, @"IndicatorBackground", @"Background");
    }

    public partial class FieldDefinitionNumberOfReportedPMRecords : FieldDefinition
    {
        private FieldDefinitionNumberOfReportedPMRecords(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionNumberOfReportedPMRecords Instance = new FieldDefinitionNumberOfReportedPMRecords(59, @"NumberOfReportedPMRecords", @"# of Reported PM Records");
    }

    public partial class FieldDefinitionNumberOfReportedExpenditureRecords : FieldDefinition
    {
        private FieldDefinitionNumberOfReportedExpenditureRecords(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionNumberOfReportedExpenditureRecords Instance = new FieldDefinitionNumberOfReportedExpenditureRecords(60, @"NumberOfReportedExpenditureRecords", @"# of Reported Expenditure Records");
    }

    public partial class FieldDefinitionProjectLocationState : FieldDefinition
    {
        private FieldDefinitionProjectLocationState(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProjectLocationState Instance = new FieldDefinitionProjectLocationState(61, @"ProjectLocationState", @"State (Geospatial),");
    }

    public partial class FieldDefinitionProjectLocationJurisdiction : FieldDefinition
    {
        private FieldDefinitionProjectLocationJurisdiction(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProjectLocationJurisdiction Instance = new FieldDefinitionProjectLocationJurisdiction(62, @"ProjectLocationJurisdiction", @"Jurisdiction (Geospatial),");
    }

    public partial class FieldDefinitionProjectLocationWatershed : FieldDefinition
    {
        private FieldDefinitionProjectLocationWatershed(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProjectLocationWatershed Instance = new FieldDefinitionProjectLocationWatershed(63, @"ProjectLocationWatershed", @"Watershed (Geospatial),");
    }

    public partial class FieldDefinitionExcludeFromFactSheet : FieldDefinition
    {
        private FieldDefinitionExcludeFromFactSheet(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionExcludeFromFactSheet Instance = new FieldDefinitionExcludeFromFactSheet(64, @"ExcludeFromFactSheet", @"Exclude from Fact Sheet");
    }

    public partial class FieldDefinitionTransportationStrategy : FieldDefinition
    {
        private FieldDefinitionTransportationStrategy(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionTransportationStrategy Instance = new FieldDefinitionTransportationStrategy(65, @"TransportationStrategy", @"Transportation Strategy");
    }

    public partial class FieldDefinitionTransportationObjective : FieldDefinition
    {
        private FieldDefinitionTransportationObjective(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionTransportationObjective Instance = new FieldDefinitionTransportationObjective(66, @"TransportationObjective", @"Transportation Objective");
    }

    public partial class FieldDefinitionTransportationStrategyName : FieldDefinition
    {
        private FieldDefinitionTransportationStrategyName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionTransportationStrategyName Instance = new FieldDefinitionTransportationStrategyName(67, @"TransportationStrategyName", @"Transportation Strategy Name");
    }

    public partial class FieldDefinitionTransportationObjectiveName : FieldDefinition
    {
        private FieldDefinitionTransportationObjectiveName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionTransportationObjectiveName Instance = new FieldDefinitionTransportationObjectiveName(68, @"TransportationObjectiveName", @"Transportation Objective Name");
    }

    public partial class FieldDefinitionProjectIsATransportationProject : FieldDefinition
    {
        private FieldDefinitionProjectIsATransportationProject(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProjectIsATransportationProject Instance = new FieldDefinitionProjectIsATransportationProject(69, @"ProjectIsATransportationProject", @"This Project is a Transportation Project");
    }

    public partial class FieldDefinitionIsTransportationFundingSource : FieldDefinition
    {
        private FieldDefinitionIsTransportationFundingSource(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionIsTransportationFundingSource Instance = new FieldDefinitionIsTransportationFundingSource(72, @"IsTransportationFundingSource", @"Transportation Funding Source");
    }

    public partial class FieldDefinitionFundingType : FieldDefinition
    {
        private FieldDefinitionFundingType(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionFundingType Instance = new FieldDefinitionFundingType(73, @"FundingType", @"Funding Type");
    }

    public partial class FieldDefinitionProjectCostInYearOfExpenditure : FieldDefinition
    {
        private FieldDefinitionProjectCostInYearOfExpenditure(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProjectCostInYearOfExpenditure Instance = new FieldDefinitionProjectCostInYearOfExpenditure(74, @"ProjectCostInYearOfExpenditure", @"Cost in Year of Expenditure");
    }

    public partial class FieldDefinitionTransportationGlobalInflationRate : FieldDefinition
    {
        private FieldDefinitionTransportationGlobalInflationRate(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionTransportationGlobalInflationRate Instance = new FieldDefinitionTransportationGlobalInflationRate(75, @"TransportationGlobalInflationRate", @"Global Inflation Rate");
    }

    public partial class FieldDefinitionReportingYear : FieldDefinition
    {
        private FieldDefinitionReportingYear(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionReportingYear Instance = new FieldDefinitionReportingYear(76, @"ReportingYear", @"Reporting Year");
    }

    public partial class FieldDefinitionTagName : FieldDefinition
    {
        private FieldDefinitionTagName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionTagName Instance = new FieldDefinitionTagName(77, @"TagName", @"Tag Name");
    }

    public partial class FieldDefinitionTagDescription : FieldDefinition
    {
        private FieldDefinitionTagDescription(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionTagDescription Instance = new FieldDefinitionTagDescription(78, @"TagDescription", @"Tag Description");
    }

    public partial class FieldDefinitionTags : FieldDefinition
    {
        private FieldDefinitionTags(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionTags Instance = new FieldDefinitionTags(79, @"Tags", @"Tags");
    }

    public partial class FieldDefinitionReportedExpenditure : FieldDefinition
    {
        private FieldDefinitionReportedExpenditure(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionReportedExpenditure Instance = new FieldDefinitionReportedExpenditure(80, @"ReportedExpenditure", @"Reported Expenditure");
    }

    public partial class FieldDefinitionProposedProject : FieldDefinition
    {
        private FieldDefinitionProposedProject(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProposedProject Instance = new FieldDefinitionProposedProject(81, @"ProposedProject", @"Proposed Project");
    }

    public partial class FieldDefinitionProjectOnFTIPList : FieldDefinition
    {
        private FieldDefinitionProjectOnFTIPList(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProjectOnFTIPList Instance = new FieldDefinitionProjectOnFTIPList(82, @"ProjectOnFTIPList", @"This project is on the Federal Transportation Improvement Program (FTIP), list");
    }

    public partial class FieldDefinitionLocalAndRegionalPlanDocumentUrl : FieldDefinition
    {
        private FieldDefinitionLocalAndRegionalPlanDocumentUrl(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionLocalAndRegionalPlanDocumentUrl Instance = new FieldDefinitionLocalAndRegionalPlanDocumentUrl(83, @"LocalAndRegionalPlanDocumentUrl", @"Local and Regional Plan Document URL");
    }

    public partial class FieldDefinitionLocalAndRegionalPlanDocumentLinkText : FieldDefinition
    {
        private FieldDefinitionLocalAndRegionalPlanDocumentLinkText(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionLocalAndRegionalPlanDocumentLinkText Instance = new FieldDefinitionLocalAndRegionalPlanDocumentLinkText(84, @"LocalAndRegionalPlanDocumentLinkText", @"Local and Regional Plan Document Link Text");
    }

    public partial class FieldDefinitionSpendingAssociatedWithPM : FieldDefinition
    {
        private FieldDefinitionSpendingAssociatedWithPM(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionSpendingAssociatedWithPM Instance = new FieldDefinitionSpendingAssociatedWithPM(85, @"SpendingAssociatedWithPM", @"Spending Associated with PM");
    }

    public partial class FieldDefinitionPlanningDesignStartYear : FieldDefinition
    {
        private FieldDefinitionPlanningDesignStartYear(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionPlanningDesignStartYear Instance = new FieldDefinitionPlanningDesignStartYear(86, @"PlanningDesignStartYear", @"Planning / Design Start Year");
    }

    public partial class FieldDefinitionAssociatedPrograms : FieldDefinition
    {
        private FieldDefinitionAssociatedPrograms(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionAssociatedPrograms Instance = new FieldDefinitionAssociatedPrograms(87, @"AssociatedPrograms", @"Associated Programs");
    }

    public partial class FieldDefinitionExternalLinks : FieldDefinition
    {
        private FieldDefinitionExternalLinks(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionExternalLinks Instance = new FieldDefinitionExternalLinks(88, @"ExternalLinks", @"External Links");
    }

    public partial class FieldDefinitionEstimatedAnnualOperatingCost : FieldDefinition
    {
        private FieldDefinitionEstimatedAnnualOperatingCost(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionEstimatedAnnualOperatingCost Instance = new FieldDefinitionEstimatedAnnualOperatingCost(89, @"EstimatedAnnualOperatingCost", @"Est. Annual Operating Cost");
    }

    public partial class FieldDefinitionCalculatedTotalRemainingOperatingCost : FieldDefinition
    {
        private FieldDefinitionCalculatedTotalRemainingOperatingCost(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionCalculatedTotalRemainingOperatingCost Instance = new FieldDefinitionCalculatedTotalRemainingOperatingCost(90, @"CalculatedTotalRemainingOperatingCost", @"Remaining Operating Cost");
    }

    public partial class FieldDefinitionCurrentRTPYearForPVCalculations : FieldDefinition
    {
        private FieldDefinitionCurrentRTPYearForPVCalculations(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionCurrentRTPYearForPVCalculations Instance = new FieldDefinitionCurrentRTPYearForPVCalculations(91, @"CurrentRTPYearForPVCalculations", @"Current RTP Year for PV Calculations");
    }

    public partial class FieldDefinitionLifecycleOperatingCost : FieldDefinition
    {
        private FieldDefinitionLifecycleOperatingCost(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionLifecycleOperatingCost Instance = new FieldDefinitionLifecycleOperatingCost(92, @"LifecycleOperatingCost", @"Lifecycle Operating Cost");
    }

    public partial class FieldDefinitionIndicatorSystemName : FieldDefinition
    {
        private FieldDefinitionIndicatorSystemName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionIndicatorSystemName Instance = new FieldDefinitionIndicatorSystemName(93, @"IndicatorSystemName", @"Indicator System Name");
    }

    public partial class FieldDefinitionIndicatorSimpleDescription : FieldDefinition
    {
        private FieldDefinitionIndicatorSimpleDescription(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionIndicatorSimpleDescription Instance = new FieldDefinitionIndicatorSimpleDescription(94, @"IndicatorSimpleDescription", @"Indicator Simple Description");
    }

    public partial class FieldDefinitionIndicatorPrimarySource : FieldDefinition
    {
        private FieldDefinitionIndicatorPrimarySource(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionIndicatorPrimarySource Instance = new FieldDefinitionIndicatorPrimarySource(95, @"IndicatorPrimarySource", @"Indicator Primary Source");
    }

    public partial class FieldDefinitionIndicatorType : FieldDefinition
    {
        private FieldDefinitionIndicatorType(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionIndicatorType Instance = new FieldDefinitionIndicatorType(96, @"IndicatorType", @"Indicator Type");
    }

    public partial class FieldDefinitionChartTitle : FieldDefinition
    {
        private FieldDefinitionChartTitle(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionChartTitle Instance = new FieldDefinitionChartTitle(97, @"ChartTitle", @"Chart Title");
    }

    public partial class FieldDefinitionProposedProjectState : FieldDefinition
    {
        private FieldDefinitionProposedProjectState(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionProposedProjectState Instance = new FieldDefinitionProposedProjectState(98, @"ProposedProjectState", @"Proposed Project State");
    }

    public partial class FieldDefinitionUserLastName : FieldDefinition
    {
        private FieldDefinitionUserLastName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionUserLastName Instance = new FieldDefinitionUserLastName(173, @"UserLastName", @"User Last Name");
    }

    public partial class FieldDefinitionUserFirstName : FieldDefinition
    {
        private FieldDefinitionUserFirstName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionUserFirstName Instance = new FieldDefinitionUserFirstName(174, @"UserFirstName", @"User First Name");
    }

    public partial class FieldDefinitionUserEmail : FieldDefinition
    {
        private FieldDefinitionUserEmail(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionUserEmail Instance = new FieldDefinitionUserEmail(175, @"UserEmail", @"User Email");
    }

    public partial class FieldDefinitionUserPhone : FieldDefinition
    {
        private FieldDefinitionUserPhone(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionUserPhone Instance = new FieldDefinitionUserPhone(176, @"UserPhone", @"Phone Number");
    }

    public partial class FieldDefinitionEIPRoleID : FieldDefinition
    {
        private FieldDefinitionEIPRoleID(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionEIPRoleID Instance = new FieldDefinitionEIPRoleID(177, @"EIPRoleID", @"EIP Role");
    }

    public partial class FieldDefinitionSiteArea : FieldDefinition
    {
        private FieldDefinitionSiteArea(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionSiteArea Instance = new FieldDefinitionSiteArea(181, @"SiteArea", @"Site Area");
    }

    public partial class FieldDefinitionRoleName : FieldDefinition
    {
        private FieldDefinitionRoleName(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionRoleName Instance = new FieldDefinitionRoleName(182, @"RoleName", @"Role Name");
    }

    public partial class FieldDefinitionRegion : FieldDefinition
    {
        private FieldDefinitionRegion(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionRegion Instance = new FieldDefinitionRegion(184, @"Region", @"Region (Geospatial),");
    }

    public partial class FieldDefinitionLatitude : FieldDefinition
    {
        private FieldDefinitionLatitude(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionLatitude Instance = new FieldDefinitionLatitude(185, @"Latitude", @"Latitude");
    }

    public partial class FieldDefinitionLongitude : FieldDefinition
    {
        private FieldDefinitionLongitude(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionLongitude Instance = new FieldDefinitionLongitude(186, @"Longitude", @"Longitude");
    }

    public partial class FieldDefinitionOrganizationUrl : FieldDefinition
    {
        private FieldDefinitionOrganizationUrl(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionOrganizationUrl Instance = new FieldDefinitionOrganizationUrl(188, @"OrganizationUrl", @"Organization Home Page");
    }

    public partial class FieldDefinitionChartCaption : FieldDefinition
    {
        private FieldDefinitionChartCaption(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionChartCaption Instance = new FieldDefinitionChartCaption(228, @"ChartCaption", @"Chart Caption");
    }

    public partial class FieldDefinitionMonitoringProgram : FieldDefinition
    {
        private FieldDefinitionMonitoringProgram(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionMonitoringProgram Instance = new FieldDefinitionMonitoringProgram(236, @"MonitoringProgram", @"Monitoring Program");
    }

    public partial class FieldDefinitionMonitoringApproach : FieldDefinition
    {
        private FieldDefinitionMonitoringApproach(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionMonitoringApproach Instance = new FieldDefinitionMonitoringApproach(237, @"MonitoringApproach", @"Monitoring Approach");
    }

    public partial class FieldDefinitionMonitoringProgramPartner : FieldDefinition
    {
        private FieldDefinitionMonitoringProgramPartner(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionMonitoringProgramPartner Instance = new FieldDefinitionMonitoringProgramPartner(238, @"MonitoringProgramPartner", @"Monitoring Program Partner");
    }

    public partial class FieldDefinitionMonitoringProgramUrl : FieldDefinition
    {
        private FieldDefinitionMonitoringProgramUrl(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionMonitoringProgramUrl Instance = new FieldDefinitionMonitoringProgramUrl(239, @"MonitoringProgramUrl", @"Monitoring Program Home Page");
    }

    public partial class FieldDefinitionThresholdCategoryDescription : FieldDefinition
    {
        private FieldDefinitionThresholdCategoryDescription(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionThresholdCategoryDescription Instance = new FieldDefinitionThresholdCategoryDescription(240, @"ThresholdCategoryDescription", @"Threshold Category Description");
    }

    public partial class FieldDefinitionThresholdCategoryGoalStatement : FieldDefinition
    {
        private FieldDefinitionThresholdCategoryGoalStatement(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionThresholdCategoryGoalStatement Instance = new FieldDefinitionThresholdCategoryGoalStatement(241, @"ThresholdCategoryGoalStatement", @"Threshold Category Goal Statement");
    }

    public partial class FieldDefinitionThresholdCategoryNarrative : FieldDefinition
    {
        private FieldDefinitionThresholdCategoryNarrative(int fieldDefinitionID, string fieldDefinitionName, string fieldDefinitionDisplayName) : base(fieldDefinitionID, fieldDefinitionName, fieldDefinitionDisplayName) {}
        public static readonly FieldDefinitionThresholdCategoryNarrative Instance = new FieldDefinitionThresholdCategoryNarrative(242, @"ThresholdCategoryNarrative", @"Threshold Category Narrative");
    }
}