exec sp_rename 'AK_GeospatialArea_GeospatialAreaName_GeospatialAreaTypeID_TenantID', 'AK_GeospatialArea_TenantID_GeospatialAreaName_GeospatialAreaTypeID', 'OBJECT'
exec sp_rename 'FK_ProjectDocument_DisplayName_ProjectID', 'AK_ProjectDocument_DisplayName_ProjectID', 'OBJECT'
exec sp_rename 'FK_ProjectDocumentUpdate_DisplayName_ProjectUpdateBatchID', 'AK_ProjectDocumentUpdate_DisplayName_ProjectUpdateBatchID', 'OBJECT'
exec sp_rename 'AK_ProjectUpdateSetting_Tenant', 'AK_ProjectUpdateSetting_TenantID', 'OBJECT'
exec sp_rename 'AK_TenantAttribute_TenantDisplayName', 'AK_TenantAttribute_TenantShortDisplayName', 'OBJECT'