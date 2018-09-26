using System.Collections.Generic;
using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Core.Models;

namespace AllianceAssociationBank.Crm.Core.Interfaces
{
    public interface IReformatRepository
    {
        Task<IEnumerable<Aq2Reformat>> GetAq2ReformatsAsync();
        Task<IEnumerable<EcpReformat>> GetEcpReformatsAsync();
    }
}