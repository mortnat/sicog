﻿using System;
using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View Project")]
    public class ProjectViewFeature : EIPFeatureWithContext, IFirmaBaseFeatureWithContext<Project>
    {
        private readonly FirmaFeatureWithContextImpl<Project> _firmaFeatureWithContextImpl;

        public ProjectViewFeature() : base(new List<Role>())
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<Project>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, Project contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person person, Project contextModelObject)
        {
            if (!HasPermissionByPerson(person))
            {
                return new PermissionCheckResult(String.Format("You don't have permission to view {0}", contextModelObject.DisplayName));
            }

            if (!contextModelObject.IsVisibleToThisPerson(person))
            {
                return new PermissionCheckResult(string.Format("Project {0} is not visible to you.", contextModelObject.ProjectID));
            }

            // Allowed
            return new PermissionCheckResult();
        }
    }
}