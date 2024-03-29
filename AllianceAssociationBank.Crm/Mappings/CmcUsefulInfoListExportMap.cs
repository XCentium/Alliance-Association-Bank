﻿using AllianceAssociationBank.Crm.Core.Dtos;
using CsvHelper.Configuration;

namespace AllianceAssociationBank.Crm.Mappings
{
    public class CmcUsefulInfoListExportMap : ClassMap<CmcReportDataSetDto>
    {
        public CmcUsefulInfoListExportMap()
        {
            Map(m => m.ID).Name("ID");
            Map(m => m.ProjectName).Name("Project Name");
            Map(m => m.LockboxCMCID).Name("Lockbox CMC ID");
            Map(m => m.TIN).Name("TIN");
            Map(m => m.DICompanyID).Name("BST Company ID");
            Map(m => m.AFPName).Name("AFP");
            Map(m => m.OwnerName).Name("Rel. Banker");
            Map(m => m.Software).Name("Software");
            Map(m => m.ACHPassThru).Name("ACH Pass Thru");
            Map(m => m.ACHBatches).Name("ACH Batches");
            Map(m => m.WireTransferTemplates).Name("Wire Transfer Templates");
            Map(m => m.ACHSystemLimit).Name("ACH System Limit");
            Map(m => m.ValidationFileNotes).Name("Validation File Notes");
            Map(m => m.MasterSigCardReceived).Name("Master Sig Card Received");
            Map(m => m.EnrollmentFormReceived).Name("Enrollment Form Received");
            Map(m => m.POBoxLine1).Name("PO Box Assigned");
            Map(m => m.MailingAddress).Name("Mailing Address");
            Map(m => m.MailingCity).Name("Mailing City");
            Map(m => m.MailingState).Name("Mailing State");
            Map(m => m.MailingZipCode).Name("Mailing Zip");
            Map(m => m.Address).Name("Address");
            Map(m => m.City).Name("City");
            Map(m => m.State).Name("State");
            Map(m => m.ZipCode).Name("Zip");
            Map(m => m.CIPGood).Name("CIP Good");
            Map(m => m.LockboxWanted).Name("Lockbox Wanted");
            Map(m => m.Status).Name("Status");
            Map(m => m.ValidationFileAutomaticRegular).Name("Validation File Automatic Regular");
            Map(m => m.ValidationFileReceived).Name("Validation File Received");
            Map(m => m.ValidationFileBulkImporterUsed).Name("Validation File Bulk Importer Used");
            Map(m => m.CheckScannerModels).Name("Check Scanner Models");
            Map(m => m.CheckScannerSerialNumbers).Name("Check Scanner Serial Numbers");
        }
    }
}