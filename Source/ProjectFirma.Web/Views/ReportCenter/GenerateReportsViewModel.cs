﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ReportCenter
{
    public class GenerateReportsViewModel : FormViewModel
    {
        [Required]
        public List<int> ProjectIDList { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ReportCenterSelectedReportTemplate)]
        public int ReportTemplateID { get; set; }

        public GenerateReportsViewModel()
        {
            ProjectIDList = new List<int>();
        }
    }
}