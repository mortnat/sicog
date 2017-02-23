﻿/*-----------------------------------------------------------------------
<copyright file="TestProjectBudget.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProjectBudget
        {
            public static ProjectBudget Create()
            {
                var project = TestProject.Create();
                var fundingSource = TestFundingSource.Create();
                return Create(project, fundingSource);
            }

            public static ProjectBudget Create(Project project, FundingSource fundingSource)
            {
                var projectBudget = ProjectBudget.CreateNewBlank(project, fundingSource, ProjectCostType.Construction);
                return projectBudget;
            }

            public static ProjectBudget Create(Project project, FundingSource fundingSource, int calendarYear)
            {
                var projectBudget = Create(project, fundingSource);
                projectBudget.CalendarYear = calendarYear;
                return projectBudget;
            }

            public static ProjectBudget Create(Project project, FundingSource fundingSource, int calendarYear, decimal expenditureAmount)
            {
                var projectBudget = Create(project, fundingSource, calendarYear);
                projectBudget.BudgetedAmount = expenditureAmount;
                return projectBudget;
            }
        }
    }
}
