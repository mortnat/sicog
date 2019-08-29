delete from dbo.FirmaPageType
go

insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(1, 'HomePage', 'Home Page', 2),
(4, 'DemoScript', 'Demo Script', 2),
(5, 'InternalSetupNotes', 'Internal Setup Notes', 2),
(6, 'FullProjectList', 'Full Project List', 1),
(9, 'PerformanceMeasuresList', 'Performance Measures List', 1),
(11, 'TaxonomyLeafList', 'Taxonomy Leaf List', 1),
(13, 'TaxonomyBranchList', 'Taxonomy Branch List', 1),
(14, 'TaxonomyTrunkList', 'Taxonomy Trunk List', 1),
(15, 'FundingSourcesList', 'Funding Sources List', 1),
(16, 'OrganizationsList', 'Organizations List', 1),
(18, 'MyProjects', 'My Projects', 1),
(20, 'ProjectResults', 'Project Results by Organization', 1),
(22, 'ProjectMap', 'Project Map', 1),
(24, 'HomeMapInfo', 'Home Page Map Info', 2),
(25, 'HomeAdditionalInfo', 'Home Page Additional Info', 2),
(26, 'FeaturedProjectList', 'Featured Project List', 1),
(31, 'CostParameterSet', 'Cost Parameter Set', 1),
(33, 'FullProjectListSimple', 'Full Project List (Simple)', 1),
(34, 'Taxonomy', 'Taxonomy', 1),
(36, 'TagList', 'Tag List', 1),
(37, 'SpendingByPerformanceMeasureByProject', 'Spending by Performance Measure by Project', 1),
(38, 'Proposals', 'Proposals', 1),
(39, 'MyOrganizationsProjects', 'My Organization''s Projects', 1),
(41, 'ManageUpdateNotifications', 'Manage Project Update Notifications', 1),
(45, 'ProposeProjectInstructions', 'Propose Project Instructions', 2),
(46, 'ProjectStewardOrganizationList', 'ProjectStewardOrganizationList', 1),
(47, 'EnterHistoricProjectInstructions', 'Enter Historic Project Instructions', 2),
(48, 'PendingProjects', 'Pending Projects', 1),
(49, 'Training','Training', 2),
(50, 'ProjectCreateImportExternal', 'ProjectCreateImportExternal', 1),
(51, 'CustomFooter', 'Custom Footer', 1),
(52, 'ManageProjectCustomAttributeTypeInstructions', 'Manage Project Custom Attribute Type Instructions', 2),
(53, 'ManageProjectCustomAttributeTypesList', 'Manage Project Custom Attribute Types List', 2),
(54, 'FactSheetCustomText', 'Fact Sheet Custom Text', 2),
(55, 'UsersList', 'Users List', 1),
(56, 'ProjectUpdateInstructions', 'Project Update Instructions', 2),
(57, 'TechnicalAssistanceInstructions', 'Technical Assistance Instructions', 1),
(58, 'TechnicalAssistanceReport', 'Technical Assistance Report', 1),
(59, 'InviteUser', 'Invite User', 1),
(60, 'ManageFundingSourceCustomAttributeTypeInstructions', 'Manage Funding Source Custom Attribute Type Instructions', 2),
(61, 'ManageFundingSourceCustomAttributeTypesList', 'Manage Funding Source Custom Attribute Types List', 2),
(62, 'FundingStatusHeader', 'Funding Status Header', 1),
(63, 'FundingStatusFooter', 'Funding Status Footer', 1),
(64, 'ManageProjectCustomGrids', 'Manage Project Custom Grids', 1)