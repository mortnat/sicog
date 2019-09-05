﻿/*-----------------------------------------------------------------------
<copyright file="CustomAttributesViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class CustomAttributesViewModel : EditProjectCustomAttributesViewModel
    {
        [DisplayName("Reviewer Comments")]
        [StringLength(ProjectUpdateBatch.FieldLengths.CustomAttributesComment)]
        public string Comments { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public CustomAttributesViewModel()
        {
        }

        public CustomAttributesViewModel(ProjectFirmaModels.Models.ProjectUpdateBatch projectUpdateBatch) : base(projectUpdateBatch)
        {
            Project = projectUpdateBatch.ProjectUpdate;
            Comments = projectUpdateBatch.CustomAttributesComment;
        }

        public void UpdateModel(ProjectFirmaModels.Models.ProjectUpdateBatch projectUpdateBatch, Person currentPerson)
        {
            ProjectCustomAttributes?.UpdateModel(projectUpdateBatch.ProjectUpdate, currentPerson);
        }
    }    
}
