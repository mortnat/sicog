﻿/*-----------------------------------------------------------------------
<copyright file="SupportFormViewData.cs" company="Tahoe Regional Planning Agency">
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
using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared
{
    public class SupportFormViewData
    {
        public readonly List<SupportRequestTypeSimple> SupportRequestTypeSimples;
        public readonly string SuccessMessage;
        public readonly bool IsUserAnonymous;
        public readonly IEnumerable<SelectListItem> SupportRequestTypes;

        public SupportFormViewData(string successMessage, bool isUserAnonymous, IEnumerable<SelectListItem> supportRequestTypes, List<SupportRequestTypeSimple> supportRequestTypeSimples)
        {
            SupportRequestTypeSimples = supportRequestTypeSimples;
            SuccessMessage = successMessage;
            IsUserAnonymous = isUserAnonymous;
            SupportRequestTypes = supportRequestTypes;
        }
    }
}
