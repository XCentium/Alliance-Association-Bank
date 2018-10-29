using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Core.Dtos;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
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

        // TODO: change sort order to Enum
        //public async Task<IEnumerable<Project>> GetProjectsBySearchTermAsync(string searchTerm, string sortOrder)
        public IQueryable<Project> GetProjectsBySearchTerm(string searchTerm, string sortOrder)
        {
            var searchFormatter = new SearchTermFormatter(searchTerm);
            var formattedForName = searchFormatter.FormatForName();
            var formattedForTIN = searchFormatter.FormatForTIN();
            var formattedForPhone = searchFormatter.FormatForPhone();

            var results = _context.Projects.Where(p =>
                    p.LockboxCMCID == searchTerm ||
                    DbFunctions.Like(p.ProjectName, formattedForName) ||
                    DbFunctions.Like(p.DBA, formattedForName) ||
                    DbFunctions.Like(p.OtherName, formattedForName) ||
                    DbFunctions.Like(p.TIN, formattedForTIN) ||
                    DbFunctions.Like(p.Phone, formattedForPhone) ||
                    p.Users.Any(u => u.Email == searchTerm && u.Active) ||
                    p.Users.Any(u => DbFunctions.Like(u.Name, formattedForName) && u.Active)||
                    p.Users.Any(u => DbFunctions.Like(u.Phone, formattedForPhone) && u.Active));

            if (sortOrder == SortOrder.Descending)
            {
                return results.OrderByDescending(p => p.ProjectName);
            }
            else
            {
                return results.OrderBy(p => p.ProjectName);
            }
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