using System.Collections.Generic;
using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Core.Models;

namespace AllianceAssociationBank.Crm.Core.Interfaces
{
    public interface IProjectUserRepository
    {
        IEnumerable<ProjectUser> GetUsers(int projectId);
        Task<ProjectUser> GetUserByIdAsync(int id);
        void AddUser(ProjectUser user);
        Task<bool> SaveAllAsync();
    }
}