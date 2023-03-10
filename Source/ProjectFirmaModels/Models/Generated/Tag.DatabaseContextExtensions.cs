//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Tag]
using System.Collections.Generic;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static Tag GetTag(this IQueryable<Tag> tags, int tagID)
        {
            var tag = tags.SingleOrDefault(x => x.TagID == tagID);
            Check.RequireNotNullThrowNotFound(tag, "Tag", tagID);
            return tag;
        }

    }
}