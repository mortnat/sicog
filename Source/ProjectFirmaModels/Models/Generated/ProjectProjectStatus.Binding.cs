//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectProjectStatus]
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
    // Table [dbo].[ProjectProjectStatus] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectProjectStatus]")]
    public partial class ProjectProjectStatus : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectProjectStatus()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectProjectStatus(int projectProjectStatusID, int projectID, int projectStatusID, DateTime projectProjectStatusUpdateDate, string projectProjectStatusComment, int projectProjectStatusCreatePersonID, DateTime projectProjectStatusCreateDate, int? projectProjectStatusLastEditedPersonID, DateTime? projectProjectStatusLastEditedDate, bool isFinalStatusUpdate, string lessonsLearned) : this()
        {
            this.ProjectProjectStatusID = projectProjectStatusID;
            this.ProjectID = projectID;
            this.ProjectStatusID = projectStatusID;
            this.ProjectProjectStatusUpdateDate = projectProjectStatusUpdateDate;
            this.ProjectProjectStatusComment = projectProjectStatusComment;
            this.ProjectProjectStatusCreatePersonID = projectProjectStatusCreatePersonID;
            this.ProjectProjectStatusCreateDate = projectProjectStatusCreateDate;
            this.ProjectProjectStatusLastEditedPersonID = projectProjectStatusLastEditedPersonID;
            this.ProjectProjectStatusLastEditedDate = projectProjectStatusLastEditedDate;
            this.IsFinalStatusUpdate = isFinalStatusUpdate;
            this.LessonsLearned = lessonsLearned;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectProjectStatus(int projectID, int projectStatusID, DateTime projectProjectStatusUpdateDate, string projectProjectStatusComment, int projectProjectStatusCreatePersonID, DateTime projectProjectStatusCreateDate, bool isFinalStatusUpdate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectProjectStatusID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.ProjectStatusID = projectStatusID;
            this.ProjectProjectStatusUpdateDate = projectProjectStatusUpdateDate;
            this.ProjectProjectStatusComment = projectProjectStatusComment;
            this.ProjectProjectStatusCreatePersonID = projectProjectStatusCreatePersonID;
            this.ProjectProjectStatusCreateDate = projectProjectStatusCreateDate;
            this.IsFinalStatusUpdate = isFinalStatusUpdate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectProjectStatus(Project project, ProjectStatus projectStatus, DateTime projectProjectStatusUpdateDate, string projectProjectStatusComment, Person projectProjectStatusCreatePerson, DateTime projectProjectStatusCreateDate, bool isFinalStatusUpdate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectProjectStatusID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectProjectStatuses.Add(this);
            this.ProjectStatusID = projectStatus.ProjectStatusID;
            this.ProjectStatus = projectStatus;
            projectStatus.ProjectProjectStatuses.Add(this);
            this.ProjectProjectStatusUpdateDate = projectProjectStatusUpdateDate;
            this.ProjectProjectStatusComment = projectProjectStatusComment;
            this.ProjectProjectStatusCreatePersonID = projectProjectStatusCreatePerson.PersonID;
            this.ProjectProjectStatusCreatePerson = projectProjectStatusCreatePerson;
            projectProjectStatusCreatePerson.ProjectProjectStatusesWhereYouAreTheProjectProjectStatusCreatePerson.Add(this);
            this.ProjectProjectStatusCreateDate = projectProjectStatusCreateDate;
            this.IsFinalStatusUpdate = isFinalStatusUpdate;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectProjectStatus CreateNewBlank(Project project, ProjectStatus projectStatus, Person projectProjectStatusCreatePerson)
        {
            return new ProjectProjectStatus(project, projectStatus, default(DateTime), default(string), projectProjectStatusCreatePerson, default(DateTime), default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectProjectStatus).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectProjectStatuses.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectProjectStatusID { get; set; }
        public int TenantID { get; set; }
        public int ProjectID { get; set; }
        public int ProjectStatusID { get; set; }
        public DateTime ProjectProjectStatusUpdateDate { get; set; }
        public string ProjectProjectStatusComment { get; set; }
        public int ProjectProjectStatusCreatePersonID { get; set; }
        public DateTime ProjectProjectStatusCreateDate { get; set; }
        public int? ProjectProjectStatusLastEditedPersonID { get; set; }
        public DateTime? ProjectProjectStatusLastEditedDate { get; set; }
        public bool IsFinalStatusUpdate { get; set; }
        public string LessonsLearned { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectProjectStatusID; } set { ProjectProjectStatusID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual ProjectStatus ProjectStatus { get; set; }
        public virtual Person ProjectProjectStatusCreatePerson { get; set; }
        public virtual Person ProjectProjectStatusLastEditedPerson { get; set; }

        public static class FieldLengths
        {
            public const int ProjectProjectStatusComment = 2500;
            public const int LessonsLearned = 2500;
        }
    }
}