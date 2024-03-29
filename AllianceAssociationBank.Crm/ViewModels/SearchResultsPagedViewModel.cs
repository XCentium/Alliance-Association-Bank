﻿using AllianceAssociationBank.Crm.Constants;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.ViewModels
{
    /// <summary>
    /// Paginated list view model that is used on the search page to display list of search results.
    /// </summary>
    public class SearchResultsPagedViewModel : PagedListViewModel<SearchResultViewModel>
    {
        public string SearchTerm { get; set; }

        public string CurrentSort { get; set; }

        [Display(Name = "Active only")]
        public bool ActiveProjectsOnly { get; set; }

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

        /// <summary>
        /// Initialize a new instance of SearchResultsPagedViewModel.
        /// </summary>
        /// <param name="searchTerm">The search phrase/term that is entered by a user.</param>
        /// <param name="projects">IQueryable collection of all projects returned based on the search phrase/term.</param>
        /// <param name="pageNumber">A page number that should be diplayed as the current page.</param>
        /// <param name="pageSize">A number of search results that should be dipslayed on the page.</param>
        /// <param name="activeProjectsOnly"></param>
        /// <param name="currentSort">Specify "asc" for ascending and "desc" for descending to sort the search page results.</param>
        /// <param name="previousRecordId">Specify previous project record Id if user navigated from a project record edit form.</param>
        public SearchResultsPagedViewModel(string searchTerm,
                                           IQueryable<SearchResultViewModel> projects,
                                           int pageNumber,
                                           int pageSize,
                                           bool activeProjectsOnly,
                                           string currentSort,
                                           int? previousRecordId) 
            : base(projects, pageNumber, pageSize)
        {
            SearchTerm = string.IsNullOrEmpty(searchTerm) ? null : searchTerm.Trim();
            CurrentSort = currentSort;
            ActiveProjectsOnly = activeProjectsOnly;
            PreviousRecordId = previousRecordId;
        }
    }
}