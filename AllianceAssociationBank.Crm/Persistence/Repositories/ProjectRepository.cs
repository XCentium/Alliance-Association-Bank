using AllianceAssociationBank.Crm.Core.Dtos;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private CrmApplicationDbContext _context;

        public ProjectRepository(CrmApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await _context.Projects
                .OrderBy(p => p.ProjectName)
                .ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _context.Projects
                .Where(p => p.ID == id)
                .Include(p => p.Users)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetProjectListAsync()
        {
            return await _context.Projects
                .OrderBy(p => p.ProjectName)
                .Select(p => new SelectListItem()
                {
                    Value = p.ID.ToString(),
                    Text = p.ProjectName
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ProjectDto>> GetProjectsBySearchPhraseAsync(string searchPhrase)
        {
            return await _context.Projects
                .OrderBy(p => p.ProjectName)
                .Where(p => p.ProjectName.Contains(searchPhrase) || p.LockboxCMCID == searchPhrase)
                .Select(p => new ProjectDto()
                {
                    Value = p.ID,
                    Label = p.ProjectName
                })
                .ToListAsync();
        }

        public void AddProject(Project project)
        {
            _context.Projects.Add(project);
        }

        //public void UpdateProject(Project project)
        //{
        //    _dbContext.Projects.Update(project);
        //}

        public async Task<ProjectUser> GetProjectUserByIdAsync(int id)
        {
            return await _context.ProjectUsers
                .Where(u => u.ID == id)
                .SingleOrDefaultAsync();
        }

        public void AddProjectUser(ProjectUser user)
        {
            _context.ProjectUsers.Add(user);
        }

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}