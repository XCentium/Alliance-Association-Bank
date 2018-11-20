using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AllianceAssociationBank.Crm.Persistence.Repositories
{
    public class CheckScannerRepository : ICheckScannerRepository
    {
        private CrmApplicationDbContext _context;

        public CheckScannerRepository(CrmApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CheckScanner> GetScanners(int projectId)
        {
            return _context.CheckScanners
                .OrderBy(s => s.DateInstalled)
                .Where(u => u.ProjectID == projectId);
        }

        public async Task<CheckScanner> GetScannerByIdAsync(int id)
        {
            return await _context.CheckScanners
                .Where(s => s.ID == id)
                .SingleOrDefaultAsync();
        }

        public void AddScanner(CheckScanner scanner)
        {
            _context.CheckScanners.Add(scanner);
        }

        public void RemoveScanner(CheckScanner scanner)
        {
            _context.CheckScanners.Remove(scanner);
        }

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}