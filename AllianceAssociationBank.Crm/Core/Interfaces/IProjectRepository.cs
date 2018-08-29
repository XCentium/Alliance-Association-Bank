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
        IEnumerable<ProjectUser> GetUsers(int projectId);
        Task<ProjectUser> GetUserByIdAsync(int id);
        void AddUser(ProjectUser user);
        void RemoveUser(ProjectUser user);
        Task<bool> SaveAllAsync();
    }
}