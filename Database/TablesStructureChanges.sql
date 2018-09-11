-- Projects table change DATA TYPE statements
ALTER TABLE dbo.Projects ALTER COLUMN [Estimated Deposits] DECIMAL(16,4)
ALTER TABLE dbo.Projects ALTER COLUMN [Actual Deposits] MONEY
ALTER TABLE dbo.Projects ALTER COLUMN [Actual Deposits] DECIMAL(16,4)
ALTER TABLE dbo.Projects ALTER COLUMN [ACH Estimated Deposits] DECIMAL(16,4)
ALTER TABLE dbo.Projects ALTER COLUMN [ACH Limit] DECIMAL(16,4)
ALTER TABLE dbo.Projects ALTER COLUMN [ACH System Limit] DECIMAL(16,4)


-- Projects table change statements (RENAME and ADD)
exec sp_rename 'Projects.Project Name', 'ProjectName', 'COLUMN';
exec sp_rename 'Projects.Inst', 'Institution', 'COLUMN';
exec sp_rename 'Projects.Owner', 'OwnerID', 'COLUMN';
exec sp_rename 'Projects.AFP', 'AFPID', 'COLUMN';
exec sp_rename 'Projects.BoardingMgr', 'BoardingManagerID', 'COLUMN';
exec sp_rename 'Projects.Start Date', 'StartDate', 'COLUMN';
exec sp_rename 'Projects.End Date', 'EndDate', 'COLUMN';
exec sp_rename 'Projects.Target Lockbox Live Date', 'TargetLockboxLiveDate', 'COLUMN';
exec sp_rename 'Projects.Zip', 'ZipCode', 'COLUMN';
exec sp_rename 'Projects.Mailing Address', 'MailingAddress', 'COLUMN';
exec sp_rename 'Projects.Mailing City', 'MailingCity', 'COLUMN';
exec sp_rename 'Projects.Mailing State', 'MailingState', 'COLUMN';
exec sp_rename 'Projects.Mailing Zip', 'MailingZipCode', 'COLUMN';
exec sp_rename 'Projects.Number of Associations', 'NumberOfAssociations', 'COLUMN';
exec sp_rename 'Projects.Number of Doors', 'NumberOfDoors', 'COLUMN';
exec sp_rename 'Projects.Estimated Deposits', 'EstimatedDeposits', 'COLUMN';
exec sp_rename 'Projects.Actual Deposits', 'ActualDeposits', 'COLUMN';
exec sp_rename 'Projects.COD Rate', 'CODRate', 'COLUMN';
exec sp_rename 'Projects.Rate Notes', 'RateNotes', 'COLUMN';
exec sp_rename 'Projects.Lockbox CMC ID', 'LockboxCMCID', 'COLUMN';
exec sp_rename 'Projects.PO Box Size', 'POBoxSize', 'COLUMN';
exec sp_rename 'Projects.PO Box Line 1', 'POBoxLine1', 'COLUMN';
exec sp_rename 'Projects.PO Box Zip Code', 'POBoxZipCode', 'COLUMN';
exec sp_rename 'Projects.Scannline Notes', 'ScannlineNotes', 'COLUMN';
exec sp_rename 'Projects.Enrollment Form Received', 'EnrollmentFormReceived', 'COLUMN';
exec sp_rename 'Projects.Master Sig Card Received', 'MasterSigCardReceived', 'COLUMN';
exec sp_rename 'Projects.Welcome Email Sent', 'WelcomeEmailSent', 'COLUMN';
exec sp_rename 'Projects.Association List Received', 'AssociationListReceived', 'COLUMN';
exec sp_rename 'Projects.Association Accounts Assigned', 'AssociationAccountsAssigned', 'COLUMN';
exec sp_rename 'Projects.Mgmt Company Agreemetns Received', 'MgmtCompanyAgreemetnsReceived', 'COLUMN';
exec sp_rename 'Projects.Association Signature Cards Sent', 'AssociationSignatureCardsSent', 'COLUMN';
exec sp_rename 'Projects.Lockbox Wanted', 'LockboxWanted', 'COLUMN';
exec sp_rename 'Projects.Validation File Received', 'ValidationFileReceived', 'COLUMN';
exec sp_rename 'Projects.Validation File Automatic/Regular', 'ValidationFileAutomaticRegular', 'COLUMN';
exec sp_rename 'Projects.Validation File Notes', 'ValidationFileNotes', 'COLUMN';
exec sp_rename 'Projects.Validation File Bulk Importer Used', 'ValidationFileBulkImporterUsed', 'COLUMN';
exec sp_rename 'Projects.Coupon Printing Notes', 'CouponPrintingNotes', 'COLUMN';
exec sp_rename 'Projects.Remitance File Tested', 'RemitanceFileTested', 'COLUMN';
exec sp_rename 'Projects.Remitance File Life', 'RemitanceFileLife', 'COLUMN';
exec sp_rename 'Projects.Lockbox Request Sent', 'LockboxRequestSent', 'COLUMN';
exec sp_rename 'Projects.PO Box Assigned', 'POBoxAssigned', 'COLUMN';
exec sp_rename 'Projects.Scanner Wanted', 'ScannerWanted', 'COLUMN';
exec sp_rename 'Projects.MM on Check Scanner', 'MMOnCheckScanner', 'COLUMN';
exec sp_rename 'Projects.Scanner Sent', 'ScannerSent', 'COLUMN';
exec sp_rename 'Projects.Scanner Aq2 Set-Up Requested', 'ScannerAQ2SetupRequested', 'COLUMN';
exec sp_rename 'Projects.Scanner Live', 'ScannerLive', 'COLUMN';
exec sp_rename 'Projects.ACH Limit and Spec Submitted', 'ACHLimitAndSpecSubmitted', 'COLUMN';
exec sp_rename 'Projects.ACH Successful Submitted', 'ACHSuccessfulSubmitted', 'COLUMN';
exec sp_rename 'Projects.Online Banking Set-up', 'OnlineBankingSetup', 'COLUMN';
exec sp_rename 'Projects.Online Banking Trained', 'OnlineBankingTrained', 'COLUMN';
exec sp_rename 'Projects.Coupons Ordered', 'CouponsOrdered', 'COLUMN';
exec sp_rename 'Projects.Coupon Proof Reviewed', 'CouponProofReviewed', 'COLUMN';
exec sp_rename 'Projects.Coupon Vender', 'CouponVender', 'COLUMN';
exec sp_rename 'Projects.Coupon Vender Number', 'CouponVenderNumber', 'COLUMN';
exec sp_rename 'Projects.Direct Deposit Payroll', 'DirectDepositPayroll', 'COLUMN';
exec sp_rename 'Projects.Direct Debit - Collection', 'DirectDebitCollection', 'COLUMN';
exec sp_rename 'Projects.Direct Credit - Payments', 'DirectCreditPayments', 'COLUMN';
exec sp_rename 'Projects.Direct Debit Business - CCD', 'DirectDebitBusinessCCD', 'COLUMN';
exec sp_rename 'Projects.Consumer Debit - WEB', 'ConsumerDebitWeb', 'COLUMN';
exec sp_rename 'Projects.Scanner Model', 'ScannerModel', 'COLUMN';
exec sp_rename 'Projects.Scanner Serial Number', 'ScannerSerialNumber', 'COLUMN';
exec sp_rename 'Projects.Scanner Provider', 'ScannerProvider', 'COLUMN';
exec sp_rename 'Projects.Boarding Next Steps', 'BoardingNextSteps', 'COLUMN';
exec sp_rename 'Projects.Boarding Notes', 'BoardingNotes', 'COLUMN';
exec sp_rename 'Projects.DI Company ID', 'DICompanyID', 'COLUMN';
exec sp_rename 'Projects.DI Company Password', 'DICompanyPassword', 'COLUMN';
exec sp_rename 'Projects.SFTP Folder Name', 'SftpFolderName', 'COLUMN';
exec sp_rename 'Projects.SFTP General User Name', 'SftpGeneralUserName', 'COLUMN';
exec sp_rename 'Projects.SFTP General User Password', 'SftpGeneralUserPassword', 'COLUMN';
exec sp_rename 'Projects.ACH PassThru', 'ACHPassThru', 'COLUMN';
exec sp_rename 'Projects.ACH Batches', 'ACHBatches', 'COLUMN';
exec sp_rename 'Projects.Wire Transfer Templates', 'WireTransferTemplates', 'COLUMN';
exec sp_rename 'Projects.ACH Estimated Deposits', 'ACHEstimatedDeposits', 'COLUMN';
exec sp_rename 'Projects.ACH Estimated Deposits Date', 'ACHEstimatedDepositsDate', 'COLUMN';
exec sp_rename 'Projects.ACH Limit', 'ACHLimit', 'COLUMN';
exec sp_rename 'Projects.ACH System Limit', 'ACHSystemLimit', 'COLUMN';
exec sp_rename 'Projects.Original Review Date', 'OriginalReviewDate', 'COLUMN';
exec sp_rename 'Projects.Last Review Date', 'LastReviewDate', 'COLUMN';
exec sp_rename 'Projects.ACH Review Notes', 'ACHReviewNotes', 'COLUMN';
exec sp_rename 'Projects.ACH Spect Form Instructions', 'ACHSpectFormInstructions', 'COLUMN';
exec sp_rename 'Projects.ACH Reivew of Historic Performance', 'ACHReviewOfHistoricPerformance', 'COLUMN';
exec sp_rename 'Projects.Ach Dual Approval', 'ACHDualApproval', 'COLUMN';
exec sp_rename 'Projects.ACH One Time Passcode', 'ACHOneTimePasscode', 'COLUMN';
exec sp_rename 'Projects.Statement Email', 'StatementEmail', 'COLUMN';
exec sp_rename 'Projects.Lockbox Email', 'LockboxEmail', 'COLUMN';
exec sp_rename 'Projects.ACH Email', 'ACHEmail', 'COLUMN';
exec sp_rename 'Projects.Audit Note', 'AuditNote', 'COLUMN';
exec sp_rename 'Projects.CIP Reviewd', 'CIPReviewed', 'COLUMN';
exec sp_rename 'Projects.CIP Good', 'CIPGood', 'COLUMN';
exec sp_rename 'Projects.Corporate Accoutns', 'HasCorporateAccounts', 'COLUMN';
exec sp_rename 'Projects.Corp Accounts', 'CorporateAccounts', 'COLUMN';
exec sp_rename 'Projects.XML Auto Recon Setup', 'XmlAutoReconSetup', 'COLUMN';
exec sp_rename 'Projects.XML Auto Recon Confirmed Use', 'XmlAutoReconConfirmedUse', 'COLUMN';
exec sp_rename 'Projects.XML Auto Recon Sent Date', 'XmlAutoReconSentDate', 'COLUMN';
exec sp_rename 'Projects.E-Statements', 'EStatements', 'COLUMN';
exec sp_rename 'Projects.SFTP Usage', 'SftpUsage', 'COLUMN';
exec sp_rename 'Projects.XML Usage', 'XmlUsage', 'COLUMN';
exec sp_rename 'Projects.Facsimilie Signature', 'FacsimileSignature', 'COLUMN';
exec sp_rename 'Projects.ACH Report Laru Name', 'ACHReportLaruName', 'COLUMN';
exec sp_rename 'Projects.SFTPwithFile', 'SftpWithFile', 'COLUMN';
exec sp_rename 'Projects.SFTPManual', 'SftpManual', 'COLUMN';
exec sp_rename 'Projects.SFTPPath', 'SftpPath', 'COLUMN';
exec sp_rename 'Projects.REformatByAssoc', 'ReformatByAssoc', 'COLUMN';
exec sp_rename 'Projects.Software', 'SoftwareID', 'COLUMN';
exec sp_rename 'Projects.SoftwareMigrateTo', 'MigratingToSoftwareID', 'COLUMN';
ALTER TABLE [dbo].[Projects] ADD OtherName NVARCHAR(255) NULL 
ALTER TABLE [dbo].[Projects] ADD RelationshipRate NVARCHAR(50) NULL 


-- Update Software data columns
--INSERT INTO dbo.Software (SoftwareName)
--SELECT DISTINCT RTRIM(LTRIM(p.SoftwareID)) FROM dbo.Projects p WHERE p.SoftwareID NOT IN (SELECT e.SoftwareName FROM dbo.Software e) ORDER BY 1

--INSERT INTO dbo.Software (SoftwareName)
--SELECT DISTINCT RTRIM(LTRIM(p.MigratingToSoftwareID)) FROM dbo.Projects p WHERE p.MigratingToSoftwareID NOT IN (SELECT e.SoftwareName FROM dbo.Software e) ORDER BY 1

--UPDATE p
--SET p.SoftwareID = s.ID
--FROM dbo.Projects p
--JOIN dbo.Software s ON RTRIM(LTRIM(s.SoftwareName)) = RTRIM(LTRIM(p.SoftwareID))

--UPDATE p
--SET p.MigratingToSoftwareID = s.ID
--FROM dbo.Projects p
--JOIN dbo.Software s ON RTRIM(LTRIM(s.SoftwareName)) = RTRIM(LTRIM(p.MigratingToSoftwareID))

ALTER TABLE dbo.Projects ALTER COLUMN SoftwareID INT
ALTER TABLE dbo.Projects ALTER COLUMN MigratingToSoftwareID INT



-- Employees table RENAME statements
exec sp_rename 'Employees.Last Name', 'LastName', 'COLUMN';
exec sp_rename 'Employees.First Name', 'FirstName', 'COLUMN';
exec sp_rename 'Employees.State/Province', 'State', 'COLUMN';
exec sp_rename 'Employees.ZIP/Postal Code', 'ZipCode', 'COLUMN';


-- Software table RENAME statements
ALTER TABLE [dbo].[Software] ADD ID INT IDENTITY(1,1) NOT NULL
ALTER TABLE [dbo].[Software] ADD CONSTRAINT [PK_Software] PRIMARY KEY CLUSTERED ( ID ASC )

exec sp_rename 'Software.Software', 'SoftwareName', 'COLUMN';
exec sp_rename 'Software.Current Software', 'CurrentSoftware', 'COLUMN';
exec sp_rename 'Software.Migrating To', 'MigratingTo', 'COLUMN';

 
-- Users table changes (RENAME and ADD)
exec sp_rename 'Users.UserID', 'ID', 'COLUMN';
exec sp_rename 'Users.SFTP', 'Sftp', 'COLUMN';
exec sp_rename 'Users.Lockbox Web', 'LockboxWeb', 'COLUMN';
exec sp_rename 'Users.E Deposit', 'EDeposit', 'COLUMN';
exec sp_rename 'Users.RemoteScannerAcctNotes', 'RemoteScannerAccountNotes', 'COLUMN';
exec sp_rename 'Users.AuthorizedOpenClose', 'AuthorizedToOpenClose', 'COLUMN';
ALTER TABLE [dbo].[Users] ADD StatementEmail BIT NOT NULL CONSTRAINT DF_Users_StatementEmail DEFAULT (0)
ALTER TABLE [dbo].[Users] ADD LockboxEmail BIT NOT NULL CONSTRAINT DF_Users_LockboxEmail DEFAULT (0)
ALTER TABLE [dbo].[Users] ADD ACHEmail BIT NOT NULL CONSTRAINT DF_Users_ACHEmail DEFAULT (0)


-- CheckScanners table RENAME statements
exec sp_rename 'CheckScanners.ScannerID', 'ID', 'COLUMN';
exec sp_rename 'CheckScanners.Serial Number', 'SerialNumber', 'COLUMN';



-- Foreign Key Constraints

-- Users
--ALTER TABLE [dbo].[Users] WITH CHECK ADD CONSTRAINT [FK_Users_Projects] FOREIGN KEY([ProjectID]) REFERENCES [dbo].[Projects] ([ID])
--GO
--ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Projects]
--GO
