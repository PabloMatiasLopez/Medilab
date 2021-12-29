using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Medilab.BusinessObjects.Properties;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;

namespace Medilab.BusinessObjects.Configuration
{
    public class Speciality : IConcurrence
    {
        #region Properties

        public Guid Id { private set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public byte[] LastUpdated { get; set; }
        public string DisplayName { set; get; }

        #endregion

        #region Methods

        private Speciality()
        {
        }

        public Speciality(Guid id)
        {
            Id = id;
        }

        public Speciality Save()
        {
            if (Id == Constants.NoSpecialityId || Id == Constants.ClinicId) return null;
            return Id == Guid.Empty ? Insert() : Update();
        }

        private Speciality Update()
        {
            using (var context = new MedilabEntities())
            {
                var speciality = (from s in context.Speciality where s.SpecialityId == Id select s).First();
                if (Tools.IsRecordChanged(speciality.LastUpdated, LastUpdated))
                {
                    throw new OptimisticConcurrencyException(BOResources.RecordUpdated);
                }
                speciality.SpecialityName = Name;
                speciality.SpecialityDescription = Description;
                speciality.SpecialityDisplayName = DisplayName;

                var modifiedFields = Utilities.GetModifiedFields(context, speciality.ToString());
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.Speciality, AuditOperations.Update,
                                     Id, modifiedFields);
                context.SaveChanges();
                return this;
            }
        }

        private Speciality Insert()
        {
            using (var context = new MedilabEntities())
            {
                var speciality = new DataAccess.Speciality
                                     {
                                         SpecialityId = Id = Guid.NewGuid(),
                                         SpecialityName = Name,
                                         SpecialityDescription = Description,
                                         IsDeleted = false,
                                         SpecialityDisplayName = DisplayName
                                     };
                context.AddToSpeciality(speciality);
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.Speciality, AuditOperations.Insert,
                                     Id, speciality.SpecialityName);
                context.SaveChanges();
                return this;
            }
        }

        public void Delete()
        {
            if (Id == Constants.NoSpecialityId || Id == Constants.ClinicId) return;
            using (var context = new MedilabEntities())
            {
                var speciality = (from s in context.Speciality where s.SpecialityId == Id select s).First();
                speciality.IsDeleted = true;
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.Speciality, AuditOperations.Delete,
                                     Id, speciality.SpecialityName);
                context.SaveChanges();
            }
        }

        public static Speciality GetSpeciality(Guid id)
        {
            using (var context = new MedilabEntities())
            {
                return GetSpeciality(id, context);
            }
        }

        internal static Speciality GetSpeciality(Guid id, MedilabEntities context)
        {
            var speciality = (from s in context.Speciality
                              where !s.IsDeleted && s.SpecialityId == id
                              select new Speciality
                                         {
                                             Id = s.SpecialityId,
                                             Name = s.SpecialityName,
                                             Description = s.SpecialityDescription,
                                             LastUpdated = s.LastUpdated,
                                             DisplayName = s.SpecialityDisplayName
                                         }).FirstOrDefault();
            if (speciality != null)
            {
                return speciality;
            }
            throw new Exception(BOResources.RecordNotFoudExeptionMessage);
        }

        public static IEnumerable<Speciality> GetList()
        {
            using (var context = new MedilabEntities())
            {
                var specialities =
                    (from s in context.Speciality where !s.IsDeleted orderby s.SpecialityName select s).ToList();
                return specialities.Select(role => new Speciality
                                                       {
                                                           Id = role.SpecialityId,
                                                           Name = role.SpecialityName,
                                                           Description = role.SpecialityDescription
                                                       }).ToList();
            }
        }

        #endregion
    }
}
