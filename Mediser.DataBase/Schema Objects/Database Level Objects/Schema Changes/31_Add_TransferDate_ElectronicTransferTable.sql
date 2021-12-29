ALTER TABLE ElectronicTransfer ADD TransferDate DATE NOT NULL DEFAULT GETDATE()
GO

UPDATE ElectronicTransfer SET TransferDate = PaymentDate
GO