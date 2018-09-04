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

        public async Task<IEnumerable<Software>> GetSoftwaresAsync()
        {
            return await _context.Softwares
                .OrderBy(e => e.SoftwareName)
                .ToListAsync();
        }
    }
}