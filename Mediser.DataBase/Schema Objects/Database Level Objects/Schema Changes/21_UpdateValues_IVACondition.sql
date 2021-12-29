update IvaCondition set IvaConditionDescription = 'IVA_Responsable_Inscripto' where IvaConditionId = 1
GO
update IvaCondition set IvaConditionDescription = 'IVA_No_Responsable' where IvaConditionId = 2
GO
update IvaCondition set IvaConditionDescription = 'IVA_No_Responsable' where IvaConditionId = 3
GO
insert into IvaCondition values (4,'IVA_Sujeto_Exento',0)
insert into IvaCondition values (5,'Consumidor_Final',0)
insert into IvaCondition values (6,'Responsable_Monotributo',0)
insert into IvaCondition values (7,'Sujeto_No_Categorizado',0)
insert into IvaCondition values (8,'Proveedor_del_Exterior',0)
insert into IvaCondition values (9,'Cliente_del_Exterior',0)
insert into IvaCondition values (10,'IVA_Liberado_Ley_19640',0)
insert into IvaCondition values (11,'IVA_Responsable_Inscripto_Agente_de_Percepcion',0)
insert into IvaCondition values (12,'Pequeño_Contribuyente_Eventual',0)
insert into IvaCondition values (13,'Monotributista_Social',0)
insert into IvaCondition values (14,'Pequeño_Contribuyente_Eventual_Social',0)
GO
