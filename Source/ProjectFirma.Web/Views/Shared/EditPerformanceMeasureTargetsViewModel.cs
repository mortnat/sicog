﻿/*-----------------------------------------------------------------------
<copyright file="EditPerformanceMeasureTargetsViewModel.cs" company="Tahoe Regional Planning Agency">
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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common.Models;
using MoreLinq;
using Newtonsoft.Json.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.PerformanceMeasure;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared
{
    public class EditPerformanceMeasureTargetsViewModel : FormViewModel, IValidatableObject
    {
        public List<PerformanceMeasureReportingPeriodSimple> PerformanceMeasureReportingPeriodSimples { get; set; }

        [Required]
        public int PerformanceMeasureTargetValueTypeID { get; set; }
        public double? OverallTargetValue { get; set; }
        public string OverallTargetValueLabel { get; set; }

        public HashSet<string> PerformanceMeasureReportedsWithValidationErrors { get; private set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditPerformanceMeasureTargetsViewModel()
        {
        }

        public EditPerformanceMeasureTargetsViewModel(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureReportingPeriodSimples = PerformanceMeasureReportingPeriodSimple.MakeFromList(performanceMeasure.PerformanceMeasureReportingPeriodTargets, performanceMeasure.PerformanceMeasureActuals);
            PerformanceMeasureTargetValueTypeID = performanceMeasure.GetTargetValueType().PerformanceMeasureTargetValueTypeID;
            if (performanceMeasure.GetTargetValueType() ==
                PerformanceMeasureTargetValueType.OverallTarget)
            {
                var overallTarget = performanceMeasure.PerformanceMeasureOverallTargets.First();
                OverallTargetValue = overallTarget.PerformanceMeasureTargetValue;
                OverallTargetValueLabel = overallTarget.PerformanceMeasureTargetValueLabel;
            }
        }

        public EditPerformanceMeasureTargetsViewModel(ProjectFirmaModels.Models.GeospatialArea geospatialArea, ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureReportingPeriodSimples = PerformanceMeasureReportingPeriodSimple.MakeFromList(performanceMeasure.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Where(x => x.GeospatialAreaID == geospatialArea.GeospatialAreaID), performanceMeasure.PerformanceMeasureActuals);
            PerformanceMeasureTargetValueTypeID = performanceMeasure.GetGeospatialAreaTargetValueType(geospatialArea).PerformanceMeasureTargetValueTypeID;

            if (performanceMeasure.GetGeospatialAreaTargetValueType(geospatialArea) ==
                PerformanceMeasureTargetValueType.OverallTarget)
            {
                var overallTarget = performanceMeasure.GeospatialAreaPerformanceMeasureOverallTargets.First(x => x.GeospatialAreaID == geospatialArea.GeospatialAreaID);
                OverallTargetValue = overallTarget.GeospatialAreaPerformanceMeasureTargetValue;
                OverallTargetValueLabel = overallTarget.GeospatialAreaPerformanceMeasureTargetValueLabel;
            }
        }


        public void DeleteOtherPerformanceMeasureTargetValueTypes(
            ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure,
            PerformanceMeasureTargetValueTypeEnum performanceMeasureTargetValueTypeEnum)
        {
            
            if (performanceMeasureTargetValueTypeEnum != PerformanceMeasureTargetValueTypeEnum.OverallTarget)
            {
                var overallTargetsToDelete = performanceMeasure.PerformanceMeasureOverallTargets.ToList();
                overallTargetsToDelete.ForEach(oa => oa.DeleteFull(HttpRequestStorage.DatabaseEntities));
            }

            if (performanceMeasureTargetValueTypeEnum != PerformanceMeasureTargetValueTypeEnum.TargetPerYear)
            {
                var reportingPeriodTargetsToDelete = performanceMeasure.PerformanceMeasureReportingPeriodTargets.ToList();
                reportingPeriodTargetsToDelete.ForEach(oa => oa.DeleteFull(HttpRequestStorage.DatabaseEntities));
            }
        }

        public void UpdateModel(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, 
                                ICollection<PerformanceMeasureReportingPeriod> allPerformanceMeasureReportingPeriods, 
                                ICollection<PerformanceMeasureReportingPeriodTarget> allPerformanceMeasureReportingPeriodTargets)
        {
            var performanceMeasureTargetValueTypeEnum = PerformanceMeasureTargetValueType.AllLookupDictionary[PerformanceMeasureTargetValueTypeID].ToEnum;
            DeleteOtherPerformanceMeasureTargetValueTypes(performanceMeasure, performanceMeasureTargetValueTypeEnum);

            switch (performanceMeasureTargetValueTypeEnum)
            {
                case PerformanceMeasureTargetValueTypeEnum.NoTarget:
                    // Nothing to do here, there are no "No Targets" to be saved in this case. But we still need this so that the ArgumentOutOfRange validation works
                    break;

                case PerformanceMeasureTargetValueTypeEnum.OverallTarget:
                    var overallTarget = PerformanceMeasureOverallTargetModelExtensions.GetOrCreatePerformanceMeasureOverallTarget(performanceMeasure, OverallTargetValue.Value);
                    overallTarget.PerformanceMeasureTargetValueLabel = OverallTargetValueLabel;
                    overallTarget.PerformanceMeasureTargetValue = OverallTargetValue;
                    break;

                case PerformanceMeasureTargetValueTypeEnum.TargetPerYear:
                    foreach (var pmrpSimple in PerformanceMeasureReportingPeriodSimples)
                    {
                        // Reporting Period
                        // ----------------
                        var reportingPeriod = allPerformanceMeasureReportingPeriods.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodCalendarYear == pmrpSimple.PerformanceMeasureReportingPeriodCalendarYear);
                        if (reportingPeriod == null)
                        {
                            reportingPeriod = new PerformanceMeasureReportingPeriod(pmrpSimple.PerformanceMeasureReportingPeriodCalendarYear,
                                                                                    pmrpSimple.PerformanceMeasureReportingPeriodLabel);
                        }
                        var performanceMeasureTarget = allPerformanceMeasureReportingPeriodTargets.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodTargetID == pmrpSimple.PerformanceMeasureReportingPeriodTargetID);
                        if (performanceMeasureTarget == null)
                        {
                            // ReSharper disable once RedundantAssignment
                            performanceMeasureTarget = new PerformanceMeasureReportingPeriodTarget(performanceMeasure, reportingPeriod)
                            {
                                PerformanceMeasureTargetValue = pmrpSimple.TargetValue,
                                PerformanceMeasureTargetValueLabel = pmrpSimple.TargetValueLabel
                            };
                        }
                        else
                        {
                            performanceMeasureTarget.PerformanceMeasureTargetValue = pmrpSimple.TargetValue;
                            performanceMeasureTarget.PerformanceMeasureTargetValueLabel = pmrpSimple.TargetValueLabel;
                        }
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException($"Invalid Target Value Type {performanceMeasureTargetValueTypeEnum}");
            }

            //Google Chart Configuration
            if (performanceMeasure.PerformanceMeasureReportingPeriodTargets.Any())
            {
                foreach (var pfSubcategory in performanceMeasure.PerformanceMeasureSubcategories)
                {
                    var tempChartConfig = GoogleChartConfiguration.GetGoogleChartConfigurationFromJsonObject(pfSubcategory.ChartConfigurationJson);
                    tempChartConfig.Series = GoogleChartSeries.GetGoogleChartSeriesForChartsWithTargets();
                    pfSubcategory.ChartConfigurationJson = JObject.FromObject(tempChartConfig).ToString();
                    pfSubcategory.GoogleChartTypeID = performanceMeasure.HasTargets() ? GoogleChartType.ComboChart.GoogleChartTypeID : GoogleChartType.ColumnChart.GoogleChartTypeID;
                    if (performanceMeasure.CanBeChartedCumulatively)
                    {
                        var cumulativeChartConfigurationJson = JObject.FromObject(performanceMeasure.GetDefaultPerformanceMeasureChartConfigurationJson()).ToString();
                        pfSubcategory.CumulativeChartConfigurationJson = cumulativeChartConfigurationJson;
                        pfSubcategory.CumulativeGoogleChartTypeID = performanceMeasure.HasTargets() ? GoogleChartType.ComboChart.GoogleChartTypeID : GoogleChartType.ColumnChart.GoogleChartTypeID;
                    }
                }
            }

            //if (PerformanceMeasureReportingPeriodSimples != null)
            //{
            //    var performanceMeasureTargetValueTypeEnum = PerformanceMeasureTargetValueType.AllLookupDictionary[PerformanceMeasureTargetValueTypeID].ToEnum;
            //    List<PerformanceMeasureReportingPeriod> performanceMeasureReportingPeriodsUpdated = new List<PerformanceMeasureReportingPeriod>();
            //    List<PerformanceMeasureReportingPeriodTarget> performanceMeasureTargetsUpdated = new List<PerformanceMeasureReportingPeriodTarget>();

            //    // if a reporting period doesn't come back from the front end we want to make sure it doesn't accidentally get deleted in the merge below.
            //    var updatedIDs = PerformanceMeasureReportingPeriodSimples.Select(x => x.PerformanceMeasureReportingPeriodID);
            //    List<PerformanceMeasureReportingPeriod> missingPeriods = performanceMeasure.PerformanceMeasureActuals.Select(x => x.PerformanceMeasureReportingPeriod).Where(x => !updatedIDs.Contains(x.PerformanceMeasureReportingPeriodID)).ToList();
            //    missingPeriods.AddRange(performanceMeasure.PerformanceMeasureActualUpdates.Select(x => x.PerformanceMeasureReportingPeriod).Where(x => !updatedIDs.Contains(x.PerformanceMeasureReportingPeriodID)));
            //    performanceMeasureReportingPeriodsUpdated.AddRange(missingPeriods);

            //    foreach (var reportingPeriodSimple in PerformanceMeasureReportingPeriodSimples)
            //    {
            //        // Reporting Period
            //        // ----------------

            //        var reportingPeriod = allPerformanceMeasureReportingPeriods.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodID == reportingPeriodSimple.PerformanceMeasureReportingPeriodID);
            //        if(reportingPeriod == null)
            //        { 
            //            reportingPeriod = new PerformanceMeasureReportingPeriod(reportingPeriodSimple.PerformanceMeasureReportingPeriodCalendarYear, reportingPeriodSimple.PerformanceMeasureReportingPeriodLabel);
            //        }

            //        performanceMeasureReportingPeriodsUpdated.Add(reportingPeriod);


            //        var performanceMeasureTarget = allPerformanceMeasureTargets.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodTargetID == reportingPeriodSimple.PerformanceMeasureTargetID);
            //        switch (performanceMeasureTargetValueTypeEnum)
            //        {
            //            case PerformanceMeasureTargetValueTypeEnum.NoTarget:
            //                performanceMeasureTarget = null; //just to make sure we don't do anything with this.
            //                break;
            //            case PerformanceMeasureTargetValueTypeEnum.OverallTarget:
            //                if (performanceMeasureTarget == null)
            //                {
            //                    performanceMeasureTarget = new PerformanceMeasureTarget(performanceMeasure, reportingPeriod)
            //                    {
            //                        PerformanceMeasureTargetValue = OverallTargetValue,
            //                        PerformanceMeasureTargetValueLabel = OverallTargetValueLabel
            //                    };
            //                }
            //                else
            //                {
            //                    performanceMeasureTarget.PerformanceMeasureTargetValue = OverallTargetValue;
            //                    performanceMeasureTarget.PerformanceMeasureTargetValueLabel = OverallTargetValueLabel;
            //                }
            //                break;
            //            case PerformanceMeasureTargetValueTypeEnum.TargetPerYear:
            //                if (performanceMeasureTarget == null)
            //                {
            //                    performanceMeasureTarget = new PerformanceMeasureTarget(performanceMeasure, reportingPeriod)
            //                    {
            //                        PerformanceMeasureTargetValue = reportingPeriodSimple.TargetValue,
            //                        PerformanceMeasureTargetValueLabel = reportingPeriodSimple.TargetValueLabel
            //                    };
            //                }
            //                else
            //                {
            //                    performanceMeasureTarget.PerformanceMeasureTargetValue = reportingPeriodSimple.TargetValue;
            //                    performanceMeasureTarget.PerformanceMeasureTargetValueLabel = reportingPeriodSimple.TargetValueLabel;
            //                }
            //                break;
            //            default:
            //                throw new ArgumentOutOfRangeException(
            //                    $"Invalid Target Value Type {performanceMeasureTargetValueTypeEnum}");
            //        }

            //        performanceMeasureTargetsUpdated.Add(performanceMeasureTarget);

            //    }

            //    // Merge just PerformanceMeasureTarget
            //    performanceMeasure.PerformanceMeasureTargets.Merge(
            //        performanceMeasureTargetsUpdated,
            //        allPerformanceMeasureTargets,
            //        (x,y) => x.PerformanceMeasureTargetID == y.PerformanceMeasureTargetID,
            //        (x, y) =>
            //        {
            //            x.PerformanceMeasureReportingPeriodID = y.PerformanceMeasureReportingPeriodID;
            //            x.PerformanceMeasureTargetValue = y.PerformanceMeasureTargetValue;
            //            x.PerformanceMeasureTargetValueLabel = y.PerformanceMeasureTargetValueLabel;
            //        }, HttpRequestStorage.DatabaseEntities);


            //    // Google Chart Configuration
            //    if (performanceMeasure.PerformanceMeasureTargets.Any())
            //    {
            //        foreach (var pfSubcategory in performanceMeasure.PerformanceMeasureSubcategories)
            //        {
            //            var tempChartConfig = GoogleChartConfiguration.GetGoogleChartConfigurationFromJsonObject(pfSubcategory.ChartConfigurationJson);
            //            tempChartConfig.Series = GoogleChartSeries.GetGoogleChartSeriesForChartsWithTargets();
            //            pfSubcategory.ChartConfigurationJson = JObject.FromObject(tempChartConfig).ToString();
            //            pfSubcategory.GoogleChartTypeID = performanceMeasure.HasTargets() ? GoogleChartType.ComboChart.GoogleChartTypeID : GoogleChartType.ColumnChart.GoogleChartTypeID;
            //            if (performanceMeasure.CanBeChartedCumulatively)
            //            {
            //                var cumulativeChartConfigurationJson = JObject.FromObject(performanceMeasure.GetDefaultPerformanceMeasureChartConfigurationJson()).ToString();
            //                pfSubcategory.CumulativeChartConfigurationJson = cumulativeChartConfigurationJson;
            //                pfSubcategory.CumulativeGoogleChartTypeID = performanceMeasure.HasTargets() ? GoogleChartType.ComboChart.GoogleChartTypeID : GoogleChartType.ColumnChart.GoogleChartTypeID;
            //            }
            //        }
            //    }
            //}
        }


        public void DeleteOtherGeospatialAreaPerformanceMeasureTargetValueTypes(
            ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure,
            ProjectFirmaModels.Models.GeospatialArea geospatialArea,
            PerformanceMeasureTargetValueTypeEnum performanceMeasureTargetValueTypeEnum)
        {
            if (performanceMeasureTargetValueTypeEnum != PerformanceMeasureTargetValueTypeEnum.NoTarget)
            {
                var noTargetsToDelete = performanceMeasure.GeospatialAreaPerformanceMeasureNoTargets.Where(x => x.GeospatialAreaID == geospatialArea.GeospatialAreaID).ToList();
                noTargetsToDelete.ForEach(oa => oa.DeleteFull(HttpRequestStorage.DatabaseEntities));
            }

            if (performanceMeasureTargetValueTypeEnum != PerformanceMeasureTargetValueTypeEnum.OverallTarget)
            {
                var overallTargetsToDelete = performanceMeasure.GeospatialAreaPerformanceMeasureOverallTargets.Where(x => x.GeospatialAreaID == geospatialArea.GeospatialAreaID).ToList();
                overallTargetsToDelete.ForEach(oa => oa.DeleteFull(HttpRequestStorage.DatabaseEntities));
            }

            if (performanceMeasureTargetValueTypeEnum != PerformanceMeasureTargetValueTypeEnum.TargetPerYear)
            {
                var reportingPeriodTargetsToDelete = performanceMeasure.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Where(x => x.GeospatialAreaID == geospatialArea.GeospatialAreaID).ToList();
                reportingPeriodTargetsToDelete.ForEach(oa => oa.DeleteFull(HttpRequestStorage.DatabaseEntities));
            }
        }


        public void UpdateModel(ProjectFirmaModels.Models.GeospatialArea geospatialArea,
                                ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure,
                                ICollection<PerformanceMeasureReportingPeriod> allPerformanceMeasureReportingPeriods,
                                ICollection<ProjectFirmaModels.Models.GeospatialAreaPerformanceMeasureNoTarget> allGeospatialAreaPerformanceMeasureNoTargets,
                                ICollection<ProjectFirmaModels.Models.GeospatialAreaPerformanceMeasureOverallTarget> allGeospatialAreaPerformanceMeasureOverallTargets,
                                ICollection<ProjectFirmaModels.Models.GeospatialAreaPerformanceMeasureReportingPeriodTarget> allGeospatialAreaPerformanceMeasureReportingPeriodTargets)
        {


            var performanceMeasureTargetValueTypeEnum = PerformanceMeasureTargetValueType.AllLookupDictionary[PerformanceMeasureTargetValueTypeID].ToEnum;
            DeleteOtherGeospatialAreaPerformanceMeasureTargetValueTypes(performanceMeasure, geospatialArea, performanceMeasureTargetValueTypeEnum);

            switch (performanceMeasureTargetValueTypeEnum)
            {
                case PerformanceMeasureTargetValueTypeEnum.NoTarget:
                    // Make a "no target" object.
                    // ReSharper disable once UnusedVariable
                    var noTarget = GeospatialAreaPerformanceMeasureNoTargetModelExtensions.GetOrCreateGeospatialAreaPerformanceMeasureNoTarget(performanceMeasure, geospatialArea);
                    break;

                case PerformanceMeasureTargetValueTypeEnum.OverallTarget:
                    var overallTarget = GeospatialAreaPerformanceMeasureOverallTargetModelExtensions.GetOrCreateGeospatialAreaPerformanceMeasureOverallTarget(performanceMeasure, geospatialArea, OverallTargetValue.Value);
                    overallTarget.GeospatialAreaPerformanceMeasureTargetValueLabel = OverallTargetValueLabel;
                    overallTarget.GeospatialAreaPerformanceMeasureTargetValue = OverallTargetValue.Value;
                    break;

                case PerformanceMeasureTargetValueTypeEnum.TargetPerYear:
                    foreach (var pmrpSimple in PerformanceMeasureReportingPeriodSimples)
                    {
                        // Reporting Period
                        // ----------------
                        var reportingPeriod = allPerformanceMeasureReportingPeriods.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodCalendarYear == pmrpSimple.PerformanceMeasureReportingPeriodCalendarYear);
                        if (reportingPeriod == null)
                        {
                            reportingPeriod = new PerformanceMeasureReportingPeriod(pmrpSimple.PerformanceMeasureReportingPeriodCalendarYear,
                                                                                    pmrpSimple.PerformanceMeasureReportingPeriodLabel);
                        }
                        var performanceMeasureTarget = allGeospatialAreaPerformanceMeasureReportingPeriodTargets.SingleOrDefault(x => x.GeospatialAreaPerformanceMeasureReportingPeriodTargetID == pmrpSimple.GeospatialAreaPerformanceMeasureReportingPeriodTargetID);
                        if (performanceMeasureTarget == null)
                        {
                            // ReSharper disable once RedundantAssignment
                            performanceMeasureTarget = new GeospatialAreaPerformanceMeasureReportingPeriodTarget(geospatialArea, performanceMeasure, reportingPeriod)
                                {
                                    GeospatialAreaPerformanceMeasureTargetValue = pmrpSimple.TargetValue,
                                    GeospatialAreaPerformanceMeasureTargetValueLabel = pmrpSimple.TargetValueLabel
                                };
                        }
                        else
                        {
                            performanceMeasureTarget.GeospatialAreaPerformanceMeasureTargetValue = pmrpSimple.TargetValue;
                            performanceMeasureTarget.GeospatialAreaPerformanceMeasureTargetValueLabel = pmrpSimple.TargetValueLabel;
                        }
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException($"Invalid Target Value Type {performanceMeasureTargetValueTypeEnum}");

            }

            //Google Chart Configuration
            if (performanceMeasure.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Any() || performanceMeasure.GeospatialAreaPerformanceMeasureOverallTargets.Any())
            {
                foreach (var pfSubcategory in performanceMeasure.PerformanceMeasureSubcategories)
                {
                    var tempChartConfig = GoogleChartConfiguration.GetGoogleChartConfigurationFromJsonObject(pfSubcategory.ChartConfigurationJson);
                    tempChartConfig.Series = GoogleChartSeries.GetGoogleChartSeriesForChartsWithTargets();
                    pfSubcategory.GeospatialAreaTargetChartConfigurationJson = JObject.FromObject(tempChartConfig).ToString();
                    pfSubcategory.GeospatialAreaTargetGoogleChartTypeID = performanceMeasure.HasGeospatialAreaTargets(geospatialArea) ? GoogleChartType.ComboChart.GoogleChartTypeID : GoogleChartType.ColumnChart.GoogleChartTypeID;
                    if (performanceMeasure.CanBeChartedCumulatively)
                    {
                        var cumulativeChartConfigurationJson = JObject.FromObject(performanceMeasure.GetDefaultPerformanceMeasureChartConfigurationJson()).ToString();
                        pfSubcategory.CumulativeChartConfigurationJson = cumulativeChartConfigurationJson;
                        pfSubcategory.CumulativeGoogleChartTypeID = performanceMeasure.HasTargets() ? GoogleChartType.ComboChart.GoogleChartTypeID : GoogleChartType.ColumnChart.GoogleChartTypeID;
                    }
                }
            }
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            var performanceMeasureTargetValueTypeEnum = PerformanceMeasureTargetValueType.AllLookupDictionary[PerformanceMeasureTargetValueTypeID].ToEnum;

            switch (performanceMeasureTargetValueTypeEnum)
            {
                case PerformanceMeasureTargetValueTypeEnum.NoTarget:
                    break;
                case PerformanceMeasureTargetValueTypeEnum.OverallTarget:
                    if (!OverallTargetValue.HasValue)
                    {
                        errors.Add(new ValidationResult("If you are submitting an overall target, you must set a target value. Otherwise choose \"No Target\"."));
                    }

                    break;
                case PerformanceMeasureTargetValueTypeEnum.TargetPerYear:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return errors;

        }
        
    }
}