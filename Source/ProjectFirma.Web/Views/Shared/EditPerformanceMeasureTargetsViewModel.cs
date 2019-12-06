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
        public string OverallTargetValueDescription { get; set; }

        public HashSet<string> PerformanceMeasureReportedsWithValidationErrors { get; private set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditPerformanceMeasureTargetsViewModel()
        {
        }

        public EditPerformanceMeasureTargetsViewModel(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureReportingPeriodSimples = PerformanceMeasureReportingPeriodSimple.MakeFromList(performanceMeasure.PerformanceMeasureTargets, performanceMeasure.PerformanceMeasureActuals);
            PerformanceMeasureTargetValueTypeID = performanceMeasure.GetTargetValueType().PerformanceMeasureTargetValueTypeID;
        }

        public EditPerformanceMeasureTargetsViewModel(ProjectFirmaModels.Models.GeospatialArea geospatialArea, ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureReportingPeriodSimples = PerformanceMeasureReportingPeriodSimple.MakeFromList(performanceMeasure.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Where(x => x.GeospatialAreaID == geospatialArea.GeospatialAreaID), performanceMeasure.PerformanceMeasureActuals);
            PerformanceMeasureTargetValueTypeID = performanceMeasure.GetGeospatialAreaTargetValueType(geospatialArea).PerformanceMeasureTargetValueTypeID;
        }

        public void UpdateModel(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, 
                                ICollection<PerformanceMeasureReportingPeriod> allPerformanceMeasureReportingPeriods, 
                                ICollection<PerformanceMeasureTarget> allPerformanceMeasureTargets)
        {

            if (PerformanceMeasureReportingPeriodSimples != null)
            {
                var performanceMeasureTargetValueTypeEnum = PerformanceMeasureTargetValueType.AllLookupDictionary[PerformanceMeasureTargetValueTypeID].ToEnum;
                List<PerformanceMeasureReportingPeriod> performanceMeasureReportingPeriodsUpdated = new List<PerformanceMeasureReportingPeriod>();
                List<PerformanceMeasureTarget> performanceMeasureTargetsUpdated = new List<PerformanceMeasureTarget>();

                // if a reporting period doesn't come back from the front end we want to make sure it doesn't accidentally get deleted in the merge below.
                var updatedIDs = PerformanceMeasureReportingPeriodSimples.Select(x => x.PerformanceMeasureReportingPeriodID);
                List<PerformanceMeasureReportingPeriod> missingPeriods = performanceMeasure.PerformanceMeasureActuals.Select(x => x.PerformanceMeasureReportingPeriod).Where(x => !updatedIDs.Contains(x.PerformanceMeasureReportingPeriodID)).ToList();
                missingPeriods.AddRange(performanceMeasure.PerformanceMeasureActualUpdates.Select(x => x.PerformanceMeasureReportingPeriod).Where(x => !updatedIDs.Contains(x.PerformanceMeasureReportingPeriodID)));
                performanceMeasureReportingPeriodsUpdated.AddRange(missingPeriods);

                foreach (var reportingPeriodSimple in PerformanceMeasureReportingPeriodSimples)
                {
                    

                    // Reporting Period
                    // ----------------

                    var reportingPeriod = allPerformanceMeasureReportingPeriods.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodID == reportingPeriodSimple.PerformanceMeasureReportingPeriodID);
                    if(reportingPeriod == null)
                    { 
                        reportingPeriod = new PerformanceMeasureReportingPeriod(reportingPeriodSimple.PerformanceMeasureReportingPeriodCalendarYear, reportingPeriodSimple.PerformanceMeasureReportingPeriodLabel);
                    }

                    performanceMeasureReportingPeriodsUpdated.Add(reportingPeriod);


                    var performanceMeasureTarget = allPerformanceMeasureTargets.SingleOrDefault(x => x.PerformanceMeasureTargetID == reportingPeriodSimple.PerformanceMeasureTargetID);
                    switch (performanceMeasureTargetValueTypeEnum)
                    {
                        case PerformanceMeasureTargetValueTypeEnum.NoTarget:
                            performanceMeasureTarget = null; //just to make sure we don't do anything with this.
                            break;
                        case PerformanceMeasureTargetValueTypeEnum.OverallTarget:
                            if (performanceMeasureTarget == null)
                            {
                                performanceMeasureTarget = new PerformanceMeasureTarget(performanceMeasure, reportingPeriod, OverallTargetValue.Value)
                                {
                                    PerformanceMeasureTargetValueLabel = OverallTargetValueDescription
                                };
                            }
                            else
                            {
                                performanceMeasureTarget.PerformanceMeasureTargetValue = OverallTargetValue.Value;
                                performanceMeasureTarget.PerformanceMeasureTargetValueLabel = OverallTargetValueDescription;
                            }
                            break;
                        case PerformanceMeasureTargetValueTypeEnum.ReportingPeriodTarget:
                            if (performanceMeasureTarget == null)
                            {
                                performanceMeasureTarget = new PerformanceMeasureTarget(performanceMeasure, reportingPeriod, reportingPeriodSimple.TargetValue.Value)
                                {
                                    PerformanceMeasureTargetValueLabel = reportingPeriodSimple.TargetValueLabel
                                };
                            }
                            else
                            {
                                performanceMeasureTarget.PerformanceMeasureTargetValue = reportingPeriodSimple.TargetValue.Value;
                                performanceMeasureTarget.PerformanceMeasureTargetValueLabel = reportingPeriodSimple.TargetValueLabel;
                            }
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(
                                $"Invalid Target Value Type {performanceMeasureTargetValueTypeEnum}");
                    }

                    performanceMeasureTargetsUpdated.Add(performanceMeasureTarget);
                    
                }

                // Merge just PerformanceMeasureTarget
                performanceMeasure.PerformanceMeasureTargets.Merge(
                    performanceMeasureTargetsUpdated,
                    allPerformanceMeasureTargets,
                    (x,y) => x.PerformanceMeasureTargetID == y.PerformanceMeasureTargetID,
                    (x, y) =>
                    {
                        x.PerformanceMeasureReportingPeriodID = y.PerformanceMeasureReportingPeriodID;
                        x.PerformanceMeasureTargetValue = y.PerformanceMeasureTargetValue;
                        x.PerformanceMeasureTargetValueLabel = y.PerformanceMeasureTargetValueLabel;
                    }, HttpRequestStorage.DatabaseEntities);


                // Google Chart Configuration
                if (performanceMeasure.PerformanceMeasureTargets.Any())
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
            switch (performanceMeasureTargetValueTypeEnum)
            {
                case PerformanceMeasureTargetValueTypeEnum.NoTarget:
                    
                    // Clean up any existing Overall objects
                    // -------------------------------------
                    var overallsToDelete = performanceMeasure.GeospatialAreaPerformanceMeasureOverallTargets.ToList();
                    overallsToDelete.ForEach(oa => oa.Delete(HttpRequestStorage.DatabaseEntities));
                    performanceMeasure.GeospatialAreaPerformanceMeasureOverallTargets.Clear();

                    // Clean up Reporting Period target objects
                    // ----------------------------------------
                    var reportingPeriodTargetsToDelete = performanceMeasure.GeospatialAreaPerformanceMeasureReportingPeriodTargets.ToList();
                    reportingPeriodTargetsToDelete.ForEach(oa => oa.Delete(HttpRequestStorage.DatabaseEntities));
                    performanceMeasure.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Clear();

                    // Make a "no target" object.
                    var noTarget = allGeospatialAreaPerformanceMeasureNoTargets.SingleOrDefault(x =>
                        x.GeospatialAreaID == geospatialArea.GeospatialAreaID &&
                        x.PerformanceMeasureID == performanceMeasure.PerformanceMeasureID);
                    if (noTarget == null)
                    {
                        noTarget = new GeospatialAreaPerformanceMeasureNoTarget(geospatialArea, performanceMeasure);
                    }

                    break;
                case PerformanceMeasureTargetValueTypeEnum.OverallTarget:
                    //if (performanceMeasureTarget == null)
                    //{
                    //    performanceMeasureTarget = new ProjectFirmaModels.Models.GeospatialAreaPerformanceMeasureReportingPeriodTarget(geospatialArea, performanceMeasure, reportingPeriod)
                    //    {
                    //        GeospatialAreaPerformanceMeasureTargetValue = OverallTargetValue,
                    //        GeospatialAreaPerformanceMeasureTargetValueLabel = OverallTargetValueDescription
                    //    };
                    //}
                    //else
                    //{
                    //    performanceMeasureTarget.GeospatialAreaPerformanceMeasureTargetValue = OverallTargetValue.Value;
                    //    performanceMeasureTarget.GeospatialAreaPerformanceMeasureTargetValueLabel = OverallTargetValueDescription;
                    //}
                    //break;
                case PerformanceMeasureTargetValueTypeEnum.ReportingPeriodTarget:
                    //if (performanceMeasureTarget == null)
                    //{
                    //    performanceMeasureTarget = new ProjectFirmaModels.Models.GeospatialAreaPerformanceMeasureReportingPeriodTarget(geospatialArea, performanceMeasure, reportingPeriod)
                    //    {
                    //        GeospatialAreaPerformanceMeasureTargetValue = reportingPeriodSimple.TargetValue,
                    //        GeospatialAreaPerformanceMeasureTargetValueLabel = reportingPeriodSimple.TargetValueLabel
                    //    };
                    //}
                    //else
                    //{
                    //    performanceMeasureTarget.GeospatialAreaPerformanceMeasureTargetValue = reportingPeriodSimple.TargetValue.Value;
                    //    performanceMeasureTarget.GeospatialAreaPerformanceMeasureTargetValueLabel = reportingPeriodSimple.TargetValueLabel;
                    //}
                    //break;
                default:
                    throw new ArgumentOutOfRangeException(
                        $"Invalid Target Value Type {performanceMeasureTargetValueTypeEnum}");
            }



            //if (PerformanceMeasureReportingPeriodSimples != null)
            //{
            //    var performanceMeasureTargetValueTypeEnum = PerformanceMeasureTargetValueType.AllLookupDictionary[PerformanceMeasureTargetValueTypeID].ToEnum;
            //    List<PerformanceMeasureReportingPeriod> performanceMeasureReportingPeriodsUpdated = new List<PerformanceMeasureReportingPeriod>();
            //    //we need to start the updated list with the Targets not tied to the current GeospatialArea, so we don't accidentally delete them in the merge below
            //    List<ProjectFirmaModels.Models.GeospatialAreaPerformanceMeasureReportingPeriodTarget> updatedGeospatialAreaPerformanceMeasureReportingPeriodTargets = performanceMeasure.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Where(x => x.GeospatialAreaID != geospatialArea.GeospatialAreaID).ToList();

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
            //        if (reportingPeriod == null)
            //        {
            //            reportingPeriod = new PerformanceMeasureReportingPeriod(reportingPeriodSimple.PerformanceMeasureReportingPeriodCalendarYear, reportingPeriodSimple.PerformanceMeasureReportingPeriodLabel);
            //        }

            //        performanceMeasureReportingPeriodsUpdated.Add(reportingPeriod);


            //        // WARNING-- WRONG ---
            //        var performanceMeasureTarget = allGeospatialAreaPerformanceMeasureReportingPeriodTargets.SingleOrDefault(x => x.GeospatialAreaPerformanceMeasureReportingPeriodTargetID == reportingPeriodSimple.GeospatialAreaPerformanceMeasureTargetID);
            //        switch (performanceMeasureTargetValueTypeEnum)
            //        {
            //            case PerformanceMeasureTargetValueTypeEnum.NoTarget:
            //                performanceMeasureTarget = null; //just to make sure we don't do anything with this.
            //                break;
            //            case PerformanceMeasureTargetValueTypeEnum.OverallTarget:
            //                if (performanceMeasureTarget == null)
            //                {
            //                    performanceMeasureTarget = new ProjectFirmaModels.Models.GeospatialAreaPerformanceMeasureReportingPeriodTarget(geospatialArea, performanceMeasure, reportingPeriod)
            //                    {
            //                        GeospatialAreaPerformanceMeasureTargetValue = OverallTargetValue,
            //                        GeospatialAreaPerformanceMeasureTargetValueLabel = OverallTargetValueDescription
            //                    };
            //                }
            //                else
            //                {
            //                    performanceMeasureTarget.GeospatialAreaPerformanceMeasureTargetValue = OverallTargetValue.Value;
            //                    performanceMeasureTarget.GeospatialAreaPerformanceMeasureTargetValueLabel = OverallTargetValueDescription;
            //                }
            //                break;
            //            case PerformanceMeasureTargetValueTypeEnum.TargetPerYear:
            //                if (performanceMeasureTarget == null)
            //                {
            //                    performanceMeasureTarget = new ProjectFirmaModels.Models.GeospatialAreaPerformanceMeasureReportingPeriodTarget(geospatialArea, performanceMeasure, reportingPeriod)
            //                    {
            //                        GeospatialAreaPerformanceMeasureTargetValue = reportingPeriodSimple.TargetValue,
            //                        GeospatialAreaPerformanceMeasureTargetValueLabel = reportingPeriodSimple.TargetValueLabel
            //                    };
            //                }
            //                else
            //                {
            //                    performanceMeasureTarget.GeospatialAreaPerformanceMeasureTargetValue = reportingPeriodSimple.TargetValue.Value;
            //                    performanceMeasureTarget.GeospatialAreaPerformanceMeasureTargetValueLabel = reportingPeriodSimple.TargetValueLabel;
            //                }
            //                break;
            //            default:
            //                throw new ArgumentOutOfRangeException(
            //                    $"Invalid Target Value Type {performanceMeasureTargetValueTypeEnum}");
            //        }

            //        updatedGeospatialAreaPerformanceMeasureReportingPeriodTargets.Add(performanceMeasureTarget);

            //    }

            //    // Merge just GeospatialAreaPerformanceMeasureTarget
            //    performanceMeasure.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Merge(
            //        updatedGeospatialAreaPerformanceMeasureReportingPeriodTargets,
            //        allGeospatialAreaPerformanceMeasureReportingPeriodTargets,
            //        (x, y) => x.GeospatialAreaPerformanceMeasureReportingPeriodTargetID == y.GeospatialAreaPerformanceMeasureReportingPeriodTargetID,
            //        (x, y) =>
            //        {
            //            x.PerformanceMeasureReportingPeriodID = y.PerformanceMeasureReportingPeriodID;
            //            x.GeospatialAreaPerformanceMeasureTargetValue = y.GeospatialAreaPerformanceMeasureTargetValue;
            //            x.GeospatialAreaPerformanceMeasureTargetValueLabel = y.GeospatialAreaPerformanceMeasureTargetValueLabel;
            //        }, HttpRequestStorage.DatabaseEntities);


            //    // Google Chart Configuration
            //    if (performanceMeasure.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Any())
            //    {
            //        foreach (var pfSubcategory in performanceMeasure.PerformanceMeasureSubcategories)
            //        {
            //            var tempChartConfig = GoogleChartConfiguration.GetGoogleChartConfigurationFromJsonObject(pfSubcategory.ChartConfigurationJson);
            //            tempChartConfig.Series = GoogleChartSeries.GetGoogleChartSeriesForChartsWithTargets();
            //            pfSubcategory.GeospatialAreaTargetChartConfigurationJson = JObject.FromObject(tempChartConfig).ToString();
            //            pfSubcategory.GeospatialAreaTargetGoogleChartTypeID = performanceMeasure.HasGeospatialAreaTargets(geospatialArea) ? GoogleChartType.ComboChart.GoogleChartTypeID : GoogleChartType.ColumnChart.GoogleChartTypeID;
            //            //if (performanceMeasure.CanBeChartedCumulatively)
            //            //{
            //            //    var cumulativeChartConfigurationJson = JObject.FromObject(performanceMeasure.GetDefaultPerformanceMeasureChartConfigurationJson()).ToString();
            //            //    pfSubcategory.CumulativeChartConfigurationJson = cumulativeChartConfigurationJson;
            //            //    pfSubcategory.CumulativeGoogleChartTypeID = performanceMeasure.HasTargets() ? GoogleChartType.ComboChart.GoogleChartTypeID : GoogleChartType.ColumnChart.GoogleChartTypeID;
            //            //}
            //        }
            //    }
            //}
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            PerformanceMeasureReportedsWithValidationErrors = new HashSet<string>();

            if (PerformanceMeasureReportingPeriodSimples == null)
            {
                return errors;
            }


            return errors.DistinctBy(x => x.ErrorMessage);
        }



    }
}
