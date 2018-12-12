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

        public async Task<IEnumerable<Aq2Reformat>> GetAq2ReformatsAsync()
        {
            return await _context.Aq2Reformats
                .OrderBy(e => e.ReformatName)
                .ToListAsync();
        }

        public async Task<Aq2Reformat> GetAq2ReformatByIdAsync(int id)
        {
            return await _context.Aq2Reformats
                .Where(s => s.ID == id)
                .SingleOrDefaultAsync();
        }

        public async Task<Aq2Reformat> GetAq2ReformatByNameAsync(string reformatName)
        {
            return await _context.Aq2Reformats
                .Where(e => e.ReformatName == reformatName)
                .SingleOrDefaultAsync();
        }

        public void AddAq2Reformat(Aq2Reformat reformat)
        {
            _context.Aq2Reformats.Add(reformat);
        }

        public void RemoveAq2Reformat(Aq2Reformat reformat)
        {
            _context.Aq2Reformats.Remove(reformat);
        }

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}