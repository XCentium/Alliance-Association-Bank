using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AllianceAssociationBank.Crm.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private CrmApplicationDbContext _dbContext;

        public ProjectRepository(CrmApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _dbContext.Projects
                .OrderBy(p => p.ProjectName)
                .ToListAsync();
        }

        public void AddProject(Project project)
        {
            _dbContext.Projects.Add(project);
        }

        //public void UpdateProject(Project project)
        //{
        //    _dbContext.Projects.Update(project);
        //}

        public async Task<bool> SaveAllAsync()
        {
            return (await _dbContext.SaveChangesAsync()) > 0;
        }
    }
}