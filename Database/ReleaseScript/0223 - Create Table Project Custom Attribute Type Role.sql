Create Table ProjectCustomAttributeTypeRolePermissionType(
	ProjectCustomAttributeTypeRolePermissionTypeID Int not null Constraint PK_ProjectCustomAttributeTypeRolePermissionType_ProjectCustomAttributeTypeRolePermissionTypeID Primary Key,
	ProjectCustomAttributeTypeRolePermissionTypeName Varchar(20) not null
)

GO

insert into dbo.ProjectCustomAttributeTypeRolePermissionType
Values
	(1, 'Edit'),
	(2, 'View')

Create Table ProjectCustomAttributeTypeRole(
	ProjectCustomAttributeTypeRoleID Int Identity(1,1) Constraint PK_ProjectCustomAttributeTypeRole_ProjectCustomAttributeTypeRoleID Primary Key,
	ProjectCustomAttributeTypeID Int not null Constraint FK_ProjectCustomAttributeTypeRole_ProjectCustomAttributeType_ProjectCustomAttributeTypeID Foreign Key (ProjectCustomAttributeTypeID) References dbo.ProjectCustomAttributeType(ProjectCustomAttributeTypeID),
	RoleID Int Not Null Constraint FK_ProjectCustomAttributeTypeRole_Role_RoleID Foreign Key (RoleID) References dbo.Role (RoleID),
	ProjectCustomAttributeTypeRolePermissionTypeID Int Not Null Constraint FK_ProjectCustomAttributeTypeRole_ProjectCustomAttributeTypeRolePermissionType_ProjectCustomAttributeTypeRolePermissionTypeID Foreign Key (ProjectCustomAttributeTypeRolePermissionTypeID) References dbo.ProjectCustomAttributeTypeRolePermissionType (ProjectCustomAttributeTypeRolePermissionTypeID)
)