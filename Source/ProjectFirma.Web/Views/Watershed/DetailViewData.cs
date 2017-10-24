﻿/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Results;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common;
using ProjectFirma.Web.Views.PerformanceMeasure;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.Watershed
{
    public class DetailViewData : FirmaViewData
    {
        public readonly Models.Watershed Watershed;
        public readonly bool UserHasWatershedManagePermissions;
        public readonly string IndexUrl;
        public readonly BasicProjectInfoGridSpec BasicProjectInfoGridSpec;
        public readonly string BasicProjectInfoGridName;
        public readonly string BasicProjectInfoGridDataUrl;
        public readonly MapInitJson MapInitJson;
        public readonly ViewGoogleChartViewData ViewGoogleChartViewData;
        public readonly List<PerformanceMeasureChartViewData> PerformanceMeasureChartViewDatas;

        public DetailViewData(Person currentPerson, Models.Watershed watershed, MapInitJson mapInitJson, ViewGoogleChartViewData viewGoogleChartViewData, List<Models.PerformanceMeasure> performanceMeasures) : base(currentPerson)
        {
            Watershed = watershed;
            MapInitJson = mapInitJson;
            ViewGoogleChartViewData = viewGoogleChartViewData;
            PageTitle = watershed.WatershedName;
            EntityName = $"{Models.FieldDefinition.Watershed.GetFieldDefinitionLabel()}";
            UserHasWatershedManagePermissions = new WatershedManageFeature().HasPermissionByPerson(currentPerson);
            IndexUrl = SitkaRoute<WatershedController>.BuildUrlFromExpression(x => x.Index());

            BasicProjectInfoGridName = "watershedProjectListGrid";
            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, false)
            {
                ObjectNameSingular = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} in this {Models.FieldDefinition.Watershed.GetFieldDefinitionLabel()}",
                ObjectNamePlural = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()} in this {Models.FieldDefinition.Watershed.GetFieldDefinitionLabel()}",
                SaveFiltersInCookie = true
            };
          
            BasicProjectInfoGridDataUrl = SitkaRoute<WatershedController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(watershed));

            PerformanceMeasureChartViewDatas = performanceMeasures.Select(x=>watershed.GetPerformanceMeasureChartViewData(x, CurrentPerson)).ToList();
        }

        
    }
}
