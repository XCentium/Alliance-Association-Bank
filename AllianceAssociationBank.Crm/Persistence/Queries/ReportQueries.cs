﻿using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

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
                .OrderBy(p => p.Priority)
                .ThenBy(p => p.OwnerID)
                .ThenBy(p => p.EndDate)
                .ThenBy(p => p.Status)
                .ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetSoftwareTransitionDataSetAsync()
        {
            return await _context.Projects
                .Where(p => p.Status == "Software Transition")
                .OrderBy(p => p.Priority)
                .ThenBy(p => p.OwnerID)
                .ThenBy(p => p.EndDate)
                .ThenBy(p => p.Status)
                .ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetCompletedAndHoldDataSetAsync()
        {
            return await _context.Projects
                .Where(p => p.Status == "Completed" || p.Status == "Deferred")
                .OrderByDescending(p => p.Status)
                .ThenBy(p => p.Priority)
                .ThenByDescending(p => p.EndDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetCmcByIdDataSetAsync()
        {
            return await _context.Projects
                .OrderBy(p => p.LockboxCMCID)
                .Include(p => p.OwnerEmployee)
                .Include(p => p.AFPEmployee)
                .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesDataSetAsync()
        {
            return await _context.Employees
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Software>> GetSoftwareDataSetAsync()
        {
            return await _context.Softwares
                .OrderBy(e => e.SoftwareName)
                .ToListAsync();
        }
    }
}