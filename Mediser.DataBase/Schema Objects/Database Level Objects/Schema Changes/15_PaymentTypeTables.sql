USE [Medilab]
GO
/****** Object:  Table [dbo].[Cash]    Script Date: 02/04/2015 16:19:57 ******/
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
/****** Object:  Table [dbo].[Check]    Script Date: 02/04/2015 16:19:57 ******/
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
/****** Object:  Table [dbo].[RetentionCertificate]    Script Date: 02/04/2015 16:19:57 ******/
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
ALTER TABLE [dbo].[RetentionCertificate]  WITH CHECK ADD  CONSTRAINT [FK_RetentionCertificate_Receipt] FOREIGN KEY([ReceiptId])
REFERENCES [dbo].[Receipt] ([ReceiptId])
GO
ALTER TABLE [dbo].[RetentionCertificate] CHECK CONSTRAINT [FK_RetentionCertificate_Receipt]
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
ALTER TABLE [dbo].[ElectronicTransfer]  WITH CHECK ADD  CONSTRAINT [FK_ElectronicTrasnfer_Receipt] FOREIGN KEY([ReceiptId])
REFERENCES [dbo].[Receipt] ([ReceiptId])
GO
ALTER TABLE [dbo].[ElectronicTransfer] CHECK CONSTRAINT [FK_ElectronicTrasnfer_Receipt]
GO

