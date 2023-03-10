using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectAttachment
{
    public class NewProjectAttachmentViewModel : IValidatableObject
    {
        [Required]
        [DisplayName("File")]
        public HttpPostedFileBase UploadedFile { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.AttachmentType)]
        public int AttachmentTypeID { get; set; }

        [Required]
        [DisplayName("Display Name")]
        [StringLength(ProjectFirmaModels.Models.ProjectAttachment.FieldLengths.DisplayName, ErrorMessage = "200 character maximum")]
        public string DisplayName { get; set; }

        [DisplayName("Description")]
        [StringLength(ProjectFirmaModels.Models.ProjectAttachment.FieldLengths.Description, ErrorMessage = "1000 character maximum.")]
        public string Description { get; set; }


        public int? ProjectID { get; set; }
        //8/21/2019 TK - this is here so we can post this ID and use it to validate the display names
        public int? ProjectUpdateBatchID { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public NewProjectAttachmentViewModel() { }
        public NewProjectAttachmentViewModel(ProjectFirmaModels.Models.Project project)
        {
            ProjectID = project.ProjectID;
            CheckForNotNullProjectId();
        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project, FirmaSession currentFirmaSession)
        {
            CheckForNotNullProjectId();
            var fileResourceInfo = FileResourceModelExtensions.CreateNewFromHttpPostedFile(UploadedFile, currentFirmaSession.Person);
            HttpRequestStorage.DatabaseEntities.AllFileResourceInfos.Add(fileResourceInfo);
            var projectAttachment = new ProjectFirmaModels.Models.ProjectAttachment(project.ProjectID, fileResourceInfo.FileResourceInfoID, AttachmentTypeID, DisplayName)
            {
                Description = Description
            };
            project.ProjectAttachments.Add(projectAttachment);
        }

        

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            CheckForNotNullProjectId();
            var validationResults = new List<ValidationResult>();
            FileResourceModelExtensions.ValidateFileSize(UploadedFile, validationResults, "File");

            // Attachments must have unique display names at the project and attachment type level
            if (HttpRequestStorage.DatabaseEntities.ProjectAttachments.Any(x => x.ProjectID == ProjectID && x.DisplayName == DisplayName && x.AttachmentTypeID == AttachmentTypeID))
            {
                AttachmentTypePrimaryKey attachmentTypePrimaryKey = AttachmentTypeID;
                var attachmentType = attachmentTypePrimaryKey.EntityObject;

                validationResults.Add(new SitkaValidationResult<NewProjectAttachmentViewModel, string>($"There is already an attachment with the display name \"{DisplayName}\" under the {attachmentType.AttachmentTypeName} attachment type for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}.", m=>m.DisplayName));
            }

            return validationResults;
        }


        protected void CheckForNotNullProjectId()
        {
            Check.Invariant(this.ProjectID.HasValue, "ProjectID must have a value");
        }
    }
}
