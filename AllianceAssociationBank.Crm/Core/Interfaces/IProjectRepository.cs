using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using AllianceAssociationBank.Crm.Core.Models;

namespace AllianceAssociationBank.Crm.Core.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<IEnumerable<SelectListItem>> GetProjectsList();
        Task<Project> GetProjectById(int id);
        void AddProject(Project project);
        Task<bool> SaveAllAsync();
    }
}