﻿/*-----------------------------------------------------------------------
<copyright file="FirmaBaseController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using log4net;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Controllers
{
    [ValidateInput(false)]
    public abstract class FirmaBaseController : Common.SitkaController
    {
        public static ControllerContext ControllerContextStatic = null;

        protected ILog Logger = LogManager.GetLogger(typeof(FirmaBaseController));

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!IsCurrentUserAnonymous())
            {
                if (DateTime.Now - (CurrentPerson.LastActivityDate ?? new DateTime()) > new TimeSpan(0, 3, 0))
                {
                    CurrentPerson.LastActivityDate = DateTime.Now;
                    HttpRequestStorage.DatabaseEntities.ChangeTracker.DetectChanges();
                    HttpRequestStorage.DatabaseEntities.SaveChangesWithNoAuditing(CurrentPerson.TenantID);
                }
            }
            base.OnActionExecuting(filterContext);
        }

        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            // OLd Way
            //var personFromClaimsIdentity = ClaimsIdentityHelper.PersonFromClaimsIdentity(HttpContext.GetOwinContext().Authentication);
            //HttpRequestStorage.Person = personFromClaimsIdentity;
            //HttpRequestStorage.DatabaseEntities.Person = personFromClaimsIdentity; // we need to set this so that the save will now who the Person is

            var firmaSessionFromClaimsIdentity = ClaimsIdentityHelper.FirmaSessionFromClaimsIdentity(HttpContext.GetOwinContext().Authentication);

            HttpRequestStorage.FirmaSession = firmaSessionFromClaimsIdentity;
            // we need to set this so that the save will know who the Person is
            HttpRequestStorage.DatabaseEntities.Person = firmaSessionFromClaimsIdentity.Person; 

            base.OnAuthentication(filterContext);
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!IsCurrentUserAnonymous())
            {
                HttpRequestStorage.DatabaseEntities.Person = CurrentPerson;
            }
            base.OnAuthorization(filterContext);
        }

        protected FirmaBaseController()
        {
            if (ControllerContextStatic == null)
            {
                ControllerContextStatic = ControllerContext;
            }
        }

        public static ReadOnlyCollection<MethodInfo> AllControllerActionMethods => AllControllerActionMethodsProtected;

        static FirmaBaseController()
        {
            AllControllerActionMethodsProtected = new ReadOnlyCollection<MethodInfo>(GetAllControllerActionMethods(typeof(FirmaBaseController)));
        }

        protected override bool IsCurrentUserAnonymous()
        {
            return CurrentPerson == null || CurrentPerson.IsAnonymousUser();
        }

        protected override string LoginUrl => FirmaHelpers.GenerateLogInUrl();

        protected override ISitkaDbContext SitkaDbContext => HttpRequestStorage.DatabaseEntities;

        protected Person CurrentPerson => HttpRequestStorage.Person;

        protected Tenant CurrentTenant => HttpRequestStorage.Tenant;
    }
}
