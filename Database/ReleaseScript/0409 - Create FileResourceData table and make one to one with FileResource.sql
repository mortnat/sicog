create table dbo.FileResourceData (
	FileResourceDataID int IDENTITY(1,1) not null constraint PK_FileResourceData_FileResourceDataID primary key,
	TenantID int not null constraint FK_FileResourceData_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	FileResourceID int not null constraint FK_FileResourceData_FileResource_FileResourceID foreign key references dbo.FileResource(FileResourceID),
	Data varbinary(max) not null,
	
	constraint FK_FileResourceData_FileResource_FileResourceID_TenantID foreign key (FileResourceID, TenantID) references dbo.FileResource(FileResourceID, TenantID),

	constraint AK_FileResourceData_FileResourceDataID_TenantID unique (FileResourceDataID, TenantID),
	constraint AK_FileResourceData_FileResourceDataID_FileResourceID unique (FileResourceDataID, FileResourceID)
)

insert into dbo.FileResourceData (TenantID, FileResourceID, Data )
select TenantID, FileResourceID, FileResourceData from dbo.FileResource

alter table dbo.FileResource drop column FileResourceData
