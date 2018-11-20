using AllianceAssociationBank.Crm.Reports;

namespace AllianceAssociationBank.Crm.Reports.Infrastructure
{
    public interface IReportSelector
    {
        IReport ResolveByName(string reportName, params object[] reportParameters);
    }
}