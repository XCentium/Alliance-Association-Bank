using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.ViewModels
{
    /// <summary>
    /// Paginated list view model that is used on Users tab to display list of project users.
    /// </summary>
    public class UsersPagedListViewModel : PagedListViewModel<UserFormViewModel>
    {
        public int ProjectID { get; set; }

        /// <summary>
        /// Initialize a new instance of UsersPagedListViewModel.
        /// </summary>
        /// <param name="projectId">The project Id that this user list is related to.</param>
        /// <param name="allUsers">IQueryable collection of all users.</param>
        /// <param name="pageNumber">A page number that should be diplayed as the current page.</param>
        /// <param name="pageSize">A number of users that should be dipslayed on the page.</param>
        public UsersPagedListViewModel(int projectId, IQueryable<UserFormViewModel> allUsers, int pageNumber, int pageSize)
            : base (allUsers, pageNumber, pageSize)
        {
            ProjectID = projectId;
        }
    }
}