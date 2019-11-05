﻿/*-----------------------------------------------------------------------
<copyright file="Person.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using Keystone.Common.OpenID;

namespace ProjectFirmaModels.Models
{
    public partial class Person : IAuditableEntity, IKeystoneUser
    {
        public const int AnonymousPersonID = -999;

        public string GetFullNameFirstLast() => $"{FirstName} {LastName}";

        public string GetFullNameLastFirst() => $"{LastName}, {FirstName}";

        /// <summary>
        /// List of Organizations for which this Person is the primary contact
        /// </summary>
        public List<Organization> GetPrimaryContactOrganizations()
        {
            return OrganizationsWhereYouAreThePrimaryContactPerson.OrderBy(x => x.OrganizationName).ToList();
        }

        public string GetAuditDescriptionString() => GetFullNameFirstLast();

        public Notification GetMostRecentReminder()
        {
            var notifications = Notifications.Where(x => x.NotificationType == NotificationType.ProjectUpdateReminder).ToList();

            if (notifications.Count == 0)
            {
                return null;
            }

            return notifications.OrderByDescending(y => y.NotificationDate).First();
        }

        /// <summary>
        /// This function really needs to die, but not doing it yet. -- SLG & SG
        /// </summary>
        /// <returns></returns>
        public bool IsAnonymousUser() => PersonID == AnonymousPersonID;

        /// <summary>
        /// All role names of BOTH types used by Keystone not for user display 
        /// </summary>
        public IEnumerable<string> GetRoleNames()
        {
            if (IsAnonymousUser())
            {
                // the presence of roles switches you from being IsAuthenticated or not
                return new List<string>();
            }

            var roleNames = new List<string> {Role.RoleName};
            return roleNames;
        }

        public IEnumerable<string> RoleNames { get { return GetRoleNames(); } }

        public void SetKeystoneUserClaims(IKeystoneUserClaims keystoneUserClaims)
        {
            // intentionally left blank
        }
    }
}
