using System.Collections.Generic;
using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Core.Dtos;
using AllianceAssociationBank.Crm.Core.Models;

namespace AllianceAssociationBank.Crm.Core.Interfaces
{
    public interface IReportQueries
    {
        Task<IEnumerable<Project>> GetBoardingDataSetAsync();
        Task<IEnumerable<Project>> GetCompletedAndHoldDataSetAsync();
        Task<IEnumerable<Project>> GetSoftwareTransitionDataSetAsync();
        Task<IEnumerable<Project>> GetCmcByIdDataSetAsync();
        Task<IEnumerable<Project>> GetCmcByNameDataSetAsync();
        Task<IEnumerable<CDEmailsDatasetDto>> GetCDEmailsDataSetAsync();
        Task<IEnumerable<Project>> GetCouponDataSetAsync();
        Task<IEnumerable<Project>> GetAchSpecDataSetAsync(int? projectId);
        Task<IEnumerable<Employee>> GetEmployeesDataSetAsync();
    }
}