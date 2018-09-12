using AllianceAssociationBank.Crm.Core.Models;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Mappings
{
    public class CmcUsefulInfoListExportMap : ClassMap<Project>
    {
        public CmcUsefulInfoListExportMap()
        {
            Map(e => e.ProjectName).Name("Project Name");
            Map(e => e.LockboxCMCID).Name("Lockbox CMC ID");
            Map(e => e.TIN).Name("TIN");
            Map(e => e.DICompanyID).Name("DI Company ID");
            Map(m => m.OwnerEmployee)
                .ConvertUsing(m => m.OwnerEmployee != null ? m.OwnerEmployee.FirstName + " " + m.OwnerEmployee.LastName : string.Empty)
                .Name("Owner");
            Map(m => m.AFPEmployee)
                .ConvertUsing(m => m.AFPEmployee != null ? m.AFPEmployee.FirstName + " " + m.AFPEmployee.LastName : string.Empty)
                .Name("AFP");
            Map(e => e.Software).Name("Software");
            Map(e => e.ID).Name("ID");
            Map(e => e.ACHPassThru).Name("ACH Pass Thru");
            Map(e => e.ACHBatches).Name("ACH Batches");
            Map(e => e.WireTransferTemplates).Name("Wire Transfer Templates");
            Map(e => e.ACHSystemLimit).Name("ACH System Limit");
            Map(e => e.MasterSigCardReceived).Name("Master Sig Card Received");
            Map(e => e.EnrollmentFormReceived).Name("Enrollment Form Received");
            Map(e => e.MailingAddress).Name("Mailing Address");
            Map(e => e.MailingCity).Name("Mailing City");
            Map(e => e.MailingState).Name("Mailing State");
            Map(e => e.MailingZipCode).Name("Mailing Zip");
            Map(e => e.Address).Name("Address");
            Map(e => e.City).Name("City");
            Map(e => e.State).Name("State");
            Map(e => e.ZipCode).Name("Zip");
            Map(e => e.POBoxLine1).Name("PO Box Line 1");
            Map(e => e.CIPGood).Name("CIP Good");
            Map(e => e.LockboxWanted).Name("Lockbox Wanted");
            Map(e => e.Status).Name("Status");
            Map(e => e.ValidationFileReceived).Name("Validation File Received");
            Map(e => e.ValidationFileAutomaticRegular).Name("Validation File Automatic Regular");
            Map(e => e.ValidationFileBulkImporterUsed).Name("Validation File Bulk Importer Used");
            Map(e => e.ValidationFileNotes).Name("Validation File Notes");
        }
    }
}