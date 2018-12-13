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
        Task<IEnumerable<CmcReportDataSetDto>> GetCmcByIdDataSetAsync();
        Task<IEnumerable<CmcReportDataSetDto>> GetCmcByIdUsefulInfoDataSetAsync();
        Task<IEnumerable<CmcReportDataSetDto>> GetCmcByNameDataSetAsync();
        Task<IEnumerable<Project>> GetAllInfoDataSetAsync();
        Task<IEnumerable<CDEmailsDataSetDto>> GetCDEmailsDataSetAsync();
        Task<IEnumerable<Project>> GetCouponDataSetAsync();
        Task<IEnumerable<AchReportDataSetDto>> GetAchReportDataSetAsync(int? projectId);
        Task<IEnumerable<AchReportDataSetDto>> GetAchRiskReviewDataSetAsync();
        Task<IEnumerable<ProjectReportDataSetDto>> GetCipReviewDataSetAsync();
        Task<IEnumerable<ProjectReportDataSetDto>> GetWelcomeChecklistDataSetAsync(int projectId);
        Task<IEnumerable<IncorrectEmployeeDataSetDto>> GetIncorrectEmployeeDataSetAsync();
        Task<IEnumerable<Employee>> GetEmployeesDataSetAsync();
    }
}