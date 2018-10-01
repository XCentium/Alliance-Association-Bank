using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.Search;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        private IProjectRepository _projectRepository;
        private IMapper _mapper;

        private const int PAGE_SIZE = 10;

        public SearchController(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            return View(SearchView.Index, new SearchResultsPagedViewModel());
        }

        public async Task<ActionResult> Results(string term, int page = 1, string sort = SortOrder.Ascending)
        {
            try
            {
                if (string.IsNullOrEmpty(term))
                {
                    return View(SearchView.Index, new SearchResultsPagedViewModel());
                }

                var results = await _projectRepository.GetProjectsBySearchPhraseAsync(term, sort);
                var projectsViewModel = _mapper.Map<IEnumerable<ProjectFormViewModel>>(results);

                var pagedModel = new SearchResultsPagedViewModel(term, projectsViewModel, page, PAGE_SIZE, sort);

                return View(SearchView.Index, pagedModel);
            }
            catch (Exception ex)
            {
                // TODO: need to log this
                return View("Error");
            }
        }
    }
}