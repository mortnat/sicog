﻿/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Project;

namespace ProjectFirma.Web.Views.Classification
{
    public class DetailViewData : FirmaViewData
    {
        public readonly Models.Classification Classification;
        public readonly string EditClassificationUrl;
        public readonly string IndexUrl;
        public readonly bool UserHasClassificationManagePermissions;

        public readonly BasicProjectInfoGridSpec BasicProjectInfoGridSpec;
        public readonly string BasicProjectInfoGridName;
        public readonly string BasicProjectInfoGridDataUrl;

        public DetailViewData(Person currentPerson, Models.Classification classification)
            : base(currentPerson)
        {
            Classification = classification;
            PageTitle = MultiTenantHelpers.GetClassificationDisplayName();
            EditClassificationUrl = SitkaRoute<ClassificationController>.BuildUrlFromExpression(c => c.Edit(classification));
            IndexUrl = SitkaRoute<ClassificationController>.BuildUrlFromExpression(c => c.Index());

            UserHasClassificationManagePermissions = new PerformanceMeasureManageFeature().HasPermissionByPerson(currentPerson);

            BasicProjectInfoGridName = "watershedProjectListGrid";
            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, false)
            {
                ObjectNameSingular = string.Format("Project associated with this {0}", MultiTenantHelpers.GetClassificationDisplayName()),
                ObjectNamePlural = string.Format("Projects associated with this {0}", MultiTenantHelpers.GetClassificationDisplayNamePluralized()),
                SaveFiltersInCookie = true
            };

            BasicProjectInfoGridDataUrl = SitkaRoute<ClassificationController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(classification));
        }
    }
}
