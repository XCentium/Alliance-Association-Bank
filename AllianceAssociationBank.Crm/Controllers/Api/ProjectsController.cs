using AllianceAssociationBank.Crm.Dtos;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Persistence.Enums;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace AllianceAssociationBank.Crm.Controllers.Api
{
    [Authorize]
    public class ProjectsController : ApiController
    {
        private IProjectRepository _projectRepository;

        private const int MAX_SEARCH_RESULTS = 10;

        public ProjectsController(IProjectRepository repository)
        {
            _projectRepository = repository;
        }
        
        [HttpGet]
        public IEnumerable<ProjectDto> Get(string search)
        {
            var results = _projectRepository.GetProjectsBySearchTerm(search, SortOrder.Ascending)
                .Take(MAX_SEARCH_RESULTS);

            return results.Select(p => new ProjectDto()
            {
                Id = p.ID,
                Name = p.ProjectName
            })
            .ToList();
        }
    }
}
