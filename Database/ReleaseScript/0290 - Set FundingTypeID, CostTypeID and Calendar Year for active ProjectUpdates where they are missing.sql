
-- Set FundingTypeID for in-progress ProjectUpdates where they are missing
update dbo.ProjectUpdate
set FundingTypeID = p.FundingTypeID
from dbo.ProjectUpdate pu
join dbo.ProjectUpdateBatch pub on pu.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
join dbo.Project p on pub.ProjectID = p.ProjectID
where pu.FundingTypeID is null and pub.ProjectUpdateStateID <> 4 and p.FundingTypeID is not null


-- Set CalendarYear and CostTypeID to reasonable defaults on ProjectFundingSourceBudgetUpdate for PSP
declare @CostTypeID int
select @CostTypeID = c.CostTypeID
from dbo.CostType c 
where CostTypeName = 'Capital'

update dbo.ProjectFundingSourceBudgetUpdate
set CalendarYear = 2019, CostTypeID = @CostTypeID
where TenantID = 11