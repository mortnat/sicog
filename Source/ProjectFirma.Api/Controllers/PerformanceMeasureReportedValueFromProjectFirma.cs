﻿using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Controllers
{
    public class PerformanceMeasureReportedValueFromProjectFirma
    {
        public int CalendarYear { get; set; }

        public double? ReportedValue { get; set; }

        public int PerformanceMeasureID { get; set; }

        public string PerformanceMeasureName { get; set; }
        public string ProjectStage { get; set; }

        public string ProjectName { get; set; }
        public string ProjectDetailUrl { get; set; }
        public string LeadImplementer { get; set; }
        public string MeasurementUnitType { get; set; }

        public List<PerformanceMeasureSubcategoryOptionFromProjectFirma> PerformanceMeasureSubcategoryOptions { get; set; }

        public string PerformanceMeasureSubcategoriesAsString { get; set; }

        public PerformanceMeasureReportedValueFromProjectFirma()
        {
        }

        public PerformanceMeasureReportedValueFromProjectFirma(PerformanceMeasureReportedValue performanceMeasureReportedValue)
        {
            PerformanceMeasureID = performanceMeasureReportedValue.PerformanceMeasureID;
            PerformanceMeasureName = performanceMeasureReportedValue.PerformanceMeasure.PerformanceMeasureDisplayName;
            CalendarYear = performanceMeasureReportedValue.CalendarYear;
            ReportedValue = performanceMeasureReportedValue.ReportedValue;
            MeasurementUnitType = performanceMeasureReportedValue.PerformanceMeasure.MeasurementUnitType.MeasurementUnitTypeDisplayName;
            //todo: 11/4/2019 TK -- find a way to get a project!
            //ProjectStage = performanceMeasureReportedValue.Project.ProjectStage.ProjectStageDisplayName;
            //LeadImplementer = performanceMeasureReportedValue.Project.GetPrimaryContactOrganization()?.OrganizationShortName;
            //ProjectName = performanceMeasureReportedValue.Project.GetDisplayName();
            //ProjectDetailUrl = $"/Project/Detail/{performanceMeasureReportedValue.Project.ProjectID}";
            PerformanceMeasureSubcategoryOptions = performanceMeasureReportedValue
                .PerformanceMeasureReportedValueSubcategoryOptions.Select(x => new PerformanceMeasureSubcategoryOptionFromProjectFirma(x))
                .ToList();
            PerformanceMeasureSubcategoriesAsString = performanceMeasureReportedValue.GetPerformanceMeasureSubcategoriesAsString();
        }
    }
}