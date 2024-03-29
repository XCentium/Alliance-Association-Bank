﻿using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.Search;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Persistence.Enums;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Web.Mvc;
using System.Web.SessionState;

namespace AllianceAssociationBank.Crm.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        private IProjectRepository _projectRepository;
        private IMapper _mapper;

        private const int DefaultPageSize = 10;

        public SearchController(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            // This will return all projects
            return RedirectToAction(nameof(Results), new { term = (string)null });
        }

        [ValidateInput(false)]
        public ActionResult Results(string term, 
                                    int page = 1, 
                                    string sort = SortOrderString.Ascending, 
                                    bool activeOnly = false, 
                                    int? previousId = null)
        {
            var results = _projectRepository.GetProjectsBySearchTerm(term, sort.ToSortOrderEnum(), activeOnly);

            var projectsViewModel = results.ProjectTo<SearchResultViewModel>(_mapper.ConfigurationProvider);

            var pagedModel = new SearchResultsPagedViewModel(term, 
                                                             projectsViewModel, 
                                                             page, 
                                                             DefaultPageSize, 
                                                             activeOnly, 
                                                             sort, 
                                                             previousId);

            return View(SearchView.Index, pagedModel);
        }
    }
}