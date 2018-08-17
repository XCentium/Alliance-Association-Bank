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
    public class EmployeeRepository : IEmployeeRepository
    {
        private CrmApplicationDbContext _context;

        public EmployeeRepository(CrmApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetEmployeeListAsync()
        {
            return await _context.Employees
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new SelectListItem()
                {
                    Value = e.ID.ToString(),
                    Text = e.FirstName + " " + e.LastName
                })
                .ToListAsync();
        }
    }
}