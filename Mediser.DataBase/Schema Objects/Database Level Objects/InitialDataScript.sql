USE [Medilab]
GO

--Object Type
INSERT INTO [ObjectType] VALUES (1,'User')
GO
INSERT INTO [ObjectType] VALUES (2,'Role')
GO
INSERT INTO [ObjectType] VALUES (3,'CompanyInfo')
GO
INSERT INTO [ObjectType] VALUES (4,'Patient')
GO
INSERT INTO [ObjectType] VALUES (5,'MedicalHistory')
GO
INSERT INTO [ObjectType] VALUES (6,'Client')
GO
INSERT INTO [ObjectType] VALUES (7,'PrivateMedicineCompany')
GO
INSERT INTO [ObjectType] VALUES (8,'Address')
GO
INSERT INTO [ObjectType] VALUES (9,'WorkRiskInsurance')
GO
INSERT INTO [ObjectType] VALUES (10,'ClinicalExam')
GO
INSERT INTO [ObjectType] VALUES (11,'Speciality')
GO
INSERT INTO [ObjectType] VALUES (12,'MedicalPractice')
GO
INSERT INTO [ObjectType] VALUES (13,'Group')
GO
INSERT INTO [ObjectType] VALUES (14,'ClientArea')
GO
INSERT INTO [ObjectType] VALUES (15,'PracticeGroupPrice')
GO
INSERT INTO [ObjectType] VALUES (16,'AditionalItem')
GO
INSERT INTO [ObjectType] VALUES (17,'FiscalRetention')
GO
INSERT INTO [ObjectType] VALUES (18,'InvoiceProfile')
GO
INSERT INTO [ObjectType] VALUES (19,'Invoice')
GO

--Gender
INSERT INTO [Gender] VALUES (1,'Hombre')
GO
INSERT INTO [Gender] VALUES (2,'Mujer')
GO

--Civil State
INSERT INTO [CivilState] VALUES (1,'Soltero')
GO
INSERT INTO [CivilState] VALUES (2,'Casado')
GO
INSERT INTO [CivilState] VALUES (3,'Divorciado')
GO
INSERT INTO [CivilState] VALUES (4,'Viudo')
GO

--Instruction Level
INSERT INTO [InstructionLevel] VALUES (1,'Primaria')
GO
INSERT INTO [InstructionLevel] VALUES (2,'Secundaria')
GO
INSERT INTO [InstructionLevel] VALUES (3,'Terciaria')
GO
INSERT INTO [InstructionLevel] VALUES (4,'Universitaria')
GO

--Document Type
INSERT INTO [DocumentType] VALUES (0, 'CI_Policia_Federal')
GO
INSERT INTO [DocumentType] VALUES (1, 'CI_Buenos_Aires')
GO
INSERT INTO [DocumentType] VALUES (2, 'CI_Catamarca')
GO
INSERT INTO [DocumentType] VALUES (3, 'CI_Cordoba')
GO
INSERT INTO [DocumentType] VALUES (4, 'CI_Corrientes')
GO
INSERT INTO [DocumentType] VALUES (5, 'CI_Entre_Rios')
GO
INSERT INTO [DocumentType] VALUES (6, 'CI_Jujuy')
GO
INSERT INTO [DocumentType] VALUES (7, 'CI_Mendoza')
GO
INSERT INTO [DocumentType] VALUES (8, 'CI_La_Rioja')
GO
INSERT INTO [DocumentType] VALUES (9, 'CI_Salta')
GO
INSERT INTO [DocumentType] VALUES (10, 'CI_San_Juan')
GO
INSERT INTO [DocumentType] VALUES (11, 'CI_San_Luis')
GO
INSERT INTO [DocumentType] VALUES (12, 'CI_Santa_Fe')
GO
INSERT INTO [DocumentType] VALUES (13, 'CI_Santiago_del_Estero')
GO
INSERT INTO [DocumentType] VALUES (15, 'CI_Tucuman')
GO
INSERT INTO [DocumentType] VALUES (16, 'CI_Chaco')
GO
INSERT INTO [DocumentType] VALUES (17, 'CI_Chubut')
GO
INSERT INTO [DocumentType] VALUES (18, 'CI_Formosa')
GO
INSERT INTO [DocumentType] VALUES (19, 'CI_Misiones')
GO
INSERT INTO [DocumentType] VALUES (20, 'CI_Neuquen')
GO
INSERT INTO [DocumentType] VALUES (21, 'CI_La_Pampa')
GO
INSERT INTO [DocumentType] VALUES (22, 'CI_Rio_Negro')
GO
INSERT INTO [DocumentType] VALUES (23, 'CI_Santa_Cruz')
GO
INSERT INTO [DocumentType] VALUES (24, 'CI_Tierra_del_Fuego')
GO
INSERT INTO [DocumentType] VALUES (80, 'CUIT')
GO
INSERT INTO [DocumentType] VALUES (86, 'CUIL')
GO
INSERT INTO [DocumentType] VALUES (87, 'CDI')
GO
INSERT INTO [DocumentType] VALUES (89, 'LE')
GO
INSERT INTO [DocumentType] VALUES (90, 'LC')
GO
INSERT INTO [DocumentType] VALUES (91, 'CI_extranjera')
GO
INSERT INTO [DocumentType] VALUES (92, 'En_tramite')
GO
INSERT INTO [DocumentType] VALUES (93, 'Acta_nacimiento')
GO
INSERT INTO [DocumentType] VALUES (94, 'Pasaporte')
GO
INSERT INTO [DocumentType] VALUES (95, 'CI_Buenos_Aires_RNP')
GO
INSERT INTO [DocumentType] VALUES (96, 'DNI')
GO
INSERT INTO [DocumentType] VALUES (99, 'Sin_identificar_venta_global_diaria')
GO
INSERT INTO [DocumentType] VALUES (30, 'Certificado_de_Migración')
GO
INSERT INTO [DocumentType] VALUES (88, 'Usado_por_Anses_para_Padron')
GO

--States
INSERT INTO [State] VALUES (0, 'Ciudad Autónoma de Buenos Aires')
GO
INSERT INTO [State] VALUES (1, 'Buenos Aires')
GO
INSERT INTO [State] VALUES (2, 'Catamarca')
GO
INSERT INTO [State] VALUES (3, 'Córdoba')
GO
INSERT INTO [State] VALUES (4, 'Corrientes')
GO
INSERT INTO [State] VALUES (5, 'Entre Ríos')
GO
INSERT INTO [State] VALUES (6, 'Jujuy')
GO
INSERT INTO [State] VALUES (7, 'Mendoza')
GO
INSERT INTO [State] VALUES (8, 'La Rioja')
GO
INSERT INTO [State] VALUES (9, 'Salta')
GO
INSERT INTO [State] VALUES (10, 'San Juan')
GO
INSERT INTO [State] VALUES (11, 'San Luis')
GO
INSERT INTO [State] VALUES (12, 'Santa Fe')
GO
INSERT INTO [State] VALUES (13, 'Santiago del Estero')
GO
INSERT INTO [State] VALUES (15, 'Tucumán')
GO
INSERT INTO [State] VALUES (16, 'Chaco')
GO
INSERT INTO [State] VALUES (17, 'Chubut')
GO
INSERT INTO [State] VALUES (18, 'Formosa')
GO
INSERT INTO [State] VALUES (19, 'Misiones')
GO
INSERT INTO [State] VALUES (20, 'Neuquén')
GO
INSERT INTO [State] VALUES (21, 'La Pampa')
GO
INSERT INTO [State] VALUES (22, 'Río Negro')
GO
INSERT INTO [State] VALUES (23, 'Santa Cruz')
GO
INSERT INTO [State] VALUES (24, 'Tierra del Fuego')
GO

--Address Type
INSERT INTO [AddressType] VALUES (1,'Casa')
GO
INSERT INTO [AddressType] VALUES (2,'Trabajo')
GO
INSERT INTO [AddressType] VALUES (3,'Legal')
GO

--Exam Type
INSERT INTO [ExamType] VALUES (1,'Pre Ingreso')
GO
INSERT INTO [ExamType] VALUES (2,'Egreso')
GO
INSERT INTO [ExamType] VALUES (3,'Periódico')
GO
INSERT INTO [ExamType] VALUES (4,'Pre Transferencial')
GO
INSERT INTO [ExamType] VALUES (5,'Libreta Sanitaria')
GO
INSERT INTO [ExamType] VALUES (6,'Otros')
GO

--Clinical History Result
INSERT INTO [ClinicalHistoryResult] VALUES (0,'Periodico')
GO
INSERT INTO [ClinicalHistoryResult] VALUES (1,'Apto')
GO
INSERT INTO [ClinicalHistoryResult] VALUES (2,'Apto Con Pre Existencia')
GO
INSERT INTO [ClinicalHistoryResult] VALUES (3,'No Apto Para La Tarea Propuesta')
GO
INSERT INTO [ClinicalHistoryResult] VALUES (4,'No Evaluado')
GO
INSERT INTO [ClinicalHistoryResult] VALUES (5,'Sin Patología Previa')
GO
INSERT INTO [ClinicalHistoryResult] VALUES (6,'Con Patología Previa')
GO
INSERT INTO [ClinicalHistoryResult] VALUES (7,'Con Patología Adquirida En El Trabajo')
GO

--Iva Condition
INSERT INTO [IvaCondition] VALUES (1, 'IVA Responsable Inscripto')
GO
INSERT INTO [IvaCondition] VALUES (2, 'IVA Responsable No Inscripto')
GO
INSERT INTO [IvaCondition] VALUES (3, 'IVA No Responsable')
GO
INSERT INTO [IvaCondition] VALUES (4, 'IVA Sujeto Exento')
GO
INSERT INTO [IvaCondition] VALUES (5, 'Consumidor Final')
GO
INSERT INTO [IvaCondition] VALUES (6, 'Responsable Monotributo')
GO
INSERT INTO [IvaCondition] VALUES (7, 'Sujeto no Categorizado')
GO
INSERT INTO [IvaCondition] VALUES (8, 'Proveedor del Exterior')
GO
INSERT INTO [IvaCondition] VALUES (9, 'Cliente del Exterior')
GO
INSERT INTO [IvaCondition] VALUES (10, 'IVA Liberado Ley 19640')
GO
INSERT INTO [IvaCondition] VALUES (11, 'IVA Responsable Inscripto Agente de Percepción')
GO
INSERT INTO [IvaCondition] VALUES (12, 'Pequeño Contribuyente Eventual')
GO
INSERT INTO [IvaCondition] VALUES (13, 'Monotributista Social')
GO
INSERT INTO [IvaCondition] VALUES (14, 'Pequeño Contribuyente Eventual Social')
GO

INSERT INTO [User]
			([UserId]
		   ,[UserName]
		   ,[UserFirstName]
		   ,[UserLastName]
		   ,[EmailAddress]
		   ,[Password]
		   ,[IsActive]
		   ,[IsDeleted]
		   ,[SpecialityId])
	 VALUES
		   ('F1341760-1D4F-483C-9B63-315156136FCF'
		   ,'administrator'
		   ,'Admin'
		   ,'Admin'
		   ,'admin@admin.com'
		   ,'/+95B8BnBhxvFEv1EbPLO37IstIc898K7T2bbElatY4DnRpv' --123456
		   ,1
		   ,0
		   ,'E45E6981-CF7D-4DA5-9BD9-7B7ED8ECCF16')
GO

--Populate price table
insert into PracticeGroupPrice (PriceId, PracticeGroupId, Price, ClientId)
Select NEWID(), p.MedicalPracticeId, 0, null
from MedicalPractice p

insert into PracticeGroupPrice (PriceId, PracticeGroupId, Price, ClientId)
Select NEWID(), g.GroupId, 0, null
from [Group] g

