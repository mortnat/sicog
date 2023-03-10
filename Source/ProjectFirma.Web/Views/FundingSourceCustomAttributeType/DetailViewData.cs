using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.FundingSourceCustomAttributeType
{
    public class DetailViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.FundingSourceCustomAttributeType FundingSourceCustomAttributeType { get; }
        public bool UserHasFundingSourceCustomAttributeTypeManagePermissions { get; }
        public string ProjectTypeGridName { get; }
        public string ProjectTypeGridDataUrl { get; }
        public string ManageUrl { get; }

        public DetailViewData(FirmaSession currentFirmaSession,
            ProjectFirmaModels.Models.FundingSourceCustomAttributeType fundingSourceCustomAttributeType) : base(currentFirmaSession)
        {
            FundingSourceCustomAttributeType = fundingSourceCustomAttributeType;
            EntityName = FieldDefinitionEnum.FundingSourceCustomAttribute.ToType().GetFieldDefinitionLabelPluralized();
            PageTitle = fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeName;
            ManageUrl = SitkaRoute<FundingSourceCustomAttributeTypeController>.BuildUrlFromExpression(c => c.Manage());

            UserHasFundingSourceCustomAttributeTypeManagePermissions = new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);

            ProjectTypeGridName = "fundingSourceTypeGridForAttribute";
            ProjectTypeGridDataUrl = "#";
        }
    }
}
