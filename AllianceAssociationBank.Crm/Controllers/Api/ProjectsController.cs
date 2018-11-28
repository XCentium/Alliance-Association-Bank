using AllianceAssociationBank.Crm.Core.Dtos;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Persistence.Enums;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace AllianceAssociationBank.Crm.Controllers.Api
{
    [Authorize]
    public class ProjectsController : ApiController
    {
        private IProjectRepository _projectRepository;

        private const int DefaultResultSize = 10;

        public ProjectsController(IProjectRepository repository)
        {
            _projectRepository = repository;
        }
        
        [HttpGet]
        public async Task<IEnumerable<ProjectDto>> Get(string search, bool activeOnly = false, int limit = DefaultResultSize)
        {
            var results = _projectRepository.GetProjectsBySearchTerm(search, SortOrder.Ascending, activeOnly)
                .Take(limit);

            return await results.Select(p => new ProjectDto()
            {
                Id = p.ID,
                Name = p.ProjectName
            })
            .ToListAsync();
        }
    }
}
