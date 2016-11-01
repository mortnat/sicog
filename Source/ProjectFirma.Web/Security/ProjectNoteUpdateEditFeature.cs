﻿using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Edit Notes for Project Updates")]
    public class ProjectNoteUpdateEditFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<ProjectNoteUpdate>
    {
        private readonly FirmaFeatureWithContextImpl<ProjectNoteUpdate> _firmaFeatureWithContextImpl;

        public ProjectNoteUpdateEditFeature()
            : base(new List<Role> { Role.Normal, Role.SitkaAdmin, Role.Admin })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<ProjectNoteUpdate>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, ProjectNoteUpdate contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person person, ProjectNoteUpdate contextModelObject)
        {
            var hasPermissionByPerson = HasPermissionByPerson(person);
            var project = contextModelObject.ProjectUpdateBatch.Project;
            if (!hasPermissionByPerson)
            {
                return new PermissionCheckResult(string.Format("You don't have permission to Edit Project Note for Project {0}", project.DisplayName));
            }

            var projectIsEditableByUser = new AdminFeature().HasPermissionByPerson(person) || project.IsMyProject(person);
            if (!projectIsEditableByUser)
            {
                return new PermissionCheckResult(string.Format("Project {0} is not editable by you.", project.ProjectID));
            }

            return new PermissionCheckResult();
        }
    }
}