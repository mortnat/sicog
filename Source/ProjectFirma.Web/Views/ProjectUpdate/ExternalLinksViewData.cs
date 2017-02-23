﻿/*-----------------------------------------------------------------------
<copyright file="ExternalLinksViewData.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.TextControls;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ExternalLinksViewData : ProjectUpdateViewData
    {
        public readonly EntityExternalLinksViewData EntityExternalLinksViewData;
        public readonly string RefreshUrl;
        public readonly string DiffUrl;
        public readonly ViewDataForAngularClass ViewDataForAngular;

        public ExternalLinksViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, UpdateStatus updateStatus, ViewDataForAngularClass viewDataForAngular, EntityExternalLinksViewData entityExternalLinksViewData, string refreshUrl, string diffUrl)
            : base(currentPerson, projectUpdateBatch, ProjectUpdateSectionEnum.ExternalLinks, updateStatus)
        {
            ViewDataForAngular = viewDataForAngular;
            EntityExternalLinksViewData = entityExternalLinksViewData;
            RefreshUrl = refreshUrl;
            DiffUrl = diffUrl;
        }

        public class ViewDataForAngularClass
        {
            public readonly int ProjectID;

            public ViewDataForAngularClass(int projectUpdateBatchID)
            {
                ProjectID = projectUpdateBatchID;
            }
        }
    }
}
