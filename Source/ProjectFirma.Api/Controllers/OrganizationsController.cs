﻿using System;
using System.Linq;
using System.Web.Http;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Api.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Controllers
{
    public class OrganizationsController : ApiController
    {
        private readonly DatabaseEntities _databaseEntities = new DatabaseEntities(Tenant.ActionAgendaForPugetSound.TenantID, "ProjectFirmaDB");

        [Route("api/Organizations/List/{apiKey}")]
        [HttpGet]
        public IHttpActionResult Get(string apiKey)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
            var organizations = _databaseEntities.Organizations.ToList();
            var result = organizations.Select(x => new OrganizationDto(x)).ToList();
            return Ok(result);
        }

        [Route("api/Organizations/PostOrganization/{apiKey}")]
        [HttpPost]
        public IHttpActionResult PostOrganization(string apiKey, [FromBody] OrganizationDto organizationDto)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
            // If Organization already exists - Org created by Keystone or if a sync process failed
            var tenantID = Tenant.ActionAgendaForPugetSound.TenantID;
            if (_databaseEntities.Organizations.Any(x => x.OrganizationName == organizationDto.OrganizationName))
            {
                var existingOrganization = _databaseEntities.Organizations.Single(x => x.OrganizationName == organizationDto.OrganizationName);
                // Set guid if it's provided in Dto bu doesn't exist in Firma database yet
                if (organizationDto.OrganizationGuid.HasValue && !existingOrganization.OrganizationGuid.HasValue)
                {
                    existingOrganization.OrganizationGuid = organizationDto.OrganizationGuid;
                    _databaseEntities.SaveChangesWithNoAuditing(tenantID);
                    var existingOrganizationReloaded = new OrganizationDto(existingOrganization);
                    return Ok(existingOrganizationReloaded);
                }
            }
            var organization = new Organization(organizationDto.OrganizationName, organizationDto.IsActive, organizationDto.OrganizationTypeID);
            organization.OrganizationGuid = organizationDto.OrganizationGuid;
            organization.OrganizationShortName = organizationDto.OrganizationShortName;
            organization.OrganizationUrl = organizationDto.OrganizationUrl;
            if (organizationDto.LogoFileResource != null)
            {
                var fileResourceDto = organizationDto.LogoFileResource;
                var fileResourceMimeType = MapFileResourceMimeTypeNameToFileResourceMimeType(fileResourceDto.FileResourceMimeTypeName);
                if (fileResourceMimeType == null)
                {
                    var error =
                        $"Invalid File Resource Mime Type '{fileResourceDto.FileResourceMimeTypeName}' for '{fileResourceDto.FileResourceGUID}'";
                    return BadRequest(error);
                }

                var peopleDictionary = _databaseEntities.People.ToDictionary(x => x.Email);
                var fileResourceMimeTypeID = fileResourceMimeType.FileResourceMimeTypeID;
                var personID = peopleDictionary.ContainsKey(fileResourceDto.Email) ? peopleDictionary[fileResourceDto.Email].PersonID : 5278;
                var fileResource = new FileResource(fileResourceMimeTypeID, fileResourceDto.OriginalBaseFilename,
                    fileResourceDto.OriginalFileExtension, fileResourceDto.FileResourceGUID,
                    fileResourceDto.FileResourceData, personID, fileResourceDto.CreateDate);

                organization.LogoFileResource = fileResource;
            }
            _databaseEntities.AllOrganizations.Add(organization);
            _databaseEntities.SaveChangesWithNoAuditing(tenantID);
            var organizationReloaded = new OrganizationDto(organization);
            return Ok(organizationReloaded);
        }

        private static FileResourceMimeType MapFileResourceMimeTypeNameToFileResourceMimeType(string googleChartTypeName)
        {
            return FileResourceMimeType.All.SingleOrDefault(x => x.FileResourceMimeTypeDisplayName.Equals(googleChartTypeName, StringComparison.InvariantCultureIgnoreCase));
        }

        [Route("api/Organizations/UpdateOrganization/{apiKey}")]
        [HttpPut]
        public IHttpActionResult UpdateOrganization(string apiKey, [FromBody] OrganizationDto organizationDto)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
            var organization = _databaseEntities.Organizations.SingleOrDefault(x => x.OrganizationID == organizationDto.OrganizationID);
            if (organization == null)
            {
                var message = $"Organization with ID = {organizationDto.OrganizationID} not found";
                return NotFound();
            }

            organization.OrganizationName = organizationDto.OrganizationName;
            organization.OrganizationGuid = organizationDto.OrganizationGuid;
            organization.OrganizationShortName = organizationDto.OrganizationShortName;
            organization.OrganizationTypeID = organizationDto.OrganizationTypeID;
            organization.IsActive = organizationDto.IsActive;
            organization.OrganizationUrl = organizationDto.OrganizationUrl;
            if (organizationDto.LogoFileResource != null)
            {
                var fileResourceDto = organizationDto.LogoFileResource;
                var fileResourceMimeType = MapFileResourceMimeTypeNameToFileResourceMimeType(fileResourceDto.FileResourceMimeTypeName);
                if (fileResourceMimeType == null)
                {
                    var error =
                        $"Invalid File Resource Mime Type '{fileResourceDto.FileResourceMimeTypeName}' for '{fileResourceDto.FileResourceGUID}'";
                    return BadRequest(error);
                }

                var peopleDictionary = _databaseEntities.People.ToDictionary(x => x.Email);
                var fileResourceMimeTypeID = fileResourceMimeType.FileResourceMimeTypeID;
                var personID = peopleDictionary.ContainsKey(fileResourceDto.Email) ? peopleDictionary[fileResourceDto.Email].PersonID : 5278;
                var fileResource = new FileResource(fileResourceMimeTypeID, fileResourceDto.OriginalBaseFilename,
                    fileResourceDto.OriginalFileExtension, fileResourceDto.FileResourceGUID,
                    fileResourceDto.FileResourceData, personID, fileResourceDto.CreateDate);

                organization.LogoFileResource = fileResource;
            }

            _databaseEntities.SaveChangesWithNoAuditing(Tenant.ActionAgendaForPugetSound.TenantID);
            var fundingSourceReloaded = new OrganizationDto(organization);
            return Ok(fundingSourceReloaded);
        }

        [Route("api/Organizations/Delete/{apiKey}/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(string apiKey, int id)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
            var organization = _databaseEntities.Organizations.SingleOrDefault(x => x.OrganizationID == id);
            if (organization == null)
            {
                var message = $"Organization with ID = {id} not found";
                return NotFound();
            }
            organization.DeleteFull(_databaseEntities);
            _databaseEntities.SaveChangesWithNoAuditing(Tenant.ActionAgendaForPugetSound.TenantID);
            return Ok();
        }
    }
}