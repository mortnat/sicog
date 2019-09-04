﻿/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasuresValidationResult.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class CustomAttributesValidationResult
    {
        
        private readonly List<string> _warningMessages;

        public CustomAttributesValidationResult(IProject project)
        {
            _warningMessages = new List<string>();
            // Validate that required Custom Attributes are present
            var requiredCustomAttributeTypeIDs = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes.Where(x => x.IsRequired).Select(x => x.ProjectCustomAttributeTypeID).ToList();
            var projectrequiredCustomAttributeTypeIDs = project.GetProjectCustomAttributes().Where(x => x.ProjectCustomAttributeType.IsRequired).Select(x => x.ProjectCustomAttributeTypeID).ToList();
            if (requiredCustomAttributeTypeIDs.Any(x => !projectrequiredCustomAttributeTypeIDs.Contains(x)))
            {
                _warningMessages.Add(FirmaValidationMessages.RequiredCustomAttribute);
            }
        }

        public CustomAttributesValidationResult(string customErrorMessage)
        {
            _warningMessages = new List<string> {customErrorMessage};
        }

        public List<string> GetWarningMessages()
        {
            return _warningMessages;
        }

        public bool IsValid => !_warningMessages.Any();
    }
}
