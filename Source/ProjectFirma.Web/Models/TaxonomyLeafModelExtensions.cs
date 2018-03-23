﻿/*-----------------------------------------------------------------------
<copyright file="TaxonomyLeafModelExtensions.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static class TaxonomyLeafModelExtensions
    {
        public static HtmlString GetDisplayNameAsUrl(this TaxonomyLeaf taxonomyLeaf)
        {
            return UrlTemplate.MakeHrefString(taxonomyLeaf.GetSummaryUrl(), taxonomyLeaf.DisplayName);
        }

        public static string GetSummaryUrl(this TaxonomyLeaf taxonomyLeaf)
        {
            return SitkaRoute<TaxonomyLeafController>.BuildUrlFromExpression(x => x.Detail(taxonomyLeaf.TaxonomyLeafID));
        }

        public static string GetDeleteUrl(this TaxonomyLeaf taxonomyLeaf)
        {
            return SitkaRoute<TaxonomyLeafController>.BuildUrlFromExpression(c => c.DeleteTaxonomyLeaf(taxonomyLeaf.TaxonomyLeafID));
        }

        public static IEnumerable<SelectListItem> ToGroupedSelectList(this List<TaxonomyLeaf> taxonomyLeafs)
        {
            var selectListItems = new List<SelectListItem>();
            var groups = new Dictionary<string, SelectListGroup>();

            if (MultiTenantHelpers.GetNumberOfTaxonomyTiers() == 3)
            {
                BuildThreeTierSelectList(taxonomyLeafs, groups, selectListItems);    
            }
            else if (MultiTenantHelpers.GetNumberOfTaxonomyTiers() == 2)
            {
                foreach (var taxonomyTierTwoGrouping in taxonomyLeafs.GroupBy(x => x.TaxonomyTierTwo).OrderBy(x => x.Key.DisplayName))
                {
                    var taxonomyTierTwo = taxonomyTierTwoGrouping.Key;
                    var selectListGroup = new SelectListGroup() { Name = taxonomyTierTwo.DisplayName };
                    groups.Add(taxonomyTierTwo.DisplayName, selectListGroup);

                    foreach (var taxonomyLeaf in taxonomyTierTwoGrouping.OrderBy(x => x.DisplayName))
                    {
                        selectListItems.Add(new SelectListItem() { Value = taxonomyLeaf.TaxonomyLeafID.ToString(), Text = taxonomyLeaf.DisplayName, Group = selectListGroup });
                    }
                }
            }
            else
            {
                return taxonomyLeafs.ToSelectListWithEmptyFirstRow(m=> m.TaxonomyLeafID.ToString(), m=> m.DisplayName, "Select the " + MultiTenantHelpers.GetTaxonomyLeafDisplayNameForProject());
            }
            
            return selectListItems;
        }

        private static void BuildThreeTierSelectList(List<TaxonomyLeaf> taxonomyLeafs, Dictionary<string, SelectListGroup> groups, List<SelectListItem> selectListItems)
        {
            foreach (var taxonomyTrunkGrouping in taxonomyLeafs.GroupBy(x => x.TaxonomyTierTwo.TaxonomyTrunk).OrderBy(x => x.Key.DisplayName))
            {                
                foreach (var taxonomyTierTwoGrouping in taxonomyTrunkGrouping.GroupBy(x => x.TaxonomyTierTwo).OrderBy(x => x.Key.DisplayName))
                {
                    var taxonomyTierTwo = taxonomyTierTwoGrouping.Key;
                    var displayName = $"{taxonomyTierTwo.TaxonomyTrunk.DisplayName} - {taxonomyTierTwo.DisplayName}";
                    var selectListGroup = new SelectListGroup() {Name = displayName};
                    groups.Add(displayName, selectListGroup);
                    
                    foreach (var taxonomyLeaf in taxonomyTierTwoGrouping.OrderBy(x => x.DisplayName))
                    {
                        selectListItems.Add(new SelectListItem() {Value = taxonomyLeaf.TaxonomyLeafID.ToString(), Text = taxonomyLeaf.DisplayName, Group = selectListGroup });
                    }
                }
            }
        }
    }
}
