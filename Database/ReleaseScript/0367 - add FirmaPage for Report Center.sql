--begin tran

INSERT INTO dbo.FirmaPageType (FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values (73, 'ReportCenter', 'Report Center' , 1)

INSERT INTO dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
select 
    TenantID,
    73,
    '<p>This page is used to create and edit reports that have attached Word Document (.docx) templates.</p>'
from Tenant

--rollback tran