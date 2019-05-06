﻿using System.Linq;
using System.Web.Http;
using LtInfo.Common.DesignByContract;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Controllers
{
    public class ProjectsController : ApiController
    {
        private readonly DatabaseEntities _databaseEntities = new DatabaseEntities(Tenant.ActionAgendaForPugetSound.TenantID, "ProjectFirmaDB");

        //public ProjectsController(DatabaseEntities databaseEntities)
        //{
        //    _databaseEntities = databaseEntities;
        //}

        [Route("api/Projects/List/{apiKey}")]
        [HttpGet]
        public IHttpActionResult Get(string apiKey)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
            var projects = _databaseEntities.Projects.ToList().Where(x => x.ProjectCustomAttributes.Any(y => y.ProjectCustomAttributeType.ProjectCustomAttributeTypeName == "NEP Funded Activities"));
            var result = projects.Where(x => x.ProjectCustomAttributes.Single(y => y.ProjectCustomAttributeType.ProjectCustomAttributeTypeName == "NEP Funded Activities").ProjectCustomAttributeValues.Single().AttributeValue == "Yes").Select(x => new ProjectDto(x)).ToList();
            return Ok(result);
        }

        [Route("api/Projects/Get/{apiKey}/{id}")]
        [HttpGet]
        public IHttpActionResult Get(string apiKey, int id)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
            var project = _databaseEntities.Projects.SingleOrDefault(x => x.ProjectID == id);
            if (project == null)
            {
                var message = $"Project with ID = {id} not found";
                return NotFound();
            }
            var result = new ProjectDto(project);
            return Ok(result);
        }
    }
}