using System;
using System.Collections.Generic;
using System.Linq;
using Medilab.DataAccess;

namespace Medilab.BusinessObjects.Invoice
{
    public class InvoiceProcess
    {
        public List<InvoiceDetails> GetPendigItemsByClient(Guid clientId, Guid areaId)
        {
            using (var context = new MedilabEntities())
            {
                const int completedItemStatus = (int)Utils.ClinicalExamStatus.Realizada;
                var pendingItems = (from item in context.MedicalHistoryPractice
                                    where item.MedicalHistory.ChargeToClientId == clientId &&
                                          (areaId == Guid.Empty || item.MedicalHistory.ClientArea.ClientAreaId == areaId) &&
                                          item.Status >= completedItemStatus &&
                                          item.InvoiceId == null
                                          orderby item.MedicalHistory.PatiendId, item.GroupId
                                    select new InvoiceDetails
                                    {
                                        ItemId = item.MedicalPracticeId,
                                        Code = item.MedicalPractice.PracticeCode,
                                        Description = item.MedicalPractice.PracticeDescription,
                                        GroupId = item.GroupId,
                                        PatientId = item.MedicalHistory.PatiendId,
                                        PatientFirstName = item.MedicalHistory.Patient.FirstName,
                                        PatientLastName = item.MedicalHistory.Patient.LastName,
                                        PatientDocumentNumber = item.MedicalHistory.Patient.DocumentNumber,
                                        Selected = true,
                                        Quantity = 1,
                                        MedicalHistoryId = item.MedicalHistoryId,
                                        ExamTypeId = item.MedicalHistory.ExamTypeId,
                                        Date = item.MedicalHistory.CreatedDate
                                    } ).ToList();
                if (pendingItems.Count > 0)
                {
                    pendingItems = GetGroupItems(pendingItems);
                }
                return pendingItems;
            }
        }

        public List<InvoiceDetails> GetGroupItems(List<InvoiceDetails> itemList)
        {
            var groupedItems = new List<InvoiceDetails>();
            var lastGroupId = Guid.Empty;
            var groupIds = (from g in itemList where g.GroupId != Guid.Empty && g.GroupId != null select g.GroupId).ToList();
            if (groupIds.Count() == 1)
            {
                var groupId = groupIds[0];
                if (groupId != null)
                {
                    ClinicalHistory.Group group = ClinicalHistory.Group.GetGroup(groupId.Value);
                    InvoiceDetails itemGroup = itemList.First(i => i.GroupId == groupId);
                    groupedItems.Add(new InvoiceDetails
                                         {
                                             Code = @group.Code,
                                             Description = @group.Description,
                                             GroupId = @group.Id,
                                             ItemId = @group.Id,
                                             PatientId = itemGroup.PatientId,
                                             PatientFirstName = itemGroup.PatientFirstName,
                                             PatientLastName = itemGroup.PatientLastName,
                                             PatientDocumentNumber = itemGroup.PatientDocumentNumber,
                                             MedicalHistoryId = itemGroup.MedicalHistoryId,
                                             Selected = true,
                                             Quantity = 1,
                                             ExamTypeId = itemGroup.ExamTypeId,
                                             Date = itemGroup.Date
                                         });
                }

                groupedItems.AddRange(itemList.Where(i => i.GroupId == null || i.GroupId == Guid.Empty));
            }
            else
            {
                var patientId = itemList[0].PatientId;
                foreach (var item in itemList)
                {
                    if (patientId != item.PatientId)
                    {
                        patientId = item.PatientId;
                        lastGroupId = Guid.Empty;
                    }
                    var itemGroupId = item.GroupId.HasValue ? item.GroupId.Value : Guid.Empty;
                    if (itemGroupId == Guid.Empty)
                    {
                        groupedItems.Add(item);
                        lastGroupId = itemGroupId;
                    }
                    else if (lastGroupId != itemGroupId)
                    {
                        var group = ClinicalHistory.Group.GetGroup(itemGroupId);
                        groupedItems.Add(new InvoiceDetails
                                             {
                                                 Code = group.Code,
                                                 Description = group.Description,
                                                 GroupId = group.Id,
                                                 ItemId = group.Id,
                                                 PatientId = item.PatientId,
                                                 PatientFirstName = item.PatientFirstName,
                                                 PatientLastName = item.PatientLastName,
                                                 PatientDocumentNumber = item.PatientDocumentNumber,
                                                 Selected = item.Selected,
                                                 Quantity = item.Quantity,
                                                 MedicalHistoryId = item.MedicalHistoryId,
                                                 ExamTypeId = item.ExamTypeId,
                                                 Date = item.Date
                                             });
                        lastGroupId = itemGroupId;
                    }
                }
            }
            return groupedItems;
        }
    }
}
