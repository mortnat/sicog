﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.ProjectAttachment;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ProjectAttachment;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectAttachmentController : FirmaBaseController
    {

        
        [FirmaAdminFeature]
        public ViewResult ProjectAttachmentIndex()
        {
            var viewData = new ProjectAttachmentIndexViewData(CurrentPerson);
            return RazorView<ProjectAttachmentIndex, ProjectAttachmentIndexViewData>(viewData);
        }

        [FirmaAdminFeature]
        public GridJsonNetJObjectResult<ProjectAttachment> ProjectAttachmentGridJsonData()
        {
            var hasManagePermissions = new ProjectAttachmentEditAsAdminFeature().HasPermissionByPerson(CurrentPerson);
            var gridSpec = new ProjectAttachmentGridSpec(hasManagePermissions);
            var projectAttachments = HttpRequestStorage.DatabaseEntities.ProjectAttachments.ToList().OrderBy(x => x.DisplayName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ProjectAttachment>(projectAttachments, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [ProjectEditAsAdminRegardlessOfStageFeature]
        public PartialViewResult New(ProjectPrimaryKey projectPrimaryKey)
        {
            var viewModel = new NewProjectAttachmentViewModel(projectPrimaryKey.EntityObject);
            return ViewNew(viewModel);
        }

        [HttpPost]
        [ProjectEditAsAdminRegardlessOfStageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(ProjectPrimaryKey projectPrimaryKey, NewProjectAttachmentViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewNew(viewModel);
            }
            
            viewModel.UpdateModel(project, CurrentPerson);

            SetMessageForDisplay($"Successfully created new document \"{viewModel.DisplayName}\" for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} \"{project.ProjectName}\".");

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNew(NewProjectAttachmentViewModel viewModel)
        {
            IEnumerable<AttachmentRelationshipType> attachmentRelationshipTypes = null;
            if (viewModel.ProjectID.HasValue)
            {
                //attempt to get the project
                var project = HttpRequestStorage.DatabaseEntities.Projects.FirstOrDefault(x => x.ProjectID == viewModel.ProjectID.Value);
                if (project != null)
                {
                    attachmentRelationshipTypes = project.GetValidAttachmentRelationshipTypesForForms();
                }


            }
            else if (viewModel.ProjectUpdateBatchID.HasValue)//if no project check for project update batch.
            {
                var projectUpdateBatch = HttpRequestStorage.DatabaseEntities.ProjectUpdateBatches.FirstOrDefault(x => x.ProjectUpdateBatchID == viewModel.ProjectUpdateBatchID.Value);
                if (projectUpdateBatch != null)
                {
                    attachmentRelationshipTypes = projectUpdateBatch.GetValidAttachmentRelationshipTypesForForms();
                }
            }

            Check.Assert(attachmentRelationshipTypes != null, "Cannot find any valid attachment relationship types for this project.");
            var viewData = new NewProjectAttachmentViewData(attachmentRelationshipTypes);
            return RazorPartialView<NewProjectAttachment, NewProjectAttachmentViewData, NewProjectAttachmentViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectAttachmentEditAsAdminFeature]
        public PartialViewResult Edit(ProjectAttachmentPrimaryKey projectAttachmentPrimaryKey)
        {
            var projectAttachment = projectAttachmentPrimaryKey.EntityObject;
            var viewModel = new EditProjectAttachmentsViewModel(projectAttachment);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [ProjectAttachmentEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ProjectAttachmentPrimaryKey projectAttachmentPrimaryKey, EditProjectAttachmentsViewModel viewModel)
        {
            var projectAttachment = projectAttachmentPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            
            viewModel.UpdateModel(projectAttachment);

            SetMessageForDisplay($"Successfully update document \"{projectAttachment.DisplayName}\".");

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditProjectAttachmentsViewModel viewModel)
        {
            var viewData = new EditProjectAttachmentsViewData();
            return RazorPartialView<EditProjectAttachments, EditProjectAttachmentsViewData, EditProjectAttachmentsViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectAttachmentEditAsAdminFeature]
        public PartialViewResult Delete(ProjectAttachmentPrimaryKey projectAttachmentPrimaryKey)
        {
            var projectAttachment = projectAttachmentPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(projectAttachment.ProjectAttachmentID);
            return ViewDelete(projectAttachment, viewModel);
        }

        [HttpPost]
        [ProjectAttachmentEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Delete(ProjectAttachmentPrimaryKey projectAttachmentPrimaryKey,
            ConfirmDialogFormViewModel viewModel)
        {
            var projectAttachment = projectAttachmentPrimaryKey.EntityObject;
            var displayName = projectAttachment.DisplayName;
            if (!ModelState.IsValid)
            {
                return ViewDelete(projectAttachment, viewModel);
            }

            projectAttachment.Attachment.DeleteFull(HttpRequestStorage.DatabaseEntities);

            SetMessageForDisplay($"Successfully deleted document \"{displayName}\".");

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewDelete(ProjectAttachment projectAttachment, ConfirmDialogFormViewModel viewModel)
        {
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to delete \"{projectAttachment.DisplayName}\" from this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}?", true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }
    }
}
