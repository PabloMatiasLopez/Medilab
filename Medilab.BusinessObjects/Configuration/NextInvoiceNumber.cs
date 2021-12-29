using System;
using System.Data;
using System.Globalization;
using System.Linq;
using Medilab.BusinessObjects.Invoice;
using Medilab.BusinessObjects.Properties;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;

namespace Medilab.BusinessObjects.Configuration
{
    public class NextInvoiceNumber : INextInvoiceNumber
    {
        #region Properties
        public int Id { private set; get; }
        public InvoiceType InvoiceNumberType { set; get; }
        public int MasterNumber { set; get; }
        public int InvoiceNumber { set; get; }
        public byte[] LastUpdated { get; set; }
        #endregion

        #region Methods
        public void SetNextInvoiceNumber(InvoiceType invoiceType, MedilabEntities context)
        {
            var type = (int) invoiceType;
            var nextNumber =
                (from n in context.NextInvoiceNumber where n.InvoiceType == type select n).FirstOrDefault();
            if (nextNumber == null)
            {
                var newInvoiceNumber = new DataAccess.NextInvoiceNumber
                                            {
                                                MasterNumber = MasterNumber,
                                                InvoiceNumber = InvoiceNumber,
                                                InvoiceType = (int) invoiceType
                                            };
                context.AddToNextInvoiceNumber(newInvoiceNumber);
            }
            else
            {
                if (Tools.IsRecordChanged(nextNumber.LastUpdated, LastUpdated))
                {
                    throw new OptimisticConcurrencyException(BOResources.RecordUpdated);
                }
                nextNumber.MasterNumber = MasterNumber;
                nextNumber.InvoiceNumber = InvoiceNumber;
            }
        }
        public INextInvoiceNumber GetNextInvoiceNumber(InvoiceType invoiceType, MedilabEntities context)
        {
            var type = (int)invoiceType;
            var nextNumber =
                (from n in context.NextInvoiceNumber where n.InvoiceType == type select n).FirstOrDefault();
            if (nextNumber != null)
            {
                Id = nextNumber.InvoiceNumberID;
                InvoiceNumberType =
                    (InvoiceType)
                    Enum.Parse(typeof (InvoiceType),
                                nextNumber.InvoiceType.ToString(CultureInfo.InvariantCulture));
                MasterNumber = nextNumber.MasterNumber;
                InvoiceNumber = nextNumber.InvoiceNumber;
                LastUpdated = nextNumber.LastUpdated;
                return this;
            }

            InvoiceNumberType = invoiceType;
            MasterNumber = 0;
            InvoiceNumber = 0;
            return this;
        }

        public void SetNextInvoiceNumber(InvoiceType invoiceType)
        {
            using (var context = new MedilabEntities())
            {
                var type = (int)invoiceType;
                var nextNumber =
                    (from n in context.NextInvoiceNumber where n.InvoiceType == type select n).FirstOrDefault();
                if (nextNumber == null)
                {
                    var newInvoiceNumber = new DataAccess.NextInvoiceNumber
                    {
                        MasterNumber = MasterNumber,
                        InvoiceNumber = InvoiceNumber,
                        InvoiceType = (int)invoiceType
                    };
                    context.AddToNextInvoiceNumber(newInvoiceNumber);
                }
                else
                {
                    if (Tools.IsRecordChanged(nextNumber.LastUpdated, LastUpdated))
                    {
                        throw new OptimisticConcurrencyException(BOResources.RecordUpdated);
                    }
                    nextNumber.MasterNumber = MasterNumber;
                    nextNumber.InvoiceNumber = InvoiceNumber;
                }
                context.SaveChanges();
            }
        }

        public INextInvoiceNumber GetNextInvoiceNumber(InvoiceType invoiceType)
        {
            using (var context = new MedilabEntities())
            {
                var type = (int)invoiceType;
                var nextNumber =
                    (from n in context.NextInvoiceNumber where n.InvoiceType == type select n).FirstOrDefault();
                if (nextNumber != null)
                {
                    Id = nextNumber.InvoiceNumberID;
                    InvoiceNumberType =
                        (InvoiceType)
                        Enum.Parse(typeof(InvoiceType),
                                   nextNumber.InvoiceType.ToString(CultureInfo.InvariantCulture));
                    MasterNumber = nextNumber.MasterNumber;
                    InvoiceNumber = nextNumber.InvoiceNumber;
                    LastUpdated = nextNumber.LastUpdated;
                    return this;
                }

                InvoiceNumberType = invoiceType;
                MasterNumber = 0;
                InvoiceNumber = 0;
                return this;
            }
        }

        public string GetNextInvoiceNumberDisplay(InvoiceType invoiceType)
        {
            using (var context = new MedilabEntities())
            {
                GetNextInvoiceNumber(invoiceType, context);
                return string.Format("{0}-{1}", MasterNumber.ToString("0000"), InvoiceNumber.ToString("00000000"));
            }
        }
        public void AddInvoiceNumber(InvoiceType invoiceType, MedilabEntities context)
        {
            GetNextInvoiceNumber(invoiceType, context);
            InvoiceNumber++;
            SetNextInvoiceNumber(invoiceType, context);
        }
        #endregion
    }
}
