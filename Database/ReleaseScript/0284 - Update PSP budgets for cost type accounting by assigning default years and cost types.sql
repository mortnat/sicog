
update dbo.ProjectFundingSourceBudget
set CalendarYear = 2019
where TenantID = 11 and CostTypeID is null
go

declare @CostTypeID int
select @CostTypeID = c.CostTypeID
from dbo.CostType c 
where CostTypeName = 'Capital'

update dbo.ProjectFundingSourceBudget
set CostTypeID = @CostTypeID
where TenantID = 11 and CostTypeID is null



