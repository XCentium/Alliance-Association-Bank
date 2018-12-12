using System.Collections.Generic;
using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Core.Models;

namespace AllianceAssociationBank.Crm.Core.Interfaces
{
    public interface IReformatRepository
    {
        Task<IEnumerable<Aq2Reformat>> GetAq2ReformatsAsync();
        Task<Aq2Reformat> GetAq2ReformatByIdAsync(int id);
        Task<Aq2Reformat> GetAq2ReformatByNameAsync(string reformatName);
        void AddAq2Reformat(Aq2Reformat reformat);
        void RemoveAq2Reformat(Aq2Reformat reformat);
        Task<bool> SaveAllAsync();
    }
}