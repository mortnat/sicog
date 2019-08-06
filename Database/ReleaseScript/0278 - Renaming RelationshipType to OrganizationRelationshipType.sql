

--rename main table
exec sp_rename 'dbo.RelationshipType', 'OrganizationRelationshipType'

--rename columns
exec sp_rename 'dbo.OrganizationRelationshipType.RelationshipTypeID', 'OrganizationRelationshipTypeID', 'COLUMN'
exec sp_rename 'dbo.OrganizationRelationshipType.RelationshipTypeName', 'OrganizationRelationshipTypeName', 'COLUMN'
exec sp_rename 'dbo.OrganizationRelationshipType.RelationshipTypeDescription', 'OrganizationRelationshipTypeDescription', 'COLUMN'

--rename constraints
exec sp_rename 'dbo.OrganizationRelationshipType.PK_RelationshipType_RelationshipTypeID', 'PK_OrganizationRelationshipType_OrganizationRelationshipTypeID'
exec sp_rename 'dbo.FK_RelationshipType_Tenant_TenantID', 'FK_OrganizationRelationshipType_Tenant_TenantID'
exec sp_rename 'dbo.OrganizationRelationshipType.AK_RelationshipType_RelationshipTypeID_TenantID', 'AK_OrganizationRelationshipType_OrganizationRelationshipTypeID_TenantID'
exec sp_rename 'dbo.OrganizationRelationshipType.AK_RelationshipType_RelationshipTypeName_TenantID', 'AK_OrganizationRelationshipType_OrganizationRelationshipTypeName_TenantID'


--rename joining table - OrganizationTypeRelationshipType to OrganizationTypeOrganizationRelationshipType
exec sp_rename 'dbo.OrganizationTypeRelationshipType', 'OrganizationTypeOrganizationRelationshipType'

--and its columns
exec sp_rename 'dbo.OrganizationTypeOrganizationRelationshipType.OrganizationTypeRelationshipTypeID', 'OrganizationTypeOrganizationRelationshipTypeID', 'COLUMN'
exec sp_rename 'dbo.OrganizationTypeOrganizationRelationshipType.RelationshipTypeID', 'OrganizationRelationshipTypeID', 'COLUMN'

--and its constraints
exec sp_rename 'dbo.OrganizationTypeOrganizationRelationshipType.PK_OrganizationTypeRelationshipType_OrganizationTypeRelationshipTypeID', 'PK_OrganizationTypeOrganizationRelationshipType_OrganizationTypeOrganizationRelationshipTypeID'
exec sp_rename 'dbo.FK_OrganizationTypeRelationshipType_OrganizationType_OrganizationTypeID', 'FK_OrganizationTypeOrganizationRelationshipType_OrganizationType_OrganizationTypeID'
exec sp_rename 'dbo.FK_OrganizationTypeRelationshipType_OrganizationType_OrganizationTypeID_TenantID', 'FK_OrganizationTypeOrganizationRelationshipType_OrganizationType_OrganizationTypeID_TenantID'
exec sp_rename 'dbo.FK_OrganizationTypeRelationshipType_RelationshipType_RelationshipTypeID', 'FK_OrganizationTypeOrganizationRelationshipType_OrganizationRelationshipType_OrganizationRelationshipTypeID'
exec sp_rename 'dbo.FK_OrganizationTypeRelationshipType_RelationshipType_RelationshipTypeID_TenantID', 'FK_OrganizationTypeOrganizationRelationshipType_OrganizationRelationshipType_OrganizationRelationshipTypeID_TenantID'
exec sp_rename 'dbo.FK_OrganizationTypeRelationshipType_Tenant_TenantID', 'FK_OrganizationTypeOrganizationRelationshipType_Tenant_TenantID'
exec sp_rename 'dbo.OrganizationTypeOrganizationRelationshipType.AK_OrganizationTypeRelationshipType_OrganizationTypeID_RelationshipTypeID_TenantID', 'AK_OrganizationTypeOrganizationRelationshipType_OrganizationTypeID_OrganizationRelationshipTypeID_TenantID'
exec sp_rename 'dbo.OrganizationTypeOrganizationRelationshipType.AK_OrganizationTypeRelationshipType_OrganizationTypeRelationshipTypeID_TenantID', 'AK_OrganizationTypeOrganizationRelationshipType_OrganizationTypeOrganizationRelationshipTypeID_TenantID'


--rename FK columns in other tables
exec sp_rename 'dbo.ProjectOrganization.RelationshipTypeID', 'OrganizationRelationshipTypeID', 'COLUMN'
exec sp_rename 'dbo.FK_ProjectOrganization_RelationshipType_RelationshipTypeID', 'FK_ProjectOrganization_OrganizationRelationshipType_OrganizationRelationshipTypeID'
exec sp_rename 'dbo.FK_ProjectOrganization_RelationshipType_RelationshipTypeID_TenantID', 'FK_ProjectOrganization_OrganizationRelationshipType_OrganizationRelationshipTypeID_TenantID'

exec sp_rename 'dbo.ProjectOrganizationUpdate.RelationshipTypeID', 'OrganizationRelationshipTypeID', 'COLUMN'
exec sp_rename 'dbo.FK_ProjectOrganizationUpdate_RelationshipType_RelationshipTypeID', 'FK_ProjectOrganizationUpdate_OrganizationRelationshipType_OrganizationRelationshipTypeID'
exec sp_rename 'dbo.FK_ProjectOrganizationUpdate_RelationshipType_RelationshipTypeID_TenantID', 'FK_ProjectOrganizationUpdate_OrganizationRelationshipType_OrganizationRelationshipTypeID_TenantID'