﻿using System.Collections.Generic;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Shared.ProjectAttachment
{
    public class ProjectAttachmentsDetailViewData
    {

        public bool ShowDownload { get; }

        public ProjectFirmaModels.Models.Project Project { get; set; }

        public Person CurrentPerson { get; set; }


        public List<EntityAttachment> Attachments { get; }
        public string AddAttachmentUrl { get; }
        public string ProjectName { get; }
        public bool CanEditAttachments { get; }
        public List<ProjectFirmaModels.Models.AttachmentRelationshipType> AttachmentRelationshipTypes { get; }

        public string AttachmentRelationshipTypesIndexUrl { get; }

        public ProjectAttachmentsDetailViewData(List<EntityAttachment> attachments, string addAttachmentUrl, string projectName, bool canEditAttachments, List<ProjectFirmaModels.Models.AttachmentRelationshipType> attachmentRelationshipTypes, Person currentPerson)
        {
            CurrentPerson = currentPerson;
            Attachments = attachments;
            AddAttachmentUrl = addAttachmentUrl;
            ProjectName = projectName;
            CanEditAttachments = canEditAttachments;
            ShowDownload = true;
            AttachmentRelationshipTypesIndexUrl = new AttachmentRelationshipTypeManageFeature().HasPermissionByPerson(CurrentPerson) ? SitkaRoute<AttachmentRelationshipTypeController>.BuildUrlFromExpression(x => x.Index()) : string.Empty;
            AttachmentRelationshipTypes = attachmentRelationshipTypes;
        }

    }
}