-- Add fields
alter table dbo.ProjectFundingSourceExpenditure
add CostTypeID int null constraint FK_ProjectFundingSourceExpenditure_CostType_CostTypeID foreign key references dbo.CostType(CostTypeID)

alter table dbo.ProjectFundingSourceExpenditureUpdate
add CostTypeID int null constraint FK_ProjectFundingSourceExpenditureUpdate_CostType_CostTypeID foreign key references dbo.CostType(CostTypeID)

-- Update unique constraints
alter table dbo.ProjectFundingSourceExpenditure
drop constraint AK_ProjectFundingSourceExpenditure_ProjectID_FundingSourceID_CalendarYear
go

alter table dbo.ProjectFundingSourceExpenditure
add constraint AK_ProjectFundingSourceExpenditure_ProjectID_FundingSourceID_CostTypeID_CalendarYear unique(ProjectID, FundingSourceID, CostTypeID, CalendarYear)
go 

alter table dbo.ProjectFundingSourceExpenditureUpdate
drop constraint AK_ProjectFundingSourceExpenditureUpdate_ProjectUpdateBatchID_FundingSourceID_CalendarYear
go

alter table dbo.ProjectFundingSourceExpenditureUpdate
add constraint AK_ProjectFundingSourceExpenditureUpdate_ProjectUpdateBatchID_FundingSourceID_CostTypeID_CalendarYear unique(ProjectUpdateBatchID, FundingSourceID, CostTypeID, CalendarYear)
go