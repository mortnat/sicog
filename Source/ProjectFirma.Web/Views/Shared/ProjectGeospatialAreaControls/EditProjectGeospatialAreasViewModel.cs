﻿/*-----------------------------------------------------------------------
<copyright file="EditProjectGeospatialAreasViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectGeospatialAreaControls
{
    public class EditProjectGeospatialAreasViewModel : FormViewModel, IValidatableObject
    {
        [DisplayName("Project GeospatialAreas")]
        public IEnumerable<int> GeospatialAreaIDs { get; set; }

        [DisplayName("Notes")]
        [StringLength(Models.Project.FieldLengths.ProjectGeospatialAreaNotes)]
        public string ProjectGeospatialAreaNotes { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectGeospatialAreasViewModel()
        {
        }

        public EditProjectGeospatialAreasViewModel(List<int> geospatialAreaIDs, string projectGeospatialAreaNotes)
        {
            GeospatialAreaIDs = geospatialAreaIDs;
            ProjectGeospatialAreaNotes = projectGeospatialAreaNotes;
        }

        public void UpdateModel(Models.Project project, List<ProjectGeospatialArea> currentProjectGeospatialAreas, IList<ProjectGeospatialArea> allProjectGeospatialAreas)
        {
            var newProjectGeospatialAreas = GeospatialAreaIDs?.Select(x => new ProjectGeospatialArea(project.ProjectID, x)).ToList() ?? new List<ProjectGeospatialArea>();
            currentProjectGeospatialAreas.Merge(newProjectGeospatialAreas, allProjectGeospatialAreas, (x, y) => x.ProjectID == y.ProjectID && x.GeospatialAreaID == y.GeospatialAreaID);
            project.ProjectGeospatialAreaNotes = ProjectGeospatialAreaNotes;
        }

        public void UpdateModel(Models.ProjectUpdateBatch project, List<ProjectGeospatialAreaUpdate> currentProjectGeospatialAreas, IList<ProjectGeospatialAreaUpdate> allProjectGeospatialAreas)
        {
            var newProjectGeospatialAreas = GeospatialAreaIDs?.Select(x => new ProjectGeospatialAreaUpdate(project.ProjectUpdateBatchID, x)).ToList() ?? new List<ProjectGeospatialAreaUpdate>();
            currentProjectGeospatialAreas.Merge(newProjectGeospatialAreas, allProjectGeospatialAreas, (x, y) => x.ProjectUpdateBatchID == y.ProjectUpdateBatchID && x.GeospatialAreaID == y.GeospatialAreaID);
            project.ProjectUpdate.ProjectGeospatialAreaNotes = ProjectGeospatialAreaNotes;
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var errors = new List<ValidationResult>();
            var noGeospatialAreasSelected = GeospatialAreaIDs == null || GeospatialAreaIDs.Count().Equals(0);
            if (noGeospatialAreasSelected && string.IsNullOrWhiteSpace(ProjectGeospatialAreaNotes))
            {
                errors.Add(
                    new SitkaValidationResult<EditProjectGeospatialAreasViewModel, string>(
                        $"Select at least one {Models.FieldDefinition.GeospatialArea.GetFieldDefinitionLabel()} or provide explanatory information in the Notes section if there are no applicable geospatialAreas for this Project.",
                        x => x.ProjectGeospatialAreaNotes));
            }

            return errors;
        }
    }
}
