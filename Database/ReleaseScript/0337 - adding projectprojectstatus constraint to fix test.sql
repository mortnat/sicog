alter table dbo.ProjectProjectStatus add constraint FK_ProjectProjectStatus_ProjectStatus_ProjectStatusID_TenantID foreign key (ProjectStatusID, TenantID) references dbo.ProjectStatus(ProjectStatusID, TenantID)
GO