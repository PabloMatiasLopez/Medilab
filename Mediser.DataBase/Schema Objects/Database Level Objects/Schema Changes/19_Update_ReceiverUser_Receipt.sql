ALTER TABLE Receipt DROP FK_Receipt_User2
ALTER TABLE Receipt DROP COLUMN ReceiverUser
ALTER TABLE Receipt ADD ReceiverName NVARCHAR(50) NULL
