using System.Collections.Generic;
using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Core.Models;

namespace AllianceAssociationBank.Crm.Core.Interfaces
{
    public interface IReportQueries
    {
        Task<IEnumerable<Project>> GetBoardingDataSetAsync();
        Task<IEnumerable<Project>> GetCompletedAndHoldDataSetAsync();
        Task<IEnumerable<Project>> GetSoftwareTransitionDataSetAsync();
        Task<IEnumerable<Employee>> GetEmployeesDataSetAsync();
        Task<IEnumerable<Software>> GetSoftwareDataSetAsync();
    }
}