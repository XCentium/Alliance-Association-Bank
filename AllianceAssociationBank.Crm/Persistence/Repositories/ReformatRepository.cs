using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Persistence.Repositories
{
    public class ReformatRepository : IReformatRepository
    {
        private CrmApplicationDbContext _context;

        public ReformatRepository(CrmApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Aq2Reformat>> GetReformatsAsync()
        {
            return await _context.Aq2Reformats
                .OrderBy(e => e.ReformatName)
                .ToListAsync();
        }

        public async Task<Aq2Reformat> GetReformatByIdAsync(int id)
        {
            return await _context.Aq2Reformats
                .Where(s => s.ID == id)
                .SingleOrDefaultAsync();
        }

        public async Task<Aq2Reformat> GetReformatByNameAsync(string reformatName)
        {
            return await _context.Aq2Reformats
                .Where(e => e.ReformatName == reformatName)
                .SingleOrDefaultAsync();
        }

        public async Task<int> GetCountOfAssociatedActiveProjects(int id)
        {
            return await _context.Projects
                .Where(p => p.Active)
                .Where(p => p.ReformatAQ2ID == id)
                .CountAsync();
        }

        public void AddReformat(Aq2Reformat reformat)
        {
            _context.Aq2Reformats.Add(reformat);
        }

        public void RemoveReformat(Aq2Reformat reformat)
        {
            _context.Aq2Reformats.Remove(reformat);
        }

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}