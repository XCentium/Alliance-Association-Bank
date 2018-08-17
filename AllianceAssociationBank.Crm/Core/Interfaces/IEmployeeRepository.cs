using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using AllianceAssociationBank.Crm.Core.Models;

namespace AllianceAssociationBank.Crm.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<SelectListItem>> GetEmployeeListAsync();
    }
}