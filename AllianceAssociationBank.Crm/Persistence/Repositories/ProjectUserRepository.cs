using AllianceAssociationBank.Crm.Constants.ProjectUsers;
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
    public class ProjectUserRepository : IProjectUserRepository
    {
        private CrmApplicationDbContext _context;

        public ProjectUserRepository(CrmApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProjectUser> GetUsers(int projectId)
        {
            return _context.ProjectUsers
                .OrderBy(u => u.Name)
                .Where(u => u.ProjectID == projectId);
        }

        public async Task<IEnumerable<ProjectUser>> GetUsersByEmailList(int projectId, string emailList)
        {
            return await _context.ProjectUsers
                .Where(u => u.ProjectID == projectId)
                .Where(u => emailList == UsersEmailListName.StatementEmails && u.StatementEmail ||
                            emailList == UsersEmailListName.LockboxEmails && u.LockboxEmail ||
                            emailList == UsersEmailListName.AchEmails && u.ACHEmail)
                .ToListAsync();
        }

        public async Task<ProjectUser> GetUserByIdAsync(int id)
        {
            return await _context.ProjectUsers
                .Where(u => u.ID == id)
                .SingleOrDefaultAsync();
        }

        public void AddUser(ProjectUser user)
        {
            _context.ProjectUsers.Add(user);
        }

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}