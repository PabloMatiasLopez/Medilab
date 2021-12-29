IF NOT EXISTS
(
	SELECT * 
	FROM sys.columns 
    WHERE Name = N'InvoiceRemainder' and Object_ID = Object_ID(N'InvoiceHeader'))
BEGIN
    ALTER TABLE InvoiceHeader
	ADD InvoiceRemainder float NULL

	EXEC('UPDATE InvoiceHeader set InvoiceRemainder = Total')

	ALTER TABLE InvoiceHeader ALTER COLUMN InvoiceRemainder float NOT NULL
END
GO