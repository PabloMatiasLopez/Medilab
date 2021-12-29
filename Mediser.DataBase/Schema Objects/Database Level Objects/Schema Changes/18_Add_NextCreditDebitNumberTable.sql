USE [Medilab]
GO

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


