using AllianceAssociationBank.Crm.Core.Dtos;
using AllianceAssociationBank.Crm.Core.Interfaces;
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

        public ProjectsController()
        {
            _repository = new ProjectRepository(new CrmApplicationDbContext());
        }
        
        [HttpGet]
        public async Task<IEnumerable<ProjectDto>> Get(string search)
        {
            return (await _repository.GetProjectsBySearchPhraseAsync(search))
                .Take(10);
        }
    }
}
