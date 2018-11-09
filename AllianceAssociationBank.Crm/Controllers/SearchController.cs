using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.Search;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Persistence.Enums;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        private IProjectRepository _projectRepository;
        private IMapper _mapper;

        private const int PAGE_SIZE = 10;
        private const int JSON_MAX_SEARCH_RESULTS = 10;

        public SearchController(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            return View(SearchView.Index, new SearchResultsPagedViewModel());
        }

        public ActionResult Results(string term, int page = 1, string sort = SortOrderString.Ascending, int? previousId = null)
        {
            var results = _projectRepository.GetProjectsBySearchTerm(term, sort.ToSortOrderEnum());

            var projectsViewModel = results.ProjectTo<ProjectFormViewModel>(_mapper.ConfigurationProvider);

            var pagedModel = new SearchResultsPagedViewModel(term, projectsViewModel, page, PAGE_SIZE, sort, previousId);

            return View(SearchView.Index, pagedModel);
        }
    }
}