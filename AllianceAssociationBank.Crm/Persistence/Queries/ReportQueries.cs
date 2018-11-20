using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Core.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Core.Dtos;
using AllianceAssociationBank.Crm.Helpers;
using AutoMapper;
using AllianceAssociationBank.Crm.Constants.Projects;
using AutoMapper.QueryableExtensions;

namespace AllianceAssociationBank.Crm.Persistence.Queries
{
    public class ReportQueries : IReportQueries
    {
        private CrmApplicationDbContext _context;
        private IMapper _mapper;

        public ReportQueries(CrmApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Project>> GetBoardingDataSetAsync()
        {
            return await _context.Projects
                .Where(p => p.Status == ProjectStatus.InProgress || p.Status == ProjectStatus.AuditConcern)
                .OrderBy(p => p.OwnerID)
                .ThenBy(p => p.AFPID)
                .ThenBy(p => p.ProjectName)
                .ThenBy(p => p.OwnerID)
                .ThenBy(p => p.EndDate)
                .ThenBy(p => p.Status)
                .ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetSoftwareTransitionDataSetAsync()
        {
            return await _context.Projects
                .Where(p => p.Status == ProjectStatus.SoftwareTransition)
                .OrderBy(p => p.OwnerID)
                .ThenBy(p => p.AFPID)
                .ThenBy(p => p.ProjectName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetCompletedAndHoldDataSetAsync()
        {
            return await _context.Projects
                .Where(p => p.Status == ProjectStatus.Completed || p.Status == ProjectStatus.Deferred)
                .OrderBy(p => p.ProjectName)
                .ThenBy(p => p.OwnerID)
                .ToListAsync();
        }

        /// <summary>
        ///This query is used by CmcById report, CmcByIdUsefulInfo report, CmcList export and CmcUsefulInfoList export.
        /// </summary>
        /// <returns>Returns a collection of CmcReportDatasetDto objects.</returns>
        public async Task<IEnumerable<CmcReportDatasetDto>> GetCmcByIdDataSetAsync()
        {
            var results = await _context.Projects
                .OrderBy(p => p.LockboxCMCID)
                .ThenBy(p => p.ProjectName)
                .Include(p => p.Owner)
                .Include(p => p.AFP)
                .ToListAsync();

            return _mapper.Map<IEnumerable<CmcReportDatasetDto>>(results);
        }

        /// <summary>
        ///This query is used by CmcByName report and CmcAddressByName report.
        /// </summary>
        /// <returns>Returns a collection of CmcReportDatasetDto objects.</returns>
        public async Task<IEnumerable<CmcReportDatasetDto>> GetCmcByNameDataSetAsync()
        {
            var results = await _context.Projects
                .OrderBy(p => p.ProjectName)
                .Include(p => p.Owner)
                .Include(p => p.AFP)
                .ToListAsync();

            return _mapper.Map<IEnumerable<CmcReportDatasetDto>>(results);
        }

        //public async Task<IEnumerable<CmcReportDatasetDto>> GetCmcAddressByNameDataSetAsync()
        //{
        //    var results = await _context.Projects
        //        .OrderBy(p => p.ProjectName)
        //        .ToListAsync();

        //    return _mapper.Map<IEnumerable<CmcReportDatasetDto>>(results);
        //}

        public async Task<IEnumerable<Project>> GetAllInfoDataSetAsync()
        {
            return await _context.Projects
                .OrderBy(p => p.ID)
                .Include(p => p.Owner)
                .Include(p => p.AFP)
                .Include(p => p.BoardingManager)
                .Include(p => p.ReformatAQ2)
                .ToListAsync();
        }

        public async Task<IEnumerable<CDEmailsDatasetDto>> GetCDEmailsDataSetAsync()
        {
            var results = await _context.Projects
                .Include(p => p.Users)
                .ToListAsync();

            // TODO: move this to automapper profile
            return results.Select(p => new CDEmailsDatasetDto()
            {
                ProjectName = p.ProjectName,
                LockboxCMCID = p.LockboxCMCID,
                StatementEmails = EmailListHelper.Concatenate(p.Users
                                                                .Where(u => u.StatementEmail)
                                                                .Select(u => u.Email))
            })
            .OrderBy(p => string.IsNullOrEmpty(p.StatementEmails))
            .ThenBy(p => p.ProjectName);
        }

        public async Task<IEnumerable<Project>> GetCouponDataSetAsync()
        {
            return await _context.Projects
                .OrderBy(p => p.ProjectName)
                .ToListAsync();
        }

        /// <summary>
        ///This query is used by AchSpec, AchInitialReview, AchSixMonthReview, AchRiskInitial, AchRiskSixMonth and AchRiskPostSixMonth reports.
        /// </summary>
        /// <returns>Returns a collection of AchReportDatasetDto objects.</returns>
        public async Task<IEnumerable<AchReportDatasetDto>> GetAchReportDataSetAsync(int? projectId)
        {
            var results = await _context.Projects
                .Where(p => p.ID == projectId || projectId == null)
                .OrderBy(p => p.ProjectName)
                .Include(p => p.Owner)
                .ToListAsync();

            return _mapper.Map<IEnumerable<AchReportDatasetDto>>(results);
        }

        public async Task<IEnumerable<AchReportDatasetDto>> GetAchAllCompaniesDataSetAsync()
        {
            var results = await _context.Projects
                .OrderByDescending(p => p.ACHLimitAndSpecSubmitted) // True first then False
                .ThenBy(p => p.Institution)
                .ThenBy(p => p.ProjectName)
                .Include(p => p.Owner)
                .ToListAsync();

            return _mapper.Map<IEnumerable<AchReportDatasetDto>>(results);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesDataSetAsync()
        {
            return await _context.Employees
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToListAsync();
        }
    }
}