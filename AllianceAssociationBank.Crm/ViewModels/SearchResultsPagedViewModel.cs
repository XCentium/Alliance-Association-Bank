using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.ViewModels
{
    public class SearchResultsPagedViewModel : PagedListViewModel<ProjectFormViewModel>
    {
        [Required]
        public string SearchTerm { get; set; }

        public SearchResultsPagedViewModel() 
            : base(new List<ProjectFormViewModel>(), 1, 10)
        {
        }

        public SearchResultsPagedViewModel(string searchTerm, IEnumerable<ProjectFormViewModel> projects, int pageNumber, int pageSize) 
            : base(projects, pageNumber, pageSize)
        {
            SearchTerm = searchTerm;
        }
    }
}