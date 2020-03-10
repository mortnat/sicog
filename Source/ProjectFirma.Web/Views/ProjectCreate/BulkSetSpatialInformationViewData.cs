﻿using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared.ProjectGeospatialAreaControls;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class BulkSetSpatialInformationViewData : ProjectCreateViewData
    {
        public BulkSetProjectSpatialInformationViewData BulkSetProjectSpatialInformationViewData { get; set; }
        public bool ShowCommentsSection { get; }
        public bool CanEditComments { get; }

        public BulkSetSpatialInformationViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Project project, ProposalSectionsStatus proposalSectionStatus, BulkSetProjectSpatialInformationViewData quickSetViewData) 
            : base(currentFirmaSession, project, ProjectCreateSection.BulkSetSpatialInformation.ProjectCreateSectionDisplayName, proposalSectionStatus)
        {
            BulkSetProjectSpatialInformationViewData = quickSetViewData;
            ShowCommentsSection = project.IsPendingApproval() || (project.BasicsComment != string.Empty &&
                                                                  project.ProjectApprovalStatus == ProjectApprovalStatus.Returned);
            CanEditComments = project.IsPendingApproval() && new ProjectEditAsAdminRegardlessOfStageFeature().HasPermission(currentFirmaSession, project).HasPermission;
        }

        
    }
}
