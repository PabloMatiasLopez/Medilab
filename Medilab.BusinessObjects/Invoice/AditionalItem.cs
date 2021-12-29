using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.ListOfPrice;
using Medilab.BusinessObjects.Properties;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Medilab.BusinessObjects.Invoice
{
    public class AditionalItem
    {
        #region Properties
        public Guid Id { private set; get; }
        public int Code { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public double Price { set; get; }
        #endregion

        #region Methods
        private AditionalItem()
        {
        }
        public AditionalItem(Guid itemId)
        {
            Id = itemId;
        }
        public static AditionalItem GetAditionalItem(Guid itemId)
        {
            using (var context = new MedilabEntities())
            {
                var item = (from i in context.AditionalItem where i.AditionaltemId == itemId && !i.IsDeleted select 
                                new {
                                    i.Code,
                                    i.Name,
                                    i.Description,
                                    Price = (from p in context.PracticeGroupPrice where p.PracticeGroupId == itemId select p.Price).FirstOrDefault()
                                }).FirstOrDefault();
                if (item == null)
                {
                    throw new Exception(BOResources.RecordNotFoudExeptionMessage);
                }
                return new AditionalItem
                {
                    Id = itemId,
                    Code = item.Code,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price
                };
            }
        }
        public AditionalItem Save()
        {
            try
            {
                return Id == Guid.Empty ? Insert() : Update();
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException as SqlException;
                if (innerException != null)
                {
                    var errorCode = (innerException).ErrorCode;
                    if (errorCode == -2146232060)
                    {
                        throw new Exception("El código ya existe");
                    }
                }
                throw;
            }
        }

        private AditionalItem Update()
        {
            using (var context = new MedilabEntities())
            {
                    var item = (from i in context.AditionalItem where i.AditionaltemId == Id select i).First();
                    item.Name = Name;
                    item.Description = Description;
                    item.Code = Code;
                    var modifiedFields = Utilities.GetModifiedFields(context, item.ToString());
                    Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.AditionalItem,
                                         AuditOperations.Update, Id, modifiedFields);
                //Update price
                var practicePrice =
                    (from p in context.PracticeGroupPrice where p.PracticeGroupId == Id select p).FirstOrDefault();
                if (practicePrice == null)
                {
                    PracticePrice.InsertPrice(context, new PracticeGroupPriceDto
                    {
                        PracticeGroupId = Id,
                        Price = Price
                    });
                }
                else
                {
                    var priceModifiedFields = Utilities.GetModifiedFields(context, practicePrice.ToString());
                    practicePrice.Price = Price;
                    Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.PracticeGroupPrice, AuditOperations.Update, Id, priceModifiedFields);
                }
                context.SaveChanges();
                return this;
            }
        }

        private AditionalItem Insert()
        {
            using (var context = new MedilabEntities())
            {
                var item = new DataAccess.AditionalItem
                {
                    AditionaltemId = Id = Guid.NewGuid(),
                    Code = Code,
                    Name = Name,
                    Description = Description,
                    IsDeleted = false
                };
                context.AddToAditionalItem(item);
                //Save Price
                PracticePrice.InsertPrice(context, new PracticeGroupPriceDto
                {
                    PracticeGroupId = Id,
                    Price = Price
                });
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.AditionalItem,
                                        AuditOperations.Insert, Id, Code.ToString());
                context.SaveChanges();
                return this;
            }
        }
        public static IEnumerable<AditionalItem> GetAllAditionalItems()
        {
            using (var context = new MedilabEntities())
            {
                return (from item in context.AditionalItem
                             where !item.IsDeleted
                             orderby item.Code
                             select new Invoice.AditionalItem
                             {
                                 Id = item.AditionaltemId,
                                 Code = item.Code,
                                 Name = item.Name,
                                 Description = item.Description
                             }).ToList();
            }
        }
        public void Delete()
        {
            using (var context = new MedilabEntities())
            {
                var item = (from i in context.AditionalItem where i.AditionaltemId == Id select i).First();
                item.IsDeleted = true;
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.AditionalItem,
                                        AuditOperations.Delete, Id, Code.ToString());
                context.SaveChanges();
            }
        }

        public static IEnumerable<AditionalItem> SearchAdditionalItems(string criteria)
        {
            using (var context = new MedilabEntities())
            {
                var medicalPractices = (from ai in context.AditionalItem
                                        where !ai.IsDeleted &&
                                        (ai.Name.Contains(criteria) || ai.Description.Contains(criteria))
                                        orderby ai.Name
                                        select new
                                        {
                                            ai.AditionaltemId,
                                            ai.Code,
                                            ai.Name,
                                            ai.Description
                                        }
                                       ).ToList();

                return medicalPractices.Select(item => new AditionalItem
                {
                    Id = item.AditionaltemId,
                    Code = item.Code,
                    Name = item.Name,
                    Description = item.Description
                }).ToList();
            }
        }
        #endregion
    }
}
