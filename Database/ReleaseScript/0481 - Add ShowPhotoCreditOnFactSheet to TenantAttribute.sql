alter table dbo.TenantAttribute add ShowPhotoCreditOnFactSheet bit null
go

update dbo.TenantAttribute set ShowPhotoCreditOnFactSheet = 0
go

alter table dbo.TenantAttribute alter column ShowPhotoCreditOnFactSheet bit not null