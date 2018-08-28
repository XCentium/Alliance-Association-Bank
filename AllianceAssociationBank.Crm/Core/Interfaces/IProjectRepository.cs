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
        Task<IEnumerable<ProjectDto>> GetProjectsBySearchPhraseAsync(string searchPhrase);
        Task<Project> GetProjectByIdAsync(int id);
        void AddProject(Project project);
        Task<ProjectUser> GetProjectUserByIdAsync(int id);
        void AddProjectUser(ProjectUser user);
        Task<bool> SaveAllAsync();
    }
}