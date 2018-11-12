delete from dbo.ProjectCreateSection

insert into dbo.ProjectCreateSection (ProjectCreateSectionID, ProjectCreateSectionName, ProjectCreateSectionDisplayName, SortOrder, HasCompletionStatus, ProjectWorkflowSectionGroupingID)
values
(1, 'Instructions', 'Instructions', 10, 0, 1),
(2, 'Basics', 'Basics', 20, 1, 1),
(3, 'LocationSimple', 'Location - Simple', 30, 1, 2),
(4, 'LocationDetailed', 'Location - Detailed', 40, 0, 2),
(5, 'Watershed', 'Watersheds', 50, 1, 2),
(6, 'ExpectedPerformanceMeasures', 'Expected Performance Measures', 60, 1, 3),
(7, 'ReportedPerformanceMeasures', 'Reported Performance Measures', 70, 1, 3),
(8, 'ExpectedFunding', 'Expected Funding', 80, 0, 4),
(9, 'ReportedExpenditures', 'Reported Expenditures', 90, 1, 4),
(11, 'Classifications', 'Classifications', 110, 1, 5),
(12, 'Assessment', 'Asssessment', 120, 1, 5),
(13, 'Photos', 'Photos', 130, 0, 5),
(14, 'NotesAndDocuments', 'Documents and Notes', 140, 0, 5),
(15, 'Organizations', 'Organizations', 55, 1, 1)