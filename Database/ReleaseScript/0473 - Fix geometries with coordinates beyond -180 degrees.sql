
update dbo.Project
set ProjectLocationPoint = geometry::STGeomFromText('POINT(151.14441 59.7121)', 4326)
where ProjectID = 12

update dbo.Project
set ProjectLocationPoint = geometry::STGeomFromText('POINT(178.74207 62.995161)', 4326)
where ProjectID = 16

update dbo.Project
set ProjectLocationPoint = geometry::STGeomFromText('POINT(-122.39996 38.44111)', 4326)
where ProjectID = 13780

/*
select p.ProjectID, 
	TenantID,
	ProjectLocationPoint.STX as Latitude,	
	ProjectLocationPoint.STY as Longitude, 
	ProjectLocationPoint.STAsText() as STAsText
from dbo.Project p
where NOT(ProjectLocationPoint.STX between -180 and 180)
or NOT(ProjectLocationPoint.STY between -90 and 90)
*/

update dbo.ProjectLocation
set ProjectLocationGeometry = geometry::STGeomFromText('POLYGON ((-122.40577340126049 38.440409941475878, -122.40096688270575 38.444208185739249, -122.39935755729687 38.443788035807593, -122.39772677421576 38.443183015609236, -122.39716887474066 38.442409926864329, -122.39620327949535 38.441569603619428, -122.39517331123358 38.440947758119918, -122.40269422531134 38.436809775609582, -122.40577340126049 38.440409941475878))', 4326)
where ProjectLocationID = 14262

/*
select ProjectLocationID,
	TenantID,
	ProjectID,
 ProjectLocationGeometry.STCentroid().STAsText()
	--ProjectLocationGeometry.STAsText()
from dbo.ProjectLocation
--where ProjectID = 13780
where NOT(ProjectLocationGeometry.STCentroid().STX between -180 and 180)
or NOT(ProjectLocationGeometry.STCentroid().STY between -90 and 90)

select OrganizationID,
	TenantID,
 OrganizationBoundary.STCentroid().STAsText()
	--OrganizationGeometry.STAsText()
from dbo.Organization
--where ProjectID = 13780
where NOT(OrganizationBoundary.STCentroid().STX between -180 and 180)
or NOT(OrganizationBoundary.STCentroid().STY between -90 and 90)
*/
