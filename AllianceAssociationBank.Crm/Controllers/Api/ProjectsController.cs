using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Core.Dtos;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Filters;
using AllianceAssociationBank.Crm.Persistence;
using AllianceAssociationBank.Crm.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AllianceAssociationBank.Crm.Controllers.Api
{
    [Authorize]
    public class ProjectsController : ApiController
    {
        private IProjectRepository _repository;

        private const int MAX_SEARCH_RESULTS = 10;

        public ProjectsController(IProjectRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public async Task<IEnumerable<ProjectDto>> Get(string search)
        {
            return (await _repository.GetProjectsBySearchTermAsync(search, SortOrder.Ascending))
                .Take(MAX_SEARCH_RESULTS)
                .Select(p => new ProjectDto()
                {
                    Id = p.ID,
                    Name = p.ProjectName
                });
        }
    }
}
