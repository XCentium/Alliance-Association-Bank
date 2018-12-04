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
    public class SoftwareRepository : ISoftwareRepository
    {
        private CrmApplicationDbContext _context;

        public SoftwareRepository(CrmApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Software>> GetSoftwareAsync()
        {
            return await _context.Softwares
                .OrderBy(e => e.SoftwareName)
                .ToListAsync();
        }

        public async Task<Software> GetSoftwareByIdAsync(int id)
        {
            return await _context.Softwares
                .Where(s => s.ID == id)
                .SingleOrDefaultAsync();
        }

        public void AddSoftware(Software software)
        {
            _context.Softwares.Add(software);
        }

        public void RemoveSoftware(Software software)
        {
            _context.Softwares.Remove(software);
        }

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}