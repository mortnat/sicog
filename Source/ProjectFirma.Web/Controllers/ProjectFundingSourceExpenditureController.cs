﻿/*-----------------------------------------------------------------------
<copyright file="ProjectFundingSourceExpenditureController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.ProjectFundingSourceExpenditure;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectFundingSourceExpenditureController : FirmaBaseController
    {
        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult EditProjectFundingSourceExpendituresForProject(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectFundingSourceExpenditures = project.ProjectFundingSourceExpenditures.ToList();
            var calendarYearRange = projectFundingSourceExpenditures.CalculateCalendarYearRangeForExpenditures(project);
            var projectExemptReportingYears = project.GetExpendituresExemptReportingYears().Select(x => new ProjectExemptReportingYearSimple(x)).ToList();
            var currentExemptedYears = projectExemptReportingYears.Select(x => x.CalendarYear).ToList();
            projectExemptReportingYears.AddRange(calendarYearRange.Where(x => !currentExemptedYears.Contains(x)).Select((x, index) => new ProjectExemptReportingYearSimple(-(index + 1), project.ProjectID, x)));
            var calendarYearRangeForExpenditures = projectFundingSourceExpenditures.CalculateCalendarYearRangeForExpenditures(project);
            var projectFundingSourceExpenditureBulks = ProjectFundingSourceExpenditureBulk.MakeFromList(projectFundingSourceExpenditures, calendarYearRangeForExpenditures);
            var viewModel = new EditProjectFundingSourceExpendituresViewModel(project, projectFundingSourceExpenditureBulks, projectExemptReportingYears);
            return ViewEditProjectFundingSourceExpenditures(project, viewModel, calendarYearRangeForExpenditures);
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProjectFundingSourceExpendituresForProject(ProjectPrimaryKey projectPrimaryKey, EditProjectFundingSourceExpendituresViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var currentProjectFundingSourceExpenditures = project.ProjectFundingSourceExpenditures.ToList();
            if (!ModelState.IsValid)
            {
                var calendarYearRangeForExpenditures = currentProjectFundingSourceExpenditures.CalculateCalendarYearRangeForExpenditures(project);
                return ViewEditProjectFundingSourceExpenditures(project, viewModel, calendarYearRangeForExpenditures);
            }

            return UpdateProjectFundingSourceExpenditures(viewModel, currentProjectFundingSourceExpenditures, project);
        }

        private static ActionResult UpdateProjectFundingSourceExpenditures(
            EditProjectFundingSourceExpendituresViewModel viewModel,
            List<ProjectFundingSourceExpenditure> currentProjectFundingSourceExpenditures, Project project)
        {
            HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditures.Load();
            var allProjectFundingSourceExpenditures = HttpRequestStorage.DatabaseEntities.AllProjectFundingSourceExpenditures.Local;
            viewModel.UpdateModel(currentProjectFundingSourceExpenditures, allProjectFundingSourceExpenditures, project);

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditProjectFundingSourceExpenditures(Project project, EditProjectFundingSourceExpendituresViewModel viewModel, List<int> calendarYearRangeForExpenditures)
        {
            var allFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.ToList().Select(x => new FundingSourceSimple(x)).OrderBy(p => p.DisplayName).ToList();
            var showNoExpendituresExplanation = project.GetExpendituresExemptReportingYears().Any();
            var viewData = new EditProjectFundingSourceExpendituresViewData(new ProjectSimple(project), allFundingSources, calendarYearRangeForExpenditures, showNoExpendituresExplanation);
            return RazorPartialView<EditProjectFundingSourceExpenditures, EditProjectFundingSourceExpendituresViewData, EditProjectFundingSourceExpendituresViewModel>(viewData, viewModel);
        }

//        [HttpGet]
//        [ProjectEditAsAdminFeature]
//        public PartialViewResult EditProjectFundingSourceExpendituresByCostTypeForProject(ProjectPrimaryKey projectPrimaryKey)
//        {
//            var project = projectPrimaryKey.EntityObject;
//            var costTypeSimples = HttpRequestStorage.DatabaseEntities.CostTypes.OrderBy(x => x.CostTypeName).ToList().Select(x => new CostTypeSimple(x)).ToList();
//
//            var projectFundingSourceExpendituresByCostTypeBulks = ProjectFundingSourceExpenditureBulk.MakeFromProject(project, costTypeSimples);
//
//            var calendarYearRange = project.GetProjectYearRangeForExpenditures();
//            var projectExemptReportingYears = project.GetExpendituresExemptReportingYears().Select(x => new ProjectExemptReportingYearSimple(x)).ToList();
//            var currentExemptedYears = projectExemptReportingYears.Select(x => x.CalendarYear).ToList();
//            projectExemptReportingYears.AddRange(calendarYearRange.Where(x => !currentExemptedYears.Contains(x)).Select((x, index) => new ProjectExemptReportingYearSimple(-(index + 1), project.ProjectID, x)));
//            var viewModel = new EditProjectFundingSourceExpendituresByCostTypeViewModel(project, projectFundingSourceExpendituresByCostTypeBulks, projectExemptReportingYears, costTypeSimples);
//            return ViewEditProjectFundingSourceExpendituresByCostType(project, viewModel);
//        }
//
//        [HttpPost]
//        [ProjectEditAsAdminFeature]
//        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
//        public ActionResult EditProjectFundingSourceExpendituresByCostTypeForProject(ProjectPrimaryKey projectPrimaryKey, EditProjectFundingSourceExpendituresByCostTypeViewModel viewModel)
//        {
//            var project = projectPrimaryKey.EntityObject;
//            var currentProjectFundingSourceExpendituresByCostType = project.ProjectFundingSourceExpenditureByCostTypes.ToList();
//            if (!ModelState.IsValid)
//            {
//                return ViewEditProjectFundingSourceExpendituresByCostType(project, viewModel);
//            }
//            return UpdateProjectFundingSourceExpenditures(viewModel, currentProjectFundingSourceExpendituresByCostType, project);
//        }
//
//        private static ActionResult UpdateProjectFundingSourceExpenditures(
//            EditProjectFundingSourceExpendituresByCostTypeViewModel viewModel,
//            List<ProjectFundingSourceExpenditureByCostType> currentProjectFundingSourceExpendituresByCostType, Project project)
//        {
//            HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditureByCostTypes.Load();
//            var allProjectFundingSourceExpendituresByCostType = HttpRequestStorage.DatabaseEntities.AllProjectFundingSourceExpenditureByCostTypes.Local;
//            viewModel.UpdateModel(currentProjectFundingSourceExpendituresByCostType, allProjectFundingSourceExpendituresByCostType, project);
//            return new ModalDialogFormJsonResult();
//        }
//
//        private PartialViewResult ViewEditProjectFundingSourceExpendituresByCostType(Project project, EditProjectFundingSourceExpendituresByCostTypeViewModel viewModel)
//        {
//            var allFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.ToList().Select(x => new FundingSourceSimple(x)).OrderBy(p => p.DisplayName).ToList();
//            var calendarYearRange = project.GetProjectYearRangeForExpenditures();
//            var showNoExpendituresExplanation = project.GetExpendituresExemptReportingYears().Any();
//            var viewData = new EditProjectFundingSourceExpendituresByCostTypeViewData(new ProjectSimple(project), allFundingSources, calendarYearRange, showNoExpendituresExplanation);
//            return RazorPartialView<EditProjectFundingSourceExpendituresByCostType, EditProjectFundingSourceExpendituresByCostTypeViewData, EditProjectFundingSourceExpendituresByCostTypeViewModel>(viewData, viewModel);
//        }
    }
}
