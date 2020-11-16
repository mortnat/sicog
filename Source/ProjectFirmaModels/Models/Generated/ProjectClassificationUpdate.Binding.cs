//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectClassificationUpdate]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[ProjectClassificationUpdate] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectClassificationUpdate]")]
    public partial class ProjectClassificationUpdate : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectClassificationUpdate()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectClassificationUpdate(int projectClassificationUpdateID, int projectUpdateBatchID, int classificationID, string projectClassificationUpdateNotes) : this()
        {
            this.ProjectClassificationUpdateID = projectClassificationUpdateID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.ClassificationID = classificationID;
            this.ProjectClassificationUpdateNotes = projectClassificationUpdateNotes;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectClassificationUpdate(int projectUpdateBatchID, int classificationID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectClassificationUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.ClassificationID = classificationID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectClassificationUpdate(ProjectUpdateBatch projectUpdateBatch, Classification classification) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectClassificationUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            this.ProjectUpdateBatch = projectUpdateBatch;
            projectUpdateBatch.ProjectClassificationUpdates.Add(this);
            this.ClassificationID = classification.ClassificationID;
            this.Classification = classification;
            classification.ProjectClassificationUpdates.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectClassificationUpdate CreateNewBlank(ProjectUpdateBatch projectUpdateBatch, Classification classification)
        {
            return new ProjectClassificationUpdate(projectUpdateBatch, classification);
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
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectClassificationUpdate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectClassificationUpdates.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectClassificationUpdateID { get; set; }
        public int TenantID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int ClassificationID { get; set; }
        public string ProjectClassificationUpdateNotes { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectClassificationUpdateID; } set { ProjectClassificationUpdateID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }
        public virtual Classification Classification { get; set; }

        public static class FieldLengths
        {
            public const int ProjectClassificationUpdateNotes = 600;
        }
    }
}