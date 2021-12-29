using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.Properties;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using AddressType = Medilab.BusinessObjects.Utils.AddressType;
using State = Medilab.BusinessObjects.Configuration.State;

namespace Medilab.BusinessObjects.Address
{
    public class Address
    {
        #region Properties
        public Guid Id { get; set; }
        public Guid Owner { set; get; }
        public AddressType Type { set; get; }
        public string StreetLineOne { set; get; }
        public string Number { set; get; }
        public string City { set; get; }
        public string OtherInformation { set; get; }
        public State AddressState { set; get; }
        public byte[] LastUpdated { get; set; }
        public bool IsDefault { set; get; }
        public DateTime? ArchiveDate { set; get; }
        public bool Modified { set; get; }

        #endregion

        #region Methods
        public Address()
        {
            
        }
        public Address(Guid id)
        {
            Id = id;
        }
        public Address Save()
        {
            return Id == Guid.Empty ? Insert() : Update();
        }

        private Address Insert()
        {
            using (var context = new MedilabEntities())
            {
                Save(context);
                context.SaveChanges();
                return this;
            }
        }

        internal void Save(MedilabEntities context)
        {
            var typeId = (int) Type;
            var address = new DataAccess.Address
                              {
                                  AddressId = Id = Guid.NewGuid(),
                                  AddressOwner = Owner,
                                  AddressType =
                                      (from at in context.AddressType where at.AddressTypeId == typeId select at).First(),
                                  Street = StreetLineOne,
                                  Number = Number ?? string.Empty,
                                  City = City ?? string.Empty,
                                  OtherInformation = OtherInformation ?? string.Empty,
                                  State = (from s in context.State where s.StateId == AddressState.Id select s).First()
                              };
            if (IsDefault)
            {
                address.IsDefault = IsDefault;
                SetDefaultAddress(context);
            }
            context.AddToAddress(address);
            Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.Address, AuditOperations.Insert,
                                     address.AddressId, address.AddressType.AddressTypeName);
        }

        private Address Update()
        {
            using (var context = new MedilabEntities())
            {
                var address = (from p in context.Address where p.AddressId == Id select p).First();
                var addressTypeId = (int)Type;
                address.AddressType =
                    (from at in context.AddressType where at.AddressTypeId == addressTypeId select at).First();
                address.State = (from s in context.State where s.StateId == AddressState.Id select s).First();
                address.Street = StreetLineOne;
                address.Number = Number ?? string.Empty;
                address.City = City ?? string.Empty;
                address.OtherInformation = OtherInformation ?? string.Empty;
                if (IsDefault)
                {
                    address.IsDefault = IsDefault;
                    SetDefaultAddress(context);
                }
                var modifiedFields = Utilities.GetModifiedFields(context, address.ToString());
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.Address, AuditOperations.Update, Id, modifiedFields);

                context.SaveChanges();
                return this;
            }
        }

        public void Delete()
        {
            using (var context = new MedilabEntities())
            {
                var address = (from p in context.Address where p.AddressId == Id select p).First();
                 if (Tools.IsRecordChanged(address.LastUpdated, LastUpdated))
                {
                    throw new OptimisticConcurrencyException(
                        "El registro fue modificado, por favor vuelva a aplicar sus cambios.");
                }
                address.IsDeleted = true;
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.Address, AuditOperations.Delete, Id, address.AddressType.AddressTypeName);
                context.SaveChanges();
            }
        }

        public void Archive()
        {
            using (var context = new MedilabEntities())
            {
                var address = (from p in context.Address where p.AddressId == Id select p).First();
                if (Tools.IsRecordChanged(address.LastUpdated, LastUpdated))
                {
                    throw new OptimisticConcurrencyException(BOResources.RecordUpdated);
                }
                address.ArchiveDate = DateTime.Today;
                var modifiedFields = Utilities.GetModifiedFields(context, address.ToString());
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.Address, AuditOperations.Update, Id, modifiedFields);
                context.SaveChanges();
            }
        }

        public static Address GetAddress(Guid id)
        {
            using (var context = new MedilabEntities())
            {
                var address = (from a in context.Address
                               where !a.IsDeleted && a.AddressId == id
                               select
                                   new Address
                                   {
                                       Id = a.AddressId,
                                       Type = (AddressType)a.AddressTypeId,
                                       Owner = a.AddressOwner,
                                       StreetLineOne = a.Street,
                                       Number = a.Number,
                                       City = a.City,
                                       OtherInformation = a.OtherInformation,
                                       AddressState = new State { Id = a.State.StateId, Name = a.State.StateName },
                                       LastUpdated = a.LastUpdated,
                                       IsDefault = a.IsDefault
                                   }).FirstOrDefault();
                if (address != null)
                {
                    return address;
                }
            }
            throw new Exception(BOResources.RecordNotFoudExeptionMessage);
        }

        public static void DeleteAddress(Guid owner, AddressType type, Guid user)
        {
            using (var context = new MedilabEntities())
            {
                var addressTypeId = (int) type;
                var address = (from p in context.Address where p.AddressType.AddressTypeId == addressTypeId && p.AddressOwner == owner select p).FirstOrDefault();
                if(address != null)
                {
                    address.IsDeleted = true;
                    Audit.Audit.LogAudit(context, user, ObjectTypes.Address, AuditOperations.Delete, address.AddressId, address.AddressType.AddressTypeName);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Make this address as default and mark all other as not default
        /// </summary>
        private void SetDefaultAddress(MedilabEntities context)
        {
            var otherAddress =
                (from ad in context.Address where ad.AddressOwner == Owner && ad.AddressId != Id select ad).ToList();
            foreach (var address in otherAddress)
            {
                address.IsDefault = false;
            }
        }

        /// <summary>
        /// Get all adresses for a given owner
        /// </summary>
        /// <param name="ownerId">Owner Id</param>
        /// <returns>List of Address</returns>
        public static IEnumerable<Address> GetAddressesByOwner(Guid ownerId)
        {
            using (var context = new MedilabEntities())
            {
                var clientAddresses =
                    (from ad in context.Address
                     where ad.AddressOwner == ownerId &&
                     ad.ArchiveDate == null
                     orderby ad.IsDefault
                     select new
                                {
                                    ad.AddressId,
                                    ad.State.StateId,
                                    ad.State.StateName,
                                    ad.Street,
                                    ad.Number,
                                    ad.City,
                                    ad.OtherInformation,
                                    ad.IsDefault,
                                    ad.LastUpdated,
                                    ad.AddressOwner,
                                    ad.AddressTypeId
                                }).ToList();
                var addressList = new List<Address>();
                foreach (var address in clientAddresses)
                {
                    addressList.Add(new Address(address.AddressId)
                                        {
                                            AddressState = new State
                                                               {
                                                                   Id = address.StateId,
                                                                   Name = address.StateName
                                                               },
                                            IsDefault = address.IsDefault,
                                            LastUpdated = address.LastUpdated,
                                            Owner = address.AddressOwner,
                                            StreetLineOne = address.Street,
                                            Number = address.Number,
                                            City = address.City,
                                            OtherInformation = address.OtherInformation,
                                            Type =
                                                (AddressType)
                                                Enum.Parse(typeof (AddressType), address.AddressTypeId.ToString(CultureInfo.InvariantCulture))
                                        });
                }
                return addressList;
            }
        }

        internal static IEnumerable<Address> GetAddresses(IEnumerable<DataAccess.Address> databaseAddressCollection)
        {
            var addressList = new List<Address>();
            foreach (var address in databaseAddressCollection)
            {
                if(address.ArchiveDate == null) continue;
                addressList.Add(new Address(address.AddressId)
                {
                    AddressState = new State
                    {
                        Id = address.StateId,
                        Name = address.State.StateName
                    },
                    IsDefault = address.IsDefault,
                    LastUpdated = address.LastUpdated,
                    Owner = address.AddressOwner,
                    StreetLineOne = address.Street,
                    Number = address.Number,
                    City = address.City,
                    OtherInformation = address.OtherInformation,
                    Type =
                        (AddressType)
                        Enum.Parse(typeof(AddressType), address.AddressTypeId.ToString(CultureInfo.InvariantCulture))
                });
            }
            return addressList;
        }

        public static IEnumerable<ArchiveAddressDto> GetArchiveAddressesByOwner(Guid ownerId)
        {
            using (var context = new MedilabEntities())
            {
                var clientAddresses =
                    (from ad in context.Address
                     where ad.AddressOwner == ownerId &&
                     ad.ArchiveDate != null
                     orderby ad.ArchiveDate
                     select new
                     {
                         ad.State.StateName,
                         ad.Street,
                         ad.Number,
                         ad.City,
                         ad.OtherInformation,
                         ad.AddressTypeId,
                         ad.ArchiveDate
                     }).ToList();
                var addressList = new List<ArchiveAddressDto>();
                foreach (var address in clientAddresses)
                {
                    addressList.Add(new ArchiveAddressDto
                    {
                        StateName = address.StateName,
                        StreetLineOne = address.Street,
                        Number = address.Number,
                        City = address.City,
                        OtherInformation = address.OtherInformation,
                        AddressType = ((AddressType) Enum.Parse(typeof(AddressType), address.AddressTypeId.ToString(CultureInfo.InvariantCulture))).ToString(),
                        ArchiveDate = address.ArchiveDate.Value.ToShortDateString()
                    });
                }
                return addressList;
            }
        }
        public override string ToString()
        {
            return string.Format("{0} {1}, {2}", StreetLineOne, Number, AddressState.Name);
        }
        #endregion
    }
}
