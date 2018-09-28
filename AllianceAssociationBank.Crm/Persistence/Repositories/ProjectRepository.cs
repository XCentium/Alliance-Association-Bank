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
                .SingleOrDefaultAsync();
        }

        // TODO: Still need to add projects users based search
        public async Task<IEnumerable<Project>> GetProjectsBySearchPhraseAsync(string searchTerm)
        {
            // TODO: remove this
            //_context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

            return await _context.Projects
                .OrderBy(p => p.ProjectName)
                .Where(p =>
                    p.ProjectName.Contains(searchTerm) ||
                    p.DBA.Contains(searchTerm) ||
                    p.OtherName.Contains(searchTerm) ||
                    p.TIN == searchTerm || // TODO: need to refine this
                    p.LockboxCMCID == searchTerm ||
                    p.Phone == searchTerm || // TODO: need to refine this
                   
                    p.Users.Any(u => u.Name.Contains(searchTerm) && u.Active) ||
                    p.Users.Any(u => u.Phone == searchTerm && u.Active) || // TODO: need to refine this
                    p.Users.Any(u => u.Email == searchTerm && u.Active))
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

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}