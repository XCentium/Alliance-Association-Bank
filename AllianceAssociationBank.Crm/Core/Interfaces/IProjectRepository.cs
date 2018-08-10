using System.Collections.Generic;
using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Core.Models;

namespace AllianceAssociationBank.Crm.Core.Interfaces
{
    public interface IProjectRepository
    {
        void AddProject(Project project);
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<bool> SaveAllAsync();
    }
}