CREATE TABLE dbo.PerformanceMeasureExpectedUpdate(
	PerformanceMeasureExpectedUpdateID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_PerformanceMeasureExpectedUpdate_PerformanceMeasureExpectedUpdateID PRIMARY KEY,
	TenantID int NOT NULL CONSTRAINT FK_PerformanceMeasureExpectedUpdate_Tenant_TenantID FOREIGN KEY REFERENCES dbo.Tenant (TenantID),
	ProjectUpdateBatchID int NOT NULL CONSTRAINT FK_PerformanceMeasureExpectedUpdate_ProjectUpdateBatch_ProjectUpdateBatchID FOREIGN KEY REFERENCES dbo.ProjectUpdateBatch (ProjectUpdateBatchID),
	PerformanceMeasureID int NOT NULL CONSTRAINT FK_PerformanceMeasureExpectedUpdate_PerformanceMeasure_PerformanceMeasureID FOREIGN KEY REFERENCES dbo.PerformanceMeasure (PerformanceMeasureID),
	ExpectedValue float NULL,
	CONSTRAINT AK_PerformanceMeasureExpectedUpdate_PerformanceMeasureExpectedUpdateID_PerformanceMeasureID UNIQUE (PerformanceMeasureExpectedUpdateID, PerformanceMeasureID),
	CONSTRAINT AK_PerformanceMeasureExpectedUpdate_PerformanceMeasureExpectedUpdateID_TenantID UNIQUE (PerformanceMeasureExpectedUpdateID, TenantID),
	CONSTRAINT FK_PerformanceMeasureExpectedUpdate_PerformanceMeasure_PerformanceMeasureID_TenantID FOREIGN KEY(PerformanceMeasureID, TenantID) REFERENCES dbo.PerformanceMeasure (PerformanceMeasureID, TenantID),
	CONSTRAINT FK_PerformanceMeasureExpectedUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID FOREIGN KEY(ProjectUpdateBatchID, TenantID) REFERENCES dbo.ProjectUpdateBatch (ProjectUpdateBatchID, TenantID)
)

CREATE TABLE dbo.PerformanceMeasureExpectedSubcategoryOptionUpdate(
	PerformanceMeasureExpectedSubcategoryOptionUpdateID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasureExpectedSubcategoryOptionUpdateID PRIMARY KEY,
	TenantID int NOT NULL CONSTRAINT FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_Tenant_TenantID FOREIGN KEY REFERENCES dbo.Tenant (TenantID),
	PerformanceMeasureExpectedUpdateID int NOT NULL CONSTRAINT FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasureExpectedUpdate_PerformanceMeasureExpectedUpdateID FOREIGN KEY REFERENCES dbo.PerformanceMeasureExpectedUpdate (PerformanceMeasureExpectedUpdateID),
	PerformanceMeasureSubcategoryOptionID int NOT NULL CONSTRAINT FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID FOREIGN KEY REFERENCES dbo.PerformanceMeasureSubcategoryOption (PerformanceMeasureSubcategoryOptionID),
	PerformanceMeasureID int NOT NULL CONSTRAINT FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasure_PerformanceMeasureID FOREIGN KEY REFERENCES dbo.PerformanceMeasure (PerformanceMeasureID),
	PerformanceMeasureSubcategoryID int NOT NULL CONSTRAINT FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID FOREIGN KEY REFERENCES dbo.PerformanceMeasureSubcategory (PerformanceMeasureSubcategoryID),
	CONSTRAINT FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasure_PerformanceMeasureID_TenantID FOREIGN KEY(PerformanceMeasureID, TenantID) REFERENCES dbo.PerformanceMeasure (PerformanceMeasureID, TenantID),
	CONSTRAINT FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasureExpectedUpdate_PerformanceMeasureExpectedUpdateID_Perform FOREIGN KEY(PerformanceMeasureExpectedUpdateID, PerformanceMeasureID) REFERENCES dbo.PerformanceMeasureExpectedUpdate (PerformanceMeasureExpectedUpdateID, PerformanceMeasureID),
	CONSTRAINT FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasureExpectedUpdate_PerformanceMeasureExpectedUpdateID_TenantI FOREIGN KEY(PerformanceMeasureExpectedUpdateID, TenantID) REFERENCES dbo.PerformanceMeasureExpectedUpdate (PerformanceMeasureExpectedUpdateID, TenantID),
	CONSTRAINT FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID_TenantID FOREIGN KEY(PerformanceMeasureSubcategoryID, TenantID) REFERENCES dbo.PerformanceMeasureSubcategory (PerformanceMeasureSubcategoryID, TenantID),
	CONSTRAINT FK_PerformanceMeasureExpectedSubcategoryOptionUpdate_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID_T FOREIGN KEY(PerformanceMeasureSubcategoryOptionID, TenantID) REFERENCES dbo.PerformanceMeasureSubcategoryOption (PerformanceMeasureSubcategoryOptionID, TenantID)
)

alter table dbo.ProjectUpdateBatch add ExpectedPerformanceMeasuresComment varchar(1000) null

exec sp_rename 'dbo.ProjectUpdateBatch.PerformanceMeasuresComment', 'ReportedPerformanceMeasuresComment', 'column'