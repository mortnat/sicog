/*
   Tuesday, June 04, 20194:30:49 PM
   User: 
   Server: (local)
   Database: ProjectFirma
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ProjectCustomAttributeTypeRole
	DROP CONSTRAINT FK_ProjectCustomAttributeTypeRole_Tenant_TenantID
GO
ALTER TABLE dbo.Tenant SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ProjectCustomAttributeTypeRole
	DROP CONSTRAINT FK_ProjectCustomAttributeTypeRole_ProjectCustomAttributeTypeRolePermissionType_ProjectCustomAttributeTypeRolePermissionTypeID
GO
ALTER TABLE dbo.ProjectCustomAttributeTypeRolePermissionType SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ProjectCustomAttributeTypeRole
	DROP CONSTRAINT FK_ProjectCustomAttributeTypeRole_Role_RoleID
GO
ALTER TABLE dbo.Role SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ProjectCustomAttributeTypeRole
	DROP CONSTRAINT FK_ProjectCustomAttributeTypeRole_ProjectCustomAttributeType_ProjectCustomAttributeTypeID
GO
ALTER TABLE dbo.ProjectCustomAttributeTypeRole
	DROP CONSTRAINT FK_ProjectCustomAttributeTypeRole_ProjectCustomAttributeType_ProjectCustomAttributeTypeID_TenantID
GO
ALTER TABLE dbo.ProjectCustomAttributeType SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_ProjectCustomAttributeTypeRole
	(
	ProjectCustomAttributeTypeRoleID int NOT NULL IDENTITY (1, 1),
	TenantID int NOT NULL,
	ProjectCustomAttributeTypeID int NOT NULL,
	RoleID int NOT NULL,
	ProjectCustomAttributeTypeRolePermissionTypeID int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_ProjectCustomAttributeTypeRole SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_ProjectCustomAttributeTypeRole ON
GO
IF EXISTS(SELECT * FROM dbo.ProjectCustomAttributeTypeRole)
	 EXEC('INSERT INTO dbo.Tmp_ProjectCustomAttributeTypeRole (ProjectCustomAttributeTypeRoleID, TenantID, ProjectCustomAttributeTypeID, RoleID, ProjectCustomAttributeTypeRolePermissionTypeID)
		SELECT ProjectCustomAttributeTypeRoleID, TenantID, ProjectCustomAttributeTypeID, RoleID, ProjectCustomAttributeTypeRolePermissionTypeID FROM dbo.ProjectCustomAttributeTypeRole WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_ProjectCustomAttributeTypeRole OFF
GO
DROP TABLE dbo.ProjectCustomAttributeTypeRole
GO
EXECUTE sp_rename N'dbo.Tmp_ProjectCustomAttributeTypeRole', N'ProjectCustomAttributeTypeRole', 'OBJECT' 
GO
ALTER TABLE dbo.ProjectCustomAttributeTypeRole ADD CONSTRAINT
	PK_ProjectCustomAttributeTypeRole_ProjectCustomAttributeTypeRoleID PRIMARY KEY CLUSTERED 
	(
	ProjectCustomAttributeTypeRoleID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ProjectCustomAttributeTypeRole ADD CONSTRAINT
	FK_ProjectCustomAttributeTypeRole_ProjectCustomAttributeType_ProjectCustomAttributeTypeID FOREIGN KEY
	(
	ProjectCustomAttributeTypeID
	) REFERENCES dbo.ProjectCustomAttributeType
	(
	ProjectCustomAttributeTypeID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ProjectCustomAttributeTypeRole ADD CONSTRAINT
	FK_ProjectCustomAttributeTypeRole_Role_RoleID FOREIGN KEY
	(
	RoleID
	) REFERENCES dbo.Role
	(
	RoleID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ProjectCustomAttributeTypeRole ADD CONSTRAINT
	FK_ProjectCustomAttributeTypeRole_ProjectCustomAttributeTypeRolePermissionType_ProjectCustomAttributeTypeRolePermissionTypeID FOREIGN KEY
	(
	ProjectCustomAttributeTypeRolePermissionTypeID
	) REFERENCES dbo.ProjectCustomAttributeTypeRolePermissionType
	(
	ProjectCustomAttributeTypeRolePermissionTypeID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ProjectCustomAttributeTypeRole ADD CONSTRAINT
	FK_ProjectCustomAttributeTypeRole_ProjectCustomAttributeType_ProjectCustomAttributeTypeID_TenantID FOREIGN KEY
	(
	ProjectCustomAttributeTypeID,
	TenantID
	) REFERENCES dbo.ProjectCustomAttributeType
	(
	ProjectCustomAttributeTypeID,
	TenantID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ProjectCustomAttributeTypeRole ADD CONSTRAINT
	FK_ProjectCustomAttributeTypeRole_Tenant_TenantID FOREIGN KEY
	(
	TenantID
	) REFERENCES dbo.Tenant
	(
	TenantID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
