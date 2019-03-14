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

using System;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjectFirma.Web.Views.User
{
    public class IndexViewData : FirmaViewData
    {
        public IndexGridSpec GridSpec { get; }
        public string GridName { get; }
        public string GridDataUrl { get; }

        public string PullUserFromKeystoneUrl { get; }
        public bool UserIsSitkaAdmin { get; }
        public IndexGridSpec.UsersStatusFilterTypeEnum UsersStatusFilterType { get; }
        public List<SelectListItem> ActiveOnlyOrAllUsersSelectListItems { get; }
        public string ShowOnlyActiveOrBothActiveAndInactive { get; }

        public IndexViewData(Person currentPerson, ProjectFirmaModels.Models.FirmaPage firmaPage, IndexGridSpec.UsersStatusFilterTypeEnum usersStatusFilterType, string gridDataUrl, List<SelectListItem> activeOnlyOrAllUsersSelectListItems) : base(currentPerson, firmaPage)
        {
            
            GridSpec = new IndexGridSpec(currentPerson) {ObjectNameSingular = "User", ObjectNamePlural = "Users", SaveFiltersInCookie = true};
            GridName = "UserGrid";
            GridDataUrl = gridDataUrl;
            PullUserFromKeystoneUrl = SitkaRoute<UserController>.BuildUrlFromExpression(x => x.PullUserFromKeystone());
            UserIsSitkaAdmin = new SitkaAdminFeature().HasPermissionByPerson(currentPerson);

            UsersStatusFilterType = usersStatusFilterType;
            switch (usersStatusFilterType)
            {
                case IndexGridSpec.UsersStatusFilterTypeEnum.ActiveUsers:
                    PageTitle = "Active Users";
                    break;
                case IndexGridSpec.UsersStatusFilterTypeEnum.AllUsers:
                    PageTitle = "All Users";
                    break;
                default: throw new ArgumentOutOfRangeException("usersStatusFilterType", usersStatusFilterType, null);
            }

            ActiveOnlyOrAllUsersSelectListItems = activeOnlyOrAllUsersSelectListItems;
            ShowOnlyActiveOrBothActiveAndInactive = "ShowOnlyActiveOrBothActiveAndInactive";
        }
    }
}
