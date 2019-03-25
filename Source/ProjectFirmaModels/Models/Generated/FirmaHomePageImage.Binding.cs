//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaHomePageImage]
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
    // Table [dbo].[FirmaHomePageImage] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[FirmaHomePageImage]")]
    public partial class FirmaHomePageImage : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FirmaHomePageImage()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FirmaHomePageImage(int firmaHomePageImageID, int fileResourceID, string caption, int sortOrder) : this()
        {
            this.FirmaHomePageImageID = firmaHomePageImageID;
            this.FileResourceID = fileResourceID;
            this.Caption = caption;
            this.SortOrder = sortOrder;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FirmaHomePageImage(int fileResourceID, string caption, int sortOrder) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FirmaHomePageImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FileResourceID = fileResourceID;
            this.Caption = caption;
            this.SortOrder = sortOrder;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public FirmaHomePageImage(FileResource fileResource, string caption, int sortOrder) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FirmaHomePageImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.FileResourceID = fileResource.FileResourceID;
            this.FileResource = fileResource;
            fileResource.FirmaHomePageImages.Add(this);
            this.Caption = caption;
            this.SortOrder = sortOrder;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FirmaHomePageImage CreateNewBlank(FileResource fileResource)
        {
            return new FirmaHomePageImage(fileResource, default(string), default(int));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FirmaHomePageImage).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllFirmaHomePageImages.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int FirmaHomePageImageID { get; set; }
        public int TenantID { get; set; }
        public int FileResourceID { get; set; }
        public string Caption { get; set; }
        public int SortOrder { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return FirmaHomePageImageID; } set { FirmaHomePageImageID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual FileResource FileResource { get; set; }

        public static class FieldLengths
        {
            public const int Caption = 300;
        }
    }
}