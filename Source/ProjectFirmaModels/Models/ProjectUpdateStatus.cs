﻿/*-----------------------------------------------------------------------
<copyright file="UpdateStatus.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
namespace ProjectFirmaModels.Models
{
    public class ProjectUpdateStatus
    {
        public bool IsBasicsUpdated { get; }
        public bool IsReportedPerformanceMeasuresUpdated { get; }
        public bool IsExpectedFundingUpdated { get; }
        public bool IsExpendituresUpdated { get; }
        public bool IsBudgetsUpdated { get; }
        public bool IsPhotosUpdated { get; }
        public bool IsLocationSimpleUpdated { get; }
        public bool IsLocationDetailUpdated { get; }
        public bool IsExternalLinksUpdated { get; }
        public bool IsNotesUpdated { get; }
        public bool IsOrganizationsUpdated { get; }
        public bool IsExpectedPerformanceMeasuresUpdated { get; }
        public bool IsTechnicalAssistanceRequestsUpdated { get;  }

        public ProjectUpdateStatus(bool isBasicsUpdated,
            bool isReportedPerformanceMeasuresUpdated,
            bool isExpendituresUpdated,
            bool isBudgetsUpdated,
            bool isPhotosUpdated,
            bool isLocationSimpleUpdated,
            bool isLocationDetailUpdated,
            bool isExternalLinksUpdated,
            bool isNotesUpdated,
            bool isExpectedFundingUpdated,
            bool isOrganizationsUpdated, 
            bool isExpectedPerformanceMeasuresUpdated,
            bool isTechnicalAssistanceRequestsUpdated)
        {
            IsBasicsUpdated = isBasicsUpdated;
            IsReportedPerformanceMeasuresUpdated = isReportedPerformanceMeasuresUpdated;
            IsExpendituresUpdated = isExpendituresUpdated;
            IsBudgetsUpdated = isBudgetsUpdated;
            IsPhotosUpdated = isPhotosUpdated;
            IsLocationSimpleUpdated = isLocationSimpleUpdated;
            IsLocationDetailUpdated = isLocationDetailUpdated;
            IsExternalLinksUpdated = isExternalLinksUpdated;
            IsNotesUpdated = isNotesUpdated;
            IsExpectedFundingUpdated = isExpectedFundingUpdated;
            IsOrganizationsUpdated = isOrganizationsUpdated;
            IsExpectedPerformanceMeasuresUpdated = isExpectedPerformanceMeasuresUpdated;
            IsTechnicalAssistanceRequestsUpdated = isTechnicalAssistanceRequestsUpdated;
        }
    }
}
