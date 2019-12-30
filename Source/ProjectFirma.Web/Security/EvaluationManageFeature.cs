﻿/*-----------------------------------------------------------------------
<copyright file="EvaluationManageFeature.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Evaluation Content")]
    public class EvaluationManageFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Evaluation>
    {
        private readonly FirmaFeatureWithContextImpl<Evaluation> _firmaFeatureWithContextImpl;

        public EvaluationManageFeature(): base(new List<Role>{Role.Admin, Role.SitkaAdmin})
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<Evaluation>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(FirmaSession firmaSession, Evaluation contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, Evaluation contextModelObject)
        {

            switch ((EvaluationVisibilityEnum)contextModelObject.EvaluationVisibilityID)
            {
                case EvaluationVisibilityEnum.AdminsFromMyOrganizationOnly:
                    if (contextModelObject.CreatePerson.OrganizationID != firmaSession.Person.OrganizationID)
                    {
                        return new PermissionCheckResult($"You don't have permission to manage {FieldDefinitionEnum.Evaluation.ToType().GetFieldDefinitionLabel()} {contextModelObject.EvaluationName} because it does not belong to your {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()}");
                    }
                    break;
                case EvaluationVisibilityEnum.OnlyMe:
                    if (contextModelObject.CreatePersonID != firmaSession.PersonID)
                    {
                        return new PermissionCheckResult($"You don't have permission to manage {FieldDefinitionEnum.Evaluation.ToType().GetFieldDefinitionLabel()} {contextModelObject.EvaluationName} because you are not the creator");
                    }
                    break;
                // EvaluationVisibilityEnum.AllAdmins just need to verify they are Admin
            }

            // check that person is an Admin
            if (HasPermissionByFirmaSession(firmaSession))
            {
                return new PermissionCheckResult();
            }

            return new PermissionCheckResult("Does not have administration privileges");
        }
    }
}
