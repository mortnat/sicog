﻿/*-----------------------------------------------------------------------
<copyright file="IndexViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ExternalMapLayer
{
    public class IndexViewData : FirmaViewData
    {
        public Organization.IndexGridSpec GridSpec { get; }
        public string GridName { get; }
        public string GridDataUrl { get; }
        public string PullOrganizationFromKeystoneUrl { get; }
        public bool UserIsSitkaAdmin { get; }
        public bool HasOrganizationManagePermissions { get; }
        public string NewUrl { get; }

        public Organization.IndexGridSpec.OrganizationStatusFilterTypeEnum OrganizationStatusFilterType { get; }
        public List<SelectListItem> ActiveOrAllOrganizationsSelectListItems { get; }
        public string ShowOnlyActiveOrAll { get; }


        public IndexViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage, string gridDataUrl, List<SelectListItem> activeOrAllOrganizationsSelectListItems)
            : base(currentFirmaSession, firmaPage)
        {
            PageTitle = $"{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabelPluralized()}";
            var hasOrganizationManagePermissions = new OrganizationManageFeature().HasPermissionByFirmaSession(currentFirmaSession);
            GridSpec = new Organization.IndexGridSpec(currentFirmaSession, hasOrganizationManagePermissions)
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()}",
                ObjectNamePlural = $"{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabelPluralized()}",
                SaveFiltersInCookie = true
            };

            GridName = "organizationsGrid";
            GridDataUrl = gridDataUrl;

            PullOrganizationFromKeystoneUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(x => x.PullOrganizationFromKeystone());
            UserIsSitkaAdmin = new SitkaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);
            HasOrganizationManagePermissions = hasOrganizationManagePermissions;
            NewUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(t => t.New());

            ActiveOrAllOrganizationsSelectListItems = activeOrAllOrganizationsSelectListItems;
            ShowOnlyActiveOrAll = "ShowOnlyActiveOrAll";
        }
    }
}
