using AllianceAssociationBank.Crm.Core.Dtos;
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

        private const bool ActiveProjectsOnly = true;
        private const int MaxSearchResults = 10;

        public ProjectsController(IProjectRepository repository)
        {
            _projectRepository = repository;
        }
        
        [HttpGet]
        public IEnumerable<ProjectDto> Get(string search)
        {
            var results = _projectRepository.GetProjectsBySearchTerm(search, SortOrder.Ascending, ActiveProjectsOnly)
                .Take(MaxSearchResults);

            return results.Select(p => new ProjectDto()
            {
                Id = p.ID,
                Name = p.ProjectName
            })
            .ToList();
        }
    }
}
