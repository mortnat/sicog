﻿using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Create New Project")]
    public class ProjectCreateNewFeature : EIPFeature
    {
        public ProjectCreateNewFeature() : base(new List<Role> { Role.Admin, Role.TMPOManager })
        {
        }
    }
}