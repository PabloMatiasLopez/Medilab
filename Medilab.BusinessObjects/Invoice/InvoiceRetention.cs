using System;
using Medilab.DataAccess;

namespace Medilab.BusinessObjects.Invoice
{
    public class InvoiceRetention
    {
        #region Properties

        private double _value;
        public double Value
        {
            set { _value = Math.Round(value, 2); }
            get { return _value; }
        }
        public Guid Id { set; get; }
        public Guid InvoiceHeaderId { set; get; }
        public Guid FiscalRetentionId { set; get; }
        public string Name { set; get; }
        public bool Selected { set; get; }
        #endregion

        #region Methods
        internal InvoiceRetention Save(MedilabEntities context)
        {
            return Id != Guid.Empty ? this : Insert(context);
        }

        private InvoiceRetention Insert(MedilabEntities context)
        {
            var retention = new DataAccess.InvoiceRetention
            {
                InvoiceRetentionId = Id = Guid.NewGuid(),
                InvoiceHeaderId = InvoiceHeaderId,
                FiscalRetentionId = FiscalRetentionId,
                FiscalRetentionName = Name,
                FiscalRetentionValue = _value,
            };
            context.AddToInvoiceRetention(retention);
            return this;
        }

        #endregion
    }
}
