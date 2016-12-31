﻿using System.Linq;
using System.Web;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.Project
{
    public class BasicProjectInfoGridSpec : GridSpec<Models.Project>
    {
        public BasicProjectInfoGridSpec(Person currentPerson, bool allowTaggingFunctionality)
        {
            var userHasTagManagePermissions = new TagManageFeature().HasPermissionByPerson(currentPerson);
            var userHasTagViewPermissions = new TagViewFeature().HasPermissionByPerson(currentPerson);

            if (userHasTagManagePermissions && allowTaggingFunctionality)
            {
                BulkTagModalDialogForm = new BulkTagModalDialogForm(SitkaRoute<TagController>.BuildUrlFromExpression(x => x.BulkTagProjects(null)));
                AddCheckBoxColumn();
                Add("ProjectID", x => x.ProjectID, 0);
            }

            Add(string.Empty, x => UrlTemplate.MakeHrefString(x.GetFactSheetUrl(), FirmaDhtmlxGridHtmlHelpers.FactSheetIcon.ToString()), 30);
            Add(Models.FieldDefinition.ProjectName.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.GetDetailUrl(), x.ProjectName), 300, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.LeadImplementer.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.LeadImplementer != null ? x.LeadImplementer.GetSummaryUrl() : null, x.LeadImplementerName), 140);
            Add(Models.FieldDefinition.ProjectStage.ToGridHeaderStringWider(), x => x.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.PlanningDesignStartYear.ToGridHeaderString(), x => x.PlanningDesignStartYear, 90, DhtmlxGridColumnFormatType.None);
            Add(Models.FieldDefinition.ImplementationStartYear.ToGridHeaderString(), x => x.ImplementationStartYear, 115, DhtmlxGridColumnFormatType.None);
            Add(Models.FieldDefinition.CompletionYear.ToGridHeaderString(), x => x.CompletionYear, 90, DhtmlxGridColumnFormatType.None);
            Add(Models.FieldDefinition.FundingType.ToGridHeaderString(), x => x.FundingType.FundingTypeShortName, 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.EstimatedTotalCost.ToGridHeaderString(), x => x.EstimatedTotalCost, 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(Models.FieldDefinition.SecuredFunding.ToGridHeaderString(), x => x.SecuredFunding, 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(Models.FieldDefinition.UnfundedNeed.ToGridHeaderString(), x => x.UnfundedNeed, 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(Models.FieldDefinition.Region.ToGridHeaderString(), a => a.ProjectLocationTypeDisplay, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("State", a => a.ProjectLocationStateProvince, 95, DhtmlxGridColumnFilterType.Text);
            Add("Jurisdiction", a => a.ProjectLocationJurisdiction, 95, DhtmlxGridColumnFilterType.Text);
            Add("Watershed", a => a.ProjectLocationWatershed, 95, DhtmlxGridColumnFilterType.Text);
            Add(Models.FieldDefinition.ProjectDescription.ToGridHeaderString(), x => x.ProjectDescription, 300);
            if (userHasTagViewPermissions)
            {
                Add("Tags", x => new HtmlString(!x.ProjectTags.Any() ? string.Empty : string.Join(", ", x.ProjectTags.Select(pt => pt.Tag.DisplayNameAsUrl))), 100, DhtmlxGridColumnFilterType.Html);    
            }
            
        }
    }
}