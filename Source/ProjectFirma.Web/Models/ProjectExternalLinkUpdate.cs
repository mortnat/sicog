﻿/*-----------------------------------------------------------------------
<copyright file="ProjectExternalLinkUpdate.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectExternalLinkUpdate : IEntityExternalLink, IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"ProjectUpdateBatch: {ProjectUpdateBatchID}, External Link Label: {ExternalLinkLabel}, External Link Url: {ExternalLinkLabel}";
        }

        public HtmlString GetExternalLinkAsUrl()
        {
            return UrlTemplate.MakeHrefString(ExternalLinkUrl, ExternalLinkLabel, new Dictionary<string, string> { { "target", "_blank" } });
        }
    }
}
