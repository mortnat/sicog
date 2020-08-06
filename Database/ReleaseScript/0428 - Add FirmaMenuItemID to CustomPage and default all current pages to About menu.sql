alter table dbo.CustomPage add  FirmaMenuItemID int null
alter table dbo.CustomPage add constraint FK_CustomPage_FirmaMenuItem_FirmaMenuItemID foreign key(FirmaMenuItemID) references dbo.FirmaMenuItem(FirmaMenuItemID)
go

update dbo.CustomPage set FirmaMenuItemID = 1 -- About menu

alter table dbo.CustomPage alter column FirmaMenuItemID int not null