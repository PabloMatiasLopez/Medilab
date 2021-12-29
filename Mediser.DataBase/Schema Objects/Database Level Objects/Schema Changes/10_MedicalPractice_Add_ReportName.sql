ALTER TABLE MedicalPractice ADD ReportName nvarchar(21) NULL
GO

UPDATE MedicalPractice set ReportName = substring(PracticeName, 0, 21)
GO
