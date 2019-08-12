﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
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

        public NewProjectAttachmentUpdateViewModel(ProjectFirmaModels.Models.ProjectUpdateBatch projectUpdateBatch)
        {
            ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            CheckForValidProjectIdOrProjectUpdateId();
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            CheckForValidProjectIdOrProjectUpdateId();
            var validationResults = new List<ValidationResult>();

            if (HttpRequestStorage.DatabaseEntities.ProjectAttachmentUpdates.Where(x => x.ProjectUpdateBatchID == ProjectUpdateBatchID)
                .Any(x => x.DisplayName.ToLower() == DisplayName.ToLower()))
            {
                validationResults.Add(new SitkaValidationResult<NewProjectAttachmentViewModel, string>($"The Display Name must be unique for each Attachment attached to a {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update", m => m.DisplayName));
            }

            return validationResults;
        }
    }
}
