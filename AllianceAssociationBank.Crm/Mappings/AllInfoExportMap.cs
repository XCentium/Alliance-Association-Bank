using AllianceAssociationBank.Crm.Core.Models;
using CsvHelper.Configuration;

namespace AllianceAssociationBank.Crm.Mappings
{
    public class AllInfoExportMap : ClassMap<Project>
    {
        public AllInfoExportMap()
        {
            Map(m => m.ID).Name("ID");
            Map(m => m.ProjectName).Name("Project Name");
            Map(m => m.Institution).Name("Institution");
            Map(m => m.Owner)
                .ConvertUsing(m => MapEmployeeName(m.Owner))
                .Name("Owner");
            Map(m => m.AFP)
                .ConvertUsing(m => MapEmployeeName(m.AFP))
                .Name("AFP");
            Map(m => m.BoardingManager)
                .ConvertUsing(m => MapEmployeeName(m.BoardingManager))
                .Name("Boarding Manager");
            Map(m => m.Status).Name("Status");
            Map(m => m.StartDate).Name("Start Date");
            Map(m => m.EndDate).Name("End Date");
            Map(m => m.TargetLockboxLiveDate).Name("Target Lockbox Live Date");
            Map(m => m.Address).Name("Address");
            Map(m => m.City).Name("City");
            Map(m => m.State).Name("State");
            Map(m => m.ZipCode).Name("Zip");
            Map(m => m.MailingAddress).Name("Mailing Address");
            Map(m => m.MailingCity).Name("Mailing City");
            Map(m => m.MailingState).Name("Mailing State");
            Map(m => m.MailingZipCode).Name("Mailing Zip");
            Map(m => m.Website).Name("Website");
            Map(m => m.TIN).Name("TIN");
            Map(m => m.DBA).Name("DBA");
            Map(m => m.Fax).Name("Fax");
            Map(m => m.Phone).Name("Phone");
            Map(m => m.TimeZone).Name("TimeZone");
            Map(m => m.Software).Name("Software");
            Map(m => m.NumberOfAssociations).Name("Number of Associations");
            Map(m => m.NumberOfDoors).Name("Number of Doors");
            Map(m => m.EstimatedDeposits).Name("Estimated Deposits");
            Map(m => m.ActualDeposits).Name("Actual Deposits");
            Map(m => m.LockboxCMCID).Name("Lockbox CMC ID");
            Map(m => m.POBoxSize).Name("PO Box Size");
            Map(m => m.POBoxLine1).Name("PO Box Line 1");
            Map(m => m.POBoxZipCode).Name("PO Box Zip Code");
            Map(m => m.EnrollmentFormReceived).Name("Enrollment Form Received");
            Map(m => m.MasterSigCardReceived).Name("Master Sig Card Received");
            Map(m => m.WelcomeEmailSent).Name("Welcome Email Sent");
            Map(m => m.AssociationListReceived).Name("Association List Received");
            Map(m => m.AssociationAccountsAssigned).Name("Association Accounts Assigned");
            Map(m => m.AssociationSignatureCardsSent).Name("Association Signature Cards Sent");
            Map(m => m.LockboxWanted).Name("Lockbox Wanted");
            Map(m => m.ValidationFileReceived).Name("Validation File Received");
            Map(m => m.ValidationFileAutomaticRegular).Name("Validation File Automatic/Regular");
            Map(m => m.ValidationFileNotes).Name("Validation File Notes");
            Map(m => m.ValidationFileBulkImporterUsed).Name("Validation File Bulk Importer Used");
            Map(m => m.RemitanceFileTested).Name("Remitance File Tested");
            Map(m => m.RemitanceFileLife).Name("Remitance File Life");
            Map(m => m.LockboxRequestSent).Name("Lockbox Request Sent");
            Map(m => m.POBoxAssigned).Name("PO Box Assigned");
            Map(m => m.ScannerWanted).Name("Scanner Wanted");
            Map(m => m.MMOnCheckScanner).Name("MM on Check Scanner");
            Map(m => m.ACHLimitAndSpecSubmitted).Name("ACH Limit and Spec Submitted");
            Map(m => m.ACHSuccessfulSubmitted).Name("ACH Successful Submitted");
            Map(m => m.OnlineBankingSetup).Name("Online Banking Set-up");
            Map(m => m.OnlineBankingTrained).Name("Online Banking Trained");
            Map(m => m.CouponsOrdered).Name("Coupons Ordered");
            Map(m => m.CouponProofReviewed).Name("Coupon Proof Reviewed");
            Map(m => m.CouponVender).Name("Coupon Vender");
            Map(m => m.CouponVenderNumber).Name("Coupon Vender Number");
            Map(m => m.BoardingNextSteps).Name("Boarding Next Steps");
            Map(m => m.BoardingNotes).Name("Boarding Notes");
            Map(m => m.DICompanyID).Name("DI Company ID");
            Map(m => m.SftpFolderName).Name("SFTP Folder Name");
            Map(m => m.SftpGeneralUserPassword).Name("SFTP General User Password");
            Map(m => m.ACHPassThru).Name("ACH PassThru");
            Map(m => m.ACHBatches).Name("ACH Batches");
            Map(m => m.WireTransferTemplates).Name("Wire Transfer Templates");
            Map(m => m.ACHEstimatedDeposits).Name("ACH Estimated Deposits");
            Map(m => m.ACHEstimatedDepositsDate).Name("ACH Estimated Deposits Date");
            Map(m => m.ACHLimit).Name("ACH Limit");
            Map(m => m.ACHSystemLimit).Name("ACH System Limit");
            Map(m => m.OriginalReviewDate).Name("Original Review Date");
            Map(m => m.LastReviewDate).Name("Last Review Date");
            Map(m => m.ACHReviewNotes).Name("ACH Review Notes");
            Map(m => m.ACHSpectFormInstructions).Name("ACH Spect Form Instructions");
            Map(m => m.ACHDualApproval).Name("ACH Dual Approval");
            Map(m => m.CIPGood).Name("CIP Good");
            Map(m => m.HasCorporateAccounts).Name("Corporate Accounts");
            Map(m => m.CorporateAccounts).Name("Corp Accounts");
            Map(m => m.XmlAutoReconSetup).Name("XML Auto Recon Setup");
            Map(m => m.XmlAutoReconSentDate).Name("XML Auto Recon Sent Date");
            Map(m => m.Narrative).Name("Narrative");
            Map(m => m.Strongroom).Name("Strongroom");
            Map(m => m.EStatements).Name("E-Statements");
            Map(m => m.SftpUsage).Name("SFTP Usage");
            Map(m => m.XmlUsage).Name("XML Usage");
            Map(m => m.FacsimileSignature).Name("Facsimile Signature");
            Map(m => m.Balanced).Name("Balanced");
            Map(m => m.LockboxLiveDate).Name("Lockbox Live Date");
            Map(m => m.LockboxStatus).Name("Lockbox Status");
            Map(m => m.LockboxSystem).Name("Lockbox System");
            Map(m => m.SftpWithFile).Name("SFTP with File");
            Map(m => m.SftpManual).Name("SFTP Manual");
            Map(m => m.SftpPath).Name("SFTP Path");
            Map(m => m.ReformatAQ2ID)
                .ConvertUsing(m => m.ReformatAQ2 != null ? m.ReformatAQ2.ReformatName : string.Empty)
                .Name("ReformatAQ2");
            Map(m => m.ReformatByAssoc).Name("Reformat by Association");
            Map(m => m.MigratingToSoftware).Name("Migrating to Software");
            Map(m => m.OtherName).Name("Other Name");
            Map(m => m.RelationshipRate).Name("Relationship Rate");
            Map(m => m.LockboxNotes).Name("Lockbox Notes");
            Map(m => m.ACHUploadPPDDebit).Name("ACH Upload PPD Debit");
            Map(m => m.ACHUploadPPDCredit).Name("ACH Upload PPD Credit");
            Map(m => m.ACHUploadCCDDebit).Name("ACH Upload CCD Debit");
            Map(m => m.ACHUploadCCDCredit).Name("ACH Upload CCD Credit");
            Map(m => m.ACHTemplatePPDDebit).Name("ACH Template PPD Debit");
            Map(m => m.ACHTemplatePPDCredit).Name("ACH Template PPD Credit");
            Map(m => m.ACHTemplateCCDDebit).Name("ACH Template CCD Debit");
            Map(m => m.ACHTemplateCCDCredit).Name("ACH Template CCD Credit");
            Map(m => m.ACHSftpPPDDebit).Name("ACH SFTP PPD Debit");
            Map(m => m.ACHSftpPPDCredit).Name("ACH SFTP PPD Credit");
            Map(m => m.ACHSftpCCDDebit).Name("ACH SFTP CCD Debit");
            Map(m => m.ACHSftpCCDCredit).Name("ACH SFTP CCD Credit");
            Map(m => m.ACHWebPPDDebit).Name("ACH Web CCD Debit");
            Map(m => m.Active).Name("Active");
        }

        private string MapEmployeeName(Employee employee)
        {
            return employee != null ? $"{employee.FirstName} {employee.LastName}" : string.Empty;
        }
    }
}