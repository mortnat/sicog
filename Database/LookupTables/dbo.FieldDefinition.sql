delete from dbo.FieldDefinition
go

INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(1, N'TaxonomyLeaf', N'Taxonomy Leaf'),
(4, N'ExpectedValue', N'Expected Value'),
(5, N'TaxonomyTrunk', N'Taxonomy Trunk'),
(8, N'FundingSource', N'Funding Source'),
(12, N'IsPrimaryContactOrganization', N'Is Primary Contact Organization'),
(13, N'ProjectsStewardOrganizationRelationshipToProject', N'Projects Steward Organization Relationship To Project'),
(14, N'Organization', N'Organization'),
(17, N'Password', N'Password'),
(18, N'PerformanceMeasure', N'Performance Measure'),
(19, N'PerformanceMeasureType', N'Performance Measure Type'),
(21, N'MeasurementUnit', N'Measurement Unit'),
(22, N'PhotoCaption', N'Photo Caption'),
(23, N'PhotoCredit', N'Photo Credit'),
(24, N'PhotoTiming', N'Photo Timing'),
(25, N'OrganizationPrimaryContact', N'Primary Contact'),
(26, N'TaxonomyBranch', N'Taxonomy Branch'),
(28, N'CompletionYear', N'Completion Year'),
(29, N'ProjectDescription', N'Project Description'),
(30, N'ProjectName', N'Project Name'),
(31, N'ProjectNote', N'Project Note'),
(32, N'ImplementationStartYear', N'Implementation Start Year'),
(33, N'ReportedValue', N'Reported Value'),
(34, N'OrganizationType', N'Organization Type'),
(35, N'SecuredFunding', N'Secured Funding'),
(36, N'ProjectStage', N'Project Stage'),
(39, N'ClassificationName', N'Classification Name'),
(40, N'EstimatedTotalCost', N'Estimated Total Cost'),
(41, N'NoFundingSourceIdentified', N'No Funding Source Identified Yet'),
(42, N'Username', N'User name'),
(44, N'Project', N'Project'),
(46, N'Classification', N'Classification'),
(49, N'PerformanceMeasureSubcategory', N'Performance Measure Subcategory'),
(50, N'PerformanceMeasureSubcategoryOption', N'Performance Measure Subcategory Option'),
(56, N'FundedAmount', N'Funded Amount'),
(57, N'ProjectLocation', N'Project Location'),
(64, N'ExcludeFromFactSheet', N'Exclude from Fact Sheet'),
(73, N'FundingType', N'Funding Type'),
(74, N'ProjectCostInYearOfExpenditure', N'Cost in Year of Expenditure'),
(75, N'GlobalInflationRate', N'Global Inflation Rate'),
(76, N'ReportingYear', N'Reporting Year'),
(77, N'TagName', N'Tag Name'),
(78, N'TagDescription', N'Tag Description'),
(80, N'ReportedExpenditure', N'Reported Expenditure'),
(81, N'Proposal', N'Proposal'),
(85, N'SpendingAssociatedWithPM', N'Spending Associated with PM'),
(86, N'PlanningDesignStartYear', N'Planning / Design Start Year'),
(87, N'AssociatedTaxonomyBranches', N'Associated Taxonomy Branches'),
(88, N'ExternalLinks', N'External Links'),
(89, N'EstimatedAnnualOperatingCost', N'Est. Annual Operating Cost'),
(90, N'CalculatedTotalRemainingOperatingCost', N'Remaining Operating Cost'),
(91, N'CurrentYearForPVCalculations', N'Current Year for PV Calculations'),
(92, N'LifecycleOperatingCost', N'Lifecycle Operating Cost'),
(97, N'PerformanceMeasureChartTitle', N'Performance Measure Chart Title'),
(182, N'RoleName', N'Role Name'),
(184, N'Region', N'Region (Geospatial)'),
(228, N'PerformanceMeasureChartCaption', N'Performance Measure Chart Caption'),
(236, N'MonitoringProgram', N'Monitoring Program'),
(237, N'MonitoringApproach', N'Monitoring Approach'),
(238, N'MonitoringProgramPartner', N'Monitoring Program Partner'),
(239, N'MonitoringProgramUrl', N'Monitoring Program Home Page'),
(240, N'ClassificationDescription', N'Classification Description'),
(241, N'ClassificationGoalStatement', N'Classification Goal Statement'),
(242, N'ClassificationNarrative', N'Classification Narrative'),
(243, N'TaxonomySystemName', N'Taxonomy System Name'),
(244, N'TaxonomyLeafDisplayNameForProject', N'Taxonomy Tier One Display Name For Project'),
(245, N'ProjectOrganizationRelationshipType', N'Project Organization Relationship Type'),
(246, N'ProjectSteward', N'Project Steward'),
(248, N'TargetedFunding', N'Targeted Funding'),
(249, N'ProjectStewardOrganizationDisplayName', N'Project Steward Organization Display Name'),
(250, N'ClassificationSystem', N'Classification System'),
(251, N'ClassificationSystemName', N'Classification System Name'),
(252, N'ProjectPrimaryContact', N'Project Primary Contact'),
(254, N'TaxonomyTrunkDescription', N'Taxonomy Trunk Description'),
(255, N'TaxonomyBranchDescription', N'Taxonomy Branch Description'),
(256, N'TaxonomyLeafDescription', N'Taxonomy Leaf Description'),
(257, N'ShowProposalsToThePublic', N'Show Proposals To The Public'),
(258, N'ShowLeadImplementerLogoOnFactSheet', N'Show Lead Implementer Logo on Project Fact Sheet?'),
(259, N'ProjectCustomAttribute', N'Project Custom Attribute'),
(260, N'ProjectCustomAttributeDataType', N'Data Type'),
(261, N'ReportingPeriodKickOffDate', N'Reporting Period Kick-off Date'),
(262, N'ProjectUpdateReminderInterval', N'Reminder Interval (days)'),
(263, N'ReportingPeriodCloseOutDate', N'Reporting Period Close-out Date'),
(264, N'PerformanceMeasureIsSummable', 'Summable?'),
(265, N'FundingSourceAmount', N'Amount'),
(266, N'NormalUser', N'Normal User'),
(267, N'ProjectStewardshipArea', N'Project Stewardship Area'),
(268, N'ProjectInternalNote', N'Internal Note'),
(269, N'SecondaryProjectTaxonomyLeaf', N'Secondary Project Taxonomy Leaf'),
(270, N'ProjectPrimaryContactEmail', N'Project Primary Contact Email'),
(271, N'ProjectCustomAttributeTypeEditableBy', 'Editable By' ),
(272, N'ProjectCustomAttributeTypeViewableBy', 'Viewable By'),
(273, N'OrganizationTypeAbbreviation', N'Abbreviation'),
(274, N'LegendColor', N'Legend Color'),
(275, N'ShowOnProjectMaps', N'Show On Map?'),
(276, N'IsDefaultOrganizationType', N'Is Default?'),
(277, N'IsFundingType', N'Is Funding Type'),
(278, N'SignificantDigits', N'Significant Digits'),
(279, N'TenantShortDisplayName', N'Tenant Short Display Name'),
(280, N'ToolDisplayName', N'Tenant Display Tool'),
(281, N'TenantSquareLogo', N'Tenant Square Logo'),
(282, N'FundingSourceCustomAttribute', N'Funding Source Custom Attribute'),
(283, N'FundingSourceCustomAttributeDataType', N'Funding Source Custom Attribute Data Type'),
(284, N'FundingSourceCustomAttributeTypeEditableBy', 'Funding Source Custom Attribute Editable By' ),
(285, N'FundingSourceCustomAttributeTypeViewableBy', 'Funding Source Custom Attribute Viewable By'),
(286, N'ContactType', N'Contact Type'),
(287, N'ContactTypeAbbreviation', N'Contact Type Abbreviation'),
(288, N'IsDefaultContactType', N'Is Default Contact Type?'),
(289, N'ProjectContactRelationshipType', N'Project Contact Relationship Type'),
(290, N'CostType', 'Cost Type'),
(291, N'AttachmentType', N'Attachment Type'),
(292, N'ProjectID', N'ProjectID'),
(293, N'ExcludeTargetedFundingOrganizations', N'Exclude Targeted Funding Organizations from List of Funders?'),
(294, N'ProjectCustomAttributeGroup', N'Project Custom Attribute Group'),
(295, N'ProjectLastUpdated', N'Last Updated'),
(296, N'NumberOfProjectsWithExpendedFunds', N'# of Projects with Expended Funds'),
(297, N'TotalExpenditures', N'Total Expenditures'),
(298, N'NumberOfProjectsWithSecuredFunds', N'# of Projects with Secured Funds'),
(299, N'TotalProjectSecuredFunds', N'Total Project Secured Funds'),
(300, N'TotalProjectTargetedFunds', N'Total Project Targeted Funds'),
(301, N'PerformanceMeasureCanBeChartedCumulatively', 'Can be charted cumulatively?'),
(302, N'Status', N'Status'),
(303, N'StatusUpdate', N'Status Update'),
(304, N'StatusHistory', N'Status History'),
(305, N'UpdateHistory', N'Update History'),
(306, N'StatusLegend', N'Status Legend'),
(307, N'StatusUpdateCreatedBy', N'Status Update Created By'),
(308, N'StatusUpdateDate', N'Status Update Date'),
(309, N'StatusComments', N'Status Comments'),
(310, N'GeospatialArea', 'Geospatial Area'),
(311, N'ArcGISFileGeodatabase', 'ArcGIS File Geodatabase'),
(312, N'KMLFile', 'KML File'),
(313, N'ExternalReferenceLayer', 'External Reference Layer'),
(314, N'ExternalMapLayerDisplayName', 'Display Name'),
(315, N'ExternalMapLayerUrl', 'Url'),
(316, N'ExternalMapLayerDescription', 'Internal Layer Description'),
(317, N'ExternalMapLayerFeatureNameField', 'Field to use as source for feature names'),
(318, N'ExternalMapLayerDisplayOnAllMaps', 'Display on all maps?'),
(319, N'GeospatialAreaTypeOnByDefaultOnProjectMap', 'Layer is on by default on Project map?'),
(320, N'ExternalMapLayerIsActive', 'Is Active?'),
(321, N'ExternalMapLayerIsATiledMapService', 'Is a Tiled Map Service?'),
(322, N'FinalStatusUpdateStatus', N'Final Status Update'),
(323, N'IsFinalStatusUpdate', N'Is Final Status Update'),
(324, N'StatusLessonsLearned', N'Lessons Learned'),
(325, N'Evaluation', 'Evaluation'),
(326, N'EvaluationCriteria', 'Evaluation Criteria'),
(327, N'EvaluationCriteriaValue', 'Evaluation Criteria Value'),
(328, N'EvaluationPortfolio', 'Evaluation Portfolio'),
(329, N'ProjectEvaluation', 'Project Evaluation'),
(330, N'EvaluationName', 'Evaluation Name'),
(331, N'EvaluationDefinition', 'Evaluation Definition'),
(332, N'EvaluationStatus', 'Evaluation Status'),
(333, N'EvaluationStartDate', 'Evaluation Start Date'),
(334, N'EvaluationEndDate', 'Evaluation End Date'),
(335, N'EvaluationVisibility', 'Evaluation Visibility'),
(336, N'EvaluationCriteriaName', 'Evaluation Criteria Name'),
(337, N'EvaluationCriteriaDefinition', 'Evaluation Criteria Definition'),
(338, N'EnableProjectEvaluations', 'Enable Project Evaluations'),
(339, N'UseProjectTimeline', 'Use Project Timeline'),
(340, N'ProjectCategory', 'Project Category'),
(341, N'EnableProjectCategory', 'Enable Project Categories'),
(342, N'EnableReports', 'Enable Reports'),
(343, N'ReportTitle', 'Report Title'),
(344, N'ReportDescription', 'Report Description'),
(345, N'ReportFile', 'Report File'),
(346, N'ReportModel', 'Report Model'),
(347, N'SelectedReportTemplate', 'Selected Report Template'),
(348, N'FactSheetCustomText', N'Fact Sheet Custom Text'),
(349, N'FactSheetLogo', N'Fact Sheet Logo'),
(350, N'IsContactRelationshipTypeRequired', N'Is Contact Relationship Type Required?'),
(351, N'IsOrganizationRelationshipTypeRequired', N'Is Organization Relationship Type Required?'),
(352, N'SyncWithKeystoneOnSave', N'Sync with Keystone on Save'),
(353, N'DocumentLibraryName', N'Document Library Name'),
(354, N'KMZFile', N'KMZ File'),
(355, N'DocumentLibrary', N'Document Library'),
(356, N'DocumentLibraryDocumentViewableBy', N'Document Viewable By'),
(357, N'CustomPageViewableBy', N'Custom Page Viewable By'),
(358, N'EnableMatchmaker', N'Enable Matchmaker'),
(359, N'GeospatialAreaMapLayerDisplayAsReferenceLayer', 'Display as Reference Layer?'),
(360, N'MatchScore', N'Match Score'),
(361, N'OrganizationCash', N'Cash'),
(362, N'OrganizationInKindServices', N'In-Kind Services'),
(363, N'OrganizationCommercialServices', N'Commercial Services'),
(364, N'AreaOfInterest', N'Area of Interest'),
(365, N'MatchmakerKeyword', N'Keyword'),
(366, N'OrganizationKeystoneGuid', N'Keystone Organization GUID'),
(367, N'ContactRelationshipTypeAcceptsMultipleValues', N'Accepts Multiple Values'),
(368, 'OrganizationTypeLayerOnByDefault', 'Layer on by Default?'),
(369, 'GeospatialAreaTypeOnByDefaultOnOtherMaps', 'Layer on by default on all maps other than the Project Map?'),
(370, 'ProjectLocationIsPrivate', 'Location Privacy'),
(371, N'CanContactTypeManageProject', N'Can Manage the Project?'),
(372, N'TrackAccomplishments', N'Track Accomplishments'),
(373, N'ShowExpectedPerformanceMeasuresOnFactSheet', N'Show Expected Performance Measures on Fact Sheet?'),
(374, N'Solicitation', N'Solicitation'),
(375, N'EnableSolicitations', N'Enable Solicitations')

