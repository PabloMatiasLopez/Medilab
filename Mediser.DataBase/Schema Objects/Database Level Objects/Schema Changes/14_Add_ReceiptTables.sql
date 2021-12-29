USE [Medilab]
GO

/****** Object:  Table [dbo].[Receipt]    Script Date: 31/03/2015 08:36:32 p.m. ******/
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
	[ReceiverUser] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Receipt] PRIMARY KEY CLUSTERED 
(
	[ReceiptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

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

ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipt_User2] FOREIGN KEY([ReceiverUser])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipt_User2]
GO

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