﻿using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class GeospatialAreaPerformanceMeasureTargetGridSpec : GridSpec<ProjectFirmaModels.Models.GeospatialArea>
    {
        public GeospatialAreaPerformanceMeasureTargetGridSpec(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure)
        {
            var userHasManagePermissions = new GeospatialAreaPerformanceMeasureTargetManageFeature().HasPermissionByFirmaSession(currentFirmaSession);

            if (userHasManagePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteGeospatialAreaPerformanceMeasureTargetUrl(performanceMeasure), true), 30, DhtmlxGridColumnFilterType.None);
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(x.GetEditGeospatialAreaPerformanceMeasureTargetUrl(performanceMeasure), $"Edit {FieldDefinitionEnum.PerformanceMeasure.ToType().GetFieldDefinitionLabelPluralized()} Target for {performanceMeasure.GetDisplayName()}"), 30, DhtmlxGridColumnFilterType.None);
            }

            Add("Geospatial Layer", x => x.GeospatialAreaType.GeospatialAreaTypeName, 150, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.GeospatialArea.ToType().ToGridHeaderString(), a =>  a.GetDisplayNameAsUrl(), 300, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add("Target Value", a => a.GetTargetValueDisplayForGrid(performanceMeasure), 300, DhtmlxGridColumnFilterType.SelectFilterStrict);
        }
    }
}