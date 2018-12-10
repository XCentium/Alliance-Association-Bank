using System.Collections.Generic;
using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Reports.Infrastructure;

namespace AllianceAssociationBank.Crm.Core.Interfaces
{
    public interface IReportService
    {
        Task<IReport> GenerateReportByName(string reportName, IDictionary<string, object> reportParameters);
    }
}