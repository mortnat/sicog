
insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(57, 'TechnicalAssistanceInstructions', 'Technical Assistance Instructions', 1)
go 

insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
values
(9, 57, '<p>Editable instructions block for Technical Assistance entry form.</p>')


