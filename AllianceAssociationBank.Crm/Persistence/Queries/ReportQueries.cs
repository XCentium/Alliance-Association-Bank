using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AllianceAssociationBank.Crm.Core.Dtos;
using AllianceAssociationBank.Crm.Helpers;

namespace AllianceAssociationBank.Crm.Persistence.Queries
{
    public class ReportQueries : IReportQueries
    {
        private CrmApplicationDbContext _context;

        public ReportQueries(CrmApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetBoardingDataSetAsync()
        {
            return await _context.Projects
                .Where(p => p.Status == "In Progress" || p.Status == "Audit Concern")
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
                .Where(p => p.Status == "Software Transition")
                .OrderBy(p => p.OwnerID)
                .ThenBy(p => p.AFPID)
                .ThenBy(p => p.ProjectName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetCompletedAndHoldDataSetAsync()
        {
            return await _context.Projects
                .Where(p => p.Status == "Completed" || p.Status == "Deferred")
                .OrderBy(p => p.ProjectName)
                //.ThenBy(p => p.Category)
                .ThenBy(p => p.OwnerID)
                .ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetCmcByIdDataSetAsync()
        {
            return await _context.Projects
                .OrderBy(p => p.LockboxCMCID)
                .ThenBy(p => p.ProjectName)
                .Include(p => p.Owner)
                .Include(p => p.AFP)
                .ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetCmcByNameDataSetAsync()
        {
            return await _context.Projects
                .OrderBy(p => p.ProjectName)
                .ToListAsync();
        }


        public async Task<IEnumerable<Project>> GetAllInfoDataSetAsync()
        {
            return await _context.Projects
                .OrderBy(p => p.ID)
                .Include(p => p.Owner)
                .Include(p => p.AFP)
                .Include(p => p.BoardingManager)
                .Include(p => p.ReformatAQ2)
                //.Include(p => p.Users)
                .ToListAsync();
        }


        public async Task<IEnumerable<CDEmailsDatasetDto>> GetCDEmailsDataSetAsync()
        {
            var results = await _context.Projects
                .Include(p => p.Users)
                .ToListAsync();

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

        public async Task<IEnumerable<Project>> GetAchReportDataSetAsync(int? projectId)
        {
            return await _context.Projects
                .Where(p => p.ID == projectId || projectId == null)
                .OrderBy(p => p.ProjectName)
                .ToListAsync();
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