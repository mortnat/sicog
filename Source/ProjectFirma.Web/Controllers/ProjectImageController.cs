﻿/*-----------------------------------------------------------------------
<copyright file="ProjectImageController.cs" company="Tahoe Regional Planning Agency">
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
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ProjectImage;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectImageController : FirmaBaseController
    {
        [HttpGet]
        [ProjectImageNewFeature]
        public PartialViewResult New(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new NewViewModel();
            return ViewNew(project, viewModel);
        }

        private PartialViewResult ViewNew(Project project, NewViewModel viewModel)
        {
            var projectImageTimings = ProjectImageTiming.All.ToSelectListWithEmptyFirstRow(x => x.ProjectImageTimingID.ToString(CultureInfo.InvariantCulture), x => x.ProjectImageTimingDisplayName);
            var viewData = new NewViewData(project, projectImageTimings);
            return RazorPartialView<New, NewViewData, NewViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectImageNewFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(ProjectPrimaryKey projectPrimaryKey, NewViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewNew(project, viewModel);
            }
            var userHasPermissionToSetKeyPhoto = new ProjectImageSetKeyPhotoFeature().HasPermissionByPerson(CurrentPerson);
            var projectImage = new ProjectImage(project, userHasPermissionToSetKeyPhoto);
            viewModel.UpdateModel(projectImage, CurrentPerson);
            project.ProjectImages.Add(projectImage);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProjectImageEditOrDeleteFeature]
        public PartialViewResult Edit(ProjectImagePrimaryKey projectImagePrimaryKey)
        {
            var projectImage = projectImagePrimaryKey.EntityObject;
            var viewModel = new EditViewModel(projectImage);
            return ViewEdit(projectImage, viewModel);
        }

        private PartialViewResult ViewEdit(ProjectImage projectImage, EditViewModel viewModel)
        {
            var projectImageTimings = ProjectImageTiming.All.ToSelectListWithEmptyFirstRow(x => x.ProjectImageTimingID.ToString(CultureInfo.InvariantCulture), x => x.ProjectImageTimingDisplayName);
            var viewData = new EditViewData(projectImage, projectImageTimings);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectImageEditOrDeleteFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ProjectImagePrimaryKey projectImagePrimaryKey, EditViewModel viewModel)
        {
            var projectImage = projectImagePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(projectImage, viewModel);
            }
            viewModel.UpdateModel(projectImage, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProjectImageEditOrDeleteFeature]
        public PartialViewResult DeleteProjectImage(ProjectImagePrimaryKey projectImagePrimaryKey)
        {
            var projectImage = projectImagePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(projectImage.ProjectImageID);
            return ViewDeleteProjectImage(projectImage, viewModel);
        }

        private PartialViewResult ViewDeleteProjectImage(ProjectImage projectImage, ConfirmDialogFormViewModel viewModel)
        {
            var confirmMessage = string.Format("Are you sure you want to delete this image from Project '{0}'? ({1})", projectImage.Project.DisplayName, projectImage.Caption);
            var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectImageEditOrDeleteFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteProjectImage(ProjectImagePrimaryKey projectImagePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var projectImage = projectImagePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteProjectImage(projectImage, viewModel);
            }
            Project.DeleteProjectImages(new[] { projectImage });
            // reset key photo if needed
            var userHasPermissionToSetKeyPhoto = new ProjectImageSetKeyPhotoFeature().HasPermissionByPerson(CurrentPerson);
            if (userHasPermissionToSetKeyPhoto && projectImage.IsKeyPhoto)
            {
                var project = projectImage.Project;
                var firstNonKeyPhoto = project.ProjectImages.FirstOrDefault(x => !x.IsKeyPhoto && x.ProjectImageID != projectImage.ProjectImageID);
                if (firstNonKeyPhoto != null)
                {
                    firstNonKeyPhoto.SetAsKeyPhoto(project.ProjectImages.Except(new[] { firstNonKeyPhoto, projectImage }).ToList());
                }
            }
            return new ModalDialogFormJsonResult();
        }

        [HttpPost]
        [ProjectImageSetKeyPhotoFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult SetKeyPhoto(ProjectImagePrimaryKey projectImagePrimaryKey)
        {
            var projectImage = projectImagePrimaryKey.EntityObject;
            projectImage.SetAsKeyPhoto();
            return new ModalDialogFormJsonResult();
        }
    }
}
