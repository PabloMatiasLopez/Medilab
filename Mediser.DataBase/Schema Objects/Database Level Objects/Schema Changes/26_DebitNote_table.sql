USE [Medilab]
GO
ALTER TABLE [dbo].[DebitNote] DROP CONSTRAINT [FK_DebitNote_User]
GO
ALTER TABLE [dbo].[DebitNote] DROP CONSTRAINT [FK_DebitNote_Client]
GO
/****** Object:  Table [dbo].[DebitNote]    Script Date: 25/07/2015 12:43:36 ******/
DROP TABLE [dbo].[DebitNote]
GO
/****** Object:  Table [dbo].[DebitNote]    Script Date: 25/07/2015 12:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DebitNote](
	[DebitNoteId] [uniqueidentifier] NOT NULL,
	[DebitNoteNumber] [int] NOT NULL,
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
 CONSTRAINT [PK_DebitNote] PRIMARY KEY CLUSTERED 
(
	[DebitNoteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[DebitNote]  WITH CHECK ADD  CONSTRAINT [FK_DebitNote_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([ClientId])
GO
ALTER TABLE [dbo].[DebitNote] CHECK CONSTRAINT [FK_DebitNote_Client]
GO
ALTER TABLE [dbo].[DebitNote]  WITH CHECK ADD  CONSTRAINT [FK_DebitNote_User] FOREIGN KEY([CreatorUserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[DebitNote] CHECK CONSTRAINT [FK_DebitNote_User]
GO
