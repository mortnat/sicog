update dbo.FirmaPageType set FirmaPageRenderTypeID = 1 where FirmaPageTypeName = 'FundingStatusHeader' or FirmaPageTypeName = 'FundingStatusFooter';


insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
select t.TenantID, 62, null
from dbo.Tenant t where TenantID != 11;

insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
select t.TenantID, 63, null
from dbo.Tenant t where TenantID != 11;