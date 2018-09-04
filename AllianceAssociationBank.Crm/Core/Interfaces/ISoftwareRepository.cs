using AllianceAssociationBank.Crm.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Core.Interfaces
{
    public interface ISoftwareRepository
    {
        Task<IEnumerable<Software>> GetSoftwaresAsync();
    }
}