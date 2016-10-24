
//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class DatabaseEntities : DbContext, LtInfo.Common.EntityModelBinding.ILtInfoEntityTypeLoader
    {
        public DatabaseEntities()
            : base("name=DatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        public virtual DbSet<ActionPriority> ActionPriorities { get; set; }
        public virtual DbSet<ActionPriorityImage> ActionPriorityImages { get; set; }
        public virtual DbSet<AuditLog> AuditLogs { get; set; }
        public virtual DbSet<County> Counties { get; set; }
        public virtual DbSet<DatabaseMigration> DatabaseMigrations { get; set; }
        public virtual DbSet<EIPPerformanceMeasureActual> EIPPerformanceMeasureActuals { get; set; }
        public virtual DbSet<EIPPerformanceMeasureActualSubcategoryOption> EIPPerformanceMeasureActualSubcategoryOptions { get; set; }
        public virtual DbSet<EIPPerformanceMeasureActualSubcategoryOptionUpdate> EIPPerformanceMeasureActualSubcategoryOptionUpdates { get; set; }
        public virtual DbSet<EIPPerformanceMeasureActualUpdate> EIPPerformanceMeasureActualUpdates { get; set; }
        public virtual DbSet<EIPPerformanceMeasureExpectedProposed> EIPPerformanceMeasureExpectedProposeds { get; set; }
        public virtual DbSet<EIPPerformanceMeasureExpected> EIPPerformanceMeasureExpecteds { get; set; }
        public virtual DbSet<EIPPerformanceMeasureExpectedSubcategoryOptionProposed> EIPPerformanceMeasureExpectedSubcategoryOptionProposeds { get; set; }
        public virtual DbSet<EIPPerformanceMeasureExpectedSubcategoryOption> EIPPerformanceMeasureExpectedSubcategoryOptions { get; set; }
        public virtual DbSet<EIPPerformanceMeasure> EIPPerformanceMeasures { get; set; }
        public virtual DbSet<FieldDefinitionData> FieldDefinitionDatas { get; set; }
        public virtual DbSet<FieldDefinitionImage> FieldDefinitionImages { get; set; }
        public virtual DbSet<FileResource> FileResources { get; set; }
        public virtual DbSet<FocusAreaImage> FocusAreaImages { get; set; }
        public virtual DbSet<FocusArea> FocusAreas { get; set; }
        public virtual DbSet<FundingSource> FundingSources { get; set; }
        public virtual DbSet<IndicatorMonitoringProgram> IndicatorMonitoringPrograms { get; set; }
        public virtual DbSet<IndicatorNote> IndicatorNotes { get; set; }
        public virtual DbSet<IndicatorRelationship> IndicatorRelationships { get; set; }
        public virtual DbSet<Indicator> Indicators { get; set; }
        public virtual DbSet<IndicatorSubcategory> IndicatorSubcategories { get; set; }
        public virtual DbSet<IndicatorSubcategoryOption> IndicatorSubcategoryOptions { get; set; }
        public virtual DbSet<Jurisdiction> Jurisdictions { get; set; }
        public virtual DbSet<LocalAndRegionalPlan> LocalAndRegionalPlans { get; set; }
        public virtual DbSet<MappedRegion> MappedRegions { get; set; }
        public virtual DbSet<MonitoringProgramDocument> MonitoringProgramDocuments { get; set; }
        public virtual DbSet<MonitoringProgramPartner> MonitoringProgramPartners { get; set; }
        public virtual DbSet<MonitoringProgram> MonitoringPrograms { get; set; }
        public virtual DbSet<NotificationProject> NotificationProjects { get; set; }
        public virtual DbSet<NotificationProposedProject> NotificationProposedProjects { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<ProgramEIPPerformanceMeasure> ProgramEIPPerformanceMeasures { get; set; }
        public virtual DbSet<ProgramImage> ProgramImages { get; set; }
        public virtual DbSet<Program> Programs { get; set; }
        public virtual DbSet<ProjectExemptReportingYear> ProjectExemptReportingYears { get; set; }
        public virtual DbSet<ProjectExemptReportingYearUpdate> ProjectExemptReportingYearUpdates { get; set; }
        public virtual DbSet<ProjectExternalLink> ProjectExternalLinks { get; set; }
        public virtual DbSet<ProjectExternalLinkUpdate> ProjectExternalLinkUpdates { get; set; }
        public virtual DbSet<ProjectFirmaPageImage> ProjectFirmaPageImages { get; set; }
        public virtual DbSet<ProjectFirmaPage> ProjectFirmaPages { get; set; }
        public virtual DbSet<ProjectFundingOrganization> ProjectFundingOrganizations { get; set; }
        public virtual DbSet<ProjectFundingSourceExpenditure> ProjectFundingSourceExpenditures { get; set; }
        public virtual DbSet<ProjectFundingSourceExpenditureUpdate> ProjectFundingSourceExpenditureUpdates { get; set; }
        public virtual DbSet<ProjectImage> ProjectImages { get; set; }
        public virtual DbSet<ProjectImageUpdate> ProjectImageUpdates { get; set; }
        public virtual DbSet<ProjectImplementingOrganization> ProjectImplementingOrganizations { get; set; }
        public virtual DbSet<ProjectLocalAndRegionalPlan> ProjectLocalAndRegionalPlans { get; set; }
        public virtual DbSet<ProjectLocationAreaGroup> ProjectLocationAreaGroups { get; set; }
        public virtual DbSet<ProjectLocationAreaJurisdiction> ProjectLocationAreaJurisdictions { get; set; }
        public virtual DbSet<ProjectLocationArea> ProjectLocationAreas { get; set; }
        public virtual DbSet<ProjectLocationAreaStateProvince> ProjectLocationAreaStateProvinces { get; set; }
        public virtual DbSet<ProjectLocationAreaWatershed> ProjectLocationAreaWatersheds { get; set; }
        public virtual DbSet<ProjectLocation> ProjectLocations { get; set; }
        public virtual DbSet<ProjectLocationStaging> ProjectLocationStagings { get; set; }
        public virtual DbSet<ProjectLocationStagingUpdate> ProjectLocationStagingUpdates { get; set; }
        public virtual DbSet<ProjectLocationUpdate> ProjectLocationUpdates { get; set; }
        public virtual DbSet<ProjectNote> ProjectNotes { get; set; }
        public virtual DbSet<ProjectNoteUpdate> ProjectNoteUpdates { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectTag> ProjectTags { get; set; }
        public virtual DbSet<ProjectThresholdCategory> ProjectThresholdCategories { get; set; }
        public virtual DbSet<ProjectTransportationQuestion> ProjectTransportationQuestions { get; set; }
        public virtual DbSet<ProjectUpdateBatch> ProjectUpdateBatches { get; set; }
        public virtual DbSet<ProjectUpdateHistory> ProjectUpdateHistories { get; set; }
        public virtual DbSet<ProjectUpdate> ProjectUpdates { get; set; }
        public virtual DbSet<ProjectWatershed> ProjectWatersheds { get; set; }
        public virtual DbSet<ProposedProjectImage> ProposedProjectImages { get; set; }
        public virtual DbSet<ProposedProjectLocation> ProposedProjectLocations { get; set; }
        public virtual DbSet<ProposedProjectLocationStaging> ProposedProjectLocationStagings { get; set; }
        public virtual DbSet<ProposedProjectNote> ProposedProjectNotes { get; set; }
        public virtual DbSet<ProposedProject> ProposedProjects { get; set; }
        public virtual DbSet<ProposedProjectThresholdCategory> ProposedProjectThresholdCategories { get; set; }
        public virtual DbSet<ProposedProjectTransportationQuestion> ProposedProjectTransportationQuestions { get; set; }
        public virtual DbSet<SnapshotEIPPerformanceMeasure> SnapshotEIPPerformanceMeasures { get; set; }
        public virtual DbSet<SnapshotEIPPerformanceMeasureSubcategoryOption> SnapshotEIPPerformanceMeasureSubcategoryOptions { get; set; }
        public virtual DbSet<SnapshotProject> SnapshotProjects { get; set; }
        public virtual DbSet<Snapshot> Snapshots { get; set; }
        public virtual DbSet<SnapshotSectorExpenditure> SnapshotSectorExpenditures { get; set; }
        public virtual DbSet<StateProvince> StateProvinces { get; set; }
        public virtual DbSet<SupportRequestLog> SupportRequestLogs { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<ThresholdCategory> ThresholdCategories { get; set; }
        public virtual DbSet<ThresholdCategoryImage> ThresholdCategoryImages { get; set; }
        public virtual DbSet<ThresholdCategoryIndicator> ThresholdCategoryIndicators { get; set; }
        public virtual DbSet<TransportationCostParameterSet> TransportationCostParameterSets { get; set; }
        public virtual DbSet<TransportationGoal> TransportationGoals { get; set; }
        public virtual DbSet<TransportationObjectiveImage> TransportationObjectiveImages { get; set; }
        public virtual DbSet<TransportationObjective> TransportationObjectives { get; set; }
        public virtual DbSet<TransportationProjectBudget> TransportationProjectBudgets { get; set; }
        public virtual DbSet<TransportationProjectBudgetUpdate> TransportationProjectBudgetUpdates { get; set; }
        public virtual DbSet<TransportationQuestion> TransportationQuestions { get; set; }
        public virtual DbSet<TransportationStrategy> TransportationStrategies { get; set; }
        public virtual DbSet<TransportationStrategyImage> TransportationStrategyImages { get; set; }
        public virtual DbSet<TransportationSubGoal> TransportationSubGoals { get; set; }
        public virtual DbSet<vProject> vProjects { get; set; }
        public virtual DbSet<Watershed> Watersheds { get; set; }

        public object LoadType(Type type, int primaryKey)
        {
            switch (type.Name)
            {
                case "ActionPriority":
                    return ActionPriorities.GetActionPriority(primaryKey);

                case "ActionPriorityImage":
                    return ActionPriorityImages.GetActionPriorityImage(primaryKey);

                case "AuditLogEventType":
                    var auditLogEventType = AuditLogEventType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(auditLogEventType, "AuditLogEventType", primaryKey);
                    return auditLogEventType;

                case "AuditLog":
                    return AuditLogs.GetAuditLog(primaryKey);

                case "County":
                    return Counties.GetCounty(primaryKey);

                case "DatabaseMigration":
                    return DatabaseMigrations.GetDatabaseMigration(primaryKey);

                case "EIPPerformanceMeasureActual":
                    return EIPPerformanceMeasureActuals.GetEIPPerformanceMeasureActual(primaryKey);

                case "EIPPerformanceMeasureActualSubcategoryOption":
                    return EIPPerformanceMeasureActualSubcategoryOptions.GetEIPPerformanceMeasureActualSubcategoryOption(primaryKey);

                case "EIPPerformanceMeasureActualSubcategoryOptionUpdate":
                    return EIPPerformanceMeasureActualSubcategoryOptionUpdates.GetEIPPerformanceMeasureActualSubcategoryOptionUpdate(primaryKey);

                case "EIPPerformanceMeasureActualUpdate":
                    return EIPPerformanceMeasureActualUpdates.GetEIPPerformanceMeasureActualUpdate(primaryKey);

                case "EIPPerformanceMeasureExpectedProposed":
                    return EIPPerformanceMeasureExpectedProposeds.GetEIPPerformanceMeasureExpectedProposed(primaryKey);

                case "EIPPerformanceMeasureExpected":
                    return EIPPerformanceMeasureExpecteds.GetEIPPerformanceMeasureExpected(primaryKey);

                case "EIPPerformanceMeasureExpectedSubcategoryOptionProposed":
                    return EIPPerformanceMeasureExpectedSubcategoryOptionProposeds.GetEIPPerformanceMeasureExpectedSubcategoryOptionProposed(primaryKey);

                case "EIPPerformanceMeasureExpectedSubcategoryOption":
                    return EIPPerformanceMeasureExpectedSubcategoryOptions.GetEIPPerformanceMeasureExpectedSubcategoryOption(primaryKey);

                case "EIPPerformanceMeasure":
                    return EIPPerformanceMeasures.GetEIPPerformanceMeasure(primaryKey);

                case "EIPPerformanceMeasureType":
                    var eIPPerformanceMeasureType = EIPPerformanceMeasureType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(eIPPerformanceMeasureType, "EIPPerformanceMeasureType", primaryKey);
                    return eIPPerformanceMeasureType;

                case "EIPRole":
                    var eIPRole = EIPRole.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(eIPRole, "EIPRole", primaryKey);
                    return eIPRole;

                case "FieldDefinitionData":
                    return FieldDefinitionDatas.GetFieldDefinitionData(primaryKey);

                case "FieldDefinitionImage":
                    return FieldDefinitionImages.GetFieldDefinitionImage(primaryKey);

                case "FieldDefinition":
                    var fieldDefinition = FieldDefinition.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(fieldDefinition, "FieldDefinition", primaryKey);
                    return fieldDefinition;

                case "FileResourceMimeType":
                    var fileResourceMimeType = FileResourceMimeType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(fileResourceMimeType, "FileResourceMimeType", primaryKey);
                    return fileResourceMimeType;

                case "FileResource":
                    return FileResources.GetFileResource(primaryKey);

                case "FocusAreaImage":
                    return FocusAreaImages.GetFocusAreaImage(primaryKey);

                case "FocusArea":
                    return FocusAreas.GetFocusArea(primaryKey);

                case "FundingSource":
                    return FundingSources.GetFundingSource(primaryKey);

                case "FundingType":
                    var fundingType = FundingType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(fundingType, "FundingType", primaryKey);
                    return fundingType;

                case "IndicatorMonitoringProgram":
                    return IndicatorMonitoringPrograms.GetIndicatorMonitoringProgram(primaryKey);

                case "IndicatorNote":
                    return IndicatorNotes.GetIndicatorNote(primaryKey);

                case "IndicatorRelationship":
                    return IndicatorRelationships.GetIndicatorRelationship(primaryKey);

                case "IndicatorRelationshipType":
                    var indicatorRelationshipType = IndicatorRelationshipType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(indicatorRelationshipType, "IndicatorRelationshipType", primaryKey);
                    return indicatorRelationshipType;

                case "Indicator":
                    return Indicators.GetIndicator(primaryKey);

                case "IndicatorSubcategory":
                    return IndicatorSubcategories.GetIndicatorSubcategory(primaryKey);

                case "IndicatorSubcategoryOption":
                    return IndicatorSubcategoryOptions.GetIndicatorSubcategoryOption(primaryKey);

                case "IndicatorTargetValueType":
                    var indicatorTargetValueType = IndicatorTargetValueType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(indicatorTargetValueType, "IndicatorTargetValueType", primaryKey);
                    return indicatorTargetValueType;

                case "IndicatorType":
                    var indicatorType = IndicatorType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(indicatorType, "IndicatorType", primaryKey);
                    return indicatorType;

                case "Jurisdiction":
                    return Jurisdictions.GetJurisdiction(primaryKey);

                case "LocalAndRegionalPlan":
                    return LocalAndRegionalPlans.GetLocalAndRegionalPlan(primaryKey);

                case "MappedRegion":
                    return MappedRegions.GetMappedRegion(primaryKey);

                case "MeasurementUnitType":
                    var measurementUnitType = MeasurementUnitType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(measurementUnitType, "MeasurementUnitType", primaryKey);
                    return measurementUnitType;

                case "MonitoringProgramDocument":
                    return MonitoringProgramDocuments.GetMonitoringProgramDocument(primaryKey);

                case "MonitoringProgramPartner":
                    return MonitoringProgramPartners.GetMonitoringProgramPartner(primaryKey);

                case "MonitoringProgram":
                    return MonitoringPrograms.GetMonitoringProgram(primaryKey);

                case "NotificationProject":
                    return NotificationProjects.GetNotificationProject(primaryKey);

                case "NotificationProposedProject":
                    return NotificationProposedProjects.GetNotificationProposedProject(primaryKey);

                case "Notification":
                    return Notifications.GetNotification(primaryKey);

                case "NotificationType":
                    var notificationType = NotificationType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(notificationType, "NotificationType", primaryKey);
                    return notificationType;

                case "Organization":
                    return Organizations.GetOrganization(primaryKey);

                case "Person":
                    return People.GetPerson(primaryKey);

                case "ProgramEIPPerformanceMeasure":
                    return ProgramEIPPerformanceMeasures.GetProgramEIPPerformanceMeasure(primaryKey);

                case "ProgramImage":
                    return ProgramImages.GetProgramImage(primaryKey);

                case "Program":
                    return Programs.GetProgram(primaryKey);

                case "ProjectColorByType":
                    var projectColorByType = ProjectColorByType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(projectColorByType, "ProjectColorByType", primaryKey);
                    return projectColorByType;

                case "ProjectExemptReportingYear":
                    return ProjectExemptReportingYears.GetProjectExemptReportingYear(primaryKey);

                case "ProjectExemptReportingYearUpdate":
                    return ProjectExemptReportingYearUpdates.GetProjectExemptReportingYearUpdate(primaryKey);

                case "ProjectExternalLink":
                    return ProjectExternalLinks.GetProjectExternalLink(primaryKey);

                case "ProjectExternalLinkUpdate":
                    return ProjectExternalLinkUpdates.GetProjectExternalLinkUpdate(primaryKey);

                case "ProjectFirmaPageImage":
                    return ProjectFirmaPageImages.GetProjectFirmaPageImage(primaryKey);

                case "ProjectFirmaPageRenderType":
                    var projectFirmaPageRenderType = ProjectFirmaPageRenderType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(projectFirmaPageRenderType, "ProjectFirmaPageRenderType", primaryKey);
                    return projectFirmaPageRenderType;

                case "ProjectFirmaPage":
                    return ProjectFirmaPages.GetProjectFirmaPage(primaryKey);

                case "ProjectFirmaPageType":
                    var projectFirmaPageType = ProjectFirmaPageType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(projectFirmaPageType, "ProjectFirmaPageType", primaryKey);
                    return projectFirmaPageType;

                case "ProjectFundingOrganization":
                    return ProjectFundingOrganizations.GetProjectFundingOrganization(primaryKey);

                case "ProjectFundingSourceExpenditure":
                    return ProjectFundingSourceExpenditures.GetProjectFundingSourceExpenditure(primaryKey);

                case "ProjectFundingSourceExpenditureUpdate":
                    return ProjectFundingSourceExpenditureUpdates.GetProjectFundingSourceExpenditureUpdate(primaryKey);

                case "ProjectImage":
                    return ProjectImages.GetProjectImage(primaryKey);

                case "ProjectImageTiming":
                    var projectImageTiming = ProjectImageTiming.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(projectImageTiming, "ProjectImageTiming", primaryKey);
                    return projectImageTiming;

                case "ProjectImageUpdate":
                    return ProjectImageUpdates.GetProjectImageUpdate(primaryKey);

                case "ProjectImplementingOrganization":
                    return ProjectImplementingOrganizations.GetProjectImplementingOrganization(primaryKey);

                case "ProjectLocalAndRegionalPlan":
                    return ProjectLocalAndRegionalPlans.GetProjectLocalAndRegionalPlan(primaryKey);

                case "ProjectLocationAreaGroup":
                    return ProjectLocationAreaGroups.GetProjectLocationAreaGroup(primaryKey);

                case "ProjectLocationAreaGroupType":
                    var projectLocationAreaGroupType = ProjectLocationAreaGroupType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(projectLocationAreaGroupType, "ProjectLocationAreaGroupType", primaryKey);
                    return projectLocationAreaGroupType;

                case "ProjectLocationAreaJurisdiction":
                    return ProjectLocationAreaJurisdictions.GetProjectLocationAreaJurisdiction(primaryKey);

                case "ProjectLocationArea":
                    return ProjectLocationAreas.GetProjectLocationArea(primaryKey);

                case "ProjectLocationAreaStateProvince":
                    return ProjectLocationAreaStateProvinces.GetProjectLocationAreaStateProvince(primaryKey);

                case "ProjectLocationAreaWatershed":
                    return ProjectLocationAreaWatersheds.GetProjectLocationAreaWatershed(primaryKey);

                case "ProjectLocationFilterType":
                    var projectLocationFilterType = ProjectLocationFilterType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(projectLocationFilterType, "ProjectLocationFilterType", primaryKey);
                    return projectLocationFilterType;

                case "ProjectLocation":
                    return ProjectLocations.GetProjectLocation(primaryKey);

                case "ProjectLocationSimpleType":
                    var projectLocationSimpleType = ProjectLocationSimpleType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(projectLocationSimpleType, "ProjectLocationSimpleType", primaryKey);
                    return projectLocationSimpleType;

                case "ProjectLocationStaging":
                    return ProjectLocationStagings.GetProjectLocationStaging(primaryKey);

                case "ProjectLocationStagingUpdate":
                    return ProjectLocationStagingUpdates.GetProjectLocationStagingUpdate(primaryKey);

                case "ProjectLocationUpdate":
                    return ProjectLocationUpdates.GetProjectLocationUpdate(primaryKey);

                case "ProjectNote":
                    return ProjectNotes.GetProjectNote(primaryKey);

                case "ProjectNoteUpdate":
                    return ProjectNoteUpdates.GetProjectNoteUpdate(primaryKey);

                case "Project":
                    return Projects.GetProject(primaryKey);

                case "ProjectStage":
                    var projectStage = ProjectStage.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(projectStage, "ProjectStage", primaryKey);
                    return projectStage;

                case "ProjectTag":
                    return ProjectTags.GetProjectTag(primaryKey);

                case "ProjectThresholdCategory":
                    return ProjectThresholdCategories.GetProjectThresholdCategory(primaryKey);

                case "ProjectTransportationQuestion":
                    return ProjectTransportationQuestions.GetProjectTransportationQuestion(primaryKey);

                case "ProjectUpdateBatch":
                    return ProjectUpdateBatches.GetProjectUpdateBatch(primaryKey);

                case "ProjectUpdateHistory":
                    return ProjectUpdateHistories.GetProjectUpdateHistory(primaryKey);

                case "ProjectUpdate":
                    return ProjectUpdates.GetProjectUpdate(primaryKey);

                case "ProjectUpdateState":
                    var projectUpdateState = ProjectUpdateState.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(projectUpdateState, "ProjectUpdateState", primaryKey);
                    return projectUpdateState;

                case "ProjectWatershed":
                    return ProjectWatersheds.GetProjectWatershed(primaryKey);

                case "ProposedProjectImage":
                    return ProposedProjectImages.GetProposedProjectImage(primaryKey);

                case "ProposedProjectLocation":
                    return ProposedProjectLocations.GetProposedProjectLocation(primaryKey);

                case "ProposedProjectLocationStaging":
                    return ProposedProjectLocationStagings.GetProposedProjectLocationStaging(primaryKey);

                case "ProposedProjectNote":
                    return ProposedProjectNotes.GetProposedProjectNote(primaryKey);

                case "ProposedProject":
                    return ProposedProjects.GetProposedProject(primaryKey);

                case "ProposedProjectState":
                    var proposedProjectState = ProposedProjectState.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(proposedProjectState, "ProposedProjectState", primaryKey);
                    return proposedProjectState;

                case "ProposedProjectThresholdCategory":
                    return ProposedProjectThresholdCategories.GetProposedProjectThresholdCategory(primaryKey);

                case "ProposedProjectTransportationQuestion":
                    return ProposedProjectTransportationQuestions.GetProposedProjectTransportationQuestion(primaryKey);

                case "ReminderMessageType":
                    var reminderMessageType = ReminderMessageType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(reminderMessageType, "ReminderMessageType", primaryKey);
                    return reminderMessageType;

                case "Sector":
                    var sector = Sector.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(sector, "Sector", primaryKey);
                    return sector;

                case "SnapshotEIPPerformanceMeasure":
                    return SnapshotEIPPerformanceMeasures.GetSnapshotEIPPerformanceMeasure(primaryKey);

                case "SnapshotEIPPerformanceMeasureSubcategoryOption":
                    return SnapshotEIPPerformanceMeasureSubcategoryOptions.GetSnapshotEIPPerformanceMeasureSubcategoryOption(primaryKey);

                case "SnapshotProject":
                    return SnapshotProjects.GetSnapshotProject(primaryKey);

                case "SnapshotProjectType":
                    var snapshotProjectType = SnapshotProjectType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(snapshotProjectType, "SnapshotProjectType", primaryKey);
                    return snapshotProjectType;

                case "Snapshot":
                    return Snapshots.GetSnapshot(primaryKey);

                case "SnapshotSectorExpenditure":
                    return SnapshotSectorExpenditures.GetSnapshotSectorExpenditure(primaryKey);

                case "StateProvince":
                    return StateProvinces.GetStateProvince(primaryKey);

                case "SupportRequestLog":
                    return SupportRequestLogs.GetSupportRequestLog(primaryKey);

                case "SupportRequestType":
                    var supportRequestType = SupportRequestType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(supportRequestType, "SupportRequestType", primaryKey);
                    return supportRequestType;

                case "Tag":
                    return Tags.GetTag(primaryKey);

                case "ThresholdCategory":
                    return ThresholdCategories.GetThresholdCategory(primaryKey);

                case "ThresholdCategoryImage":
                    return ThresholdCategoryImages.GetThresholdCategoryImage(primaryKey);

                case "ThresholdCategoryIndicator":
                    return ThresholdCategoryIndicators.GetThresholdCategoryIndicator(primaryKey);

                case "TransportationCostParameterSet":
                    return TransportationCostParameterSets.GetTransportationCostParameterSet(primaryKey);

                case "TransportationGoal":
                    return TransportationGoals.GetTransportationGoal(primaryKey);

                case "TransportationObjectiveImage":
                    return TransportationObjectiveImages.GetTransportationObjectiveImage(primaryKey);

                case "TransportationObjective":
                    return TransportationObjectives.GetTransportationObjective(primaryKey);

                case "TransportationProjectBudget":
                    return TransportationProjectBudgets.GetTransportationProjectBudget(primaryKey);

                case "TransportationProjectBudgetUpdate":
                    return TransportationProjectBudgetUpdates.GetTransportationProjectBudgetUpdate(primaryKey);

                case "TransportationProjectCostType":
                    var transportationProjectCostType = TransportationProjectCostType.All.SingleOrDefault(x => x.PrimaryKey == primaryKey);
                    Check.RequireNotNullThrowNotFound(transportationProjectCostType, "TransportationProjectCostType", primaryKey);
                    return transportationProjectCostType;

                case "TransportationQuestion":
                    return TransportationQuestions.GetTransportationQuestion(primaryKey);

                case "TransportationStrategy":
                    return TransportationStrategies.GetTransportationStrategy(primaryKey);

                case "TransportationStrategyImage":
                    return TransportationStrategyImages.GetTransportationStrategyImage(primaryKey);

                case "TransportationSubGoal":
                    return TransportationSubGoals.GetTransportationSubGoal(primaryKey);

                case "Watershed":
                    return Watersheds.GetWatershed(primaryKey);
                default:
                    throw new NotImplementedException(string.Format("No loader for type \"{0}\"", type.FullName));
            }
        }
    }
}