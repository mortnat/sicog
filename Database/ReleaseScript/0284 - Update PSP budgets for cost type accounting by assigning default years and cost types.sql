
update dbo.ProjectFundingSourceBudget
set CalendarYear = 2019
where TenantID = 11 and CostTypeID is null
go

update dbo.ProjectFundingSourceBudget
set CostTypeID = 1
where TenantID = 11 and CostTypeID is null



