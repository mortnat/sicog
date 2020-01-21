
-- Add feature flags and enable for PSP only
alter table dbo.Tenant
add AreOrganizationsExternallySourced bit

alter table dbo.Tenant
add AreFundingSourcesExternallySourced bit
go

update dbo.Tenant
set AreOrganizationsExternallySourced = 1
where TenantID = 11

update dbo.Tenant
set AreOrganizationsExternallySourced = 0
where TenantID <> 11

update dbo.Tenant
set AreFundingSourcesExternallySourced = 1
where TenantID = 11

update dbo.Tenant
set AreFundingSourcesExternallySourced = 0
where TenantID <> 11

alter table dbo.Tenant
alter column AreOrganizationsExternallySourced bit not null

alter table dbo.Tenant
alter column AreFundingSourcesExternallySourced bit not null
