ALTER TABLE [dbo].[Receipt] ADD Discount FLOAT NOT NULL DEFAULT 0
GO
ALTER TABLE [dbo].[Receipt] ADD Notes NVARCHAR(MAX) NOT NULL DEFAULT ''
GO