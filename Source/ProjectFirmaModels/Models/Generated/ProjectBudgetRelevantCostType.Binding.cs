//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectBudgetRelevantCostType]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[ProjectBudgetRelevantCostType] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectBudgetRelevantCostType]")]
    public partial class ProjectBudgetRelevantCostType : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectBudgetRelevantCostType()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectBudgetRelevantCostType(int projectBudgetRelevantCostTypeID, int projectID, int costTypeID) : this()
        {
            this.ProjectBudgetRelevantCostTypeID = projectBudgetRelevantCostTypeID;
            this.ProjectID = projectID;
            this.CostTypeID = costTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectBudgetRelevantCostType(int projectID, int costTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectBudgetRelevantCostTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.CostTypeID = costTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectBudgetRelevantCostType(Project project, CostType costType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectBudgetRelevantCostTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectBudgetRelevantCostTypes.Add(this);
            this.CostTypeID = costType.CostTypeID;
            this.CostType = costType;
            costType.ProjectBudgetRelevantCostTypes.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectBudgetRelevantCostType CreateNewBlank(Project project, CostType costType)
        {
            return new ProjectBudgetRelevantCostType(project, costType);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectBudgetRelevantCostType).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectBudgetRelevantCostTypes.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectBudgetRelevantCostTypeID { get; set; }
        public int TenantID { get; set; }
        public int ProjectID { get; set; }
        public int CostTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectBudgetRelevantCostTypeID; } set { ProjectBudgetRelevantCostTypeID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual CostType CostType { get; set; }

        public static class FieldLengths
        {

        }
    }
}