﻿/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureModelExtensions.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class PerformanceMeasureGroupModelExtensions
    {
        public static readonly UrlTemplate<int> EditUrlTemplate = new UrlTemplate<int>(SitkaRoute<PerformanceMeasureGroupController>.BuildUrlFromExpression(t => t.Edit(UrlTemplate.Parameter1Int)));
        public static string GetEditUrl(this PerformanceMeasureGroup performanceMeasureGroup)
        {
            return EditUrlTemplate.ParameterReplace(performanceMeasureGroup.PerformanceMeasureGroupID);
        }

        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(SitkaRoute<PerformanceMeasureGroupController>.BuildUrlFromExpression(t => t.DeletePerformanceMeasureGroup(UrlTemplate.Parameter1Int)));
        public static string GetDeleteUrl(this PerformanceMeasureGroup performanceMeasureGroup)
        {
            return DeleteUrlTemplate.ParameterReplace(performanceMeasureGroup.PerformanceMeasureGroupID);
        }

        public static bool IsPerformanceMeasureGroupNameUnique(IEnumerable<PerformanceMeasureGroup> performanceMeasureGroups, string performanceMeasureGroupName, int currentPerformanceMeasureGroupID)
        {
            var performanceMeasureGroup =
                performanceMeasureGroups.SingleOrDefault(
                    x => x.PerformanceMeasureGroupID != currentPerformanceMeasureGroupID && String.Equals(x.PerformanceMeasureGroupName, performanceMeasureGroupName, StringComparison.InvariantCultureIgnoreCase));
            return performanceMeasureGroup == null;
        }
    }
}
