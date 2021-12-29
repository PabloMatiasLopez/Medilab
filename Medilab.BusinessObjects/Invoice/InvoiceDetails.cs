using System;
using System.Linq;
using Medilab.DataAccess;

namespace Medilab.BusinessObjects.Invoice
{
    public class InvoiceDetails
    {
        #region Properties
        private double _price;
        public Guid Id { set; get; }
        public Guid InvoiceHeaderId { set; get; }
        public Guid ItemId { set; get; }
        public Guid? GroupId { set; get; }
        public int Code { set; get; }
        public string Description { set; get; }
        public int Quantity { set; get; }
        public string Observations { set; get; }
        public Guid? PatientId { set; get; }
        public string PatientFirstName { set; get; }
        public string PatientLastName { set; get; }
        public string PatientDocumentNumber { set; get; }
        public int? ExamTypeId { set; get; }
        public DateTime Date { set; get; }

        public double Price { 
            set { _price = value; }
            get
            {
                if (_price == 0)
                {
                    _price = GetPrice();
                }
                return _price;
            } 
        }
        public bool Selected { set; get; }
        public string FullName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(PatientLastName) || string.IsNullOrWhiteSpace(PatientFirstName))
                {
                    return string.Empty;
                }
                return string.Format("{0}, {1}", PatientLastName, PatientFirstName);
            }
        }

        public Guid MedicalHistoryId { set; get; }
        #endregion

        #region Methods
        internal InvoiceDetails Save(MedilabEntities context)
        {
            return Id == Guid.Empty ? Insert(context) : Update(context);
        }

        private InvoiceDetails Insert(MedilabEntities context)
        {
            var detail = new InvoiceDetail
                {
                    InvoiceDetailId = Id = Guid.NewGuid(),
                    InvoiceHeaderId = InvoiceHeaderId,
                    ItemId = ItemId,
                    ItemCode = Code,
                    ItemDescription = Description,
                    ItemQuantity = Quantity,
                    ItemPrice = Price,
                    ItemObservation = Observations,
                    ItemGroupId = GroupId,
                    PatientId = PatientId,
                    ExamTypeId = ExamTypeId,
                    ItemCreationDate = Date
                };
            context.AddToInvoiceDetail(detail);
            return this;
        }

        private InvoiceDetails Update(MedilabEntities context)
        {
            var detail =
                (from invoiceDetail in context.InvoiceDetail
                 where invoiceDetail.InvoiceDetailId == Id
                 select invoiceDetail).First();
            detail.ItemObservation = Observations;
            return this;
        }

        private double GetPrice()
        {
            using (var context = new MedilabEntities())
            {
                var price =
                    (from p in context.PracticeGroupPrice where p.PracticeGroupId == ItemId select p.Price).
                        FirstOrDefault();
                return price;
            }
        }
        #endregion
    }
}
