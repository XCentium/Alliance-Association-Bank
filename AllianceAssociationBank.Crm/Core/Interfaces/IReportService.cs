using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Reports.Infrastructure;

namespace AllianceAssociationBank.Crm.Core.Interfaces
{
    public interface IReportService
    {
        Task<IReport> GenerateReportByName(string reportName, params object[] reportParameters);
        string GetReportNameFromQueryString(NameValueCollection nameValueCollection);
        object[] GetReportParametersFromQueryString(NameValueCollection queryStringCollection, string[] queryParameters);
    }
}