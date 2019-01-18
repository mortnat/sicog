//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectClassification]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    // Table [dbo].[ProjectClassification] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectClassification]")]
    public partial class ProjectClassification : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectClassification()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectClassification(int projectClassificationID, int projectID, int classificationID, string projectClassificationNotes) : this()
        {
            this.ProjectClassificationID = projectClassificationID;
            this.ProjectID = projectID;
            this.ClassificationID = classificationID;
            this.ProjectClassificationNotes = projectClassificationNotes;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectClassification(int projectID, int classificationID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectClassificationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.ClassificationID = classificationID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectClassification(Project project, Classification classification) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectClassificationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectClassifications.Add(this);
            this.ClassificationID = classification.ClassificationID;
            this.Classification = classification;
            classification.ProjectClassifications.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectClassification CreateNewBlank(Project project, Classification classification)
        {
            return new ProjectClassification(project, classification);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return false;
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectClassification).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            dbContext.AllProjectClassifications.Remove(this);
        }

        [Key]
        public int ProjectClassificationID { get; set; }
        public int TenantID { get; private set; }
        public int ProjectID { get; set; }
        public int ClassificationID { get; set; }
        public string ProjectClassificationNotes { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectClassificationID; } set { ProjectClassificationID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual Classification Classification { get; set; }

        public static class FieldLengths
        {
            public const int ProjectClassificationNotes = 600;
        }
    }
}