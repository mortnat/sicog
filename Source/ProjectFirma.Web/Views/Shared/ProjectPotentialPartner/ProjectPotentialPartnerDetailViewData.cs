﻿/*-----------------------------------------------------------------------
<copyright file="ProjectOrganizationsDetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using System.Web;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.PartnerFinder;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectPotentialPartner
{
    public enum ProjectPotentialPartnerListDisplayMode
    {
        StandAloneFullList,
        ProjectDetailViewPartialList
    }

    public class ProjectPotentialPartnerDetailViewData : FirmaUserControlViewData
    {
        // Number of matches to show before we offer a "show more" link.
        public int NumberOfMatchesToShowForPartialList = 5;

        public bool ShouldShowPotentialPartnerPanel { get; }
        public List<PartnerOrganizationMatchMakerScore> RelevantPartnerOrganizationMatchMakerScores { get; }
        public bool ShouldShowMorePartnersLink { get; }
        public HtmlString MorePartnersLinkHtml { get; }
        public ProjectPotentialPartnerListDisplayMode DisplayMode;

        public ProjectPotentialPartnerDetailViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Project project, ProjectPotentialPartnerListDisplayMode displayMode)
        {
            ShouldShowPotentialPartnerPanel = FirmaWebConfiguration.FeatureMatchMakerEnabled &&
                                              new MatchMakerViewPotentialPartnersFeature().HasPermissionByFirmaSession(currentFirmaSession);

            DisplayMode = displayMode;

            ShouldShowMorePartnersLink = false;
            // Don't bother doing this work if we aren't going to show it
            if (ShouldShowPotentialPartnerPanel)
            {
                ProjectOrganizationMatchmaker matchMaker = new ProjectOrganizationMatchmaker();
                var allPossibleRelevantPartnerOrganizationMatchMakerScores = matchMaker.GetPartnerOrganizationMatchMakerScoresForParticularProject(currentFirmaSession, project);

                bool hasExcessMatches = allPossibleRelevantPartnerOrganizationMatchMakerScores.Count > NumberOfMatchesToShowForPartialList;
                bool inPartialViewMode = DisplayMode == ProjectPotentialPartnerListDisplayMode.ProjectDetailViewPartialList;
                ShouldShowMorePartnersLink = hasExcessMatches && inPartialViewMode;

                // Show an abbreviated set if we are in partial view mode
                if (inPartialViewMode)
                {
                    RelevantPartnerOrganizationMatchMakerScores = allPossibleRelevantPartnerOrganizationMatchMakerScores.Take(NumberOfMatchesToShowForPartialList).ToList();
                }
                else
                {
                    RelevantPartnerOrganizationMatchMakerScores = allPossibleRelevantPartnerOrganizationMatchMakerScores;
                }

                if (ShouldShowMorePartnersLink)
                {
                    MorePartnersLinkHtml = new HtmlString(SitkaRoute<MatchMakerController>.BuildLinkFromExpression(x => x.ProjectPotentialPartners(project), "More Potential Partners..."));
                }
            }
        }
    }
}
