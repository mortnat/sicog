IF NOT EXISTS (SELECT name FROM sysindexes WHERE name = 'SPATIAL_GeospatialArea_GeospatialAreaFeature') create spatial index SPATIAL_GeospatialArea_GeospatialAreaFeature on dbo.GeospatialArea(GeospatialAreaFeature) with (BOUNDING_BOX=(-125, 32, -105, 53))