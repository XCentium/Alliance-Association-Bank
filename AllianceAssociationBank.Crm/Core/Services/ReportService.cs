using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Reports.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

        public async Task<IReport> GenerateReportByName(string reportName, params object[] reportParameters)
        {
            if (string.IsNullOrEmpty(reportName))
            {
                throw new ArgumentNullException("reportName", "Value cannot be null.");
            }

            var report = _reportSelector.ResolveByName(reportName, reportParameters);

            await report.ExecuteReport();

            return report;
        }

        public string GetReportNameFromQueryString(NameValueCollection queryStringCollection)
        {
            return queryStringCollection[QueryStringValue.ReportName];
        }

        public object[] GetReportParametersFromQueryString(NameValueCollection queryStringCollection, string[] queryParameters)
        {
            var parametersList = new List<object>();

            foreach (var queryParameter in queryParameters)
            {
                var parameterValue = queryStringCollection[queryParameter];

                if (string.IsNullOrEmpty(parameterValue))
                {
                    continue;
                }
                else if (DateTime.TryParse(parameterValue, out var dateTimeParameter))
                {
                    parametersList.Add(dateTimeParameter);
                }
                else if (int.TryParse(parameterValue, out var integerParameter))
                {
                    parametersList.Add(integerParameter);
                }
                else
                {
                    parametersList.Add(parameterValue);
                }
            }

            return parametersList.ToArray();
        }
    }
}