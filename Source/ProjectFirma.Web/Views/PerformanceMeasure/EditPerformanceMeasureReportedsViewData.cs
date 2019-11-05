﻿/*-----------------------------------------------------------------------
<copyright file="EditPerformanceMeasureReportedsViewData.cs" company="Tahoe Regional Planning Agency">
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

using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class EditPerformanceMeasureReportedsViewData
    {        
        public readonly ProjectFirmaModels.Models.PerformanceMeasure PerformanceMeasure;
        public readonly List<PerformanceMeasureTargetValueType> PerformanceMeasureTargetValueTypes;
        public readonly EditPerformanceMeasureReportedsViewDataForAngular ViewDataForAngular;

        public EditPerformanceMeasureReportedsViewData(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, EditPerformanceMeasureReportedsViewDataForAngular viewDataForAngular, List<PerformanceMeasureTargetValueType> performanceMeasureTargetValueTypes)
        {
            PerformanceMeasure = performanceMeasure;
            ViewDataForAngular = viewDataForAngular;
            PerformanceMeasureTargetValueTypes = performanceMeasureTargetValueTypes;
        }
    }

    public class EditPerformanceMeasureReportedsViewDataForAngular
    {
        public readonly int? PerformanceMeasureSubcategoryID;
        public readonly int DefaultReportingPeriodYear;
        public readonly Dictionary<string, int> PerformanceMeasureTargetValueTypes;
        public List<ReportingCategoryForDisplay> ReportingCategoriesForDisplay;

        public EditPerformanceMeasureReportedsViewDataForAngular(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, int defaultReportingPeriodYear, Dictionary<string, int> performanceMeasureTargetValueTypes)
        {
            PerformanceMeasureTargetValueTypes = performanceMeasureTargetValueTypes;
            DefaultReportingPeriodYear = defaultReportingPeriodYear;
            var performanceMeasureSubcategory = performanceMeasure.PerformanceMeasureSubcategories.Single();
            ReportingCategoriesForDisplay = performanceMeasureSubcategory.PerformanceMeasureSubcategoryOptions.Select(x => new ReportingCategoryForDisplay(x)).ToList();
            PerformanceMeasureSubcategoryID = performanceMeasureSubcategory.PerformanceMeasureSubcategoryID;
        }
    }
}
