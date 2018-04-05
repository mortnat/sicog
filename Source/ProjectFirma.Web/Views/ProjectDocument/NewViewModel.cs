﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectDocument
{
    public class NewViewModel
    {
        [Required]
        [DisplayName("File")]
        [SitkaFileExtensions("pdf|zip|doc|docx|xls|xlsx|jpg|png")]
        public HttpPostedFileBase File { get; set; }

        [Required]
        [DisplayName("Display Name")]
        [MaxLength(Models.ProjectDocument.FieldLengths.DisplayName)]
        public string DisplayName { get; set; }

        [DisplayName("Description")]
        [MaxLength(Models.ProjectDocument.FieldLengths.Description)]
        public string Description { get; set; }

        public void UpdateModel(Models.Project project, Person currentPerson)
        {
            var fileResource = FileResource.CreateNewFromHttpPostedFile(File, currentPerson);
            HttpRequestStorage.DatabaseEntities.AllFileResources.Add(fileResource);
            var projectDocument = new Models.ProjectDocument(project.ProjectID, fileResource.FileResourceID, DisplayName)
            {
                Description = Description
            };
            project.ProjectDocuments.Add(projectDocument);
        }
    }
}
