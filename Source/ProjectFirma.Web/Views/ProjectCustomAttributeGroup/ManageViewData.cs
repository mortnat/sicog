using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ProjectCustomAttributeType;

namespace ProjectFirma.Web.Views.ProjectCustomAttributeGroup
{
    public class ManageViewData : FirmaViewData
    {
        public ProjectCustomAttributeGroupGridSpec GridSpec { get; }
        public string GridName { get; }
        public string GridDataUrl { get; }
        public string NewProjectCustomAttributeGroupUrl { get; }
        public string EditSortOrderUrl { get; }
        public bool HasManagePermissions { get; }

        public ManageViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage)
            : base(currentFirmaSession, firmaPage)
        {
            EntityName = "Attribute Group";
            PageTitle = $"{FieldDefinitionEnum.ProjectCustomAttribute.ToType().GetFieldDefinitionLabelPluralized()} Groups";

            NewProjectCustomAttributeGroupUrl = SitkaRoute<ProjectCustomAttributeGroupController>.BuildUrlFromExpression(t => t.New());
            GridSpec = new ProjectCustomAttributeGroupGridSpec()
            {
                ObjectNameSingular = "Attribute Group",
                ObjectNamePlural = "Attribute Groups",
                SaveFiltersInCookie = true
            };

            GridName = "projectCustomAttributeGroupGrid";
            GridDataUrl = SitkaRoute<ProjectCustomAttributeGroupController>.BuildUrlFromExpression(c => c.ProjectCustomAttributeGroupGridJsonData());

            HasManagePermissions = new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);

            EditSortOrderUrl = SitkaRoute<ProjectCustomAttributeGroupController>.BuildUrlFromExpression(x => x.EditSortOrder());
        }
    }
}
