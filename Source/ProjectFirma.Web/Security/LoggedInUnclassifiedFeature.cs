﻿using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    /// <summary>
    /// Must be at least logged in
    /// </summary>
    [SecurityFeatureDescription("Has a ProjectFirma role")]
    public class LoggedInUnclassifiedFeature : EIPFeature
    {
        public LoggedInUnclassifiedFeature()
            : base(Role.All)
        {
        }
    }
}