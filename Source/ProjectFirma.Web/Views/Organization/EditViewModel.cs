﻿/*-----------------------------------------------------------------------
<copyright file="EditViewModel.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.KeystoneDataService;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Organization
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        public int OrganizationID { get; set; }

        [Required]
        [StringLength(Models.Organization.FieldLengths.OrganizationName)]
        [DisplayName("Name")]
        public string OrganizationName { get; set; }

        [Required]
        [StringLength(Models.Organization.FieldLengths.OrganizationAbbreviation)]
        [DisplayName("Abbreviation")]
        public string OrganizationAbbreviation { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.OrganizationType)]
        [Required]
        public int? OrganizationTypeID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.PrimaryContact)]
        public int? PrimaryContactPersonID { get; set; }

        [Url]
        [DisplayName("Home Page")]
        public string OrganizationUrl { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

        [DisplayName("Logo")]
        [SitkaFileExtensions("jpg|jpeg|gif|png")]
        public HttpPostedFileBase LogoFileResourceData { get; set; }

        [DisplayName("Keystone Organization Guid")]
        public Guid? OrganizationGuid { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.Organization organization)
        {
            OrganizationID = organization.OrganizationID;
            OrganizationName = organization.OrganizationName;
            OrganizationAbbreviation = organization.OrganizationAbbreviation;
            OrganizationTypeID = organization.OrganizationTypeID;
            PrimaryContactPersonID = organization.PrimaryContactPerson?.PersonID;
            OrganizationUrl = organization.OrganizationUrl;

            IsActive = organization.IsActive;
            OrganizationGuid = organization.OrganizationGuid;
        }

        public void UpdateModel(Models.Organization organization, Person currentPerson)
        {
            organization.OrganizationName = OrganizationName;
            organization.OrganizationAbbreviation = OrganizationAbbreviation;
            organization.OrganizationTypeID = OrganizationTypeID.Value;
            organization.IsActive = IsActive;
            organization.PrimaryContactPersonID = PrimaryContactPersonID;
            organization.OrganizationUrl = OrganizationUrl;
            if (LogoFileResourceData != null)
            {
                organization.LogoFileResource = FileResource.CreateNewFromHttpPostedFileAndSave(LogoFileResourceData, currentPerson);    
            }

            var isSitkaAdmin = new SitkaAdminFeature().HasPermissionByPerson(currentPerson);
            if (isSitkaAdmin)
            {
                organization.OrganizationGuid = OrganizationGuid;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            // If we are updating an existing object, make sure we have a Primary Contact
            var primaryContactNotSet = (PrimaryContactPersonID == null);
            if (primaryContactNotSet && ModelObjectHelpers.IsRealPrimaryKeyValue(OrganizationID))
            {
                var organizationBeingUpdated = HttpRequestStorage.DatabaseEntities.Organizations.GetOrganization(OrganizationID);
                if (organizationBeingUpdated.IsLeadImplementerForOneOrMoreProjects)
                {
                    validationResults.Add(
                        new SitkaValidationResult<EditViewModel, int?>(
                            $"Organization {organizationBeingUpdated.OrganizationName} is {Models.FieldDefinition.LeadImplementer.GetFieldDefinitionLabel()} for one or more projects, so you must specify a {Models.FieldDefinition.PrimaryContact.GetFieldDefinitionLabel()}",
                            x => x.PrimaryContactPersonID));
                }
            }

            if (LogoFileResourceData != null && LogoFileResourceData.ContentLength > MaxLogoSizeInBytes)
            {
                var errorMessage = String.Format("Logo is too large - must be less than {0}. Your logo was {1}.",
                    FileUtility.FormatBytes(MaxLogoSizeInBytes),
                    FileUtility.FormatBytes(LogoFileResourceData.ContentLength));
                validationResults.Add(new SitkaValidationResult<EditViewModel, HttpPostedFileBase>(errorMessage, x => x.LogoFileResourceData));
            }

            var isSitkaAdmin = new SitkaAdminFeature().HasPermissionByPerson(HttpRequestStorage.Person);
            if (OrganizationGuid.HasValue && isSitkaAdmin)
            {
                var organization = HttpRequestStorage.DatabaseEntities.Organizations.SingleOrDefault(x => x.OrganizationGuid == OrganizationGuid);
                if (organization != null && organization.OrganizationID != OrganizationID)
                {
                    validationResults.Add(new SitkaValidationResult<EditViewModel, Guid?>("This Guid is already associated with an Organization", x => x.OrganizationGuid));
                }
                else
                {
                    try
                    {
                        var keystoneClient = new KeystoneDataClient();
                        var keystoneOrganization = keystoneClient.GetOrganization(OrganizationGuid.Value);
                    }
                    catch (Exception)
                    {
                        validationResults.Add(new SitkaValidationResult<EditViewModel, Guid?>("Organization Guid not found in Keystone", x => x.OrganizationGuid));
                    }
                    
                }
            }

            return validationResults;
        }

        public const int MaxLogoSizeInBytes = 1024 * 200;
    }
}
