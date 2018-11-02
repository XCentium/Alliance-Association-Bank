using AllianceAssociationBank.Crm.Constants;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AllianceAssociationBank.Crm.ViewModels
{
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
                if (CurrentSort == SortOrder.Descending)
                {
                    return SortOrder.Ascending;
                }
                else
                {
                    return SortOrder.Descending;
                }
            }
        }

        public SearchResultsPagedViewModel() 
            : base(new Collection<ProjectFormViewModel>(), 1, 10)
        {
        }

        public SearchResultsPagedViewModel(string searchTerm, 
                                           IQueryable<ProjectFormViewModel> projects, 
                                           int pageNumber, 
                                           int pageSize, 
                                           string currentSort = null,
                                           int? previousRecordId = null) 
            : base(projects, pageNumber, pageSize)
        {
            SearchTerm = searchTerm;
            CurrentSort = currentSort;
            PreviousRecordId = previousRecordId;
        }
    }
}