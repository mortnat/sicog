﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.Models;
using Newtonsoft.Json;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectCustomAttributeType
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        public int ProjectCustomAttributeTypeID { get; set; }

        [Required]
        [StringLength(ProjectFirmaModels.Models.ProjectCustomAttributeType.FieldLengths.ProjectCustomAttributeTypeName)]
        [DisplayName("Name of Attribute")]
        public string ProjectCustomAttributeTypeName { get; set; }

        [Required(ErrorMessage = "Specify data type for this custom attribute")]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectCustomAttributeDataType)]
        public int? ProjectCustomAttributeDataTypeID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.MeasurementUnit)]
        public int? MeasurementUnitTypeID { get; set; }

        [DisplayName("Options")]
        public string ProjectCustomAttributeTypeOptionsSchema { get; set; }
        
        [Required(ErrorMessage = "Specify whether the attribute is required or optional")]
        [DisplayName("Required?")]
        public bool? IsRequired { get; set; }

        [DisplayName("Description")]
        [StringLength(ProjectFirmaModels.Models.ProjectCustomAttributeType.FieldLengths.ProjectCustomAttributeTypeDescription)]
        public string ProjectCustomAttributeTypeDesription { get; set; }

        [DisplayName("Editable By")]
        public int? ProjectCustomAttributeEditableBy { get; set; }

        [DisplayName("Viewable By")]
        public int? ProjectCustomAttributeViewableBy { get; set; }

        [DisplayName("Include in NTA Grid?")]
        public bool? ProjectCustomAttributeIncludeInNtaGrid { get; set; }
        

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(ProjectFirmaModels.Models.ProjectCustomAttributeType projectCustomAttributeType)
        {
            ProjectCustomAttributeTypeID = projectCustomAttributeType.ProjectCustomAttributeTypeID;
            ProjectCustomAttributeTypeName = projectCustomAttributeType.ProjectCustomAttributeTypeName;
            ProjectCustomAttributeDataTypeID = projectCustomAttributeType.ProjectCustomAttributeDataTypeID;
            MeasurementUnitTypeID = projectCustomAttributeType.MeasurementUnitTypeID;
            ProjectCustomAttributeTypeOptionsSchema = projectCustomAttributeType.ProjectCustomAttributeTypeOptionsSchema;
            IsRequired = projectCustomAttributeType.IsRequired;
            ProjectCustomAttributeTypeDesription = projectCustomAttributeType.ProjectCustomAttributeTypeDescription;
            ProjectCustomAttributeEditableBy = projectCustomAttributeType.EditableByRoleID;
            ProjectCustomAttributeViewableBy = projectCustomAttributeType.ViewableByRoleID;
            ProjectCustomAttributeIncludeInNtaGrid = projectCustomAttributeType.IncludeInNtaGrid;


        }


        public void UpdateModel(ProjectFirmaModels.Models.ProjectCustomAttributeType projectCustomAttributeType, Person currentPerson)
        {
            projectCustomAttributeType.ProjectCustomAttributeTypeName = ProjectCustomAttributeTypeName;
            projectCustomAttributeType.ProjectCustomAttributeDataTypeID = ProjectCustomAttributeDataTypeID ?? ModelObjectHelpers.NotYetAssignedID;
            projectCustomAttributeType.MeasurementUnitTypeID = MeasurementUnitTypeID;
            projectCustomAttributeType.IsRequired = IsRequired.GetValueOrDefault();
            projectCustomAttributeType.ProjectCustomAttributeTypeDescription = ProjectCustomAttributeTypeDesription;
            projectCustomAttributeType.EditableByRoleID = ProjectCustomAttributeEditableBy;
            projectCustomAttributeType.ViewableByRoleID = ProjectCustomAttributeViewableBy;
            projectCustomAttributeType.IncludeInNtaGrid = ProjectCustomAttributeIncludeInNtaGrid;

            var projectCustomAttributeDataType = ProjectCustomAttributeDataTypeID != null
                ? ProjectCustomAttributeDataType.AllLookupDictionary[ProjectCustomAttributeDataTypeID.Value]
                : null;
            if (projectCustomAttributeDataType != null && projectCustomAttributeDataType.HasOptions())
            {
                projectCustomAttributeType.ProjectCustomAttributeTypeOptionsSchema = ProjectCustomAttributeTypeOptionsSchema;
            }
            else
            {
                projectCustomAttributeType.ProjectCustomAttributeTypeOptionsSchema = null;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes
                .Where(x => x.ProjectCustomAttributeTypeName == ProjectCustomAttributeTypeName)
                .Any(x => x.ProjectCustomAttributeTypeID != ProjectCustomAttributeTypeID))
            {
                yield return new ValidationResult($"A {FieldDefinitionEnum.ProjectCustomAttribute.ToType().GetFieldDefinitionLabel()} with this name already exists.");
            }

            if (ModelObjectHelpers.IsRealPrimaryKeyValue(ProjectCustomAttributeTypeID))
            {
                var type = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes.GetProjectCustomAttributeType(ProjectCustomAttributeTypeID);
                var isStringType = type.ProjectCustomAttributeDataType == ProjectCustomAttributeDataType.String;
                if (!isStringType && type.ProjectCustomAttributeDataTypeID != ProjectCustomAttributeDataTypeID)
                {
                    yield return new ValidationResult("You cannot change the type of attribute.");
                }

                var updatedTypeIsStringPickFromListOrMultiselect = ProjectCustomAttributeDataTypeID == ProjectCustomAttributeDataType.String.ProjectCustomAttributeDataTypeID ||
                                                                   ProjectCustomAttributeDataTypeID == ProjectCustomAttributeDataType.PickFromList.ProjectCustomAttributeDataTypeID ||
                                                                   ProjectCustomAttributeDataTypeID == ProjectCustomAttributeDataType.MultiSelect.ProjectCustomAttributeDataTypeID;
                if (isStringType && !updatedTypeIsStringPickFromListOrMultiselect)
                {
                    yield return new ValidationResult("You cannot change a String attribute to any other than a single or multi select list.");
                }
            }

            var projectCustomAttributeDataType = ProjectCustomAttributeDataTypeID != null
                ? ProjectCustomAttributeDataType.AllLookupDictionary[ProjectCustomAttributeDataTypeID.Value]
                : null;
            if (projectCustomAttributeDataType != null && projectCustomAttributeDataType.HasOptions())
            {
                List<string> options = null;
                try
                {
                    options = JsonConvert.DeserializeObject<List<string>>(ProjectCustomAttributeTypeOptionsSchema);
                }
                catch { /* ignored */ }

                if (options == null)
                {
                    yield return new ValidationResult("Options cannot be saved.");
                    yield break;
                }

                if (options.Any(string.IsNullOrEmpty))
                {
                    yield return new ValidationResult("Options cannot be empty.");
                }

                if (options.Count.Equals(0))
                {
                    yield return new ValidationResult("This type of attribute must have options defined.");
                }

                if (projectCustomAttributeDataType == ProjectCustomAttributeDataType.MultiSelect && options.Count == 1)
                {
                    yield return new ValidationResult("This type of attribute must have more than one option defined.");
                }

                if (options.Select(x => x.ToLower()).HasDuplicates())
                {
                    yield return new ValidationResult("Options must be unique, remove duplicates.");
                }
            }
        }
    }
}
