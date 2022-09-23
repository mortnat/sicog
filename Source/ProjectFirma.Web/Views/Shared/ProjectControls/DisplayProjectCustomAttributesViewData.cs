﻿/*-----------------------------------------------------------------------
<copyright file="ProjectCustomAttributesViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public class DisplayProjectCustomAttributesViewData : FirmaUserControlViewData
    {
        //ProjectCustomAttributeTypes is here because the project Detail.cshtml uses this to check if it should output Project Custom Attributes
        public List<ProjectFirmaModels.Models.ProjectCustomAttributeType> ProjectCustomAttributeTypes { get; }
        public List<IProjectCustomAttribute> ProjectCustomAttributes { get; }
        public List<ProjectFirmaModels.Models.ProjectCustomAttributeGroup> ProjectCustomAttributeGroups { get; }

        public DisplayProjectCustomAttributesViewData(List<ProjectFirmaModels.Models.ProjectCustomAttributeType> projectCustomAttributeTypes, List<IProjectCustomAttribute> projectCustomAttributes, List<ProjectFirmaModels.Models.ProjectCustomAttributeGroup> projectCustomAttributeGroups)
        {
            ProjectCustomAttributeTypes = projectCustomAttributeTypes;
            ProjectCustomAttributeGroups = projectCustomAttributeGroups;
            ProjectCustomAttributes = projectCustomAttributes;
        }

    }
}
