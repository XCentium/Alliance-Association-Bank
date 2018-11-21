using AllianceAssociationBank.Crm.Constants;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.ViewModels
{
    /// <summary>
    /// Paginated list view model that is used on the search page to display list of search results.
    /// </summary>
    public class SearchResultsPagedViewModel : PagedListViewModel<ProjectFormViewModel>
    {
        public string SearchTerm { get; set; }

        public string CurrentSort { get; set; }

        public string ResultsLabel
        {
            get
            {
                var label = TotalItems == 1 ? "{0} Result" : "{0} Results";
                return String.Format(label, TotalItems);
            }
        }

        public int? PreviousRecordId { get; set; }

        public string SortOrderParam
        {
            get
            {
                if (CurrentSort == SortOrderString.Descending)
                {
                    return SortOrderString.Ascending;
                }
                else
                {
                    return SortOrderString.Descending;
                }
            }
        }

        /// Initialize an empty new instance of SearchResultsPagedViewModel.
        public SearchResultsPagedViewModel() 
            : base(new Collection<ProjectFormViewModel>(), 1, 10)
        {
        }

        /// <summary>
        /// Initialize a new instance of SearchResultsPagedViewModel.
        /// </summary>
        /// <param name="searchTerm">The search phrase/term that is entered by a user.</param>
        /// <param name="projects">IQueryable collection of all projects returned based on the search phrase/term.</param>
        /// <param name="pageNumber">A page number that should be diplayed as the current page.</param>
        /// <param name="pageSize">A number of search results that should be dipslayed on the page.</param>
        /// <param name="currentSort">Specify "asc" for ascending and "desc" for descending to sort the search page results.</param>
        /// <param name="previousRecordId">Specify previous project record Id if user navigated from a project record edit form.</param>
        public SearchResultsPagedViewModel(string searchTerm, 
                                           IQueryable<ProjectFormViewModel> projects, 
                                           int pageNumber, 
                                           int pageSize, 
                                           string currentSort = null,
                                           int? previousRecordId = null) 
            : base(projects, pageNumber, pageSize)
        {
            SearchTerm = searchTerm?.Trim();
            CurrentSort = currentSort;
            PreviousRecordId = previousRecordId;
        }
    }
}