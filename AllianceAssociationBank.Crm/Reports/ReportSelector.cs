using AllianceAssociationBank.Crm.Reports.Interfaces;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Extensions;
using System;
using System.Linq;
using System.Reflection;

namespace AllianceAssociationBank.Crm.Reports
{
    public class ReportSelector : IReportSelector
    {
        private static readonly string REPORTS_NAMESPACE = MethodBase.GetCurrentMethod().DeclaringType.Namespace;

        //public ReportSelector()
        //{
        //}

        public IReport ResolveByName(string reportName, params object[] reportParameters)
        {
            var reportType = GetTypeByReportName(reportName);
            var reportInstance = (IReport)Activator.CreateInstance(reportType, reportParameters);
            return reportInstance;
        }

        private Type GetTypeByReportName(string reportName)
        {
            var reportClassName = FormatName(reportName);

            var types = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.Name.EqualsIgnoreCase(reportClassName) && t.Namespace == REPORTS_NAMESPACE);

            if (types.Count() == 1)
            {
                return types.First();
            }
            else
            {
                throw new InvalidReportException($"Cannot identify report by the name of {reportName}.");
            }
        }

        private string FormatName(string name)
        {
            const string REPORT = "Report";

            name = name.Replace("-", string.Empty);
            if (!name.EndsWith(REPORT, StringComparison.InvariantCultureIgnoreCase))
            {
                name += REPORT;
            }

            return name;
        }
    }
}