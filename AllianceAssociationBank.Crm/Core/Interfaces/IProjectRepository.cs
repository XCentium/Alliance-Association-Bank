using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using AllianceAssociationBank.Crm.Core.Dtos;
using AllianceAssociationBank.Crm.Core.Models;

namespace AllianceAssociationBank.Crm.Core.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetProjectsAsync();
        Task<IEnumerable<SelectListItem>> GetProjectListAsync();
        Task<IEnumerable<ProjectDto>> GetProjectsBySearchPhrase(string searchPhrase);
        Task<Project> GetProjectById(int id);
        void AddProject(Project project);
        Task<bool> SaveAllAsync();
    }
}