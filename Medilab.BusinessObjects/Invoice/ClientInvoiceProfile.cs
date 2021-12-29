using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.Properties;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Medilab.BusinessObjects.Invoice
{
    public class ClientInvoiceProfile
    {
        #region Properties
        public Guid Id { private set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public IEnumerable<FiscalRetention> Retentions { set; get; }
        public byte[] LastUpdated { get; set; }
        public Guid LastUpdatedUser { set; get; }
        public bool IsDefault { set; get; }
        #endregion

        #region Methods
        private ClientInvoiceProfile() { }
        public ClientInvoiceProfile(Guid invoiceProfileId)
        {
            Id = invoiceProfileId;
        }
        public static ClientInvoiceProfile GetInviceProfile(Guid invoiceProfileId)
        {
            using (var context = new MedilabEntities())
            {
                var profile = (from p in context.InvoiceProfile
                             where p.InvoiceProfileId == invoiceProfileId
                             select new 
                             {
                                 Id = p.InvoiceProfileId,
                                 Name = p.Name,
                                 Description = p.Description,
                                 LastUpdated = p.LastUpdated,
                                 IsDefault = p.IsDefault,
                                 Retentions =
                                     (from r in p.InvoiceProfileRetention
                                      select
                                          new 
                                          {
                                              Id = r.FiscalRetention.FiscalRetentionId,
                                              Name = r.FiscalRetention.Name,
                                              Description = r.FiscalRetention.Description,
                                              Value = r.FiscalRetention.Value,
                                              IsIVA = r.FiscalRetention.IsIVA,
                                              CAECode = r.FiscalRetention.CAECode
                                          })
                             }).FirstOrDefault();

                if (profile != null)
                {
                    var retentions = (from p in profile.Retentions
                                      select new FiscalRetention(p.Id)
                                      {
                                          Name = p.Name,
                                          Description = p.Description,
                                          Value = p.Value,
                                          IsIVA = p.IsIVA,
                                          CAECode = p.CAECode
                                      }).ToList();
                    return new ClientInvoiceProfile
                    {
                        Id = profile.Id,
                        Name = profile.Name,
                        Description = profile.Description,
                        Retentions = retentions,
                        IsDefault = profile.IsDefault,
                        LastUpdated = profile.LastUpdated
                    };
                }
                throw new Exception(BOResources.RecordNotFoudExeptionMessage);
            }
        }
        public ClientInvoiceProfile Save()
        {
            return Id == Guid.Empty ? Insert() : Update();
        }
        private ClientInvoiceProfile Update()
        {
            using (var context = new MedilabEntities())
            {
                var profile = (from r in context.InvoiceProfile where r.InvoiceProfileId == Id select r).First();
                if (Tools.IsRecordChanged(profile.LastUpdated, LastUpdated))
                {
                    throw new OptimisticConcurrencyException(
                        "El registro fue modificado, por favor vuelva a aplicar sus cambios.");
                }
                profile.Name = Name;
                profile.Description = Description;
                profile.IsDefault = IsDefault;
                LastUpdatedUser = Security.GetCurrentUser();
                //update retentions
                ProfileFiscalRetention.RemoveMedicalPractices(context, Id);
                SaveRetentions(context);
                var modifiedFields = Utilities.GetModifiedFields(context, profile.ToString());
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.InvoiceProfile, AuditOperations.Update, Id, modifiedFields);
                if (IsDefault)
                {
                    SetDefaultProfile(context);
                }
                context.SaveChanges();
                return this;
            }
        }
        private ClientInvoiceProfile Insert()
        {
            using (var context = new MedilabEntities())
            {
                var profile = new DataAccess.InvoiceProfile
                {
                    InvoiceProfileId = Id = Guid.NewGuid(),
                    Name = Name,
                    Description = Description,
                    LastUpdateUser = Security.GetCurrentUser(),
                    IsDefault = IsDefault
                };
                SaveRetentions(context);
                context.AddToInvoiceProfile(profile);
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.InvoiceProfile, AuditOperations.Insert, Id,
                                     profile.Name);
                if (IsDefault)
                {
                    SetDefaultProfile(context);
                }
                context.SaveChanges();
                return this;
            }
        }
        private void SaveRetentions(MedilabEntities context)
        {
            foreach (var retention in Retentions)
            {
                var profileRetention = new ProfileFiscalRetention { ProfileId = Id, RetentionId = retention.Id };
                profileRetention.Save(context);
            }
        }
        public static IEnumerable<ClientInvoiceProfile> GetAllInvoiceProfile()
        {
            using (var context = new MedilabEntities())
            {
                var profileList = new List<ClientInvoiceProfile>();
                var profiles = (from p in context.InvoiceProfile where !p.IsDeleted orderby p.Name select p);
                foreach (var profile in profiles)
                {
                    profileList.Add(new ClientInvoiceProfile(profile.InvoiceProfileId)
                        {
                            Name = profile.Name,
                            Description = profile.Description,
                            IsDefault = profile.IsDefault
                        });
                }
                return profileList;
            }
        }
        private void SetDefaultProfile(MedilabEntities context)
        {
            var profileList = (from p in context.InvoiceProfile where !p.IsDeleted select p).ToList();
            foreach (var profile in profileList)
            {
                if(profile.InvoiceProfileId != Id)
                {
                    profile.IsDefault = false;
                }
            }
        }
        public void Delete()
        {
            using (var context = new MedilabEntities())
            {
                var profile = (from p in context.InvoiceProfile where p.InvoiceProfileId == Id select p).First();
                profile.IsDeleted = true;
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.InvoiceProfile, AuditOperations.Delete, Id,
                                     profile.Name);
                context.SaveChanges();
            }
        }
        public static ClientInvoiceProfile GetDefaultProfile()
        {
            using (var context = new MedilabEntities())
            {
                var profile = (from p in context.InvoiceProfile where !p.IsDeleted && p.IsDefault
                               select new
                               {
                                   Id = p.InvoiceProfileId,
                                   Name = p.Name,
                                   Description = p.Description,
                                   LastUpdated = p.LastUpdated,
                                   IsDefault = p.IsDefault,
                                   Retentions =
                                       (from r in p.InvoiceProfileRetention
                                        select
                                            new
                                            {
                                                Id = r.FiscalRetention.FiscalRetentionId,
                                                Name = r.FiscalRetention.Name,
                                                Description = r.FiscalRetention.Description,
                                                Value = r.FiscalRetention.Value,
                                                IsIVA = r.FiscalRetention.IsIVA,
                                                CAECode = r.FiscalRetention.CAECode
                                            })
                               }).FirstOrDefault();

                if (profile != null)
                {
                    var retentions = (from p in profile.Retentions
                                      select new FiscalRetention(p.Id)
                                      {
                                          Name = p.Name,
                                          Description = p.Description,
                                          Value = p.Value,
                                          IsIVA = p.IsIVA,
                                          CAECode = p.CAECode
                                      }).ToList();
                    return new ClientInvoiceProfile
                    {
                        Id = profile.Id,
                        Name = profile.Name,
                        Description = profile.Description,
                        Retentions = retentions,
                        IsDefault = profile.IsDefault,
                        LastUpdated = profile.LastUpdated
                    };
                }
                throw new Exception(BOResources.RecordNotFoudExeptionMessage);
            }
        }
        #endregion
    }
}
