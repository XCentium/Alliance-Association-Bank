/*************************** CheckScanners TABLE ***************************/
CREATE TABLE [dbo].[CheckScanners](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[Model] [nvarchar](255) NULL,
	[SerialNumber] [nvarchar](255) NULL,
	[DateMailed] [datetime2](0) NULL,
	[DateInstalled] [datetime2](0) NULL,
	[DateTrained] [datetime2](0) NULL,
	[ComputerInstalledOn] [nvarchar](255) NULL,
	[System] [nvarchar](255) NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_CheckScanners] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_CheckScanners_ProjectID] ON [dbo].[CheckScanners]
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[CheckScanners].[ScannerID]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CheckScanners', @level2type=N'COLUMN',@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[CheckScanners].[ProjectID]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CheckScanners', @level2type=N'COLUMN',@level2name=N'ProjectID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[CheckScanners].[Model]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CheckScanners', @level2type=N'COLUMN',@level2name=N'Model'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[CheckScanners].[Serial Number]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CheckScanners', @level2type=N'COLUMN',@level2name=N'SerialNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[CheckScanners].[DateMailed]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CheckScanners', @level2type=N'COLUMN',@level2name=N'DateMailed'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[CheckScanners].[DateInstalled]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CheckScanners', @level2type=N'COLUMN',@level2name=N'DateInstalled'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[CheckScanners].[DateTrained]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CheckScanners', @level2type=N'COLUMN',@level2name=N'DateTrained'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[CheckScanners].[ComputerInstalledOn]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CheckScanners', @level2type=N'COLUMN',@level2name=N'ComputerInstalledOn'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[CheckScanners].[System]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CheckScanners', @level2type=N'COLUMN',@level2name=N'System'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[CheckScanners].[Notes]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CheckScanners', @level2type=N'COLUMN',@level2name=N'Notes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[CheckScanners].[PrimaryKey]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CheckScanners', @level2type=N'CONSTRAINT',@level2name=N'PK_CheckScanners'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[CheckScanners]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CheckScanners'
GO



/*************************** Employees TABLE ***************************/
CREATE TABLE [dbo].[Employees](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[Company] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[ZipCode] [nvarchar](15) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Employees].[ID]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Employees].[Last Name]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'LastName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Employees].[First Name]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'FirstName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Employees].[Company]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'Company'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Employees].[City]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'City'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Employees].[State/Province]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'State'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Employees].[ZIP/Postal Code]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'ZipCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Employees].[PrimaryKey]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'CONSTRAINT',@level2name=N'PK_Employees'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Employees]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees'
GO



/*************************** Notes TABLE ***************************/
CREATE TABLE [dbo].[Notes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[NoteText] [nvarchar](max) NOT NULL,
	[DateAdded] [datetime2](0) NOT NULL,
 CONSTRAINT [PK_Notes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Notes_ProjectID] ON [dbo].[Notes]
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO




/*************************** Projects TABLE ***************************/
CREATE TABLE [dbo].[Projects](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](150) NULL,
	[Institution] [nvarchar](255) NULL,
	[OwnerID] [int] NULL,
	[AFPID] [int] NULL,
	[BoardingManagerID] [int] NULL,
	[Category] [nvarchar](50) NULL,
	[Priority] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[StartDate] [datetime2](0) NULL,
	[EndDate] [datetime2](0) NULL,
	[TargetLockboxLiveDate] [datetime2](0) NULL,
	[Address] [nvarchar](255) NULL,
	[City] [nvarchar](255) NULL,
	[State] [nvarchar](255) NULL,
	[ZipCode] [nvarchar](255) NULL,
	[MailingAddress] [nvarchar](255) NULL,
	[MailingCity] [nvarchar](255) NULL,
	[MailingState] [nvarchar](255) NULL,
	[MailingZipCode] [nvarchar](255) NULL,
	[Website] [nvarchar](255) NULL,
	[TIN] [nvarchar](255) NULL,
	[DBA] [nvarchar](255) NULL,
	[Fax] [nvarchar](255) NULL,
	[Phone] [nvarchar](255) NULL,
	[Type] [nvarchar](255) NULL,
	[TimeZone] [nvarchar](255) NULL,
	[Software] [nvarchar](255) NULL,
	[NumberOfAssociations] [int] NULL,
	[NumberOfDoors] [int] NULL,
	[EstimatedDeposits] [decimal](16, 4) NULL,
	[ActualDeposits] [decimal](16, 4) NULL,
	[LockboxCMCID] [nvarchar](10) NULL,
	[POBoxSize] [nvarchar](255) NULL,
	[POBoxLine1] [nvarchar](255) NULL,
	[POBoxZipCode] [nvarchar](255) NULL,
	[ScannlineNotes] [nvarchar](max) NULL,
	[EnrollmentFormReceived] [bit] NULL,
	[MasterSigCardReceived] [bit] NULL,
	[WelcomeEmailSent] [bit] NULL,
	[AssociationListReceived] [bit] NULL,
	[AssociationAccountsAssigned] [bit] NULL,
	[MgmtCompanyAgreemetnsReceived] [bit] NULL,
	[AssociationSignatureCardsSent] [bit] NULL,
	[LockboxWanted] [bit] NULL,
	[ValidationFileReceived] [bit] NULL,
	[ValidationFileAutomaticRegular] [bit] NULL,
	[ValidationFileNotes] [nvarchar](max) NULL,
	[ValidationFileBulkImporterUsed] [bit] NULL,
	[CouponPrintingNotes] [nvarchar](max) NULL,
	[RemitanceFileTested] [bit] NULL,
	[RemitanceFileLife] [bit] NULL,
	[LockboxRequestSent] [bit] NULL,
	[POBoxAssigned] [bit] NULL,
	[ScannerWanted] [bit] NULL,
	[MMOnCheckScanner] [bit] NULL,
	[ScannerSent] [bit] NULL,
	[ScannerAQ2SetupRequested] [bit] NULL,
	[ScannerLive] [bit] NULL,
	[ACHLimitAndSpecSubmitted] [bit] NULL,
	[ACHSuccessfulSubmitted] [bit] NULL,
	[OnlineBankingSetup] [bit] NULL,
	[OnlineBankingTrained] [bit] NULL,
	[CouponsOrdered] [bit] NULL,
	[CouponProofReviewed] [bit] NULL,
	[CouponVender] [nvarchar](255) NULL,
	[CouponVenderNumber] [nvarchar](255) NULL,
	[ScannerModel] [nvarchar](255) NULL,
	[ScannerSerialNumber] [nvarchar](255) NULL,
	[ScannerProvider] [nvarchar](255) NULL,
	[BoardingNextSteps] [nvarchar](max) NULL,
	[BoardingNotes] [nvarchar](max) NULL,
	[Ports] [nvarchar](255) NULL,
	[DICompanyID] [nvarchar](255) NULL,
	[DICompanyPassword] [nvarchar](255) NULL,
	[SftpFolderName] [nvarchar](255) NULL,
	[SftpGeneralUserName] [nvarchar](255) NULL,
	[SftpGeneralUserPassword] [nvarchar](255) NULL,
	[ACHPassThru] [bit] NULL,
	[ACHBatches] [bit] NULL,
	[WireTransferTemplates] [bit] NULL,
	[ACHEstimatedDeposits] [decimal](16, 4) NULL,
	[ACHEstimatedDepositsDate] [datetime2](0) NULL,
	[ACHLimit] [decimal](16, 4) NULL,
	[ACHSystemLimit] [decimal](16, 4) NULL,
	[OriginalReviewDate] [datetime2](0) NULL,
	[LastReviewDate] [datetime2](0) NULL,
	[ACHReviewNotes] [nvarchar](max) NULL,
	[ACHSpectFormInstructions] [nvarchar](max) NULL,
	[ACHReviewOfHistoricPerformance] [nvarchar](max) NULL,
	[ACHDualApproval] [bit] NULL,
	[ACHOneTimePasscode] [bit] NULL,
	[StatementEmail] [nvarchar](255) NULL,
	[LockboxEmail] [nvarchar](255) NULL,
	[ACHEmail] [nvarchar](255) NULL,
	[AuditNote] [nvarchar](max) NULL,
	[CIPReviewed] [nvarchar](255) NULL,
	[CIPGood] [bit] NULL,
	[HasCorporateAccounts] [bit] NULL,
	[CorporateAccounts] [nvarchar](255) NULL,
	[XmlAutoReconSetup] [bit] NULL,
	[XmlAutoReconConfirmedUse] [bit] NULL,
	[XmlAutoReconSentDate] [datetime2](0) NULL,
	[Narrative] [nvarchar](max) NULL,
	[Strongroom] [bit] NULL,
	[EStatements] [bit] NULL,
	[SftpUsage] [nvarchar](255) NULL,
	[XmlUsage] [nvarchar](255) NULL,
	[FacsimileSignature] [bit] NULL,
	[Balanced] [bit] NULL,
	[LockboxLiveDate] [datetime2](0) NULL,
	[LockboxStatus] [nvarchar](50) NULL,
	[LockboxSystem] [nvarchar](50) NULL,
	[SftpWithFile] [bit] NULL,
	[SftpManual] [bit] NULL,
	[SftpPath] [nvarchar](100) NULL,
	[ReformatAQ2ID] [int] NULL,
	[ReformatByAssoc] [bit] NULL,
	[MigratingToSoftware] [nvarchar](255) NULL,
	[OtherName] [nvarchar](255) NULL,
	[RelationshipRate] [nvarchar](50) NULL,
	[LockboxNotes] [nvarchar](max) NULL,
	[ACHUploadPPDDebit] [bit] NOT NULL,
	[ACHUploadPPDCredit] [bit] NOT NULL,
	[ACHUploadCCDDebit] [bit] NOT NULL,
	[ACHUploadCCDCredit] [bit] NOT NULL,
	[ACHTemplatePPDDebit] [bit] NOT NULL,
	[ACHTemplatePPDCredit] [bit] NOT NULL,
	[ACHTemplateCCDDebit] [bit] NOT NULL,
	[ACHTemplateCCDCredit] [bit] NOT NULL,
	[ACHSftpPPDDebit] [bit] NOT NULL,
	[ACHSftpPPDCredit] [bit] NOT NULL,
	[ACHSftpCCDDebit] [bit] NOT NULL,
	[ACHSftpCCDCredit] [bit] NOT NULL,
	[ACHWebPPDDebit] [bit] NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Projects_ProjectName] ON [dbo].[Projects]
(
	[ProjectName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Projects_LockboxCMCID] ON [dbo].[Projects]
(
	[LockboxCMCID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Projects_TIN] ON [dbo].[Projects]
(
	[TIN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [EnrollmentFormReceived]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [MasterSigCardReceived]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [WelcomeEmailSent]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [AssociationListReceived]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [AssociationAccountsAssigned]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [MgmtCompanyAgreemetnsReceived]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [AssociationSignatureCardsSent]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [LockboxWanted]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [ValidationFileReceived]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [ValidationFileAutomaticRegular]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [ValidationFileBulkImporterUsed]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [RemitanceFileTested]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [RemitanceFileLife]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [LockboxRequestSent]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [POBoxAssigned]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [ScannerWanted]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [MMOnCheckScanner]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [ScannerSent]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [ScannerAQ2SetupRequested]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [ScannerLive]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [ACHLimitAndSpecSubmitted]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [ACHSuccessfulSubmitted]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [OnlineBankingSetup]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [OnlineBankingTrained]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [CouponsOrdered]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [CouponProofReviewed]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [ACHPassThru]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [ACHBatches]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [WireTransferTemplates]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [ACHDualApproval]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [ACHOneTimePasscode]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [CIPGood]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [HasCorporateAccounts]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [XmlAutoReconSetup]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [XmlAutoReconConfirmedUse]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [Strongroom]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [EStatements]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [FacsimileSignature]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [Balanced]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [SftpWithFile]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [SftpManual]
GO

ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [ReformatByAssoc]
GO

ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_ACHUploadPPDDebit]  DEFAULT ((0)) FOR [ACHUploadPPDDebit]
GO

ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_ACHUploadPPDCredit]  DEFAULT ((0)) FOR [ACHUploadPPDCredit]
GO

ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_ACHUploadCCDDebit]  DEFAULT ((0)) FOR [ACHUploadCCDDebit]
GO

ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_ACHUploadCCDCredit]  DEFAULT ((0)) FOR [ACHUploadCCDCredit]
GO

ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_ACHTemplatePPDDebit]  DEFAULT ((0)) FOR [ACHTemplatePPDDebit]
GO

ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_ACHTemplatePPDCredit]  DEFAULT ((0)) FOR [ACHTemplatePPDCredit]
GO

ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_ACHTemplateCCDDebit]  DEFAULT ((0)) FOR [ACHTemplateCCDDebit]
GO

ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_ACHTemplateCCDCredit]  DEFAULT ((0)) FOR [ACHTemplateCCDCredit]
GO

ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_ACHSftpPPDDebit]  DEFAULT ((0)) FOR [ACHSftpPPDDebit]
GO

ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_ACHSftpPPDCredit]  DEFAULT ((0)) FOR [ACHSftpPPDCredit]
GO

ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_ACHSftpCCDDebit]  DEFAULT ((0)) FOR [ACHSftpCCDDebit]
GO

ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_ACHSftpCCDCredit]  DEFAULT ((0)) FOR [ACHSftpCCDCredit]
GO

ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_ACHWebPPDDebit]  DEFAULT ((0)) FOR [ACHWebPPDDebit]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[ID]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Project Name]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ProjectName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Inst]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'Institution'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Owner]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'OwnerID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[AFP]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'AFPID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[BoardingMgr]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'BoardingManagerID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Category]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'Category'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Priority]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'Priority'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Status]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'Status'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Start Date]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'StartDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[End Date]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'EndDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Target Lockbox Live Date]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'TargetLockboxLiveDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Address]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'Address'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[City]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'City'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[State]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'State'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Zip]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ZipCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Mailing Address]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'MailingAddress'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Mailing City]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'MailingCity'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Mailing State]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'MailingState'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Mailing Zip]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'MailingZipCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Website]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'Website'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[TIN]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'TIN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[DBA]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'DBA'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Fax]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'Fax'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Phone]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'Phone'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Type]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'Type'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[TimeZone]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'TimeZone'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Software]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'Software'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Number of Associations]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'NumberOfAssociations'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Number of Doors]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'NumberOfDoors'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Estimated Deposits]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'EstimatedDeposits'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Actual Deposits]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ActualDeposits'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Lockbox CMC ID]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'LockboxCMCID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[PO Box Size]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'POBoxSize'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[PO Box Line 1]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'POBoxLine1'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[PO Box Zip Code]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'POBoxZipCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Scannline Notes]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ScannlineNotes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Enrollment Form Received]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'EnrollmentFormReceived'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Master Sig Card Received]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'MasterSigCardReceived'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Welcome Email Sent]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'WelcomeEmailSent'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Association List Received]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'AssociationListReceived'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Association Accounts Assigned]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'AssociationAccountsAssigned'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Mgmt Company Agreemetns Received]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'MgmtCompanyAgreemetnsReceived'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Association Signature Cards Sent]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'AssociationSignatureCardsSent'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Lockbox Wanted]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'LockboxWanted'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Validation File Received]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ValidationFileReceived'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Validation File Automatic/Regular]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ValidationFileAutomaticRegular'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Validation File Notes]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ValidationFileNotes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Validation File Bulk Importer Used]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ValidationFileBulkImporterUsed'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Coupon Printing Notes]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'CouponPrintingNotes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Remitance File Tested]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'RemitanceFileTested'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Remitance File Life]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'RemitanceFileLife'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Lockbox Request Sent]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'LockboxRequestSent'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[PO Box Assigned]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'POBoxAssigned'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Scanner Wanted]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ScannerWanted'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[MM on Check Scanner]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'MMOnCheckScanner'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Scanner Sent]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ScannerSent'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Scanner Aq2 Set-Up Requested]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ScannerAQ2SetupRequested'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Scanner Live]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ScannerLive'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[ACH Limit and Spec Submitted]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ACHLimitAndSpecSubmitted'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[ACH Successful Submitted]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ACHSuccessfulSubmitted'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Online Banking Set-up]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'OnlineBankingSetup'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Online Banking Trained]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'OnlineBankingTrained'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Coupons Ordered]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'CouponsOrdered'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Coupon Proof Reviewed]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'CouponProofReviewed'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Coupon Vender]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'CouponVender'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Coupon Vender Number]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'CouponVenderNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Scanner Model]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ScannerModel'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Scanner Serial Number]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ScannerSerialNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Scanner Provider]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ScannerProvider'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Boarding Next Steps]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'BoardingNextSteps'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Boarding Notes]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'BoardingNotes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Ports]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'Ports'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[DI Company ID]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'DICompanyID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[DI Company Password]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'DICompanyPassword'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[SFTP Folder Name]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'SftpFolderName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[SFTP General User Name]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'SftpGeneralUserName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[SFTP General User Password]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'SftpGeneralUserPassword'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[ACH PassThru]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ACHPassThru'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[ACH Batches]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ACHBatches'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Wire Transfer Templates]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'WireTransferTemplates'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[ACH Estimated Deposits]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ACHEstimatedDeposits'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[ACH Estimated Deposits Date]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ACHEstimatedDepositsDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[ACH Limit]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ACHLimit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[ACH System Limit]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ACHSystemLimit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Original Review Date]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'OriginalReviewDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Last Review Date]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'LastReviewDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[ACH Review Notes]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ACHReviewNotes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[ACH Spect Form Instructions]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ACHSpectFormInstructions'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[ACH Reivew of Historic Performance]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ACHReviewOfHistoricPerformance'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Ach Dual Approval]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ACHDualApproval'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[ACH One Time Passcode]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ACHOneTimePasscode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Statement Email]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'StatementEmail'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Lockbox Email]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'LockboxEmail'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[ACH Email]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ACHEmail'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Audit Note]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'AuditNote'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[CIP Reviewd]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'CIPReviewed'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[CIP Good]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'CIPGood'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Corporate Accoutns]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'HasCorporateAccounts'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Corp Accounts]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'CorporateAccounts'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'If we have set-up an auto recon user' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'XmlAutoReconSetup'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[XML Auto Recon Setup]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'XmlAutoReconSetup'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Confirm we are using XML Auto Recon' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'XmlAutoReconConfirmedUse'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[XML Auto Recon Confirmed Use]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'XmlAutoReconConfirmedUse'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[XML Auto Recon Sent Date]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'XmlAutoReconSentDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Narrative from sales team' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'Narrative'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Narrative]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'Narrative'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Strongroom]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'Strongroom'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[E-Statements]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'EStatements'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[SFTP Usage]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'SftpUsage'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[XML Usage]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'XmlUsage'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Facsimilie Signature]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'FacsimileSignature'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[Balanced]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'Balanced'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[LockboxLiveDate]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'LockboxLiveDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[LockboxStatus]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'LockboxStatus'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[LockboxSystem]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'LockboxSystem'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[SFTPwithFile]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'SftpWithFile'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[SFTPManual]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'SftpManual'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[SFTPPath]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'SftpPath'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[ReformatAQ2]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ReformatAQ2ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[REformatByAssoc]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'ReformatByAssoc'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[SoftwareMigrateTo]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'COLUMN',@level2name=N'MigratingToSoftware'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects].[PrimaryKey]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects', @level2type=N'CONSTRAINT',@level2name=N'PK_Projects'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Projects]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projects'
GO



/*************************** ReformatsAQ2 TABLE ***************************/
CREATE TABLE [dbo].[ReformatsAQ2](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ReformatName] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[ECPReformatSpec] [nvarchar](255) NULL,
	[ECPPriorityOrder] [float] NULL,
 CONSTRAINT [PK_ReformatsAQ2] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[ReformatsAQ2].[ReformatSpec]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ReformatsAQ2', @level2type=N'COLUMN',@level2name=N'ReformatName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[ReformatsAQ2].[Description]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ReformatsAQ2', @level2type=N'COLUMN',@level2name=N'Description'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[ReformatsAQ2].[ECPReformatSpec]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ReformatsAQ2', @level2type=N'COLUMN',@level2name=N'ECPReformatSpec'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[ReformatsAQ2].[ECPPriorityOrder]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ReformatsAQ2', @level2type=N'COLUMN',@level2name=N'ECPPriorityOrder'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[ReformatsAQ2]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ReformatsAQ2'
GO



/*************************** Software TABLE ***************************/
CREATE TABLE [dbo].[Software](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SoftwareName] [nvarchar](255) NULL,
	[CurrentSoftware] [nvarchar](255) NULL,
	[MigratingTo] [nvarchar](255) NULL,
 CONSTRAINT [PK_Software] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Software].[Software]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Software', @level2type=N'COLUMN',@level2name=N'SoftwareName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Software].[Current Software]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Software', @level2type=N'COLUMN',@level2name=N'CurrentSoftware'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Software].[Migrating To]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Software', @level2type=N'COLUMN',@level2name=N'MigratingTo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Software]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Software'
GO



/*************************** Users TABLE ***************************/
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[Title] [nvarchar](255) NULL,
	[DI] [nvarchar](255) NULL,
	[Sftp] [nvarchar](255) NULL,
	[LockboxWeb] [nvarchar](255) NULL,
	[EDeposit] [nvarchar](255) NULL,
	[Phone] [nvarchar](255) NULL,
	[Mobile] [nvarchar](255) NULL,
	[Authorization] [nvarchar](255) NULL,
	[Admin] [bit] NOT NULL,
	[CorpOnlineUser] [bit] NULL,
	[RemoteScannerUser] [bit] NULL,
	[RemoteScannerAccountNotes] [nvarchar](255) NULL,
	[Birthday] [datetime2](0) NULL,
	[DateAdded] [datetime2](0) NULL,
	[DateDeleted] [datetime2](0) NULL,
	[Active] [bit] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[AuthorizedToOpenClose] [bit] NULL,
	[StatementEmail] [bit] NOT NULL,
	[LockboxEmail] [bit] NOT NULL,
	[ACHEmail] [bit] NOT NULL,
	[EnrollmentFormAuthorization] [bit] NOT NULL,
	[EmailAuthorization] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Users_ProjectID] ON [dbo].[Users]
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Users_Name] ON [dbo].[Users]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Admin] DEFAULT ((0)) FOR [Admin]
GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_CorpOnlineUser]  DEFAULT ((0)) FOR [CorpOnlineUser]
GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_RemoteScannerUser]  DEFAULT ((0)) FOR [RemoteScannerUser]
GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Active]  DEFAULT ((0)) FOR [Active]
GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_AuthorizedToOpenClose]  DEFAULT ((0)) FOR [AuthorizedToOpenClose]
GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_StatementEmail]  DEFAULT ((0)) FOR [StatementEmail]
GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_LockboxEmail]  DEFAULT ((0)) FOR [LockboxEmail]
GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_ACHEmail]  DEFAULT ((0)) FOR [ACHEmail]
GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_EnrollmentFormAuthorization]  DEFAULT ((0)) FOR [EnrollmentFormAuthorization]
GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_EmailAuthorization]  DEFAULT ((0)) FOR [EmailAuthorization]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Users].[UserID]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Users].[ProjectID]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'ProjectID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Users].[Name]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Users].[Email]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Email'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Users].[Title]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Title'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Users].[DI]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'DI'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Users].[SFTP]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Sftp'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Users].[Lockbox Web]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'LockboxWeb'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Users].[E Deposit]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'EDeposit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Users].[Phone]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Phone'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Users].[Mobile]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Mobile'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Users].[Authorization]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Authorization'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Users].[Admin]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Admin'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Users].[CorpOnlineUser]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'CorpOnlineUser'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Users].[RemoteScannerUser]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'RemoteScannerUser'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Users].[RemoteScannerAcctNotes]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'RemoteScannerAccountNotes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Users].[Birthday]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Birthday'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Users].[DateAdded]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'DateAdded'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Users].[DateDeleted]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'DateDeleted'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Users].[Active]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Active'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Users].[Notes]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Notes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Users].[AuthorizedOpenClose]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'AuthorizedToOpenClose'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Users].[PrimaryKey]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'CONSTRAINT',@level2name=N'PK_Users'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'AAB_Database_be.[Users]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users'
GO
