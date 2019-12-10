﻿using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class PerformanceMeasureReportingPeriodModelExtensions
    {
        public static PerformanceMeasureReportingPeriod GetOrCreatePerformanceMeasureReportingPeriod(this IQueryable<PerformanceMeasureReportingPeriod> performanceMeasureReportingPeriods, int calendarYear)
        {
            var performanceMeasureReportingPeriod = performanceMeasureReportingPeriods.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodCalendarYear == calendarYear);

            return performanceMeasureReportingPeriod ?? new PerformanceMeasureReportingPeriod(calendarYear, calendarYear.ToString());
        }

        public static double? GetTargetValue(this PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod, PerformanceMeasure performanceMeasure)
        {
            var overallTarget = performanceMeasure.PerformanceMeasureOverallTargets.FirstOrDefault();
            if (overallTarget != null)
            {
                return overallTarget.PerformanceMeasureTargetValue;
            }
            return performanceMeasure.PerformanceMeasureReportingPeriodTargets.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodID == performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodID)?.PerformanceMeasureTargetValue;
        }

        public static double? GetGeospatialAreaTargetValue(this PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod, PerformanceMeasure performanceMeasure, GeospatialArea geospatialArea)
        {
            var overallTarget = performanceMeasure.GeospatialAreaPerformanceMeasureOverallTargets.FirstOrDefault(x =>
                x.GeospatialAreaID == geospatialArea.GeospatialAreaID);
            if (overallTarget != null)
            {
                return overallTarget.GeospatialAreaPerformanceMeasureTargetValue;
            }
            return performanceMeasure.GeospatialAreaPerformanceMeasureReportingPeriodTargets.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodID == performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodID && x.GeospatialAreaID == geospatialArea.GeospatialAreaID)?.GeospatialAreaPerformanceMeasureTargetValue;
        }

        public static string GetTargetValueLabel(this PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod, PerformanceMeasure performanceMeasure)
        {
            var overallTarget = performanceMeasure.PerformanceMeasureOverallTargets.FirstOrDefault();
            if (overallTarget != null)
            {
                return overallTarget.PerformanceMeasureTargetValueLabel;
            }
            return performanceMeasure.PerformanceMeasureReportingPeriodTargets.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodID == performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodID)?.PerformanceMeasureTargetValueLabel;
        }

        public static string GetGeospatialAreaTargetValueLabel(this PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod, PerformanceMeasure performanceMeasure, GeospatialArea geospatialArea)
        {
            var overallTarget = performanceMeasure.GeospatialAreaPerformanceMeasureOverallTargets.FirstOrDefault(x =>
                x.GeospatialAreaID == geospatialArea.GeospatialAreaID);
            if (overallTarget != null)
            {
                return overallTarget.GeospatialAreaPerformanceMeasureTargetValueLabel;
            }
            return performanceMeasure.GeospatialAreaPerformanceMeasureReportingPeriodTargets.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodID == performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodID && x.GeospatialAreaID == geospatialArea.GeospatialAreaID)?.GeospatialAreaPerformanceMeasureTargetValueLabel;
        }
    }
}