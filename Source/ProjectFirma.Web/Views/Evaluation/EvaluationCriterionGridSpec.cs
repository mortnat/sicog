﻿using System.Web;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Evaluation
{
    public class EvaluationCriterionGridSpec : GridSpec<EvaluationCriterion>
    {
        public EvaluationCriterionGridSpec(FirmaSession currentFirmaSession)
        {

            Add(string.Empty, ec => MakeDeleteIconAndLinkBootstrapIfAvailable(currentFirmaSession, ec), 30, DhtmlxGridColumnFilterType.None);
            Add(string.Empty, ec => MakeEditIconAndLinkBootstrapIfAvailable(currentFirmaSession, ec), 30, DhtmlxGridColumnFilterType.None);

            Add("Name", a => a.EvaluationCriterionName, 220, DhtmlxGridColumnFilterType.Text);
            Add("Definition", a => a.EvaluationCriterionDefinition, 220, DhtmlxGridColumnFilterType.Text);
            Add("Number of Criterion Values", a => a.GetNumberOfEvaluationCriterionValues().ToString(), 40, DhtmlxGridColumnFilterType.SelectFilterStrict);

        }

        private static HtmlString MakeDeleteIconAndLinkBootstrapIfAvailable(FirmaSession currentFirmaSession, EvaluationCriterion evaluationCriterion)
        {
            if (EvaluationCriterionManageFeature.HasEvaluationCriterionManagePermission(currentFirmaSession, evaluationCriterion))
            {
                return DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(evaluationCriterion.GetDeleteUrl(), true, evaluationCriterion.CanDelete());
            }
            return new HtmlString(string.Empty);
        }

        private static HtmlString MakeEditIconAndLinkBootstrapIfAvailable(FirmaSession currentFirmaSession, EvaluationCriterion evaluationCriterion)
        {
            if (EvaluationManageFeature.HasEvaluationManagePermission(currentFirmaSession, evaluationCriterion.Evaluation))
            {
                return DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(evaluationCriterion.GetEditUrl(), $"Edit {FieldDefinitionEnum.EvaluationCriterion.ToType().GetFieldDefinitionLabel()} '{evaluationCriterion.EvaluationCriterionName}'");
            }
            return new HtmlString(string.Empty);
        }
    }
}