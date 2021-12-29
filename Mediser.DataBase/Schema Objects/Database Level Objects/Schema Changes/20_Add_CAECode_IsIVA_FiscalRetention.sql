ALTER TABLE FiscalRetention ADD CAECode int NOT NULL
ALTER TABLE FiscalRetention ADD IsIVA bit NOT NULL

ALTER TABLE InvoiceHeader ADD CAEExpirationDate date NOT NULL
ALTER TABLE InvoiceHeader ADD SalePoint int NOT NULL
ALTER TABLE InvoiceHeader ALTER COLUMN InvoiceNumber int