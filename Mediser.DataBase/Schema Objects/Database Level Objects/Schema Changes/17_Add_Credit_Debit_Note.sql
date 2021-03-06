USE [Medilab]
GO
/****** Object:  Table [dbo].[CreditNote]    Script Date: 16/06/2015 19:18:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditNote](
	[CreditNoteId] [uniqueidentifier] NOT NULL,
	[CreditNoteNumber] [nvarchar](50) NOT NULL,
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
 CONSTRAINT [PK_CreditNote] PRIMARY KEY CLUSTERED 
(
	[CreditNoteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

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
/****** Object:  Table [dbo].[DebitNote]    Script Date: 08/06/2015 22:15:05 ******/
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
