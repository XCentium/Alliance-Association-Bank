using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Reports.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity;

namespace AllianceAssociationBank.Crm.Core.Services
{
    public class ReportService : IReportService
    {
        private IReportSelector _reportSelector;

        public ReportService() : this(UnityConfig.Container.Resolve<IReportSelector>())
        {
        }

        public ReportService(IReportSelector reportSelector)
        {
            _reportSelector = reportSelector ?? throw new ArgumentNullException("reportSelector", "Value cannot be null.");
        }

        public async Task<IReport> GenerateReportByName(string reportName, IDictionary<string, object> reportParameters)
        {
            if (string.IsNullOrEmpty(reportName))
            {
                throw new ArgumentNullException("reportName", "Value cannot be null.");
            }

            IReport report;

            if (TryGetInt32Parameter(reportParameters, ReportParameterName.ProjectId, out int projectIdParam))
            {
                report = _reportSelector.ResolveByName(reportName, projectIdParam);
            }
            else
            {
                report = _reportSelector.ResolveByName(reportName);
            }

            await report.ExecuteReport();

            return report;
        }

        private bool TryGetInt32Parameter(IDictionary<string, object> parameters, string parameterName, out int parameterValue)
        {
            parameterValue = 0;

            if (parameters.TryGetValue(parameterName, out var value) && 
                value != null && 
                int.TryParse(value.ToString(), out parameterValue))
            {
                return true;
            }

            return false;
        }
    }
}