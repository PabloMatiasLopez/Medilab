USE [Medilab]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[AddressId] [uniqueidentifier] NOT NULL,
	[AddressOwner] [uniqueidentifier] NOT NULL,
	[AddressTypeId] [int] NOT NULL,
	[Street] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[LastUpdated] [timestamp] NOT NULL,
	[IsDefault] [bit] NOT NULL,
	[ArchiveDate] [datetime] NULL,
	[Number] [nvarchar](50) NOT NULL,
	[OtherInformation] [nvarchar](max) NOT NULL,
	[StateId] [int] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AddressType]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddressType](
	[AddressTypeId] [int] NOT NULL,
	[AddressTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AddressType] PRIMARY KEY CLUSTERED 
(
	[AddressTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AditionalItem]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AditionalItem](
	[AditionaltemId] [uniqueidentifier] NOT NULL,
	[Code] [int] NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_AditionalItem] PRIMARY KEY CLUSTERED 
(
	[AditionaltemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Audit]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Audit](
	[AuditId] [uniqueidentifier] NOT NULL,
	[AuditCreatedDate] [datetime] NOT NULL,
	[AuditUserId] [uniqueidentifier] NOT NULL,
	[AuditObjectTypeId] [int] NOT NULL,
	[AuditOperation] [nvarchar](50) NOT NULL,
	[AuditObjectId] [uniqueidentifier] NOT NULL,
	[AuditChangedValues] [nvarchar](2000) NOT NULL,
 CONSTRAINT [PK_Audit] PRIMARY KEY CLUSTERED 
(
	[AuditId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cash]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cash](
	[CashId] [uniqueidentifier] NOT NULL,
	[CashImport] [float] NOT NULL,
	[PaymentDate] [datetime] NOT NULL,
	[ReceiptId] [uniqueidentifier] NOT NULL,
	[Notes] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Cash] PRIMARY KEY CLUSTERED 
(
	[CashId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Check]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Check](
	[CheckId] [uniqueidentifier] NOT NULL,
	[CheckImport] [float] NOT NULL,
	[PaymentDate] [datetime] NOT NULL,
	[ReceiptId] [uniqueidentifier] NOT NULL,
	[BankName] [nvarchar](max) NOT NULL,
	[CheckNumber] [nvarchar](25) NOT NULL,
	[OwnerName] [nvarchar](200) NOT NULL,
	[IsOwner] [bit] NOT NULL,
	[IssuanceDate] [datetime] NOT NULL,
	[ExpirationDate] [datetime] NOT NULL,
	[Notes] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Check] PRIMARY KEY CLUSTERED 
(
	[CheckId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CivilState]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CivilState](
	[CivilStateId] [int] NOT NULL,
	[CivilStateName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CivilState] PRIMARY KEY CLUSTERED 
(
	[CivilStateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Client]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ClientId] [uniqueidentifier] NOT NULL,
	[ClientName] [nvarchar](100) NOT NULL,
	[ClientCuit] [nvarchar](50) NOT NULL,
	[ClientAditionalInformation] [nvarchar](500) NOT NULL,
	[LastUpdated] [timestamp] NOT NULL,
	[ClientIsDeleted] [bit] NOT NULL,
	[ClientPhoneNumber] [nvarchar](50) NOT NULL,
	[ClientFaxNumber] [nvarchar](50) NOT NULL,
	[ClientEmailAddress] [nvarchar](50) NOT NULL,
	[ClientNumber] [int] NOT NULL,
	[IvaConditionId] [int] NOT NULL,
	[InvoiceProfileId] [uniqueidentifier] NULL,
	[ClientLogo] [nvarchar](100) NULL,
	[DocumentTypeId] [int] NOT NULL DEFAULT ((80)),
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClientArea]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientArea](
	[ClientAreaId] [uniqueidentifier] NOT NULL,
	[CllientId] [uniqueidentifier] NOT NULL,
	[AreaName] [nvarchar](250) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[LastUpdated] [timestamp] NOT NULL,
 CONSTRAINT [PK_ClientArea] PRIMARY KEY CLUSTERED 
(
	[ClientAreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClinicalExam]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClinicalExam](
	[ClinicalExamId] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[MedicalHistoryId] [uniqueidentifier] NOT NULL,
	[HereditaryHistory] [nvarchar](max) NOT NULL,
	[PathologicalHistory] [nvarchar](max) NOT NULL,
	[SurgicalHistory] [nvarchar](max) NOT NULL,
	[TraumaHistory] [nvarchar](max) NOT NULL,
	[ObstetricalHistory] [nvarchar](max) NOT NULL,
	[OtherHistory] [nvarchar](max) NOT NULL,
	[Smoke] [bit] NOT NULL,
	[SmokeCount] [nvarchar](500) NOT NULL,
	[Alcohol] [bit] NOT NULL,
	[AlcoholCount] [nvarchar](500) NOT NULL,
	[NormalSleep] [bit] NOT NULL,
	[SleepHours] [nvarchar](500) NOT NULL,
	[Diet] [bit] NOT NULL,
	[DietDetails] [nvarchar](500) NOT NULL,
	[Sports] [bit] NOT NULL,
	[SportsDetails] [nvarchar](500) NOT NULL,
	[UseEyeGlasses] [bit] NOT NULL,
	[EyeFarNoCorrectionRight] [int] NULL,
	[EyeFarNoCorrectionLeft] [int] NULL,
	[EyeFarWithCorrectionRight] [int] NULL,
	[EyeFarWithCorrectionLeft] [int] NULL,
	[EyeNearNoCorrectionRight] [float] NULL,
	[EyeNearNoCorrectionLeft] [float] NULL,
	[EyeNearWithCorrectionRight] [float] NULL,
	[EyeNearWithCorrectionLeft] [float] NULL,
	[ColorVision] [nvarchar](500) NOT NULL,
	[FunduscopicRight] [nvarchar](200) NOT NULL,
	[FunduscopicLeft] [nvarchar](200) NOT NULL,
	[ViewObservations] [nvarchar](max) NOT NULL,
	[Size] [int] NOT NULL,
	[Weight] [int] NOT NULL,
	[AbdominalCircunference] [int] NULL,
	[CervicalPerimeter] [int] NULL,
	[BloodPressureHight] [int] NOT NULL,
	[BloodPressureLow] [int] NOT NULL,
	[Pulse] [int] NOT NULL,
	[Head] [int] NOT NULL,
	[HeadDetails] [nvarchar](500) NOT NULL,
	[Eyes] [int] NOT NULL,
	[EyesDetails] [nvarchar](500) NOT NULL,
	[Ear] [int] NOT NULL,
	[EarDetails] [nvarchar](500) NOT NULL,
	[Nose] [int] NOT NULL,
	[NoseDetails] [nvarchar](500) NOT NULL,
	[Mouth] [int] NOT NULL,
	[MouthDetails] [nvarchar](500) NOT NULL,
	[Neck] [int] NOT NULL,
	[NeckDetails] [nvarchar](500) NOT NULL,
	[Chest] [int] NOT NULL,
	[ChestDetails] [nvarchar](500) NOT NULL,
	[Lung] [int] NOT NULL,
	[LungDetails] [nvarchar](500) NOT NULL,
	[Heart] [int] NOT NULL,
	[HeartDetails] [nvarchar](500) NOT NULL,
	[PeripheralVeins] [int] NOT NULL,
	[PeripheralVeinsDetails] [nvarchar](500) NOT NULL,
	[PeripheralArteries] [int] NOT NULL,
	[PeripheralArteriesDetails] [nvarchar](500) NOT NULL,
	[Abdomen] [int] NOT NULL,
	[AbdomenDetails] [nvarchar](500) NOT NULL,
	[Hernia] [int] NOT NULL,
	[HerniaDetails] [nvarchar](500) NOT NULL,
	[Genitals] [int] NOT NULL,
	[GenitalsDetails] [nvarchar](500) NOT NULL,
	[Anus] [int] NOT NULL,
	[AnusDetails] [nvarchar](500) NOT NULL,
	[Tips] [int] NOT NULL,
	[TipsDetails] [nvarchar](500) NOT NULL,
	[Backbone] [int] NOT NULL,
	[BackboneDetails] [nvarchar](500) NOT NULL,
	[Skin] [int] NOT NULL,
	[SkinDetails] [nvarchar](500) NOT NULL,
	[LympNodes] [int] NOT NULL,
	[LympNodesDetails] [nvarchar](500) NOT NULL,
	[NervousSystem] [int] NOT NULL,
	[NervousSystemDetails] [nvarchar](500) NOT NULL,
	[Motion] [int] NOT NULL,
	[MotionDetails] [nvarchar](500) NOT NULL,
	[PsychicTest] [int] NOT NULL,
	[PsychicTestDetails] [nvarchar](500) NOT NULL,
	[Scars] [int] NOT NULL,
	[ScarsDetails] [nvarchar](500) NOT NULL,
	[Kidneys] [int] NOT NULL,
	[KidneysDetails] [nvarchar](500) NOT NULL,
	[SubcutaneousCellularTissue] [int] NOT NULL,
	[SubcutaneousCellularTissueDetails] [nvarchar](500) NOT NULL,
	[Status] [int] NOT NULL,
	[LastUpdated] [timestamp] NOT NULL,
	[Observations] [nvarchar](max) NOT NULL,
	[VaccinesHistory] [nvarchar](max) NOT NULL,
	[BalanceTest] [int] NOT NULL,
	[BalanceTestDetails] [nvarchar](500) NOT NULL,
	[IMCStatus] [int] NOT NULL,
	[IMCStatusDetail] [nvarchar](500) NOT NULL,
	[BloodPressureStatus] [int] NOT NULL,
	[BloodPressureStatusDetail] [nvarchar](500) NOT NULL,
	[ProfessionalId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_ClinicalExam] PRIMARY KEY CLUSTERED 
(
	[ClinicalExamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClinicalHistoryResult]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClinicalHistoryResult](
	[ClinicalHistoryResultId] [int] NOT NULL,
	[ClinicalHistoryResultName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ClinicalHistoryResult] PRIMARY KEY CLUSTERED 
(
	[ClinicalHistoryResultId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CompanyInfo]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyInfo](
	[CompanyInfoId] [uniqueidentifier] NOT NULL CONSTRAINT [DF_CompanyInfo_CompanyInfoId]  DEFAULT (newid()),
	[CompanyInfoName] [nvarchar](50) NOT NULL,
	[CompanyInfoAddress] [nvarchar](100) NOT NULL,
	[CompanyInfoPostalCode] [nvarchar](20) NOT NULL,
	[CompanyInfoProvince] [nvarchar](50) NOT NULL,
	[CompanyInfoCountry] [nvarchar](50) NOT NULL,
	[CompanyInfoPhone] [nchar](100) NOT NULL,
	[CompanyInfoFax] [nvarchar](100) NOT NULL,
	[CompanyInfoEmail] [nvarchar](50) NOT NULL,
	[CompanyInfoImage] [nvarchar](50) NOT NULL,
	[CompanyInfoCuit] [nvarchar](50) NOT NULL,
	[CompanyInfoIsActive] [bit] NOT NULL,
	[CompanyInfoIsDeleted] [bit] NOT NULL,
	[LastUpdated] [timestamp] NOT NULL,
	[ExcelFormat] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CompanyInfo] PRIMARY KEY CLUSTERED 
(
	[CompanyInfoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Configuration]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Configuration](
	[Name] [nvarchar](50) NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Configuration] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CreditNote]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditNote](
	[CreditNoteId] [uniqueidentifier] NOT NULL,
	[CreditNoteNumber] [int] NOT NULL,
	[CreationDate] [date] NOT NULL,
	[ClientId] [uniqueidentifier] NOT NULL,
	[RelatedInvoiceId] [uniqueidentifier] NULL,
	[Detail] [nvarchar](max) NOT NULL,
	[Import] [float] NOT NULL,
	[IVA] [bit] NOT NULL,
	[IVAImport] [float] NOT NULL,
	[CreatorUserId] [uniqueidentifier] NOT NULL,
	[CreditNoteType] [int] NOT NULL,
	[Observations] [nvarchar](max) NOT NULL,
	[State] [int] NOT NULL,
	[ReceiptId] [uniqueidentifier] NULL,
	[CAEExpirationDate] [date] NOT NULL,
	[SalePoint] [int] NOT NULL,
	[CAE] [nvarchar](50) NOT NULL,
	[IVAType] [int] NOT NULL,
 CONSTRAINT [PK_CreditNote] PRIMARY KEY CLUSTERED 
(
	[CreditNoteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DebitNote]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DebitNote](
	[DebitNoteId] [uniqueidentifier] NOT NULL,
	[DebitNoteNumber] [nvarchar](50) NOT NULL,
	[CreationDate] [date] NOT NULL,
	[ClientId] [uniqueidentifier] NOT NULL,
	[RelatedInvoiceId] [uniqueidentifier] NULL,
	[Detail] [nvarchar](max) NOT NULL,
	[Import] [float] NOT NULL,
	[IVA] [bit] NOT NULL,
	[IVAImport] [float] NOT NULL,
	[CreatorUserId] [uniqueidentifier] NOT NULL,
	[CreditNoteType] [int] NOT NULL,
	[Observations] [nvarchar](max) NOT NULL,
	[State] [int] NOT NULL,
 CONSTRAINT [PK_DebitNote] PRIMARY KEY CLUSTERED 
(
	[DebitNoteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DocumentType]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentType](
	[DocumentTypeId] [int] NOT NULL,
	[DocumentTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DocumentType] PRIMARY KEY CLUSTERED 
(
	[DocumentTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ElectronicTransfer]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ElectronicTransfer](
	[ElectronicTransferId] [uniqueidentifier] NOT NULL,
	[TransferImport] [float] NOT NULL,
	[PaymentDate] [datetime] NOT NULL,
	[ReceiptId] [uniqueidentifier] NOT NULL,
	[BankName] [nvarchar](200) NOT NULL,
	[AccountNumber] [nvarchar](50) NOT NULL,
	[Notes] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ElectronicTrasnfer] PRIMARY KEY CLUSTERED 
(
	[ElectronicTransferId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExamType]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamType](
	[ExamTypeId] [int] NOT NULL,
	[ExamTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ExamType] PRIMARY KEY CLUSTERED 
(
	[ExamTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FiscalRetention]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FiscalRetention](
	[FiscalRetentionId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Value] [float] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[LastUpdated] [timestamp] NOT NULL,
	[LastUpdateUser] [uniqueidentifier] NOT NULL,
	[CAECode] [int] NOT NULL,
	[IsIVA] [bit] NOT NULL,
 CONSTRAINT [PK_FiscalRetention] PRIMARY KEY CLUSTERED 
(
	[FiscalRetentionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Gender]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[GenderId] [int] NOT NULL,
	[GenderName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[GenderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Group]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[GroupId] [uniqueidentifier] NOT NULL,
	[GroupCode] [int] NOT NULL,
	[GroupName] [nvarchar](150) NOT NULL,
	[GroupDescription] [nvarchar](max) NOT NULL,
	[LastUpdated] [timestamp] NOT NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_MedicalPracticeGroup] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupMedicalPractice]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupMedicalPractice](
	[GroupMedicalPracticeId] [uniqueidentifier] NOT NULL,
	[GroupId] [uniqueidentifier] NOT NULL,
	[MedicalPracticeId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_GroupMedicalPractice] PRIMARY KEY CLUSTERED 
(
	[GroupMedicalPracticeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InstructionLevel]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InstructionLevel](
	[InstructionLevelId] [int] NOT NULL,
	[InstructionLevelName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_InstructionLevel] PRIMARY KEY CLUSTERED 
(
	[InstructionLevelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InvoiceDetail]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetail](
	[InvoiceDetailId] [uniqueidentifier] NOT NULL,
	[InvoiceHeaderId] [uniqueidentifier] NOT NULL,
	[ItemId] [uniqueidentifier] NOT NULL,
	[ItemCode] [int] NOT NULL,
	[ItemDescription] [nvarchar](max) NOT NULL,
	[ItemQuantity] [int] NOT NULL,
	[ItemPrice] [float] NOT NULL,
	[ItemObservation] [nvarchar](max) NULL,
	[ItemGroupId] [uniqueidentifier] NULL,
	[PatientId] [uniqueidentifier] NULL,
	[ExamTypeId] [int] NULL,
 CONSTRAINT [PK_InvoiceDetail] PRIMARY KEY CLUSTERED 
(
	[InvoiceDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InvoiceHeader]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceHeader](
	[InvoiceHeaderId] [uniqueidentifier] NOT NULL,
	[ClientId] [uniqueidentifier] NOT NULL,
	[Date] [datetime] NOT NULL,
	[InvoiceType] [int] NOT NULL,
	[CompanyInfoId] [uniqueidentifier] NOT NULL,
	[InvoiceNumber] [int] NOT NULL,
	[Total] [float] NOT NULL,
	[IvaPercentage] [float] NOT NULL,
	[IvaPerception] [float] NOT NULL,
	[OtherPerception] [float] NOT NULL,
	[DgrPerception] [float] NOT NULL,
	[NoTaxedConcept] [float] NOT NULL,
	[InvoiceObservation] [nvarchar](max) NULL,
	[ManualDetailText] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[SubTotal] [float] NOT NULL,
	[CAE] [nvarchar](50) NULL,
	[CreateUserId] [uniqueidentifier] NOT NULL,
	[LastUpdateUserId] [uniqueidentifier] NOT NULL,
	[InvoiceRemainder] [float] NOT NULL,
	[CAEExpirationDate] [date] NOT NULL,
	[SalePoint] [int] NOT NULL,
 CONSTRAINT [PK_InvoiceHeader] PRIMARY KEY CLUSTERED 
(
	[InvoiceHeaderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InvoiceProfile]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceProfile](
	[InvoiceProfileId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[LastUpdated] [timestamp] NOT NULL,
	[LastUpdateUser] [uniqueidentifier] NOT NULL,
	[IsDefault] [bit] NOT NULL,
 CONSTRAINT [PK_InvoiceProfile] PRIMARY KEY CLUSTERED 
(
	[InvoiceProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InvoiceProfileRetention]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceProfileRetention](
	[InvoiceProfileRetentionId] [uniqueidentifier] NOT NULL,
	[InvoiceProfileId] [uniqueidentifier] NOT NULL,
	[FiscalRetentionId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_InvoiceProfileRetention] PRIMARY KEY CLUSTERED 
(
	[InvoiceProfileRetentionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InvoiceRetention]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceRetention](
	[InvoiceRetentionId] [uniqueidentifier] NOT NULL,
	[InvoiceHeaderId] [uniqueidentifier] NOT NULL,
	[FiscalRetentionId] [uniqueidentifier] NOT NULL,
	[FiscalRetentionName] [nvarchar](150) NOT NULL,
	[FiscalRetentionValue] [float] NOT NULL,
 CONSTRAINT [PK_InvoiceRetention] PRIMARY KEY CLUSTERED 
(
	[InvoiceRetentionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IvaCondition]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IvaCondition](
	[IvaConditionId] [int] NOT NULL,
	[IvaConditionDescription] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_IvaCondition] PRIMARY KEY CLUSTERED 
(
	[IvaConditionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IvaPercentage]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IvaPercentage](
	[IvaPercentageId] [int] NOT NULL,
	[IvaConditionId] [int] NOT NULL,
	[Percentage] [float] NOT NULL,
	[LastUpdated] [timestamp] NOT NULL,
 CONSTRAINT [PK_IvaPercentage] PRIMARY KEY CLUSTERED 
(
	[IvaPercentageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MedicalHistory]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalHistory](
	[MedicalHistoryId] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[PatiendId] [uniqueidentifier] NOT NULL,
	[ClientId] [uniqueidentifier] NOT NULL,
	[ClientAreaId] [uniqueidentifier] NULL,
	[ExamTypeId] [int] NOT NULL,
	[TasksToDo] [nvarchar](1000) NOT NULL,
	[WorkArea] [nvarchar](1000) NOT NULL,
	[Observations] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
	[IsHighPriority] [bit] NOT NULL,
	[LastUpdated] [timestamp] NOT NULL,
	[ResultId] [int] NOT NULL,
	[LastUpdateUserId] [uniqueidentifier] NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
	[ResultObservations] [nvarchar](max) NOT NULL,
	[AnotherTypeDescription] [nvarchar](250) NULL,
	[DailyPatientNumber] [int] NOT NULL,
	[ChargeToClientId] [uniqueidentifier] NULL,
	[SystemVersion] [int] NULL,
	[ReceptionUser] [uniqueidentifier] NULL,
 CONSTRAINT [PK_ClinicalHistory] PRIMARY KEY CLUSTERED 
(
	[MedicalHistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MedicalHistoryPractice]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalHistoryPractice](
	[MedicalHistoryPracticeId] [uniqueidentifier] NOT NULL,
	[MedicalHistoryId] [uniqueidentifier] NOT NULL,
	[MedicalPracticeId] [uniqueidentifier] NOT NULL,
	[Status] [int] NOT NULL,
	[Result] [int] NOT NULL,
	[Observations] [nvarchar](max) NULL,
	[GroupId] [uniqueidentifier] NULL,
	[InvoiceId] [uniqueidentifier] NULL,
	[ProfessionalId] [uniqueidentifier] NULL,
	[AttentionDate] [datetime] NULL,
 CONSTRAINT [PK_MedicalHistoryPractice] PRIMARY KEY CLUSTERED 
(
	[MedicalHistoryPracticeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MedicalHistoryResult]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalHistoryResult](
	[MedicalHistoryResultId] [uniqueidentifier] NOT NULL,
	[MedicalHistoryId] [uniqueidentifier] NOT NULL,
	[DateCompleted] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ChestXRay] [int] NOT NULL,
	[ChestXRayDetails] [nvarchar](max) NOT NULL,
	[ColumnXRay] [int] NOT NULL,
	[ColumnXRayDetails] [nvarchar](max) NOT NULL,
	[Laboratory] [int] NOT NULL,
	[LaboratoryDetails] [nvarchar](max) NOT NULL,
	[Electrocardiogram] [int] NOT NULL,
	[ElectrocardiogramDetails] [nvarchar](max) NOT NULL,
	[Audiometry] [int] NOT NULL,
	[AudiometryDetails] [nvarchar](max) NOT NULL,
	[Spirometry] [int] NOT NULL,
	[SpirometryDetails] [nvarchar](max) NOT NULL,
	[PsychologicalExam] [int] NOT NULL,
	[PsychologicalExamDetails] [nvarchar](max) NOT NULL,
	[Electroencephalogram] [int] NOT NULL,
	[ElectroencephalogramDetails] [nvarchar](max) NOT NULL,
	[Ergometry] [int] NOT NULL,
	[ErgometryDetails] [nvarchar](max) NOT NULL,
	[Ophthalmology] [int] NOT NULL,
	[OphthalmologyDetails] [nvarchar](max) NOT NULL,
	[NeurologicalConsultation] [int] NOT NULL,
	[NeurologicalDetails] [nvarchar](max) NOT NULL,
	[CardiologyConsultation] [int] NOT NULL,
	[CardiologyDetails] [nvarchar](max) NOT NULL,
	[NeumonologyConsultation] [int] NOT NULL,
	[NeumonologyDetails] [nvarchar](max) NOT NULL,
	[MagneticResonance] [int] NOT NULL,
	[MagneticResonanceDetails] [nvarchar](max) NOT NULL,
	[Ultrasound] [int] NOT NULL,
	[UltrasoundDetails] [nvarchar](max) NOT NULL,
	[VestibularExam] [int] NOT NULL,
	[VestibularExamDetails] [nvarchar](max) NOT NULL,
	[Dental] [int] NOT NULL,
	[DentalDetails] [nvarchar](max) NOT NULL,
	[ORL] [int] NOT NULL,
	[ORLDetails] [nvarchar](max) NOT NULL,
	[Others] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_MedicalHistoryResult] PRIMARY KEY CLUSTERED 
(
	[MedicalHistoryResultId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MedicalPractice]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalPractice](
	[MedicalPracticeId] [uniqueidentifier] NOT NULL,
	[PracticeCode] [int] NOT NULL,
	[PracticeName] [nvarchar](50) NOT NULL,
	[PracticeDescription] [nvarchar](500) NOT NULL,
	[SpecialityId] [uniqueidentifier] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[LastUpdated] [timestamp] NOT NULL,
	[IsExternal] [bit] NOT NULL CONSTRAINT [DF_MedicalPractice_IsExternal]  DEFAULT ((0)),
	[ReportName] [nvarchar](21) NULL,
 CONSTRAINT [PK_MedicalPractice] PRIMARY KEY CLUSTERED 
(
	[MedicalPracticeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NextCreditNoteNumber]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NextCreditNoteNumber](
	[CreditNoteNumberID] [int] IDENTITY(1,1) NOT NULL,
	[CreditNoteType] [int] NOT NULL,
	[MasterNumber] [int] NOT NULL,
	[CreditNoteNumber] [int] NOT NULL,
	[LastUpdated] [timestamp] NOT NULL,
 CONSTRAINT [PK_NextCreditNoteNumber] PRIMARY KEY CLUSTERED 
(
	[CreditNoteNumberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NextDebitNoteNumber]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NextDebitNoteNumber](
	[DebitNoteNumberID] [int] IDENTITY(1,1) NOT NULL,
	[DebitNoteType] [int] NOT NULL,
	[MasterNumber] [int] NOT NULL,
	[DebitNoteNumber] [int] NOT NULL,
	[LastUpdated] [timestamp] NOT NULL,
 CONSTRAINT [PK_NextDebitNoteNumber] PRIMARY KEY CLUSTERED 
(
	[DebitNoteNumberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NextInvoiceNumber]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NextInvoiceNumber](
	[InvoiceNumberID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceType] [int] NOT NULL,
	[MasterNumber] [int] NOT NULL,
	[InvoiceNumber] [int] NOT NULL,
	[LastUpdated] [timestamp] NOT NULL,
 CONSTRAINT [PK_NextInvoiceNumber] PRIMARY KEY CLUSTERED 
(
	[InvoiceNumberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ObjectType]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ObjectType](
	[ObjectTypeId] [int] NOT NULL,
	[ObjectTypeName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ObjectType] PRIMARY KEY CLUSTERED 
(
	[ObjectTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Patient]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[PatientId] [uniqueidentifier] NOT NULL,
	[DocumentTypeId] [int] NOT NULL,
	[DocumentNumber] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](150) NOT NULL,
	[FirstName] [nvarchar](250) NOT NULL,
	[BirthDay] [smalldatetime] NOT NULL,
	[GenderId] [int] NOT NULL,
	[ChildrenNumber] [int] NOT NULL,
	[CivilStateId] [int] NOT NULL,
	[InstructionLevelId] [int] NOT NULL,
	[InstructionTitle] [nvarchar](500) NOT NULL,
	[HomePhoneNumber] [nvarchar](50) NULL,
	[CellPhoneNumber] [nvarchar](50) NULL,
	[IsDeleted] [bit] NOT NULL,
	[LastUpdated] [timestamp] NOT NULL,
	[Observations] [nvarchar](max) NOT NULL,
	[PrivateMedicineId] [uniqueidentifier] NULL,
	[Photo] [nvarchar](100) NOT NULL,
	[PrivateMedicineNumber] [nvarchar](50) NOT NULL,
	[WorkRiskInsuranceId] [uniqueidentifier] NULL,
	[Nationality] [nvarchar](150) NOT NULL,
	[BirthPlaceId] [int] NOT NULL,
 CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PracticeGroupPrice]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PracticeGroupPrice](
	[PriceId] [uniqueidentifier] NOT NULL,
	[PracticeGroupId] [uniqueidentifier] NOT NULL,
	[Price] [float] NOT NULL,
	[ClientId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_PracticeGroupPrice] PRIMARY KEY CLUSTERED 
(
	[PriceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PrivateMedicineCompany]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrivateMedicineCompany](
	[PrivateMedicineCompanyId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[LastUpdated] [timestamp] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_PrivateMedicineCompany] PRIMARY KEY CLUSTERED 
(
	[PrivateMedicineCompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Receipt]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipt](
	[ReceiptId] [uniqueidentifier] NOT NULL,
	[ReceiptNumber] [nvarchar](105) NOT NULL,
	[ClientId] [uniqueidentifier] NOT NULL,
	[Total] [float] NOT NULL,
	[CreateUserId] [uniqueidentifier] NOT NULL,
	[LastUpdateUserId] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Date] [datetime] NOT NULL,
	[ReceiverName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Receipt] PRIMARY KEY CLUSTERED 
(
	[ReceiptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReceiptInvoice]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceiptInvoice](
	[ReceiptInvoiceId] [uniqueidentifier] NOT NULL,
	[ReceiptId] [uniqueidentifier] NOT NULL,
	[InvoiceId] [uniqueidentifier] NOT NULL,
	[PaymentAmount] [float] NOT NULL,
 CONSTRAINT [PK_ReceiptInvoice] PRIMARY KEY CLUSTERED 
(
	[ReceiptInvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RetentionCertificate]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RetentionCertificate](
	[RetentionCertificateId] [uniqueidentifier] NOT NULL,
	[RetentionImport] [float] NOT NULL,
	[PaymentDate] [datetime] NOT NULL,
	[RetentionType] [int] NOT NULL,
	[Notes] [nvarchar](max) NOT NULL,
	[ReceiptId] [uniqueidentifier] NOT NULL,
	[CertificateNumber] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RetentionCertificate] PRIMARY KEY CLUSTERED 
(
	[RetentionCertificateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [uniqueidentifier] NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[RoleDescription] [nvarchar](500) NOT NULL,
	[LastUpdated] [timestamp] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RolePrivilege]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePrivilege](
	[RolePrivilegeId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[PrivilegeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RolePrivilege] PRIMARY KEY CLUSTERED 
(
	[RolePrivilegeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Speciality]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Speciality](
	[SpecialityId] [uniqueidentifier] NOT NULL,
	[SpecialityName] [nvarchar](50) NOT NULL,
	[SpecialityDescription] [nvarchar](500) NOT NULL,
	[LastUpdated] [timestamp] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[SpecialityDisplayName] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Speciality] PRIMARY KEY CLUSTERED 
(
	[SpecialityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[State]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[StateName] [nvarchar](50) NOT NULL,
	[StateId] [int] NOT NULL,
 CONSTRAINT [PK_State_1] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[UserFirstName] [nvarchar](50) NOT NULL,
	[UserLastName] [nvarchar](50) NOT NULL,
	[EmailAddress] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[LastUpdated] [timestamp] NOT NULL,
	[SpecialityId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserRoleId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkRiskInsurance]    Script Date: 02/07/2015 21:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkRiskInsurance](
	[WorkRiskInsuranceId] [uniqueidentifier] NOT NULL,
	[WorkRiskInsuranceName] [nvarchar](150) NOT NULL,
	[WorkRiskInsuranceDescription] [nvarchar](2000) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[LastUpdated] [timestamp] NOT NULL,
 CONSTRAINT [PK_WorkRiskInsurance] PRIMARY KEY CLUSTERED 
(
	[WorkRiskInsuranceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_AditionalItem]    Script Date: 02/07/2015 21:28:04 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_AditionalItem] ON [dbo].[AditionalItem]
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Client]    Script Date: 02/07/2015 21:28:04 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Client] ON [dbo].[Client]
(
	[ClientNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Group]    Script Date: 02/07/2015 21:28:04 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Group] ON [dbo].[Group]
(
	[GroupCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MedicalPractice]    Script Date: 02/07/2015 21:28:04 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_MedicalPractice] ON [dbo].[MedicalPractice]
(
	[PracticeCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_AddressType] FOREIGN KEY([AddressTypeId])
REFERENCES [dbo].[AddressType] ([AddressTypeId])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_AddressType]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_State] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([StateId])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_State]
GO
ALTER TABLE [dbo].[Audit]  WITH CHECK ADD  CONSTRAINT [FK_Audit_ObjectType] FOREIGN KEY([AuditObjectTypeId])
REFERENCES [dbo].[ObjectType] ([ObjectTypeId])
GO
ALTER TABLE [dbo].[Audit] CHECK CONSTRAINT [FK_Audit_ObjectType]
GO
ALTER TABLE [dbo].[Audit]  WITH CHECK ADD  CONSTRAINT [FK_Audit_User] FOREIGN KEY([AuditUserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Audit] CHECK CONSTRAINT [FK_Audit_User]
GO
ALTER TABLE [dbo].[Cash]  WITH CHECK ADD  CONSTRAINT [FK_Cash_Receipt] FOREIGN KEY([ReceiptId])
REFERENCES [dbo].[Receipt] ([ReceiptId])
GO
ALTER TABLE [dbo].[Cash] CHECK CONSTRAINT [FK_Cash_Receipt]
GO
ALTER TABLE [dbo].[Check]  WITH CHECK ADD  CONSTRAINT [FK_Check_Receipt] FOREIGN KEY([ReceiptId])
REFERENCES [dbo].[Receipt] ([ReceiptId])
GO
ALTER TABLE [dbo].[Check] CHECK CONSTRAINT [FK_Check_Receipt]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_InvoiceProfile] FOREIGN KEY([InvoiceProfileId])
REFERENCES [dbo].[InvoiceProfile] ([InvoiceProfileId])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_InvoiceProfile]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_IvaCondition] FOREIGN KEY([IvaConditionId])
REFERENCES [dbo].[IvaCondition] ([IvaConditionId])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_IvaCondition]
GO
ALTER TABLE [dbo].[ClientArea]  WITH CHECK ADD  CONSTRAINT [FK_ClientArea_Client] FOREIGN KEY([CllientId])
REFERENCES [dbo].[Client] ([ClientId])
GO
ALTER TABLE [dbo].[ClientArea] CHECK CONSTRAINT [FK_ClientArea_Client]
GO
ALTER TABLE [dbo].[ClinicalExam]  WITH CHECK ADD  CONSTRAINT [FK_ClinicalExam_MedicalHistory] FOREIGN KEY([MedicalHistoryId])
REFERENCES [dbo].[MedicalHistory] ([MedicalHistoryId])
GO
ALTER TABLE [dbo].[ClinicalExam] CHECK CONSTRAINT [FK_ClinicalExam_MedicalHistory]
GO
ALTER TABLE [dbo].[CreditNote]  WITH CHECK ADD  CONSTRAINT [FK_CreditNote_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([ClientId])
GO
ALTER TABLE [dbo].[CreditNote] CHECK CONSTRAINT [FK_CreditNote_Client]
GO
ALTER TABLE [dbo].[CreditNote]  WITH CHECK ADD  CONSTRAINT [FK_CreditNote_InvoiceHeader] FOREIGN KEY([RelatedInvoiceId])
REFERENCES [dbo].[InvoiceHeader] ([InvoiceHeaderId])
GO
ALTER TABLE [dbo].[CreditNote] CHECK CONSTRAINT [FK_CreditNote_InvoiceHeader]
GO
ALTER TABLE [dbo].[CreditNote]  WITH CHECK ADD  CONSTRAINT [FK_CreditNote_Receipt] FOREIGN KEY([ReceiptId])
REFERENCES [dbo].[Receipt] ([ReceiptId])
GO
ALTER TABLE [dbo].[CreditNote] CHECK CONSTRAINT [FK_CreditNote_Receipt]
GO
ALTER TABLE [dbo].[CreditNote]  WITH CHECK ADD  CONSTRAINT [FK_CreditNote_User] FOREIGN KEY([CreatorUserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[CreditNote] CHECK CONSTRAINT [FK_CreditNote_User]
GO
ALTER TABLE [dbo].[DebitNote]  WITH CHECK ADD  CONSTRAINT [FK_DebitNote_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([ClientId])
GO
ALTER TABLE [dbo].[DebitNote] CHECK CONSTRAINT [FK_DebitNote_Client]
GO
ALTER TABLE [dbo].[DebitNote]  WITH CHECK ADD  CONSTRAINT [FK_DebitNote_InvoiceHeader] FOREIGN KEY([RelatedInvoiceId])
REFERENCES [dbo].[InvoiceHeader] ([InvoiceHeaderId])
GO
ALTER TABLE [dbo].[DebitNote] CHECK CONSTRAINT [FK_DebitNote_InvoiceHeader]
GO
ALTER TABLE [dbo].[DebitNote]  WITH CHECK ADD  CONSTRAINT [FK_DebitNote_User] FOREIGN KEY([CreatorUserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[DebitNote] CHECK CONSTRAINT [FK_DebitNote_User]
GO
ALTER TABLE [dbo].[ElectronicTransfer]  WITH CHECK ADD  CONSTRAINT [FK_ElectronicTrasnfer_Receipt] FOREIGN KEY([ReceiptId])
REFERENCES [dbo].[Receipt] ([ReceiptId])
GO
ALTER TABLE [dbo].[ElectronicTransfer] CHECK CONSTRAINT [FK_ElectronicTrasnfer_Receipt]
GO
ALTER TABLE [dbo].[FiscalRetention]  WITH CHECK ADD  CONSTRAINT [FK_FiscalRetention_User] FOREIGN KEY([LastUpdateUser])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[FiscalRetention] CHECK CONSTRAINT [FK_FiscalRetention_User]
GO
ALTER TABLE [dbo].[GroupMedicalPractice]  WITH CHECK ADD  CONSTRAINT [FK_GroupMedicalPractice_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([GroupId])
GO
ALTER TABLE [dbo].[GroupMedicalPractice] CHECK CONSTRAINT [FK_GroupMedicalPractice_Group]
GO
ALTER TABLE [dbo].[GroupMedicalPractice]  WITH CHECK ADD  CONSTRAINT [FK_GroupMedicalPractice_MedicalPractice] FOREIGN KEY([MedicalPracticeId])
REFERENCES [dbo].[MedicalPractice] ([MedicalPracticeId])
GO
ALTER TABLE [dbo].[GroupMedicalPractice] CHECK CONSTRAINT [FK_GroupMedicalPractice_MedicalPractice]
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetail_ExamType] FOREIGN KEY([ExamTypeId])
REFERENCES [dbo].[ExamType] ([ExamTypeId])
GO
ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_ExamType]
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetail_Group] FOREIGN KEY([ItemGroupId])
REFERENCES [dbo].[Group] ([GroupId])
GO
ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_Group]
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetail_InvoiceHeader] FOREIGN KEY([InvoiceHeaderId])
REFERENCES [dbo].[InvoiceHeader] ([InvoiceHeaderId])
GO
ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_InvoiceHeader]
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetail_Patient] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([PatientId])
GO
ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_Patient]
GO
ALTER TABLE [dbo].[InvoiceHeader]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceHeader_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([ClientId])
GO
ALTER TABLE [dbo].[InvoiceHeader] CHECK CONSTRAINT [FK_InvoiceHeader_Client]
GO
ALTER TABLE [dbo].[InvoiceHeader]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceHeader_CompanyInfo] FOREIGN KEY([CompanyInfoId])
REFERENCES [dbo].[CompanyInfo] ([CompanyInfoId])
GO
ALTER TABLE [dbo].[InvoiceHeader] CHECK CONSTRAINT [FK_InvoiceHeader_CompanyInfo]
GO
ALTER TABLE [dbo].[InvoiceHeader]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceHeader_User] FOREIGN KEY([CreateUserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[InvoiceHeader] CHECK CONSTRAINT [FK_InvoiceHeader_User]
GO
ALTER TABLE [dbo].[InvoiceHeader]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceHeader_User1] FOREIGN KEY([LastUpdateUserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[InvoiceHeader] CHECK CONSTRAINT [FK_InvoiceHeader_User1]
GO
ALTER TABLE [dbo].[InvoiceProfile]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceProfile_User] FOREIGN KEY([LastUpdateUser])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[InvoiceProfile] CHECK CONSTRAINT [FK_InvoiceProfile_User]
GO
ALTER TABLE [dbo].[InvoiceProfileRetention]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceProfileRetention_FiscalRetention] FOREIGN KEY([FiscalRetentionId])
REFERENCES [dbo].[FiscalRetention] ([FiscalRetentionId])
GO
ALTER TABLE [dbo].[InvoiceProfileRetention] CHECK CONSTRAINT [FK_InvoiceProfileRetention_FiscalRetention]
GO
ALTER TABLE [dbo].[InvoiceProfileRetention]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceProfileRetention_InvoiceProfile] FOREIGN KEY([InvoiceProfileId])
REFERENCES [dbo].[InvoiceProfile] ([InvoiceProfileId])
GO
ALTER TABLE [dbo].[InvoiceProfileRetention] CHECK CONSTRAINT [FK_InvoiceProfileRetention_InvoiceProfile]
GO
ALTER TABLE [dbo].[IvaPercentage]  WITH CHECK ADD  CONSTRAINT [FK_IvaPercentage_IvaCondition] FOREIGN KEY([IvaConditionId])
REFERENCES [dbo].[IvaCondition] ([IvaConditionId])
GO
ALTER TABLE [dbo].[IvaPercentage] CHECK CONSTRAINT [FK_IvaPercentage_IvaCondition]
GO
ALTER TABLE [dbo].[MedicalHistory]  WITH CHECK ADD  CONSTRAINT [FK_MedicalHistory_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([ClientId])
GO
ALTER TABLE [dbo].[MedicalHistory] CHECK CONSTRAINT [FK_MedicalHistory_Client]
GO
ALTER TABLE [dbo].[MedicalHistory]  WITH CHECK ADD  CONSTRAINT [FK_MedicalHistory_ClientArea] FOREIGN KEY([ClientAreaId])
REFERENCES [dbo].[ClientArea] ([ClientAreaId])
GO
ALTER TABLE [dbo].[MedicalHistory] CHECK CONSTRAINT [FK_MedicalHistory_ClientArea]
GO
ALTER TABLE [dbo].[MedicalHistory]  WITH CHECK ADD  CONSTRAINT [FK_MedicalHistory_ClinicalHistoryResult] FOREIGN KEY([ResultId])
REFERENCES [dbo].[ClinicalHistoryResult] ([ClinicalHistoryResultId])
GO
ALTER TABLE [dbo].[MedicalHistory] CHECK CONSTRAINT [FK_MedicalHistory_ClinicalHistoryResult]
GO
ALTER TABLE [dbo].[MedicalHistory]  WITH CHECK ADD  CONSTRAINT [FK_MedicalHistory_ExamType] FOREIGN KEY([ExamTypeId])
REFERENCES [dbo].[ExamType] ([ExamTypeId])
GO
ALTER TABLE [dbo].[MedicalHistory] CHECK CONSTRAINT [FK_MedicalHistory_ExamType]
GO
ALTER TABLE [dbo].[MedicalHistory]  WITH CHECK ADD  CONSTRAINT [FK_MedicalHistory_Patient] FOREIGN KEY([PatiendId])
REFERENCES [dbo].[Patient] ([PatientId])
GO
ALTER TABLE [dbo].[MedicalHistory] CHECK CONSTRAINT [FK_MedicalHistory_Patient]
GO
ALTER TABLE [dbo].[MedicalHistory]  WITH CHECK ADD  CONSTRAINT [FK_MedicalHistory_User] FOREIGN KEY([LastUpdateUserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[MedicalHistory] CHECK CONSTRAINT [FK_MedicalHistory_User]
GO
ALTER TABLE [dbo].[MedicalHistoryPractice]  WITH CHECK ADD  CONSTRAINT [FK_MedicalHistoryPractice_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([GroupId])
GO
ALTER TABLE [dbo].[MedicalHistoryPractice] CHECK CONSTRAINT [FK_MedicalHistoryPractice_Group]
GO
ALTER TABLE [dbo].[MedicalHistoryPractice]  WITH CHECK ADD  CONSTRAINT [FK_MedicalHistoryPractice_MedicalHistory] FOREIGN KEY([MedicalHistoryId])
REFERENCES [dbo].[MedicalHistory] ([MedicalHistoryId])
GO
ALTER TABLE [dbo].[MedicalHistoryPractice] CHECK CONSTRAINT [FK_MedicalHistoryPractice_MedicalHistory]
GO
ALTER TABLE [dbo].[MedicalHistoryPractice]  WITH CHECK ADD  CONSTRAINT [FK_MedicalHistoryPractice_MedicalPractice] FOREIGN KEY([MedicalPracticeId])
REFERENCES [dbo].[MedicalPractice] ([MedicalPracticeId])
GO
ALTER TABLE [dbo].[MedicalHistoryPractice] CHECK CONSTRAINT [FK_MedicalHistoryPractice_MedicalPractice]
GO
ALTER TABLE [dbo].[MedicalHistoryPractice]  WITH CHECK ADD  CONSTRAINT [FK_MedicalHistoryPractice_User] FOREIGN KEY([ProfessionalId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[MedicalHistoryPractice] CHECK CONSTRAINT [FK_MedicalHistoryPractice_User]
GO
ALTER TABLE [dbo].[MedicalHistoryResult]  WITH CHECK ADD  CONSTRAINT [FK_MedicalHistoryResult_MedicalHistory] FOREIGN KEY([MedicalHistoryId])
REFERENCES [dbo].[MedicalHistory] ([MedicalHistoryId])
GO
ALTER TABLE [dbo].[MedicalHistoryResult] CHECK CONSTRAINT [FK_MedicalHistoryResult_MedicalHistory]
GO
ALTER TABLE [dbo].[MedicalHistoryResult]  WITH CHECK ADD  CONSTRAINT [FK_MedicalHistoryResult_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[MedicalHistoryResult] CHECK CONSTRAINT [FK_MedicalHistoryResult_User]
GO
ALTER TABLE [dbo].[MedicalPractice]  WITH CHECK ADD  CONSTRAINT [FK_MedicalPractice_Speciality] FOREIGN KEY([SpecialityId])
REFERENCES [dbo].[Speciality] ([SpecialityId])
GO
ALTER TABLE [dbo].[MedicalPractice] CHECK CONSTRAINT [FK_MedicalPractice_Speciality]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_CivilState] FOREIGN KEY([CivilStateId])
REFERENCES [dbo].[CivilState] ([CivilStateId])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_CivilState]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_DocumentType] FOREIGN KEY([DocumentTypeId])
REFERENCES [dbo].[DocumentType] ([DocumentTypeId])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_DocumentType]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_Gender] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Gender] ([GenderId])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_Gender]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_InstructionLevel] FOREIGN KEY([InstructionLevelId])
REFERENCES [dbo].[InstructionLevel] ([InstructionLevelId])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_InstructionLevel]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_PrivateMedicineCompany] FOREIGN KEY([PrivateMedicineId])
REFERENCES [dbo].[PrivateMedicineCompany] ([PrivateMedicineCompanyId])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_PrivateMedicineCompany]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_State] FOREIGN KEY([BirthPlaceId])
REFERENCES [dbo].[State] ([StateId])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_State]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_WorkRiskInsurance] FOREIGN KEY([WorkRiskInsuranceId])
REFERENCES [dbo].[WorkRiskInsurance] ([WorkRiskInsuranceId])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_WorkRiskInsurance]
GO
ALTER TABLE [dbo].[PracticeGroupPrice]  WITH CHECK ADD  CONSTRAINT [FK_PracticeGroupPrice_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([ClientId])
GO
ALTER TABLE [dbo].[PracticeGroupPrice] CHECK CONSTRAINT [FK_PracticeGroupPrice_Client]
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipt_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([ClientId])
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipt_Client]
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipt_User] FOREIGN KEY([CreateUserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipt_User]
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipt_User1] FOREIGN KEY([LastUpdateUserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipt_User1]
GO
ALTER TABLE [dbo].[ReceiptInvoice]  WITH CHECK ADD  CONSTRAINT [FK_ReceiptInvoice_InvoiceHeader] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[InvoiceHeader] ([InvoiceHeaderId])
GO
ALTER TABLE [dbo].[ReceiptInvoice] CHECK CONSTRAINT [FK_ReceiptInvoice_InvoiceHeader]
GO
ALTER TABLE [dbo].[ReceiptInvoice]  WITH CHECK ADD  CONSTRAINT [FK_ReceiptInvoice_Receipt] FOREIGN KEY([ReceiptId])
REFERENCES [dbo].[Receipt] ([ReceiptId])
GO
ALTER TABLE [dbo].[ReceiptInvoice] CHECK CONSTRAINT [FK_ReceiptInvoice_Receipt]
GO
ALTER TABLE [dbo].[RetentionCertificate]  WITH CHECK ADD  CONSTRAINT [FK_RetentionCertificate_Receipt] FOREIGN KEY([ReceiptId])
REFERENCES [dbo].[Receipt] ([ReceiptId])
GO
ALTER TABLE [dbo].[RetentionCertificate] CHECK CONSTRAINT [FK_RetentionCertificate_Receipt]
GO
ALTER TABLE [dbo].[RolePrivilege]  WITH CHECK ADD  CONSTRAINT [FK_RolePrivilege_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[RolePrivilege] CHECK CONSTRAINT [FK_RolePrivilege_Role]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Speciality] FOREIGN KEY([SpecialityId])
REFERENCES [dbo].[Speciality] ([SpecialityId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Speciality]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO
