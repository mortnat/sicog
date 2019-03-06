﻿using System;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectCustomAttributeTypeModelExtensions
    {
        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(c => c.DeleteProjectCustomAttributeType(UrlTemplate.Parameter1Int)));

        public static readonly UrlTemplate<int> EditUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(c => c.Edit(UrlTemplate.Parameter1Int)));

        public static readonly UrlTemplate<int> DetailUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(c => c.Detail(UrlTemplate.Parameter1Int)));

        public static readonly UrlTemplate<int> DescriptionUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(c => c.Description(UrlTemplate.Parameter1Int)));

        public static string GetDeleteUrl(this ProjectCustomAttributeType projectCustomAttributeType) => DeleteUrlTemplate.ParameterReplace(projectCustomAttributeType.ProjectCustomAttributeTypeID);
        public static string GetEditUrl(this ProjectCustomAttributeType projectCustomAttributeType) => EditUrlTemplate.ParameterReplace(projectCustomAttributeType.ProjectCustomAttributeTypeID);
        public static string GetDetailUrl(this ProjectCustomAttributeType projectCustomAttributeType) => DetailUrlTemplate.ParameterReplace(projectCustomAttributeType.ProjectCustomAttributeTypeID);
        public static string GetDescriptionUrl(this ProjectCustomAttributeType projectCustomAttributeType) => DescriptionUrlTemplate.ParameterReplace(projectCustomAttributeType.ProjectCustomAttributeTypeID);

        public static HtmlString GetEditableRoles(this ProjectCustomAttributeType projectCustomAttributeType)
        {
            var customAttributeTypeEditableRoles = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypeRoles.Where(x => x.ProjectCustomAttributeTypeID == projectCustomAttributeType.ProjectCustomAttributeTypeID).ToList();
            return new HtmlString(customAttributeTypeEditableRoles.Any() 
                ? String.Join(", ", customAttributeTypeEditableRoles.OrderBy(x => x.RoleID).Where(x => x.ProjectCustomAttributeTypeRolePermissionType == ProjectCustomAttributeTypeRolePermissionType.Edit).Select(x => x.Role.RoleDisplayName)) 
                : ViewUtilities.NoAnswerProvided);
        }

        public static HtmlString GetViewableRoles(this ProjectCustomAttributeType projectCustomAttributeType)
        {
            var customAttributeTypViewableRoles = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypeRoles.Where(x => x.ProjectCustomAttributeTypeID == projectCustomAttributeType.ProjectCustomAttributeTypeID).ToList();
            return new HtmlString(customAttributeTypViewableRoles.Any()
                ? String.Join(", ", customAttributeTypViewableRoles.OrderBy(x => x.RoleID).Where(x => x.ProjectCustomAttributeTypeRolePermissionType == ProjectCustomAttributeTypeRolePermissionType.View).Select(x => x.Role.RoleDisplayName))
                : ViewUtilities.NoAnswerProvided);
        }
    }
}