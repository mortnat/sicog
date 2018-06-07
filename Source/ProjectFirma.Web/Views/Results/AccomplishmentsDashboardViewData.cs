﻿/*-----------------------------------------------------------------------
<copyright file="InvestmentByFundingOrganizationTypeViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/

using System.Collections.Generic;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.Results
{
    public class AccomplishmentsDashboardViewData : FirmaViewData
    {
        public string OrganizationDashboardSummaryUrl { get; }
        public string OrganizationAccomplishmentsUrl { get; }
        public string OrganizationDetailUrl { get; }
        public string SpendingByOrganizationTypeAndOrganizationUrl { get; }
        public string ParticipatingOrganizationsUrl { get; }

        public List<Models.Organization> Organizations { get; }
        public List<int> CalendarYears { get; }
        public int DefaultBeginYear { get; }
        public int DefaultEndYear { get; }
        public List<ITaxonomyTier> TaxonomyTiers { get; }
        public string ProjectStewardOrganizationTypeName { get; }
        public string TaxonomyTierDisplayName { get; }
        public bool HasSitkaAdminPermissions { get; set; }
        public string ConfigureAccomplishmentsDashboardUrl { get; set; }
        public TenantAttribute TenantAttribute { get; set; }

        public AccomplishmentsDashboardViewData(Person currentPerson, Models.FirmaPage firmaPage, TenantAttribute tenantAttribute,
            List<Models.Organization> organizations, List<int> calendarYears, int defaultBeginYear, int defaultEndYear,
            List<ITaxonomyTier> taxonomyTiers, TaxonomyLevel associatePerformanceMeasureTaxonomyLevel) : base(currentPerson, firmaPage)
        {
            var projectStewardOrganizationTypeName = Models.FieldDefinition.ProjectStewardOrganizationDisplayName
                .GetFieldDefinitionLabelPluralized();
            PageTitle = "Accomplishments Dashboard";
            TenantAttribute = tenantAttribute;
            Organizations = organizations;
            CalendarYears = calendarYears;
            DefaultBeginYear = defaultBeginYear;
            DefaultEndYear = defaultEndYear;
            TaxonomyTiers = taxonomyTiers;
            ParticipatingOrganizationsUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.ParticipatingOrganizations(UrlTemplate.Parameter1Int));
            OrganizationDashboardSummaryUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.OrganizationDashboardSummary(UrlTemplate.Parameter1Int));
            OrganizationAccomplishmentsUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.OrganizationAccomplishments(UrlTemplate.Parameter1Int, UrlTemplate.Parameter2Int));
            OrganizationDetailUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(x => x.Detail(UrlTemplate.Parameter1Int));
            SpendingByOrganizationTypeAndOrganizationUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.SpendingByOrganizationTypeByOrganization(UrlTemplate.Parameter1Int, UrlTemplate.Parameter2Int, UrlTemplate.Parameter3Int));
            ProjectStewardOrganizationTypeName = projectStewardOrganizationTypeName;
            TaxonomyTierDisplayName = associatePerformanceMeasureTaxonomyLevel.GetFieldDefinition().GetFieldDefinitionLabel();
            HasSitkaAdminPermissions = new SitkaAdminFeature().HasPermissionByPerson(CurrentPerson);
            ConfigureAccomplishmentsDashboardUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(c => c.ConfigureAccomplishmentsDashboard());
        }
    }
}
