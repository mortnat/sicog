﻿using System.Collections.Generic;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Watershed
{
    public class IndexViewData : FirmaViewData
    {
        public readonly MapInitJson MapInitJson;
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;        

        public IndexViewData(Person currentPerson, Models.FirmaPage firmaPage, MapInitJson mapInitJson) : base(currentPerson, firmaPage, false)
        {
            PageTitle = "Watersheds";
            MapInitJson = mapInitJson;
            GridSpec = new IndexGridSpec {ObjectNameSingular = "Watershed", ObjectNamePlural = "Watersheds", SaveFiltersInCookie = true};
            GridName = "watershedsGrid";
            GridDataUrl = SitkaRoute<WatershedController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}