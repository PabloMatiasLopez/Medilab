using Medilab.DataAccess;
using System;
using System.Linq;

namespace Medilab.BusinessObjects.Invoice
{
    public class ProfileFiscalRetention
    {
        #region Properties
        public Guid Id { private set; get; }
        public Guid ProfileId { set; get; }
        public Guid RetentionId { set; get; }
        #endregion

        #region Methods
        internal void Save(MedilabEntities context)
        {
            var profileRetention = new DataAccess.InvoiceProfileRetention
            {
                InvoiceProfileRetentionId = Id = Guid.NewGuid(),
                InvoiceProfileId = ProfileId,
                FiscalRetentionId = RetentionId
            };
            context.AddToInvoiceProfileRetention(profileRetention);
        }
        internal static void RemoveMedicalPractices(MedilabEntities context, Guid profileId)
        {
            var fiscalRetentions = (from r in context.InvoiceProfileRetention where r.InvoiceProfileId == profileId select r).ToList();
            foreach (var retention in fiscalRetentions)
            {
                context.DeleteObject(retention);
            }
        }
        #endregion

    }
}