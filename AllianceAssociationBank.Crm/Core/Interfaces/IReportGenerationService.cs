using System.Threading.Tasks;
using Microsoft.Reporting.WebForms;

namespace AllianceAssociationBank.Crm.Core.Interfaces
{
    public interface IReportGenerationService
    {
        Task<ReportViewer> GenerateReportByName(string reportName, int? projectId = null);
        //ReportViewer GenerateReportByName(string reportName, int? projectId = null);
    }
}