﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class BasicsViewData : ProjectUpdateViewData
    {
        public readonly IEnumerable<SelectListItem> PlanningDesignStartYearRange;
        public readonly IEnumerable<SelectListItem> ImplementationStartYearRange;
        public readonly IEnumerable<SelectListItem> CompletionYearRange;
        public readonly IEnumerable<SelectListItem> ProjectStages;
        public readonly string ActionPriorityDisplayName;
        public readonly string RefreshUrl;
        public readonly string DiffUrl;
        public readonly Models.ProjectUpdate ProjectUpdate;
        public readonly SectionCommentsViewData SectionCommentsViewData;
        // ReSharper disable once InconsistentNaming
        public readonly ViewDataForAngularClass ViewDataForAngular;

        public readonly decimal InflationRate;
        public readonly decimal? CapitalCostInYearOfExpenditure;
        public readonly decimal? TotalOperatingCostInYearOfExpenditure;
        public readonly int? StartYearForTotalOperatingCostCalculation;

        public BasicsViewData(Person currentPerson, Models.ProjectUpdate projectUpdate, IEnumerable<ProjectStage> projectStages, ViewDataForAngularClass viewDataForAngular, decimal inflationRate, UpdateStatus updateStatus)
            : base(currentPerson, projectUpdate.ProjectUpdateBatch, ProjectUpdateSectionEnum.Basics, updateStatus)
        {
            ProjectUpdate = projectUpdate;
            ActionPriorityDisplayName = projectUpdate.ProjectUpdateBatch.Project.ActionPriority.DisplayName;
            ProjectStages = projectStages.OrderBy(x => x.SortOrder).ToSelectListWithEmptyFirstRow(x => x.ProjectStageID.ToString(CultureInfo.InvariantCulture), y => y.ProjectStageDisplayName);
            PlanningDesignStartYearRange = FirmaDateUtilities.YearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.ToString(CultureInfo.InvariantCulture));
            ImplementationStartYearRange = FirmaDateUtilities.YearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.ToString(CultureInfo.InvariantCulture));
            CompletionYearRange = FirmaDateUtilities.YearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.ToString(CultureInfo.InvariantCulture));
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshBasics(Project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffBasics(Project));
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdate.ProjectUpdateBatch.BasicsComment, projectUpdate.ProjectUpdateBatch.IsReturned);            
            ViewDataForAngular = viewDataForAngular;

            InflationRate = inflationRate;
            CapitalCostInYearOfExpenditure = Models.CostParameterSet.CalculateCapitalCostInYearOfExpenditure(projectUpdate);
            TotalOperatingCostInYearOfExpenditure = Models.CostParameterSet.CalculateTotalRemainingOperatingCost(projectUpdate);
            StartYearForTotalOperatingCostCalculation = Models.CostParameterSet.StartYearForTotalCostCalculations(projectUpdate);
        }

        public class ViewDataForAngularClass
        {
            public readonly List<string> ValidationWarnings;

            public ViewDataForAngularClass(List<string> validationWarnings)
            {
                ValidationWarnings = validationWarnings;
            }
        }
    }
}