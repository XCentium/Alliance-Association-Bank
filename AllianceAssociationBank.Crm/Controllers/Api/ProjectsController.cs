using AllianceAssociationBank.Crm.Core.Dtos;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Persistence.Enums;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace AllianceAssociationBank.Crm.Controllers.Api
{
    [Authorize]
    public class ProjectsController : ApiController
    {
        private IProjectRepository _projectRepository;
        private IMapper _mapper;
        private const int DefaultResultSize = 10;

        public ProjectsController(IProjectRepository repository, IMapper mapper)
        {
            _projectRepository = repository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IEnumerable<ProjectDto> Get(string search, bool activeOnly = false, int limit = DefaultResultSize)
        {
            var results = _projectRepository.GetProjectsBySearchTerm(search, SortOrder.Ascending, activeOnly)
                .Take(limit);

            return results.ProjectTo<ProjectDto>(_mapper.ConfigurationProvider)
                .ToList();
        }
    }
}
