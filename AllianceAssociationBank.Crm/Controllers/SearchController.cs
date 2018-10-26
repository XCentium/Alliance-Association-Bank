using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.Search;
using AllianceAssociationBank.Crm.Core.Dtos;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Exceptions;
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

        public async Task<ActionResult> Results(string term, int page = 1, string sort = SortOrder.Ascending, int? previousId = null)
        {
            var results = await _projectRepository.GetProjectsBySearchTermAsync(term, sort);
            var projectsViewModel = _mapper.Map<IEnumerable<ProjectFormViewModel>>(results);

            var pagedModel = new SearchResultsPagedViewModel(term, projectsViewModel, page, PAGE_SIZE, sort, previousId);

            return View(SearchView.Index, pagedModel);
        }

        //public async Task<ActionResult> JsonResults(string search)
        //{
        //    var results = (await _projectRepository.GetProjectsBySearchTermAsync(search, SortOrder.Ascending))
        //        .Take(JSON_MAX_SEARCH_RESULTS)
        //        .Select(p => new
        //        {
        //            id = p.ID,
        //            name = p.ProjectName
        //        });

        //    return new JsonResult()
        //    {
        //        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
        //        Data = results          
        //    };
        //}
    }
}