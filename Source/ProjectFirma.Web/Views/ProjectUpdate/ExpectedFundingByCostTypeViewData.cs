﻿/*-----------------------------------------------------------------------
<copyright file="ExpectedFundingViewData.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/

using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ExpectedFundingByCostTypeViewData : ProjectUpdateViewData
    {
        public string RefreshUrl { get; }
        public string DiffUrl { get; }
        public string RequestFundingSourceUrl { get; }
        public ViewDataForAngularClass ViewDataForAngular { get; }
        public ProjectBudgetSummaryViewData ProjectBudgetSummaryViewData { get; }
        public ProjectBudgetsAnnualByCostTypeViewData ProjectBudgetsAnnualByCostTypeViewData { get; }
        public SectionCommentsViewData SectionCommentsViewData { get; }

        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForProject { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForFundingSource { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForCostType { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForNoFundingSourceIdentified { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForSecuredFunding { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForTargetedFunding { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForPlanningDesignStartYear { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForCompletionYear { get; }

        public ExpectedFundingByCostTypeViewData(Person currentPerson,
            ProjectUpdateBatch projectUpdateBatch,
            ViewDataForAngularClass viewDataForAngularClass,
            ProjectBudgetSummaryViewData projectBudgetSummaryViewData,
            ProjectBudgetsAnnualByCostTypeViewData projectBudgetsAnnualByCostTypeViewData,
            ProjectUpdateStatus projectUpdateStatus,
            ExpectedFundingValidationResult expectedFundingValidationResult
        ) : base(currentPerson, projectUpdateBatch, projectUpdateStatus, expectedFundingValidationResult.GetWarningMessages(), ProjectUpdateSection.Budget.ProjectUpdateSectionDisplayName)
        {
            RequestFundingSourceUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.MissingFundingSource());
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshExpectedFunding(projectUpdateBatch.Project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffExpectedFunding(projectUpdateBatch.Project));
            ViewDataForAngular = viewDataForAngularClass;
            ProjectBudgetSummaryViewData = projectBudgetSummaryViewData;
            ProjectBudgetsAnnualByCostTypeViewData = projectBudgetsAnnualByCostTypeViewData;
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdateBatch.ExpectedFundingComment, projectUpdateBatch.IsReturned());


            FieldDefinitionForProject = FieldDefinitionEnum.Project.ToType();
            FieldDefinitionForFundingSource = FieldDefinitionEnum.FundingSource.ToType();
            FieldDefinitionForCostType = FieldDefinitionEnum.CostType.ToType();
            FieldDefinitionForNoFundingSourceIdentified = FieldDefinitionEnum.NoFundingSourceIdentified.ToType();
            FieldDefinitionForSecuredFunding = FieldDefinitionEnum.SecuredFunding.ToType();
            FieldDefinitionForTargetedFunding = FieldDefinitionEnum.TargetedFunding.ToType();
            FieldDefinitionForPlanningDesignStartYear = FieldDefinitionEnum.PlanningDesignStartYear.ToType();
            FieldDefinitionForCompletionYear = FieldDefinitionEnum.CompletionYear.ToType();
        }

        public class ViewDataForAngularClass
        {
            public List<int> RequiredCalendarYearRange { get; }
            public List<FundingSourceSimple> AllFundingSources { get; }
            public List<CostTypeSimple> AllCostTypes { get; }
            // Actually a ProjectUpdateID
            public int ProjectUpdateBatchID { get; }
            public int MaxYear { get; }

            public IEnumerable<SelectListItem> FundingTypes { get; }

            public ViewDataForAngularClass(ProjectUpdateBatch projectUpdateBatch,
                List<FundingSourceSimple> allFundingSources,
                List<CostTypeSimple> allCostTypes,
                List<int> requiredCalendarYearRange,
                IEnumerable<SelectListItem> fundingTypes)
            {
                RequiredCalendarYearRange = requiredCalendarYearRange;
                AllFundingSources = allFundingSources;
                AllCostTypes = allCostTypes;
                ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
                FundingTypes = fundingTypes;
                MaxYear = FirmaDateUtilities.CalculateCurrentYearToUseForUpToAllowableInputInReporting();
            }
        }
    }
}