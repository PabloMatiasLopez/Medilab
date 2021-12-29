ALTER TABLE CreditNote ADD CAE nvarchar(50) NOT NULL
ALTER TABLE CreditNote ADD IVAType int NOT NULL
ALTER TABLE CreditNote ADD CAEExpirationDate date NOT NULL
ALTER TABLE CreditNote ADD SalePoint int NOT NULL
ALTER TABLE CreditNote ALTER COLUMN CreditNoteNumber int
