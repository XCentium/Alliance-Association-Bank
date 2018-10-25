using AllianceAssociationBank.Crm.Core.Models;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Mappings
{
    public class CmcListExportMap : ClassMap<Project>
    {
        public CmcListExportMap()
        {
            Map(m => m.ProjectName).Name("Project Name");
            Map(m => m.LockboxCMCID).Name("Lockbox CMC ID");
            Map(m => m.AFP)
                .ConvertUsing(m => GetEmployeeName(m.AFP))
                .Name("AFP");
            Map(m => m.Owner)
                .ConvertUsing(m => GetEmployeeName(m.Owner))
                .Name("Owner");
            Map(m => m.POBoxLine1).Name("PO Box Line 1 ");
        }

        private string GetEmployeeName(Employee employee)
        {
            return employee != null ? employee.FirstName + " " + employee.LastName : string.Empty;
        }
    }
}