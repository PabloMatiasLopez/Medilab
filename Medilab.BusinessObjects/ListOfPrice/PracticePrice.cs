using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;

namespace Medilab.BusinessObjects.ListOfPrice
{
    public class PracticePrice
    {
        public static void InsertPrice(MedilabEntities context, PracticeGroupPriceDto praticeGroupPrice)
        {
            var practicePrice = new PracticeGroupPrice
            {
                PriceId = Guid.NewGuid(),
                PracticeGroupId = praticeGroupPrice.PracticeGroupId,
                Price = praticeGroupPrice.Price,
                Client = null
            };
            context.AddToPracticeGroupPrice(practicePrice);
            Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.PracticeGroupPrice, AuditOperations.Insert,
                                 practicePrice.PriceId, practicePrice.Price.ToString(CultureInfo.InvariantCulture));
        }

        public static IEnumerable<PriceListItemDto> GetList()
        {
            using (var context = new MedilabEntities())
            {
                var practices = (from p in context.MedicalPractice
                                 where !p.IsDeleted
                                 select new
                                            {
                                                Id = p.MedicalPracticeId,
                                                Name = p.PracticeName,
                                                Code = p.PracticeCode
                                            }).Concat(from g in context.Group
                                                      select new
                                                                 {
                                                                     Id = g.GroupId,
                                                                     Name = g.GroupName,
                                                                     Code = g.GroupCode
                                                                 }).Concat(from i in context.AditionalItem
                                                                           where !i.IsDeleted
                                                                           select new
                                                                           {
                                                                               Id = i.AditionaltemId,
                                                                               i.Name,
                                                                               i.Code
                                                                           });

                var priceList = (from pr in practices
                                 join pl in context.PracticeGroupPrice on pr.Id equals pl.PracticeGroupId into p
                                 from pl in p.DefaultIfEmpty()
                                 select
                                     new PriceListItemDto
                                         {
                                             Id = pr.Id,
                                             Price = pl.Price,
                                             Code = pr.Code,
                                             Name = pr.Name
                                         }).ToList();
                    return priceList;
            }
        }
    }
}
