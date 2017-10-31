﻿/*-----------------------------------------------------------------------
<copyright file="ProjectLocationStagingUpdate.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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
using System.IO;
using System.Linq;
using ProjectFirma.Web.Common;
using GeoJSON.Net.Feature;
using LtInfo.Common;
using LtInfo.Common.GdalOgr;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectLocationStagingUpdate : IProjectLocationStaging
    {
        public FeatureCollection ToGeoJsonFeatureCollection()
        {
            var featureCollection = JsonTools.DeserializeObject<FeatureCollection>(GeoJson);
            return featureCollection;
        }

        public static List<ProjectLocationStagingUpdate> CreateProjectLocationStagingUpdateListFromGdb(FileInfo gdbFile, ProjectUpdateBatch projectUpdateBatch, Person currentPerson)
        {
            var ogr2OgrCommandLineRunner = new Ogr2OgrCommandLineRunner(FirmaWebConfiguration.Ogr2OgrExecutable,
                Ogr2OgrCommandLineRunner.DefaultCoordinateSystemId,
                FirmaWebConfiguration.HttpRuntimeExecutionTimeout.TotalMilliseconds);

            var featureClassNames = OgrInfoCommandLineRunner.GetFeatureClassNamesFromFileGdb(new FileInfo(FirmaWebConfiguration.OgrInfoExecutable), gdbFile, Ogr2OgrCommandLineRunner.DefaultTimeOut);

            var projectLocationStagings =
                featureClassNames.Select(x => new ProjectLocationStagingUpdate(projectUpdateBatch, currentPerson, x, ogr2OgrCommandLineRunner.ImportFileGdbToGeoJson(gdbFile, x, true), true)).ToList();
            return projectLocationStagings;
        }
    }
}
