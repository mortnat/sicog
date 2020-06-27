ALTER TABLE dbo.GeospatialArea ADD GeospatialAreaShortName VARCHAR(200) NULL
go
UPDATE dbo.GeospatialArea SET GeospatialAreaShortName = GeospatialAreaName
UPDATE dbo.GeospatialArea SET GeospatialAreaName = GeospatialAreaName + ' Local Area' Where GeospatialAreaTypeID=14
UPDATE dbo.GeospatialArea SET GeospatialAreaName = GeospatialAreaName + ' Lead Entity Management Area' Where GeospatialAreaTypeID=18
UPDATE dbo.GeospatialArea SET GeospatialAreaName = GeospatialAreaName + ' County' Where GeospatialAreaTypeID=19

ALTER TABLE dbo.GeospatialArea ALTER COLUMN GeospatialAreaShortName VARCHAR(200) NOT NULL