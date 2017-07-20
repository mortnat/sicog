﻿/*-----------------------------------------------------------------------
<copyright file="FirmaViewData.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views
{
    public abstract class FirmaViewData
    {
        public List<LtInfoMenuItem> TopLevelLtInfoMenuItems;

        public readonly string FullProjectListUrl;
        public readonly string ProjectSearchUrl;
        public readonly string ProjectFindUrl;
        public string PageTitle;
        public string HtmlPageTitle;
        public string BreadCrumbTitle;
        public string EntityName;
        public readonly Models.FirmaPage FirmaPage;
        public readonly Person CurrentPerson;
        public readonly string FirmaHomeUrl;
        public readonly string LogInUrl;
        public readonly string LogOutUrl;
        public readonly string RequestSupportUrl;

        /// <summary>
        /// Call for page without associated FirmaPage
        /// </summary>
        protected FirmaViewData(Person currentPerson) : this(currentPerson, null)
        {
        }
     
        /// <summary>
        /// Call for page with associated FirmaPage
        /// </summary>
        protected FirmaViewData(Person currentPerson, Models.FirmaPage firmaPage)
        {
            FirmaPage = firmaPage;

            CurrentPerson = currentPerson;
            FirmaHomeUrl = SitkaRoute<HomeController>.BuildUrlFromExpression(c => c.Index());

            LogInUrl = FirmaHelpers.GenerateLogInUrlWithReturnUrl();
            LogOutUrl = FirmaHelpers.GenerateLogOutUrlWithReturnUrl();

            RequestSupportUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(c => c.Support());

            MakeFirmaMenu(currentPerson);

            FullProjectListUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.Index());
            ProjectSearchUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.Search(UrlTemplate.Parameter1String));
            ProjectFindUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.Find(string.Empty));
        }


        private void MakeFirmaMenu(Person currentPerson)
        {
            var homeMenuItem = LtInfoMenuItem.MakeItem(new SitkaRoute<HomeController>(c => c.Index()), currentPerson, "Home");

            TopLevelLtInfoMenuItems = new List<LtInfoMenuItem>
            {
                homeMenuItem,
                BuildAboutMenu(currentPerson),
                BuildProjectsMenu(currentPerson),
                BuildProgramInfoMenu(currentPerson),
                //BuildResultsMenu(currentPerson),
                BuildManageMenu(currentPerson)
            };

            TopLevelLtInfoMenuItems.ForEach(x => x.ExtraTopLevelMenuCssClasses = new List<string> { "navigation-root-item" });
            TopLevelLtInfoMenuItems.SelectMany(x => x.ChildMenus).ToList().ForEach(x => x.ExtraTopLevelMenuCssClasses = new List<string> { "navigation-dropdown-item" });
        }

        private static LtInfoMenuItem BuildAboutMenu(Person currentPerson)
        {
            var aboutMenu = new LtInfoMenuItem("About");
            aboutMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<HomeController>(c => c.About()), currentPerson, "About " + MultiTenantHelpers.GetTenantDisplayName()));
            aboutMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<HomeController>(c => c.Meetings()), currentPerson, "Meetings and Documents"));
            return aboutMenu;
        }

        private static LtInfoMenuItem BuildResultsMenu(Person currentPerson)
        {
            var resultsMenu = new LtInfoMenuItem("Results");
            resultsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ResultsController>(c => c.InvestmentByOrganizationType(null)), currentPerson, $"Investment by {Models.FieldDefinition.OrganizationType.GetFieldDefinitionLabel()}"));
            resultsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ResultsController>(c => c.SpendingByOrganizationTypeByTaxonomyTierThreeByTaxonomyTierTwo(null)),
                currentPerson,
                $"Spending by {Models.FieldDefinition.OrganizationType.GetFieldDefinitionLabel()} by {Models.FieldDefinition.TaxonomyTierThree.GetFieldDefinitionLabel()} by {Models.FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabel()}"));
            resultsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ResultsController>(c => c.ResultsByTaxonomyTierTwo(null)), currentPerson,
                $"Results by {Models.FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabel()}"));
            resultsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ResultsController>(c => c.ProjectMap()), currentPerson, $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Map"));

            resultsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<SnapshotController>(c => c.Index()), currentPerson, "System Snapshot", "Group2"));
            return resultsMenu;
        }

        private static LtInfoMenuItem BuildProgramInfoMenu(Person currentPerson)
        {
            var programInfoMenu = new LtInfoMenuItem("Program Info");
            programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProgramInfoController>(c => c.Taxonomy()), currentPerson, MultiTenantHelpers.GetTaxonomySystemName(), "Group1"));
            programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ClassificationController>(c => c.Index()), currentPerson, Models.FieldDefinition.Classification.GetFieldDefinitionLabelPluralized(), "Group1"));
            programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<PerformanceMeasureController>(c => c.Index()), currentPerson, MultiTenantHelpers.GetPerformanceMeasureNamePluralized(), "Group1"));          

            programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<WatershedController>(c => c.Index()), currentPerson, $"{Models.FieldDefinition.Watershed.GetFieldDefinitionLabelPluralized()}", "Group2"));

            programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<OrganizationController>(c => c.Index()), currentPerson, $"{Models.FieldDefinition.Organization.GetFieldDefinitionLabelPluralized()}", "Group3"));
            programInfoMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<FundingSourceController>(c => c.Index()), currentPerson, $"{Models.FieldDefinition.FundingSource.GetFieldDefinitionLabelPluralized()}", "Group3"));
            return programInfoMenu;
        }

        private LtInfoMenuItem BuildManageMenu(Person currentPerson)
        {
            var manageMenu = new LtInfoMenuItem("Manage");
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<PerformanceMeasureController>(c => c.Manage()), currentPerson, MultiTenantHelpers.GetPerformanceMeasureNamePluralized(), "Group1"));
            //manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ResultsController>(c => c.SpendingByPerformanceMeasureByProject(null)), currentPerson, "Spending by Performance Measures", "Group1"));

            if (MultiTenantHelpers.GetNumberOfTaxonomyTiers() == 3)
            {
                manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<TaxonomyTierThreeController>(c => c.Manage()), currentPerson, Models.FieldDefinition.TaxonomyTierThree.GetFieldDefinitionLabelPluralized(), "Group2"));    
            }
            if (MultiTenantHelpers.GetNumberOfTaxonomyTiers() >= 2)
            {
                manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<TaxonomyTierTwoController>(c => c.Manage()), currentPerson, Models.FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabelPluralized(), "Group2"));    
            }
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<TaxonomyTierOneController>(c => c.Manage()), currentPerson, Models.FieldDefinition.TaxonomyTierOne.GetFieldDefinitionLabelPluralized(), "Group2"));

            //manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<AssessmentController>(c => c.Manage()), currentPerson, "Project Assessment Questions", "Group1"));
            
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectController>(c => c.FeaturedList()), currentPerson, $"Featured {Models.FieldDefinition.Project.GetFieldDefinitionLabel()}", "Group6"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<TagController>(c => c.Index()), currentPerson, $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Tags", "Group6"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectUpdateController>(c => c.Manage()), currentPerson, $"Manage {Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Updates", "Group6"));

            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<CostParameterSetController>(c => c.Manage()), currentPerson, "Cost Parameters", "Group6"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<FirmaPageController>(c => c.Index()), currentPerson, "Page Content", "Group7"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<FieldDefinitionController>(c => c.Index()), currentPerson, "Field Definitions", "Group7"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<OrganizationAndRelationshipTypeController>(c => c.Index()), currentPerson, Models.FieldDefinition.OrganizationType.GetFieldDefinitionLabelPluralized(), "Group7"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<UserController>(c => c.Index()), currentPerson, "Users", "Group7"));
            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<TenantController>(c => c.Detail()), currentPerson, "Tenant Configuration", "Group7"));
            // TODO: poor man's hack until we do tenant specific menu and features
            if (HttpRequestStorage.Tenant == Models.Tenant.SitkaTechnologyGroup)
            {
                manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<HomeController>(c => c.DemoScript()), currentPerson, "Demo Script", "Group7"));
            }

            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<HomeController>(c => c.ManageHomePageImages()), currentPerson, "Configure Homepage", "Group7"));

            manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<HomeController>(c => c.InternalSetupNotes()), currentPerson, "Internal Setup Notes", "Group8"));

            return manageMenu;
        }


        private static LtInfoMenuItem BuildProjectsMenu(Person currentPerson)
        {
            var projectsMenu = new LtInfoMenuItem($"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()}");
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ResultsController>(c => c.ProjectMap()), currentPerson, $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Map", "Group1"));
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectController>(c => c.Index()), currentPerson, $"Full {Models.FieldDefinition.Project.GetFieldDefinitionLabel()} List", "Group2"));
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectController>(c => c.ActiveProjectsList()), currentPerson, $"Active {Models.FieldDefinition.Project.GetFieldDefinitionLabel()} List", "Group2"));
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProjectController>(c => c.MyOrganizationsProjects()), currentPerson, $"My {Models.FieldDefinition.Organization.GetFieldDefinitionLabel()}'s {Models.FieldDefinition.Project.GetFieldDefinitionLabel()}", "Group2"));
            projectsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ProposedProjectController>(c => c.Index()), currentPerson, $"{Models.FieldDefinition.ProposedProject.GetFieldDefinitionLabel()}", "Group3"));
            return projectsMenu;
        }

        public string IsActiveUrl(string currentUrlPathAndQuery, string urlToCompare)
        {
            return currentUrlPathAndQuery == urlToCompare ? " class=\"active\"" : string.Empty;
        }

        public string GetBreadCrumbTitle()
        {
            if (!string.IsNullOrWhiteSpace(BreadCrumbTitle))
            {
                return $" | {BreadCrumbTitle}";
            }
            else if (!string.IsNullOrWhiteSpace(PageTitle))
            {
                return $" | {PageTitle}";
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
