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

        public async Task<IEnumerable<EcpReformat>> GetEcpReformatsAsync()
        {
            return await _context.EcpReformats
                .OrderBy(e => e.ReformatName)
                .ToListAsync();
        }
    }
}