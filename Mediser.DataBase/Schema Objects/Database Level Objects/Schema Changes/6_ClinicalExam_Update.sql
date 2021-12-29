ALTER TABLE ClinicalExam DROP COLUMN Aspect, AspectDetails, Tonsils, TonsilsDetails, Flatfoot, FlatfootDetails, PhysicalDefects, PhysicalDefectsDetails
GO
ALTER TABLE ClinicalExam ADD BalanceTest INT NULL
ALTER TABLE ClinicalExam ADD BalanceTestDetails NVARCHAR(500) NULL
GO
UPDATE ClinicalExam SET BalanceTest = 0, BalanceTestDetails = ''
GO
ALTER TABLE ClinicalExam ALTER COLUMN BalanceTest INT NOT NULL
ALTER TABLE ClinicalExam ALTER COLUMN BalanceTestDetails NVARCHAR(500) NOT NULL
GO
ALTER TABLE ClinicalExam ADD IMCStatus INT NULL
ALTER TABLE ClinicalExam ADD IMCStatusDetail NVARCHAR(500) NULL
GO
UPDATE ClinicalExam SET IMCStatus = 0, IMCStatusDetail = ''
GO
ALTER TABLE ClinicalExam ALTER COLUMN IMCStatus INT NOT NULL
ALTER TABLE ClinicalExam ALTER COLUMN IMCStatusDetail NVARCHAR(500) NOT NULL
GO
ALTER TABLE ClinicalExam ADD BloodPressureStatus INT NULL
ALTER TABLE ClinicalExam ADD BloodPressureStatusDetail NVARCHAR(500) NULL
GO
UPDATE ClinicalExam SET BloodPressureStatus = 0, BloodPressureStatusDetail = ''
GO
ALTER TABLE ClinicalExam ALTER COLUMN BloodPressureStatus INT NOT NULL
ALTER TABLE ClinicalExam ALTER COLUMN BloodPressureStatusDetail NVARCHAR(500) NOT NULL
GO
