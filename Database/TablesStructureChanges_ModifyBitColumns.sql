ALTER TABLE [dbo].[Projects] ALTER COLUMN [EnrollmentFormReceived] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [MasterSigCardReceived] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [WelcomeEmailSent] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [AssociationListReceived] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [AssociationAccountsAssigned] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [MgmtCompanyAgreemetnsReceived] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [AssociationSignatureCardsSent] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [LockboxWanted] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [ValidationFileReceived] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [ValidationFileAutomaticRegular] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [ValidationFileBulkImporterUsed] [bit] NOT NULL  
ALTER TABLE [dbo].[Projects] ALTER COLUMN [RemitanceFileTested] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [RemitanceFileLife] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [LockboxRequestSent] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [POBoxAssigned] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [ScannerWanted] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [MMOnCheckScanner] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [ScannerSent] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [ScannerAQ2SetupRequested] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [ScannerLive] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [ACHLimitAndSpecSubmitted] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [ACHSuccessfulSubmitted] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [OnlineBankingSetup] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [OnlineBankingTrained] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [CouponsOrdered] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [CouponProofReviewed] [bit] NOT NULL    
ALTER TABLE [dbo].[Projects] ALTER COLUMN [ACHPassThru] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [ACHBatches] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [WireTransferTemplates] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [ACHDualApproval] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [ACHOneTimePasscode] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [CIPGood] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [HasCorporateAccounts] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [XmlAutoReconSetup] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [XmlAutoReconConfirmedUse] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [Strongroom] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [EStatements] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [FacsimileSignature] [bit] NOT NULL
--[Balanced] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [SftpWithFile] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [SftpManual] [bit] NOT NULL
ALTER TABLE [dbo].[Projects] ALTER COLUMN [ReformatByAssoc] [bit] NOT NULL


ALTER TABLE [dbo].[Users] ALTER COLUMN [CorpOnlineUser] [bit] NOT NULL
ALTER TABLE [dbo].[Users] ALTER COLUMN [RemoteScannerUser] [bit] NOT NULL
ALTER TABLE [dbo].[Users] ALTER COLUMN [AuthorizedToOpenClose] [bit] NOT NULL




--UPDATE [dbo].[Projects] 
--SET [MgmtCompanyAgreemetnsReceived] = 0
--WHERE [MgmtCompanyAgreemetnsReceived] is null

--UPDATE [dbo].[Projects] 
--SET [ScannerSent] = 0
--WHERE [ScannerSent] is null

--UPDATE [dbo].[Projects] 
--SET [ScannerAQ2SetupRequested] = 0
--WHERE [ScannerAQ2SetupRequested] is null

--UPDATE [dbo].[Projects] 
--SET [ScannerLive] = 0
--WHERE [ScannerLive] is null

--UPDATE [dbo].[Projects] 
--SET [CIPGood] = 0
--WHERE [CIPGood] is null

--UPDATE [dbo].[Projects] 
--SET [XmlAutoReconConfirmedUse] = 0
--WHERE [XmlAutoReconConfirmedUse] is null