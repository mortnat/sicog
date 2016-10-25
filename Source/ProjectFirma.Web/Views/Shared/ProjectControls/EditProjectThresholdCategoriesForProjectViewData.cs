﻿using System.Collections.Generic;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public class EditProjectThresholdCategoriesForProjectViewData : FirmaUserControlViewData
    {
        public readonly List<Models.ThresholdCategory> ThresholdCategories;
        public readonly string ProjectName;

        public EditProjectThresholdCategoriesForProjectViewData(Models.Project project, List<Models.ThresholdCategory> thresholdCategories)
        {
            ProjectName = project.DisplayName;
            ThresholdCategories = thresholdCategories;
        }

        public EditProjectThresholdCategoriesForProjectViewData(Models.ProposedProject proposedProject, List<Models.ThresholdCategory> thresholdCategories)
        {
            ProjectName = proposedProject.DisplayName;
            ThresholdCategories = thresholdCategories;
        }
    }
}