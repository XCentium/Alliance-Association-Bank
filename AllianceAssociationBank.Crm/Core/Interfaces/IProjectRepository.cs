using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Persistence.Enums;

namespace AllianceAssociationBank.Crm.Core.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetProjectsAsync();
        IQueryable<Project> GetProjectsBySearchTerm(string searchTerm, SortOrder sortOrder);
        IQueryable<Project> GetProjectsBySearchTerm(string searchTerm, SortOrder sortOrder, bool activeOnly);
        Task<Project> GetProjectByIdAsync(int id);
        void AddProject(Project project);
        Task<bool> SaveAllAsync();
    }
}