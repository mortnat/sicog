
INSERT INTO dbo.FirmaPageType (FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
VALUES (54, 'FactSheet', 'Fact Sheet', 2);



INSERT INTO dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
VALUES (6, 54, NULL);



