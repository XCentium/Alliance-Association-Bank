using System.Collections.Generic;
using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Core.Models;

namespace AllianceAssociationBank.Crm.Core.Interfaces
{
    public interface ICheckScannerRepository
    {
        IEnumerable<CheckScanner> GetScanners(int projectId);
        Task<CheckScanner> GetScannerByIdAsync(int id);
        void AddScanner(CheckScanner scanner);
        void RemoveUser(CheckScanner scanner);
        Task<bool> SaveAllAsync();
    }
}