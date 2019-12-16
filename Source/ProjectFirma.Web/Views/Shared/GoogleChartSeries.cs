using System;
using System.Collections.Generic;
using MoreLinq;
using ProjectFirmaModels.Models;
using Newtonsoft.Json;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared
{
    public class GoogleChartSeries
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "color", NullValueHandling = NullValueHandling.Ignore)]
        public string Color { get; set; }

        [JsonProperty(PropertyName = "targetAxisIndex", NullValueHandling = NullValueHandling.Ignore)]
        public int? TargetAxisIndex { get; set; }

        [JsonProperty(PropertyName = "lineWidth", NullValueHandling = NullValueHandling.Ignore)]
        public int? LineWidth { get; set; }
        [JsonProperty(PropertyName = "pointSize", NullValueHandling = NullValueHandling.Ignore)]
        public int? PointSize { get; set; }

        [JsonProperty(PropertyName = "enableInteractivity", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnableInteractivity { get; set; }

        //default constructor for serialization, otherwise it will get "creative" with default values...
        public GoogleChartSeries()
        {            
            TargetAxisIndex = null;
        }

        public GoogleChartSeries(GoogleChartType googleChartType, GoogleChartAxisType googleChartAxisType, string color, int? lineWidth, int? pointSize) 
        {
            Type = googleChartType.SeriesDataDisplayType;
            GetTargetAxisIndex(googleChartAxisType);
            Color = color;
            LineWidth = lineWidth;
            PointSize = pointSize;
        }


        public GoogleChartSeries(GoogleChartType googleChartType, GoogleChartAxisType googleChartAxisType)
        {
            Type = googleChartType.SeriesDataDisplayType;
            GetTargetAxisIndex(googleChartAxisType);
            LineWidth = 2;
        }

        private void GetTargetAxisIndex(GoogleChartAxisType googleChartAxisType)
        {
            switch (googleChartAxisType)
            {
                case GoogleChartAxisType.Primary:
                    TargetAxisIndex = null;
                    break;
                case GoogleChartAxisType.Secondary:
                    TargetAxisIndex = 1;
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(googleChartAxisType), googleChartAxisType, null);
            }
        }

        public static List<GoogleChartSeries> GetDefaultGoogleChartSeriesForChartsWithTargets()
        {
            var chartSeries = new List<GoogleChartSeries>
            {
                new GoogleChartSeries(GoogleChartType.LineChart, GoogleChartAxisType.Primary),
                new GoogleChartSeries(GoogleChartType.ColumnChart, GoogleChartAxisType.Primary)
            };
            return chartSeries;
        }

        public static List<GoogleChartSeries> GetDefaultGoogleChartSeriesForChartsWithTwoTargets()
        {
            var chartSeries = new List<GoogleChartSeries>
            {
                new GoogleChartSeries(GoogleChartType.LineChart, GoogleChartAxisType.Primary),
                new GoogleChartSeries(GoogleChartType.LineChart, GoogleChartAxisType.Primary),
                new GoogleChartSeries(GoogleChartType.ColumnChart, GoogleChartAxisType.Primary)
            };
            return chartSeries;
        }
        
        public static List<GoogleChartSeries> CalculateChartSeriesFromCurrentChartSeries(object currentChartSeries, ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, ProjectFirmaModels.Models.GeospatialArea geospatialArea)
        {
            // this was needed to ensure that the graphs on the geospatial detail page display appropriately for performance measure targets. 
            // It attempts to be as friendly as we can to the current chart series that the user/tenant might have set
            if (currentChartSeries == null)
            {
                var chartSeries = new List<GoogleChartSeries>();
                if (performanceMeasure.HasTargets())
                {
                    chartSeries.Add(new GoogleChartSeries(GoogleChartType.LineChart, GoogleChartAxisType.Primary));
                }
                if (performanceMeasure.HasGeospatialAreaTargets(geospatialArea))
                {
                    chartSeries.Add(new GoogleChartSeries(GoogleChartType.LineChart, GoogleChartAxisType.Primary));
                }
                chartSeries.Add(new GoogleChartSeries(GoogleChartType.ColumnChart, GoogleChartAxisType.Primary));
                return chartSeries;
            }

            var isListOfGoogleChartSeries = currentChartSeries is List<GoogleChartSeries>;

            var deserializedChartSeries = !isListOfGoogleChartSeries ? JsonConvert.DeserializeObject<List<GoogleChartSeries>>(currentChartSeries.ToString()) : (List<GoogleChartSeries>) currentChartSeries;
            if (performanceMeasure.HasTargets() || performanceMeasure.HasGeospatialAreaTargets(geospatialArea))
            {
                for (int i = 0; i < deserializedChartSeries.Count; i++)
                {
                    if (i < deserializedChartSeries.Count - 1)
                    {
                        deserializedChartSeries[i].Type = "line";
                    }
                }
            }

            if (performanceMeasure.HasTargets() && performanceMeasure.HasGeospatialAreaTargets(geospatialArea))
            {
                // Just in case you're wondering. Not a fan of this myself... SMG
                if (deserializedChartSeries.Count < 3)
                {
                    deserializedChartSeries.Insert(0, new GoogleChartSeries(GoogleChartType.LineChart, GoogleChartAxisType.Primary));
                }
            }

            return deserializedChartSeries;
        }
    }
}