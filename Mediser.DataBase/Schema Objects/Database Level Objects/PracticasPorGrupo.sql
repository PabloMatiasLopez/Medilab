USE Medilab
GO
--practicas

DECLARE @clinicalExamId UNIQUEIDENTIFIER
SELECT @clinicalExamId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 134
DECLARE @ECGId UNIQUEIDENTIFIER
SELECT @ECGId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 16
DECLARE @hemogramaId UNIQUEIDENTIFIER
SELECT @hemogramaId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 13
DECLARE @uremiaExamId UNIQUEIDENTIFIER
SELECT @uremiaExamId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 15
DECLARE @glucemiaId UNIQUEIDENTIFIER
SELECT @glucemiaId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 14
DECLARE @orinaId UNIQUEIDENTIFIER
SELECT @orinaId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 23
DECLARE @eritroId UNIQUEIDENTIFIER
SELECT @eritroId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 22
DECLARE @rxToraxFrenteId UNIQUEIDENTIFIER
SELECT @rxToraxFrenteId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 17
DECLARE @rxLumbarFrenteId UNIQUEIDENTIFIER
SELECT @rxLumbarFrenteId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 3
DECLARE @rxLumbarPerfilId UNIQUEIDENTIFIER
SELECT @rxLumbarPerfilId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 4
DECLARE @audiometriaId UNIQUEIDENTIFIER
SELECT @audiometriaId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 2
DECLARE @psicotecnicoId UNIQUEIDENTIFIER
SELECT @psicotecnicoId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 378
DECLARE @oftalmologicoId UNIQUEIDENTIFIER
SELECT @oftalmologicoId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 88
DECLARE @campimetriaId UNIQUEIDENTIFIER
SELECT @campimetriaId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 54
DECLARE @eegId UNIQUEIDENTIFIER
SELECT @eegId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 19
DECLARE @vdrlId UNIQUEIDENTIFIER
SELECT @vdrlId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 28
DECLARE @huddlesonId UNIQUEIDENTIFIER
SELECT @huddlesonId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 27
DECLARE @cocainaId UNIQUEIDENTIFIER
SELECT @cocainaId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 379
DECLARE @opiaceasId UNIQUEIDENTIFIER
SELECT @opiaceasId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 353
DECLARE @marihuanaId UNIQUEIDENTIFIER
SELECT @marihuanaId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 372
DECLARE @anfetaminaId UNIQUEIDENTIFIER
SELECT @anfetaminaId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 391
DECLARE @barbituricoId UNIQUEIDENTIFIER
SELECT @barbituricoId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 434
DECLARE @benzodiId UNIQUEIDENTIFIER
SELECT @benzodiId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 415
DECLARE @trigliId UNIQUEIDENTIFIER
SELECT @trigliId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 50
DECLARE @hdlId UNIQUEIDENTIFIER
SELECT @hdlId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 90
DECLARE @ldlId UNIQUEIDENTIFIER
SELECT @ldlId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 91
DECLARE @colestTotalId UNIQUEIDENTIFIER
SELECT @colestTotalId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 24
DECLARE @uricemialId UNIQUEIDENTIFIER
SELECT @uricemialId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 25
DECLARE @rxToraxFyPId UNIQUEIDENTIFIER
SELECT @rxToraxFyPId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 249
DECLARE @grupoSangId UNIQUEIDENTIFIER
SELECT @grupoSangId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 31
DECLARE @factorRHId UNIQUEIDENTIFIER
SELECT @factorRHId = mp.MedicalPracticeId FROM MedicalPractice mp WHERE mp.PracticeCode = 32


--1	EXAMEN INGRESO MINIMO DE LEY	Examen clinico	ECG	Hemograma	Uremia	Glucemia	Orina Completa	Eritrosedimentación	Rx Torax Frente

DECLARE @minimoLeyId UNIQUEIDENTIFIER
SELECT @minimoLeyId = g.GroupId FROM [Group] g WHERE g.GroupCode = 1

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@minimoLeyId,@clinicalExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@minimoLeyId,@ECGId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@minimoLeyId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@minimoLeyId,@uremiaExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@minimoLeyId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@minimoLeyId,@orinaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@minimoLeyId,@eritroId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@minimoLeyId,@rxToraxFrenteId)


--8	EXAMEN INGRESO COMPLETO  	Examen clinico	ECG	Hemograma	Uremia	Glucemia	Orina Completa	Eritrosedimentación	Rx Torax Frente	Rx. Lumbar F/P	Audiometria

DECLARE @ingresoCompletoId UNIQUEIDENTIFIER
SELECT @ingresoCompletoId = g.GroupId FROM [Group] g WHERE g.GroupCode = 8

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@ingresoCompletoId,@clinicalExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@ingresoCompletoId,@ECGId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@ingresoCompletoId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@ingresoCompletoId,@uremiaExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@ingresoCompletoId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@ingresoCompletoId,@orinaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@ingresoCompletoId,@eritroId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@ingresoCompletoId,@rxToraxFrenteId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@ingresoCompletoId,@rxLumbarFrenteId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@ingresoCompletoId,@rxLumbarPerfilId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@ingresoCompletoId,@audiometriaId)

--11	EXAMEN PERIODICO COMPLETO	Examen clinico	ECG	Hemograma	Uremia	Glucemia	Orina Completa	Eritrosedimentación	Rx Torax Frente	Rx. Lumbar F/P	Audiometria

DECLARE @periodicoCompletoId UNIQUEIDENTIFIER
SELECT @periodicoCompletoId = g.GroupId FROM [Group] g WHERE g.GroupCode = 11

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@periodicoCompletoId,@clinicalExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@periodicoCompletoId,@ECGId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@periodicoCompletoId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@periodicoCompletoId,@uremiaExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@periodicoCompletoId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@periodicoCompletoId,@orinaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@periodicoCompletoId,@eritroId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@periodicoCompletoId,@rxToraxFrenteId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@periodicoCompletoId,@rxLumbarFrenteId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@periodicoCompletoId,@rxLumbarPerfilId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@periodicoCompletoId,@audiometriaId)

--21	CARNET DE CONDUCIR (PAQUETE)	Examen clinico	ECG	Hemograma	Uremia	Glucemia	Psicotécnico c/ Téc.	Exam. Oftalmológico	Campimetría 	E.E.G	Audiometria
DECLARE @carnetConducirId UNIQUEIDENTIFIER
SELECT @carnetConducirId = g.GroupId FROM [Group] g WHERE g.GroupCode = 21

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@carnetConducirId,@clinicalExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@carnetConducirId,@ECGId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@carnetConducirId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@carnetConducirId,@uremiaExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@carnetConducirId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@carnetConducirId,@psicotecnicoId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@carnetConducirId,@oftalmologicoId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@carnetConducirId,@campimetriaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@carnetConducirId,@eegId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@carnetConducirId,@audiometriaId)

--37	EXAMEN EGRESO  COMPLETO	Examen clinico	ECG	Hemograma	Uremia	Glucemia	Orina Completa	Eritrosedimentación	Rx Torax Frente	Rx. Lumbar F/P	Audiometria
DECLARE @egresoCompletoId UNIQUEIDENTIFIER
SELECT @egresoCompletoId = g.GroupId FROM [Group] g WHERE g.GroupCode = 37

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@egresoCompletoId,@clinicalExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@carnetConducirId,@ECGId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@carnetConducirId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@carnetConducirId,@uremiaExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@carnetConducirId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@carnetConducirId,@orinaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@carnetConducirId,@eritroId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@periodicoCompletoId,@rxToraxFrenteId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@periodicoCompletoId,@rxLumbarFrenteId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@periodicoCompletoId,@rxLumbarPerfilId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@periodicoCompletoId,@audiometriaId)

--41	EXAMEN PERIODICO MINIMO DE LEY	Examen clinico	ECG	Hemograma	Uremia	Glucemia	Orina Completa	Eritrosedimentación
DECLARE @periodMinLeyId UNIQUEIDENTIFIER
SELECT @periodMinLeyId = g.GroupId FROM [Group] g WHERE g.GroupCode = 41

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@periodMinLeyId,@clinicalExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@periodMinLeyId,@ECGId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@periodMinLeyId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@periodMinLeyId,@uremiaExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@periodMinLeyId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@periodMinLeyId,@orinaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@periodMinLeyId,@eritroId)

--42	LIBRETA  SANITARIA	Examen clinico	ECG	Hemograma	Uremia	Glucemia	Orina Completa	Eritrosedimentación	Rx Torax Frente	VDRL	Huddleson
DECLARE @libretaSanitId UNIQUEIDENTIFIER
SELECT @libretaSanitId = g.GroupId FROM [Group] g WHERE g.GroupCode = 42

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@libretaSanitId,@clinicalExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@libretaSanitId,@ECGId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@libretaSanitId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@libretaSanitId,@uremiaExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@libretaSanitId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@libretaSanitId,@orinaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@libretaSanitId,@eritroId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@libretaSanitId,@rxToraxFrenteId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@libretaSanitId,@vdrlId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@libretaSanitId,@huddlesonId)

--43	EXAMEN EGRESO MINIMO DE LEY	Examen clinico	ECG	Hemograma	Uremia	Glucemia	Orina Completa	Eritrosedimentación
DECLARE @examEgresoMinLeyId UNIQUEIDENTIFIER
SELECT @examEgresoMinLeyId = g.GroupId FROM [Group] g WHERE g.GroupCode = 43

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgresoMinLeyId,@clinicalExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgresoMinLeyId,@ECGId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgresoMinLeyId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgresoMinLeyId,@uremiaExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgresoMinLeyId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgresoMinLeyId,@orinaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgresoMinLeyId,@eritroId)

--52	EXAMEN PERIODICO MINIMO DE LEY (sin Rx)	Examen clinico	ECG	Hemograma	Uremia	Glucemia	Orina Completa	Eritrosedimentación
DECLARE @examPeriodMinLeyId UNIQUEIDENTIFIER
SELECT @examPeriodMinLeyId = g.GroupId FROM [Group] g WHERE g.GroupCode = 52

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodMinLeyId,@clinicalExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodMinLeyId,@ECGId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodMinLeyId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodMinLeyId,@uremiaExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodMinLeyId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodMinLeyId,@orinaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodMinLeyId,@eritroId)

--119	EXAMEN INGRESO MINIMO DE LEY  (sin Rx)	Examen clinico	ECG	Hemograma	Uremia	Glucemia	Orina Completa	Eritrosedimentación
DECLARE @examIngreMinLeyId UNIQUEIDENTIFIER
SELECT @examIngreMinLeyId = g.GroupId FROM [Group] g WHERE g.GroupCode = 119

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreMinLeyId,@clinicalExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreMinLeyId,@ECGId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreMinLeyId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreMinLeyId,@uremiaExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreMinLeyId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreMinLeyId,@orinaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreMinLeyId,@eritroId)

--209	EXAMEN EGRESO COMPLETO (Sin Rx)	Examen clinico	ECG	Hemograma	Uremia	Glucemia	Orina Completa	Eritrosedimentación			Audiometria
DECLARE @examEgreMinLeyId UNIQUEIDENTIFIER
SELECT @examEgreMinLeyId = g.GroupId FROM [Group] g WHERE g.GroupCode = 209

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgreMinLeyId,@clinicalExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgreMinLeyId,@ECGId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgreMinLeyId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgreMinLeyId,@uremiaExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgreMinLeyId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgreMinLeyId,@orinaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgreMinLeyId,@eritroId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgreMinLeyId,@audiometriaId)

--266	LIBRETA SANITARIA (SIN RX TORAX)	Examen clinico	ECG	Hemograma	Uremia	Glucemia	Orina Completa	Eritrosedimentación		VDRL	Huddleson
DECLARE @libSanitSinRxId UNIQUEIDENTIFIER
SELECT @libSanitSinRxId = g.GroupId FROM [Group] g WHERE g.GroupCode = 266

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@libSanitSinRxId,@clinicalExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@libSanitSinRxId,@ECGId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@libSanitSinRxId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@libSanitSinRxId,@uremiaExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@libSanitSinRxId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@libSanitSinRxId,@orinaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@libSanitSinRxId,@eritroId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@libSanitSinRxId,@vdrlId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@libSanitSinRxId,@huddlesonId)

--305	EXAM. EGRESO MÍN. LEY  (sin Rx)	Examen clinico	ECG	Hemograma	Uremia	Glucemia	Orina Completa	Eritrosedimentación
DECLARE @minLeyRxId UNIQUEIDENTIFIER
SELECT @minLeyRxId = g.GroupId FROM [Group] g WHERE g.GroupCode = 305

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@minLeyRxId,@clinicalExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@minLeyRxId,@ECGId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@minLeyRxId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@minLeyRxId,@uremiaExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@minLeyRxId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@minLeyRxId,@orinaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@minLeyRxId,@eritroId)

--344	EXAMENES PERIODICOS DE TELECOM	Examen clinico	ECG	Hemograma	Uremia	Glucemia	Orina Completa	Eritrosedimentación	Rx Torax Frente
DECLARE @examPerdioTelecomId UNIQUEIDENTIFIER
SELECT @examPerdioTelecomId = g.GroupId FROM [Group] g WHERE g.GroupCode = 344

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPerdioTelecomId,@clinicalExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPerdioTelecomId,@ECGId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPerdioTelecomId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPerdioTelecomId,@uremiaExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPerdioTelecomId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPerdioTelecomId,@orinaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPerdioTelecomId,@eritroId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPerdioTelecomId,@rxToraxFrenteId)

--345	EXÁMENES DE EGRESO TELECOM	Examen clinico		Hemograma	Uremia	Glucemia	Orina Completa	Eritrosedimentación	Rx Torax Frente
DECLARE @examEgresTelecomId UNIQUEIDENTIFIER
SELECT @examEgresTelecomId = g.GroupId FROM [Group] g WHERE g.GroupCode = 345

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgresTelecomId,@clinicalExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgresTelecomId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgresTelecomId,@uremiaExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgresTelecomId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgresTelecomId,@orinaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgresTelecomId,@eritroId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgresTelecomId,@rxToraxFrenteId)

--347	PREOCUPACIONAL DE INGRESO TELECOM	Examen clinico	ECG	Hemograma	Uremia	Glucemia	Orina Completa	Eritrosedimentación	Rx Torax Frente
DECLARE @preocIngresTelecomId UNIQUEIDENTIFIER
SELECT @preocIngresTelecomId = g.GroupId FROM [Group] g WHERE g.GroupCode = 347

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@preocIngresTelecomId,@clinicalExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@preocIngresTelecomId,@ECGId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@preocIngresTelecomId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@preocIngresTelecomId,@uremiaExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@preocIngresTelecomId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@preocIngresTelecomId,@orinaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@preocIngresTelecomId,@eritroId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@preocIngresTelecomId,@rxToraxFrenteId)

--412	PAQUETES DE DROGAS	Cocaína	Opiaces	Marihuana	Anfetaminas	Barbituricos	Benzodiazepinas
DECLARE @paqDrogasId UNIQUEIDENTIFIER
SELECT @paqDrogasId = g.GroupId FROM [Group] g WHERE g.GroupCode = 412

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@paqDrogasId,@cocainaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@paqDrogasId,@opiaceasId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@paqDrogasId,@marihuanaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@paqDrogasId,@anfetaminaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@paqDrogasId,@barbituricoId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@paqDrogasId,@benzodiId)

--419	EX. INGRESO M DE LEY + COL F/P	Examen clinico	ECG	Hemograma	Uremia	Glucemia	Orina Completa	Eritrosedimentación	Rx Torax Frente	Rx. Lumbar F/P
DECLARE @examIngreMinLeyColumId UNIQUEIDENTIFIER
SELECT @examIngreMinLeyColumId = g.GroupId FROM [Group] g WHERE g.GroupCode = 419

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreMinLeyColumId,@clinicalExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreMinLeyColumId,@ECGId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreMinLeyColumId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreMinLeyColumId,@uremiaExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreMinLeyColumId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreMinLeyColumId,@orinaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreMinLeyColumId,@eritroId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreMinLeyColumId,@rxToraxFrenteId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreMinLeyColumId,@rxLumbarFrenteId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreMinLeyColumId,@rxLumbarPerfilId)

--427	ITEM 2 EXAMEN PERIODICO ECOGAS	Examen clinico	ECG	Hemograma	Uremia	Glucemia	Orina Completa	Eritrosedimentación	Rx Torax Frente	Rx. Lumbar F/P	Trigliceridos	HDL	LDL	Colesterol Total 	Uricemia
DECLARE @examPeriodEcogasId UNIQUEIDENTIFIER
SELECT @examPeriodEcogasId = g.GroupId FROM [Group] g WHERE g.GroupCode = 427

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodEcogasId,@clinicalExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodEcogasId,@ECGId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodEcogasId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodEcogasId,@uremiaExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodEcogasId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodEcogasId,@orinaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodEcogasId,@eritroId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodEcogasId,@rxToraxFrenteId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodEcogasId,@rxLumbarFrenteId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodEcogasId,@rxLumbarPerfilId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodEcogasId,@trigliId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodEcogasId,@hdlId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodEcogasId,@ldlId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodEcogasId,@colestTotalId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodEcogasId,@uricemialId)

--678	ITEM 3 EX. EGRESO ECOGAS	Examen clinico	ECG	Hemograma	Uremia	Glucemia	Orina Completa	Eritrosedimentación	Rx Torax F/P	Rx. Lumbar F/P
DECLARE @examEgreEcogasId UNIQUEIDENTIFIER
SELECT @examEgreEcogasId = g.GroupId FROM [Group] g WHERE g.GroupCode = 678

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgreEcogasId,@clinicalExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgreEcogasId,@ECGId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgreEcogasId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgreEcogasId,@uremiaExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgreEcogasId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgreEcogasId,@orinaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgreEcogasId,@eritroId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgreEcogasId,@rxToraxFyPId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgreEcogasId,@rxLumbarFrenteId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examEgreEcogasId,@rxLumbarPerfilId)

--432	ITEM 1 EXÁMEN INGRESO ECOGAS	Examen clinico	ECG	Hemograma	Uremia	Glucemia	Orina Completa	Eritrosedimentación	Rx Torax F/P	VDRL	Grupo Sanguineo	Factor RH
DECLARE @examIngreEcogasId UNIQUEIDENTIFIER
SELECT @examIngreEcogasId = g.GroupId FROM [Group] g WHERE g.GroupCode = 432

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreEcogasId,@clinicalExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreEcogasId,@ECGId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreEcogasId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreEcogasId,@uremiaExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreEcogasId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreEcogasId,@orinaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreEcogasId,@eritroId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreEcogasId,@rxToraxFyPId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreEcogasId,@vdrlId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreEcogasId,@grupoSangId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngreEcogasId,@factorRHId)

--445	ESTUDIO COMPLEMENTARIO 187 	Cocaína
DECLARE @estComple187Id UNIQUEIDENTIFIER
SELECT @estComple187Id = g.GroupId FROM [Group] g WHERE g.GroupCode = 445

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@estComple187Id,@cocainaId)

--446	ESTUDIO COMPLEMENTARIO 188 	Marihuana
DECLARE @estComple188Id UNIQUEIDENTIFIER
SELECT @estComple188Id = g.GroupId FROM [Group] g WHERE g.GroupCode = 445

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@estComple188Id,@marihuanaId)

--447	EXAM. INGRESO COMPLETO (Sin Rx)	Examen clinico	ECG	Hemograma	Uremia	Glucemia	Orina Completa	Eritrosedimentación			Audiometria
DECLARE @exaIngresoSinRxId UNIQUEIDENTIFIER
SELECT @exaIngresoSinRxId = g.GroupId FROM [Group] g WHERE g.GroupCode = 447

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@exaIngresoSinRxId,@clinicalExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@exaIngresoSinRxId,@ECGId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@exaIngresoSinRxId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@exaIngresoSinRxId,@uremiaExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@exaIngresoSinRxId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@exaIngresoSinRxId,@orinaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@exaIngresoSinRxId,@eritroId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@exaIngresoSinRxId,@audiometriaId)

--537	VISADO DE CARNET	Glucemia	ECG	Hemograma	Uremia
DECLARE @visadoCarnetId UNIQUEIDENTIFIER
SELECT @visadoCarnetId = g.GroupId FROM [Group] g WHERE g.GroupCode = 537

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@visadoCarnetId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@visadoCarnetId,@ECGId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@visadoCarnetId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@visadoCarnetId,@uremiaExamId)

--604	EXAM. PERIÓDICO COMPLETO (Sin Rx)	Examen clinico	ECG	Hemograma	Uremia	Glucemia	Orina Completa	Eritrosedimentación			Audiometria
DECLARE @exaPeriodCompleId UNIQUEIDENTIFIER
SELECT @exaPeriodCompleId = g.GroupId FROM [Group] g WHERE g.GroupCode = 604

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@exaPeriodCompleId,@clinicalExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@exaPeriodCompleId,@ECGId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@exaPeriodCompleId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@exaPeriodCompleId,@uremiaExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@exaPeriodCompleId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@exaPeriodCompleId,@orinaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@exaPeriodCompleId,@eritroId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@exaPeriodCompleId,@audiometriaId)

--638	ENFERMEDAD PROLONGADA (COMPLETO)	Examen clinico	ECG	Hemograma	Uremia	Glucemia	Orina Completa	Eritrosedimentación	Rx Torax Frente	Rx. Lumbar F/P
DECLARE @enfermProlongId UNIQUEIDENTIFIER
SELECT @enfermProlongId = g.GroupId FROM [Group] g WHERE g.GroupCode = 638

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@enfermProlongId,@clinicalExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@enfermProlongId,@ECGId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@enfermProlongId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@enfermProlongId,@uremiaExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@enfermProlongId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@enfermProlongId,@orinaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@enfermProlongId,@eritroId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@enfermProlongId,@rxToraxFrenteId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@enfermProlongId,@rxLumbarFrenteId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@enfermProlongId,@rxLumbarPerfilId)

--640	EXAMEN INGRESO COMPLETO CON PLACAS	Examen clinico	ECG	Hemograma	Uremia	Glucemia	Orina Completa	Eritrosedimentación	Rx Torax Frente	Rx. Lumbar F/P	Audiometria
DECLARE @examIngrComplPlacasId UNIQUEIDENTIFIER
SELECT @examIngrComplPlacasId = g.GroupId FROM [Group] g WHERE g.GroupCode = 640

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngrComplPlacasId,@clinicalExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngrComplPlacasId,@ECGId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngrComplPlacasId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngrComplPlacasId,@uremiaExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngrComplPlacasId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngrComplPlacasId,@orinaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngrComplPlacasId,@eritroId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngrComplPlacasId,@rxToraxFrenteId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngrComplPlacasId,@rxLumbarFrenteId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngrComplPlacasId,@rxLumbarPerfilId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examIngrComplPlacasId,@audiometriaId)

--641	EXAMEN BASICO DE LEY CON PLACAS 	Examen clinico	ECG	Hemograma	Uremia	Glucemia	Orina Completa	Eritrosedimentación	Rx Torax Frente
DECLARE @examBasicoPlacasId UNIQUEIDENTIFIER
SELECT @examBasicoPlacasId = g.GroupId FROM [Group] g WHERE g.GroupCode = 641

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examBasicoPlacasId,@clinicalExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examBasicoPlacasId,@ECGId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examBasicoPlacasId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examBasicoPlacasId,@uremiaExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examBasicoPlacasId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examBasicoPlacasId,@orinaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examBasicoPlacasId,@eritroId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examBasicoPlacasId,@rxToraxFrenteId)

--646	EXAMEN PERIODICO COMPLETO CON PLACAS	Examen clinico	ECG	Hemograma	Uremia	Glucemia	Orina Completa	Eritrosedimentación	Rx Torax Frente	Rx. Lumbar F/P	Audiometria
DECLARE @examPeriodComplPlacasId UNIQUEIDENTIFIER
SELECT @examPeriodComplPlacasId = g.GroupId FROM [Group] g WHERE g.GroupCode = 646

INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodComplPlacasId,@clinicalExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodComplPlacasId,@ECGId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodComplPlacasId,@hemogramaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodComplPlacasId,@uremiaExamId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodComplPlacasId,@glucemiaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodComplPlacasId,@orinaId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodComplPlacasId,@eritroId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodComplPlacasId,@rxToraxFrenteId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodComplPlacasId,@rxLumbarFrenteId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodComplPlacasId,@rxLumbarPerfilId)
INSERT INTO GroupMedicalPractice (GroupMedicalPracticeId,GroupId,MedicalPracticeId) VALUES (NEWID(),@examPeriodComplPlacasId,@audiometriaId)
GO

