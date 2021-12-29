using System;
using System.Collections.Generic;
using System.Linq;
using Medilab.BusinessObjects.Properties;
using Medilab.DataAccess;
using Medilab.BusinessObjects.Utils;
using System.Data;

namespace Medilab.BusinessObjects.Configuration
{
    public class CompanyInfo
    {
        #region Properties
        
        
        public Guid Id { private set; get;}
        
	    public string Address { get; set;}
        public string Name { get; set; }
	    public string PostalCode{ get; set;}
	    public string Province{ get; set;}
	    public string Country{ get; set;}
	    public string Phone{ get; set;}
	    public string Fax{ get; set;}
	    public string Email{ get; set;}
        public string Image { get; set; }
        public string Cuit { get; set;  }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public byte[] LastUpdated { get; set; }
        public string ExcelFormat { get; set; }
        #endregion

        #region Methods
        private CompanyInfo()
        {}
        public CompanyInfo(Guid id)
        {
            Id = id; 
        }
        public CompanyInfo Save()
        { 
            return Id == Guid.Empty ? Insert(): Update();
        }
        private CompanyInfo Update()
        {
            using (var context = new MedilabEntities())
            {
                var companyInfo = (from c in context.CompanyInfo
                                            where c.CompanyInfoId == Id
                                            select c).First();
                if (Tools.IsRecordChanged(companyInfo.LastUpdated, LastUpdated))
                {
                    throw new OptimisticConcurrencyException(BOResources.RecordUpdated);
                }
                companyInfo.CompanyInfoAddress = Address;
                companyInfo.CompanyInfoCountry = Country;
                companyInfo.CompanyInfoCuit = Cuit;
                companyInfo.CompanyInfoEmail = Email;
                companyInfo.CompanyInfoFax = Fax;
                companyInfo.CompanyInfoImage = Image;
                companyInfo.CompanyInfoPhone = Phone;
                companyInfo.CompanyInfoPostalCode = PostalCode;
                companyInfo.CompanyInfoProvince = Province;
                companyInfo.CompanyInfoIsDeleted = IsDeleted;
                companyInfo.CompanyInfoExcelFormat = ExcelFormat;
                if (IsActive)
                {
                    EnsureOnlyOneConfigurationActive();
                }
                companyInfo.CompanyInfoIsActive = IsActive;
                companyInfo.CompanyInfoName = Name;
                var modifiedFields = Utilities.GetModifiedFields(context, companyInfo.ToString());
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.CompanyInfo, AuditOperations.Update, Id, modifiedFields);
                context.SaveChanges();
                return this;
            }
        }
        private CompanyInfo Insert()
        {
            using(var context = new MedilabEntities())
            {
                var companyInfo = new DataAccess.CompanyInfo
                {
                    CompanyInfoId = Id = Guid.NewGuid(),
                    CompanyInfoAddress = Address,
                    CompanyInfoPostalCode = PostalCode,
                    CompanyInfoProvince = Province,
                    CompanyInfoCountry = Country,
                    CompanyInfoPhone = Phone,
                    CompanyInfoFax = Fax,
                    CompanyInfoEmail = Email,
                    CompanyInfoImage = Image,
                    CompanyInfoCuit = Cuit,
                    CompanyInfoIsDeleted = IsDeleted,
                    CompanyInfoIsActive = IsActive,
                    CompanyInfoName = Name,
                    CompanyInfoExcelFormat = ExcelFormat
                };
                if (IsActive)
                {
                    EnsureOnlyOneConfigurationActive();
                }
                context.AddToCompanyInfo(companyInfo);
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.CompanyInfo, AuditOperations.Insert, Id, companyInfo.CompanyInfoName);
                context.SaveChanges();
                return this;
            }
        }
        public static CompanyInfo GetCompanyInfo(Guid companyInfoId)
        {
            using (var context = new MedilabEntities())
            {
                var compInfo = (from c in context.CompanyInfo
                                            where c.CompanyInfoId == companyInfoId && c.CompanyInfoIsDeleted == false
                                            select c).First();
                if(compInfo != null)
                {
                    return new CompanyInfo {
                    Address = compInfo.CompanyInfoAddress,
                    Country = compInfo.CompanyInfoCountry,
                    Cuit = compInfo.CompanyInfoCuit,
                    Email = compInfo.CompanyInfoEmail,
                    Fax = compInfo.CompanyInfoFax,
                    Id = compInfo.CompanyInfoId,
                    Image = compInfo.CompanyInfoImage,
                    IsDeleted = compInfo.CompanyInfoIsDeleted,
                    Phone = compInfo.CompanyInfoPhone,
                    PostalCode = compInfo.CompanyInfoPostalCode,
                    Province = compInfo.CompanyInfoProvince,
                    IsActive = compInfo.CompanyInfoIsActive,
                    Name = compInfo.CompanyInfoName,
                    LastUpdated = compInfo.LastUpdated,
                    ExcelFormat = compInfo.CompanyInfoExcelFormat};
                }
                throw new Exception(BOResources.RecordNotFoudExeptionMessage);
            }
       }
        public static IEnumerable<CompanyInfo> GetCompanyInfoList()
        {
            using (var context = new MedilabEntities())
            {
                var companyInfoList = (from c in context.CompanyInfo
                                                 where c.CompanyInfoIsDeleted == false
                                                 select c).ToList();
                return companyInfoList.Select(companyInfo => new CompanyInfo
                    {
                        Address = companyInfo.CompanyInfoAddress,
                        Country = companyInfo.CompanyInfoCountry,
                        Cuit = companyInfo.CompanyInfoCuit,
                        Email = companyInfo.CompanyInfoEmail,
                        Fax = companyInfo.CompanyInfoFax,
                        Id = companyInfo.CompanyInfoId,
                        Image = companyInfo.CompanyInfoImage,
                        IsDeleted = companyInfo.CompanyInfoIsDeleted,
                        Phone = companyInfo.CompanyInfoPhone,
                        PostalCode = companyInfo.CompanyInfoPostalCode,
                        Province = companyInfo.CompanyInfoProvince,
                        IsActive = companyInfo.CompanyInfoIsActive,
                        Name = companyInfo.CompanyInfoName,
                        LastUpdated = companyInfo.LastUpdated,
                        ExcelFormat = companyInfo.CompanyInfoExcelFormat
                    }).ToList();
            }
        
        }
        public static string GetCompanyExcelFormat()
        {
            try
            {
                using (var context = new MedilabEntities())
                {
                    var format = (from ci in context.CompanyInfo
                                  where ci.CompanyInfoIsActive
                                  select ci.CompanyInfoExcelFormat).ToList();
                    return format[0];

                }
            }
            catch (Exception)
            {
                return Constants.NotAvailable;
            }
        }

        /// <summary>
        /// this method represent a softdelete it will just update the flag IsDelete.
        /// </summary>
        /// <param name="companyInfoId"></param>
        public static bool Delete(Guid companyInfoId)
        {
            using (var context = new MedilabEntities())
            {
                var companyInfo = (from c in context.CompanyInfo
                                   where c.CompanyInfoId == companyInfoId
                                   select c).First();

                companyInfo.CompanyInfoIsDeleted = true;
                companyInfo.CompanyInfoIsActive = false;
                Audit.Audit.LogAudit(context, Security.GetCurrentUser(), ObjectTypes.CompanyInfo, AuditOperations.Delete, companyInfo.CompanyInfoId, companyInfo.CompanyInfoName);
                context.SaveChanges();
                if (IsAnyConfigurationActive())
                {
                    return false;
                }
                return true;
            }

        }
        /// <summary>
        /// Ensure just one Company configuration active by updating any previously created 
        /// configuration saved as active.
        /// </summary>
        private void EnsureOnlyOneConfigurationActive()
        {
            using (var context = new MedilabEntities())
            {
                if (IsAnyConfigurationActive())
                {
                    var companyInfo = (from c in context.CompanyInfo
                                                where c.CompanyInfoIsDeleted == false &&
                                                         c.CompanyInfoIsActive
                                                select c).First();
                    companyInfo.CompanyInfoIsActive = false;
                    context.SaveChanges();
                }
            }    
        }
        public static bool IsAnyConfigurationActive()
        { 
            using (var context = new MedilabEntities())
            {
                var isOtherActive = (from c in context.CompanyInfo
                                   where c.CompanyInfoIsDeleted == false &&
                                   c.CompanyInfoIsActive
                                   select c).Any();
                return isOtherActive;
            }
        }

        public static CompanyInfoDto GetCompanyToPrint()
        {
            using (var context = new MedilabEntities())
            {
                var compInfo = (from c in context.CompanyInfo
                                where c.CompanyInfoIsActive
                                select new CompanyInfoDto
                                {
                                    Address = c.CompanyInfoAddress,
                                    Email = c.CompanyInfoEmail,
                                    Phone = c.CompanyInfoPhone,
                                    PostalCode = c.CompanyInfoPostalCode
                                }).First();
                return compInfo;
            }
        }
        #endregion

    }
}
