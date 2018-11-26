using AllianceAssociationBank.Crm.Core.Dtos;
using CsvHelper.Configuration;

namespace AllianceAssociationBank.Crm.Mappings
{
    public class CmcListExportMap : ClassMap<CmcReportDataSetDto>
    {
        public CmcListExportMap()
        {
            Map(m => m.ProjectName).Name("Project Name");
            Map(m => m.LockboxCMCID).Name("Lockbox CMC ID");
            Map(m => m.AFPName).Name("AFP");
            Map(m => m.OwnerName).Name("Owner");
            Map(m => m.POBoxLine1).Name("PO Box Line 1 ");
        }

        //private string MapEmployeeName(Employee employee)
        //{
        //    return employee != null ? $"{employee.FirstName} {employee.LastName}" : string.Empty;
        //}
    }
}