using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Persistence.Enums;

namespace AllianceAssociationBank.Crm.Core.Interfaces
{
    public interface IProjectUserRepository
    {
        IEnumerable<ProjectUser> GetUsers(int projectId);
        IQueryable<ProjectUser> GetUsers(int projectId, UserFilter filter);
        Task<IEnumerable<ProjectUser>> GetUsersByEmailList(int projectId, string emailList);
        Task<ProjectUser> GetUserByIdAsync(int id);
        void AddUser(ProjectUser user);
        Task<bool> SaveAllAsync();
    }
}