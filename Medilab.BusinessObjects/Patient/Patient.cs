using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.Properties;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using CivilState = Medilab.BusinessObjects.Utils.CivilState;
using DocumentType = Medilab.BusinessObjects.Utils.DocumentType;
using Gender = Medilab.BusinessObjects.Utils.Gender;
using PrivateMedicineCompany = Medilab.BusinessObjects.Configuration.PrivateMedicineCompany;
using State = Medilab.BusinessObjects.Configuration.State;
using WorkRiskInsurance = Medilab.BusinessObjects.Configuration.WorkRiskInsurance;

namespace Medilab.BusinessObjects.Patient
{
    public class Patient
    {
        #region Properties

        public Guid Id { private set; get; }
        public DocumentType DocumentType { set; get; }
        public string DocumentNumber { set; get; }
        public string LastName { set; get; }
        public string FirstName { set; get; }
        public DateTime BirthDay { set; get; }
        public State BirthPlace { set; get; }
        public Gender Gender { set; get; }
        public int ChildrenNumber { set; get; }
        public CivilState CivilState { set; get; }
        public Instruction InstructionLevel { set; get; }
        public string InstructionTitle { set; get; }
        public string HomePhone { set; get; }
        public string CellPhone { set; get; }
        public byte[] LastUpdated { get; set; }
        public string Observations { set; get; }
        public IEnumerable<Address.Address> Addresses { set; get; }
        public PrivateMedicineCompany PrivateMedicine { set; get; }
        public string AffiliateNumber { set; get; }
        public WorkRiskInsurance RiskInsurance { set; get; }
        public string Photo { set; get; }
        public string Nationality { set; get; }
        public string FullName
        {
            get { return String.Format("{0}, {1}", LastName, FirstName); }
        }

        #endregion

        #region Methods

        public Patient()
        {

        }

        public Patient(Guid id)
        {
            Id = id;
        }

        public Patient Save()
        {
            if (IsValid())
            {
                return Id == Guid.Empty ? Insert() : Update();
            }
            throw new Exception(BOResources.InvalidObject);
        }

        private Patient Insert()
        {
            var documentTypeId = (int) DocumentType;
            var genderId = (int) Gender;
            var civilStateId = (int) CivilState;
            var intructionLevelId = (int) InstructionLevel;
            using (var context = new MedilabEntities())
            {
                var patient = new DataAccess.Patient
                                  {
                                      PatientId = Id = Guid.NewGuid(),
                                      DocumentTypeId = documentTypeId,
                                      DocumentNumber = DocumentNumber,
                                      LastName = LastName,
                                      FirstName = FirstName,
                                      BirthDay = BirthDay,
                                      BirthPlaceId = BirthPlace.Id,
                                      GenderId = genderId,
                                      ChildrenNumber = ChildrenNumber,
                                      CivilStateId = civilStateId,
                                      InstructionLevelId = intructionLevelId,
                                      InstructionTitle = InstructionTitle,
                                      HomePhoneNumber = HomePhone,
                                      CellPhoneNumber = CellPhone,
                                      Observations = Observations,
                                      PrivateMedicineCompany = null,
                                      PrivateMedicineNumber = AffiliateNumber,
                                      Photo = Photo,
                                      WorkRiskInsuranceId = null,
                                      Nationality = Nationality
                                  };
                if (PrivateMedicine != null && PrivateMedicine.Id != Guid.Empty)
                {
                    patient.PrivateMedicineId = PrivateMedicine.Id;
                }
                if (RiskInsurance != null && RiskInsurance.Id != Guid.Empty)
                {
                    patient.WorkRiskInsuranceId = RiskInsurance.Id;
                }
                context.AddToPatient(patient);
                foreach (var address in Addresses)
                {
                    address.Owner = Id;
                    address.Save(context);
                }
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.Patient, AuditOperations.Insert,
                                     patient.PatientId, patient.DocumentNumber);
                context.SaveChanges();
                return this;
            }
        }

        private Patient Update()
        {
            using (var context = new MedilabEntities())
            {
                var patient = (from p in context.Patient where p.PatientId == Id select p).First();
                if (Tools.IsRecordChanged(patient.LastUpdated, LastUpdated))
                {
                    throw new OptimisticConcurrencyException(
                        BOResources.RecordUpdated);
                }
                var documentTypeId = (int) DocumentType;
                var genderId = (int) Gender;
                var civilStateId = (int) CivilState;
                var intructionLevelId = (int) InstructionLevel;
                patient.DocumentTypeId = documentTypeId;
                patient.DocumentNumber = DocumentNumber;
                patient.LastName = LastName;
                patient.FirstName = FirstName;
                patient.BirthDay = BirthDay;
                patient.BirthPlaceId = BirthPlace.Id;
                patient.GenderId = genderId;
                patient.ChildrenNumber = ChildrenNumber;
                patient.CivilStateId = civilStateId;
                patient.InstructionLevelId = intructionLevelId;
                patient.InstructionTitle = InstructionTitle;
                patient.HomePhoneNumber = HomePhone;
                patient.CellPhoneNumber = CellPhone;
                patient.Observations = Observations;
                patient.Photo = Photo;
                patient.PrivateMedicineNumber = AffiliateNumber;
                patient.Nationality = Nationality;
                var modifiedFields = Utilities.GetModifiedFields(context, patient.ToString());

                foreach (var address in Addresses)
                {
                    address.Owner = Id;
                    address.Save();
                }

                if (PrivateMedicine != null && PrivateMedicine.Id != Guid.Empty)
                {
                    if (patient.PrivateMedicineCompany == null ||
                        patient.PrivateMedicineCompany.PrivateMedicineCompanyId != PrivateMedicine.Id)
                    {
                        patient.PrivateMedicineId = PrivateMedicine.Id;
                    }
                }
                else
                {
                    patient.PrivateMedicineId = null;
                }

                if (RiskInsurance != null && RiskInsurance.Id != Guid.Empty)
                {
                    if (patient.WorkRiskInsurance == null ||
                        patient.WorkRiskInsurance.WorkRiskInsuranceId != RiskInsurance.Id)
                    {
                        patient.WorkRiskInsuranceId = RiskInsurance.Id;
                    }
                }
                else
                {
                    patient.WorkRiskInsuranceId = null;
                }
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.Patient, AuditOperations.Update, Id,
                                     modifiedFields);

                context.SaveChanges();
                return this;
            }
        }

        public void Delete()
        {
            using (var context = new MedilabEntities())
            {
                var patient = (from p in context.Patient where p.PatientId == Id select p).First();
                if (Tools.IsRecordChanged(patient.LastUpdated, LastUpdated))
                {
                    throw new OptimisticConcurrencyException(
                        "El registro fue modificado, por favor vuelva a aplicar sus cambios.");
                }
                patient.IsDeleted = true;
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.Patient, AuditOperations.Delete, Id,
                                     string.Empty);
                context.SaveChanges();
            }
        }

        public static Patient GetPatient(Guid id)
        {
            using (var context = new MedilabEntities())
            {
                var patient = (from p in context.Patient
                               where !p.IsDeleted && p.PatientId == id
                               select p).FirstOrDefault();
                if (patient != null)
                {
                    return GetPatient(patient, context);
                }

            }
            throw new Exception(BOResources.RecordNotFoudExeptionMessage);
        }

        private static PrivateMedicineCompany GetPrivateMedicine(Patient patient, MedilabEntities context)
        {
            var privateMedicine = (from p in context.Patient
                                   where p.PatientId == patient.Id
                                   select new
                                              {
                                                  p.PrivateMedicineId
                                              }).First();
            if (privateMedicine.PrivateMedicineId.HasValue)
            {
                return new PrivateMedicineCompany(privateMedicine.PrivateMedicineId.Value);
            }
            return null;
        }

        private static WorkRiskInsurance GetRiskInsurance(Patient patient, MedilabEntities context)
        {
            var riskInsurance = (from p in context.Patient
                                   where p.PatientId == patient.Id
                                   select new
                                   {
                                       p.WorkRiskInsuranceId
                                   }).First();
            if (riskInsurance.WorkRiskInsuranceId.HasValue)
            {
                return new WorkRiskInsurance(riskInsurance.WorkRiskInsuranceId.Value);
            }
            return null;
        }

        public static Patient GetPatient(DocumentType documentType, string documentNumber)
        {
            using (var context = new MedilabEntities())
            {
                var documentTypeId = (short) documentType;
                var patient = (from p in context.Patient
                               where !p.IsDeleted && p.DocumentType.DocumentTypeId == documentTypeId
                                     && p.DocumentNumber == documentNumber
                               select p).FirstOrDefault();
                if (patient != null)
                {
                    return GetPatient(patient, context);
                }
            }
            throw new Exception(BOResources.RecordNotFoudExeptionMessage);
        }

        private static Patient GetPatient(DataAccess.Patient databasePatient, MedilabEntities context)
        {
            var patient = new Patient
                              {
                                  Id = databasePatient.PatientId,
                                  DocumentType = (DocumentType) databasePatient.DocumentTypeId,
                                  DocumentNumber = databasePatient.DocumentNumber,
                                  LastName = databasePatient.LastName,
                                  FirstName = databasePatient.FirstName,
                                  BirthDay = databasePatient.BirthDay,
                                  BirthPlace = new State {Id = databasePatient.BirthPlaceId},
                                  Gender = (Gender) databasePatient.GenderId,
                                  ChildrenNumber = databasePatient.ChildrenNumber,
                                  CivilState = (CivilState) databasePatient.CivilStateId,
                                  InstructionLevel = (Instruction) databasePatient.InstructionLevelId,
                                  InstructionTitle = databasePatient.InstructionTitle,
                                  HomePhone = databasePatient.HomePhoneNumber,
                                  CellPhone = databasePatient.CellPhoneNumber,
                                  LastUpdated = databasePatient.LastUpdated,
                                  Observations = databasePatient.Observations,
                                  Photo = databasePatient.Photo,
                                  AffiliateNumber = databasePatient.PrivateMedicineNumber,
                                  Nationality = databasePatient.Nationality
                              };
            patient.Addresses = Address.Address.GetAddressesByOwner(patient.Id);
            patient.PrivateMedicine = GetPrivateMedicine(patient, context);
            //Load Work Risk Insurance
            patient.RiskInsurance = GetRiskInsurance(patient, context);
            patient.BirthPlace = State.GetState(patient.BirthPlace.Id, context);
            return patient;
        }

        public static IEnumerable<PatientListItemDto> GetList()
        {
            using (var context = new MedilabEntities())
            {
                var patients = (from p in context.Patient where !p.IsDeleted orderby p.LastName select p).ToList();
                return patients.Select(p => new PatientListItemDto
                                                {
                                                    Id = p.PatientId,
                                                    DocumentType = ((DocumentType) p.DocumentTypeId).ToString(),
                                                    DocumentNumber = p.DocumentNumber,
                                                    LastName = p.LastName,
                                                    FirstName = p.FirstName
                                                }).ToList();
            }
        }

        private bool IsValid()
        {
            return !string.IsNullOrEmpty(DocumentNumber) && !string.IsNullOrEmpty(FirstName) &&
                   !string.IsNullOrEmpty(LastName);
        }

        public static IEnumerable<PatientListItemDto> SearchPatient(string searchTerm)
        {
            using (var context = new MedilabEntities())
            {
                var patients = (from p in context.Patient
                                where !p.IsDeleted &&
                                      (p.LastName.Contains(searchTerm) || p.DocumentNumber.Contains(searchTerm) || p.FirstName.Contains(searchTerm))
                                orderby p.LastName
                                select p).ToList();
                return patients.Select(p => new PatientListItemDto
                                                {
                                                    Id = p.PatientId,
                                                    DocumentType = ((DocumentType) p.DocumentTypeId).ToString(),
                                                    DocumentNumber = p.DocumentNumber,
                                                    LastName = p.LastName,
                                                    FirstName = p.FirstName
                                                }).ToList();
            }
        }

        #endregion
    }
}