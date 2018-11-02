using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Core.Dtos;
using AllianceAssociationBank.Crm.Core.Models;

namespace AllianceAssociationBank.Crm.Core.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetProjectsAsync();
        //Task<IEnumerable<Project>> GetProjectsBySearchTermAsync(string searchTerm, string sortOrder);
        IQueryable<Project> GetProjectsBySearchTerm(string searchTerm, string sortOrder);
        Task<Project> GetProjectByIdAsync(int id);
        void AddProject(Project project);
        Task<bool> SaveAllAsync();
    }
}