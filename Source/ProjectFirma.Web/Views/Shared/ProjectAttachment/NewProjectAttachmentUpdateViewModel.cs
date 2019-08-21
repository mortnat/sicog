﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectAttachment
{
    // exists because validating a document requires making sure its name is unique, and to do that requires knowing if it's a Attachment or a Attachment Update
    public class NewProjectAttachmentUpdateViewModel : NewProjectAttachmentViewModel
    {


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public NewProjectAttachmentUpdateViewModel() { }

        public NewProjectAttachmentUpdateViewModel(ProjectUpdateBatch projectUpdateBatch)
        {
            ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            CheckForNotNullProjectUpdateBatchId();
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            CheckForNotNullProjectUpdateBatchId();
            var validationResults = new List<ValidationResult>();

            if (HttpRequestStorage.DatabaseEntities.ProjectAttachmentUpdates.Where(x => x.ProjectUpdateBatchID == ProjectUpdateBatchID)
                .Any(x => x.DisplayName.ToLower() == DisplayName.ToLower()))
            {
                validationResults.Add(new SitkaValidationResult<NewProjectAttachmentViewModel, string>($"The Display Name must be unique for each Attachment attached to a {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update", m => m.DisplayName));
            }

            return validationResults;
        }

        public void UpdateModel(ProjectUpdateBatch projectUpdateBatch, Person currentPerson)
        {
            CheckForNotNullProjectUpdateBatchId();
            var fileResource = FileResourceModelExtensions.CreateNewFromHttpPostedFile(UploadedFile, currentPerson);
            HttpRequestStorage.DatabaseEntities.AllFileResources.Add(fileResource);
            var projectAttachment = new ProjectAttachmentUpdate(projectUpdateBatch.ProjectUpdateBatchID, fileResource.FileResourceID, AttachmentRelationshipTypeID, DisplayName)
            {
                Description = Description
            };
            projectUpdateBatch.ProjectAttachmentUpdates.Add(projectAttachment);
        }

        protected void CheckForNotNullProjectUpdateBatchId()
        {
            Check.Invariant(this.ProjectUpdateBatchID.HasValue, "ProjectUpdateBatchID must have a value");
        }
    }
}
