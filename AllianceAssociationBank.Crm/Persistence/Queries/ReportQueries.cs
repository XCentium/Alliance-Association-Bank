using AllianceAssociationBank.Crm.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AllianceAssociationBank.Crm.Persistence.Queries
{
    public class ReportQueries
    {
        private CrmApplicationDbContext _context;

        public ReportQueries(CrmApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> ExecuteBoardingReportQueryAsync()
        {
            return await _context.Projects
                .Where(p => p.Status == "In Progress" || p.Status == "Audit Concern")
                .OrderBy(p => p.Priority)
                .ThenBy(p => p.OwnerID)
                .ThenBy(p => p.EndDate)
                .ThenBy(p => p.Status)
                .ToListAsync();
        }
    }
}