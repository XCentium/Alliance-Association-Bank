using System.Collections.Generic;
using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Core.Models;

namespace AllianceAssociationBank.Crm.Core.Interfaces
{
    public interface IReformatRepository
    {
        Task<IEnumerable<Aq2Reformat>> GetReformatsAsync();
        Task<Aq2Reformat> GetReformatByIdAsync(int id);
        Task<Aq2Reformat> GetReformatByNameAsync(string reformatName);
        Task<int> GetCountOfAssociatedActiveProjects(int id);
        void AddReformat(Aq2Reformat reformat);
        void RemoveReformat(Aq2Reformat reformat);
        Task<bool> SaveAllAsync();
    }
}