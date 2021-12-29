ALTER TABLE MedicalHistory
ADD SystemVersion INT NULL
GO

--Update existing data run only in prod
UPDATE MedicalHistory SET SystemVersion = 1, [Status] = 4 WHERE [Status] = 3
GO