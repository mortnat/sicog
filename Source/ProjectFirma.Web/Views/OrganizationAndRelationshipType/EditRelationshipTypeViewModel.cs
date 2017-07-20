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

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.OrganizationAndRelationshipType
{
    public class EditRelationshipTypeViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int RelationshipTypeID { get; set; }

        [Required]
        [StringLength(Models.RelationshipType.FieldLengths.RelationshipTypeName)]
        [DisplayName("Name")]
        public string RelationshipTypeName { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.OrganizationType)]
        public List<OrganizationTypeSimple> OrganizationTypeSimples { get; set; }
                

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditRelationshipTypeViewModel()
        {
        }

        public EditRelationshipTypeViewModel(Models.RelationshipType relationshipType)
        {
            RelationshipTypeID = relationshipType.RelationshipTypeID;
            RelationshipTypeName = relationshipType.RelationshipTypeName;
            OrganizationTypeSimples = relationshipType.OrganizationTypeRelationshipTypes
                .Select(x => new OrganizationTypeSimple(x.OrganizationType))
                .ToList();
        }

        public void UpdateModel(Models.RelationshipType relationshipType, ICollection<Models.OrganizationTypeRelationshipType> allOrganizationTypeRelationshipTypes)
        {
            relationshipType.RelationshipTypeName = RelationshipTypeName;

            var organizationTypesUpdated = OrganizationTypeSimples.Select(orgBeingAdded => new OrganizationTypeRelationshipType(orgBeingAdded.OrganizationTypeID, relationshipType.RelationshipTypeID)).ToList();

            relationshipType.OrganizationTypeRelationshipTypes.Merge(organizationTypesUpdated,
                allOrganizationTypeRelationshipTypes,
                (x, y) => x.OrganizationTypeID == y.OrganizationTypeID && x.RelationshipTypeID == y.RelationshipTypeID);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            var existingRelationshipType = HttpRequestStorage.DatabaseEntities.RelationshipTypes.ToList();
            if (!RelationshipType.IsRelationshipTypeNameUnique(existingRelationshipType, RelationshipTypeName, RelationshipTypeID))
            {
                errors.Add(new SitkaValidationResult<EditRelationshipTypeViewModel, string>("Name already exists", x => x.RelationshipTypeName));
            }
           
            return errors;
        }
    }
}
