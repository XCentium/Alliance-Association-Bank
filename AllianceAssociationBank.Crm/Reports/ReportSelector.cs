using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AllianceAssociationBank.Crm.Reports
{
    public class ReportSelector
    {
        private static readonly string REPORTS_NAMESPACE = MethodBase.GetCurrentMethod().DeclaringType.Namespace;

        public static IReport ResolveByName(string reportName, params int[] reportParameters)
        {
            var reportType = GetTypeByReportName(reportName);
            var reportInstance = (IReport)Activator.CreateInstance(reportType);
            return reportInstance;

            //switch (reportName)
            //{
            //    case var name when name.EqualsIgnoreCase(ReportName.Boarding):
            //        {
            //            return new BoardingReport();
            //        }
            //    default:
            //        throw new InvalidReportException($"Cannot identify report by the name of {reportName}.");
            //}
        }

        private static Type GetTypeByReportName(string reportName)
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

        private static string FormatName(string name)
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