UPDATE dbo.GeospatialArea SET GeospatialAreaName = GeospatialAreaName + ' Local Area' Where GeospatialAreaTypeID=14

ALTER TABLE dbo.GeospatialAreaType ADD IncludeTypeInPageTitle BIT NULL
go

UPDATE dbo.GeospatialAreaType SET IncludeTypeInPageTitle = 0
UPDATE dbo.GeospatialAreaType SET IncludeTypeInPageTitle = 1 WHERE GeospatialAreaTypeID = 18
go

ALTER TABLE dbo.GeospatialAreaType ALTER COLUMN IncludeTypeInPageTitle BIT NOT NULL