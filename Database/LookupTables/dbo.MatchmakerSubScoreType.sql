delete from dbo.MatchmakerSubScoreType
go

insert into dbo.MatchmakerSubScoreType(MatchmakerSubScoreTypeID, MatchmakerSubScoreTypeName, MatchmakerSubScoreTypeDisplayName)
values
(1, 'MatchmakerKeyword', 'Matchmaker Keywords'),
(2, 'AreaOfInterest', 'Areas Of Interest'),
(3, 'TaxonomySystem', 'Taxonomy System'),
(4, 'Classification', 'Classification'),
(5, 'PerformanceMeasure', 'Performance Measures')

