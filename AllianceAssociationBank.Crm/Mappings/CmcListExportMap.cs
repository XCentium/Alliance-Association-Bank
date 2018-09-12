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
            Map(m => m.AFPEmployee)
                .ConvertUsing(m => m.AFPEmployee != null ? m.AFPEmployee.FirstName + " " + m.AFPEmployee.LastName : string.Empty)
                .Name("AFP");
            Map(m => m.OwnerEmployee)
                .ConvertUsing(m => m.OwnerEmployee != null ? m.OwnerEmployee.FirstName + " " + m.OwnerEmployee.LastName : string.Empty)
                .Name("Owner");
            Map(m => m.POBoxLine1).Name("PO Box Line 1 ");
        }
    }
}