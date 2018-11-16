using AllianceAssociationBank.Crm.Reports;

namespace AllianceAssociationBank.Crm.Reports.Interfaces
{
    public interface IReportSelector
    {
        IReport ResolveByName(string reportName, params object[] reportParameters);
    }
}