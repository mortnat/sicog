
INSERT INTO dbo.ProjectRelevantCostTypeGroup (ProjectRelevantCostTypeGroupID, ProjectRelevantCostTypeGroupName, ProjectRelevantCostTypeGroupDisplayName) 
VALUES 
(1, 'Expenditures', 'Expenditures'),
(2, 'Budgets', 'Budgets');

-- clear existing records
delete from dbo.ProjectRelevantCostType
where TenantID = 11
delete from dbo.ProjectRelevantCostTypeUpdate
where TenantID = 11
go

-- Project Expenditures
insert into dbo.ProjectRelevantCostType
select TenantID,
	ProjectID,
	CostTypeID,
	1 ProjectRelevantCostTypeGroupID 
from dbo.ProjectFundingSourceExpenditure
where TenantID = 11
group by TenantID, ProjectID, CostTypeID

-- Project Budgets
insert into dbo.ProjectRelevantCostType
select TenantID,
	ProjectID,
	CostTypeID,
	2 ProjectRelevantCostTypeGroupID 
from dbo.ProjectFundingSourceBudget
where TenantID = 11
group by TenantID, ProjectID, CostTypeID

-- Project Update Expenditures
insert into dbo.ProjectRelevantCostTypeUpdate
select TenantID,
	ProjectUpdateBatchID,
	CostTypeID,
	1 ProjectRelevantCostTypeGroupID 
from dbo.ProjectFundingSourceExpenditureUpdate
where TenantID =11
group by TenantID, ProjectUpdateBatchID, CostTypeID

-- Project Update Budgets
insert into dbo.ProjectRelevantCostTypeUpdate
select TenantID,
	ProjectUpdateBatchID,
	CostTypeID,
	2 ProjectRelevantCostTypeGroupID 
from dbo.ProjectFundingSourceBudgetUpdate
where TenantID = 11 and CostTypeID is not null
group by TenantID, ProjectUpdateBatchID, CostTypeID


