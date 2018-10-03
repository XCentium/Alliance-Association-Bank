using AllianceAssociationBank.Crm.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
            : base(new List<ProjectFormViewModel>(), 1, 10)
        {
        }

        public SearchResultsPagedViewModel(string searchTerm, IEnumerable<ProjectFormViewModel> projects, int pageNumber, int pageSize, string currentSort = null) 
            : base(projects, pageNumber, pageSize)
        {
            SearchTerm = searchTerm;
            CurrentSort = currentSort;
        }
    }
}