using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.ViewModels
{
    public class UsersPagedListViewModel : PagedListViewModel<UserFormViewModel>
    {
        public int ProjectID { get; set; }

        public UsersPagedListViewModel(int projectId, IEnumerable<UserFormViewModel> allUsers, int pageNumber, int pageSize)
            : base (allUsers, pageNumber, pageSize)
        {
            ProjectID = projectId;
        }
    }
}