
INSERT INTO dbo.FirmaPageType (FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
VALUES (54, 'FactSheetCustomText', 'Fact Sheet CustomText', 2);



INSERT INTO dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
VALUES (6, 54, NULL);



