using Medilab.BusinessObjects.CAE;
using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.Utils;
using Medilab.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using NextInvoiceNumber = Medilab.BusinessObjects.Configuration.NextInvoiceNumber;
using User = Medilab.BusinessObjects.Configuration.User;

namespace Medilab.BusinessObjects.Invoice
{
    public class InvoiceHeader
    {
        #region Properties
        public Guid Id { private set; get; }
        public Configuration.Client ClientInformation { set; get; }
        public Configuration.CompanyInfo Company { set; get; }
        public DateTime Date { set; get; }
        public InvoiceType InvoiceType { set; get; }
        public int SalePoint { set; get; }
        public int InvoiceNumber { set; get; }
        private double _total;
        public double Total
        {
            set { _total = Math.Round(value, 2); }
            get { return _total; }
        }
        private double _subTotal;
        public double SubTotal
        {
            set { _subTotal = Math.Round(value, 2); }
            get { return _subTotal; }
        }
        private double _notTaxed;
        public double NotTaxed
        {
            set { _notTaxed = Math.Round(value, 2); }
            get { return _notTaxed; }
        }

        private double _ivaPerception;
        public double IvaPerception
        {
            set { _ivaPerception = Math.Round(value, 2); }
            get { return _ivaPerception; }
        }
        private double _otherPerception;
        public double OtherPerception
        {
            set { _otherPerception = Math.Round(value, 2); }
            get { return _otherPerception; }
        }
        public double Remainder { private set; get; }
        public string Observation { set; get; }
        public string ManualDetailText { set; get; }
        public InvoiceStatus Status { set; get; }
        public IEnumerable<InvoiceDetails> Items { set; get; }
        public IEnumerable<InvoiceDetails> InvoicedPractices { set; get; }
        public IEnumerable<InvoiceRetention> Retentions { set; get; }
        public string CAE { private set; get; }
        public DateTime CAEExpirationDate { private set; get; }
        public Guid CreateUser { set; get; }
        public Guid UpdateUser { set; get; }

        #endregion

        #region Methods
        public InvoiceHeader(Guid id)
        {
            Id = id;
        }
        public InvoiceHeader()
        {

        }
        public InvoiceHeader Save()
        {
            return Id == Guid.Empty ? Insert() : Update();
        }

        /// <summary>
        /// Get invoice by id
        /// </summary>
        /// <param name="invoiceId">invoice Id</param>
        /// <returns>Invoice</returns>
        public static InvoiceHeader GetInvoiceById(Guid invoiceId)
        {
            using (var context = new MedilabEntities())
            {
                var invoice = (from h in context.InvoiceHeader
                               where h.InvoiceHeaderId == invoiceId
                               select new
                               {
                                   Header = h,
                                   Details = h.InvoiceDetail,
                                   Retentions = h.InvoiceRetention
                               }).FirstOrDefault();

                if (null == invoice) return null;

                var rta = new InvoiceHeader(invoice.Header.InvoiceHeaderId)
                {
                    ClientInformation = Configuration.Client.GetClient(invoice.Header.ClientId),
                    Company = Configuration.CompanyInfo.GetCompanyInfo(invoice.Header.CompanyInfoId),
                    Date = invoice.Header.Date,
                    InvoiceType = (InvoiceType)invoice.Header.InvoiceType,
                    SalePoint = invoice.Header.SalePoint,
                    InvoiceNumber = invoice.Header.InvoiceNumber,
                    _total = invoice.Header.Total,
                    Observation = invoice.Header.InvoiceObservation,
                    ManualDetailText = invoice.Header.ManualDetailText,
                    Status = (InvoiceStatus)invoice.Header.Status,
                    _subTotal = invoice.Header.SubTotal,
                    CAE = invoice.Header.CAE,
                    Remainder = invoice.Header.InvoiceRemainder
                };
                var items = invoice.Details.Select(LoadDetailData).ToList();
                rta.Items = items;
                IList<InvoiceRetention> retentions = invoice.Retentions.Select(LoadRetentionData).ToList();
                rta.Retentions = retentions;
                return rta;
            }
        }

        /// <summary>
        /// Get invoice by number
        /// </summary>
        /// <param name="invoiceNumber">invoice Number</param>
        /// <param name="type">Invoice Type</param>
        /// <returns>Invoice</returns>
        public static InvoiceHeaderDto GetInvoiceByNumber(string invoiceNumber, InvoiceType type)
        {
            var splitNumber = invoiceNumber.Split('-');
            int salePoint;
            int number;
            if (!int.TryParse(splitNumber[0], out salePoint) & !int.TryParse(splitNumber[1], out number))
            {
                return null;
            }
            var invoiceType = (int) type;
            using (var context = new MedilabEntities())
            {
                var invoice = (from h in context.InvoiceHeader
                               where h.InvoiceNumber == number && h.SalePoint == salePoint && h.InvoiceType == invoiceType
                               select new InvoiceHeaderDto()
                               {
                                   InvoiceId = h.InvoiceHeaderId,
                                   InvoiceNumberDisplay = invoiceNumber,
                                   InvoiceType = (InvoiceType)h.InvoiceType,
                                   ClientName = h.Client.ClientName,
                                   Subtotal = h.SubTotal,
                                   Total = h.Total,
                                   Status = (InvoiceStatus)h.Status,
                                   InvoiceDate = h.Date,
                                   CAE = h.CAE
                               }).FirstOrDefault();
                return invoice;
            }
        }
        public static InvoiceHeaderDto GetInvoiceToPrint(Guid invoiceId)
        {
            using (var context = new MedilabEntities())
            {
                var invoice = (from h in context.InvoiceHeader
                               where h.InvoiceHeaderId == invoiceId
                               select h).FirstOrDefault();
                if (invoice == null)
                {
                    return null;
                }
                var invoiceDto = new InvoiceHeaderDto()
                {
                    InvoiceId = invoice.InvoiceHeaderId,
                    InvoiceNumberDisplay = invoice.SalePoint.ToString("0000") + "-" + invoice.InvoiceNumber.ToString("00000000"),
                    InvoiceType = (InvoiceType)invoice.InvoiceType,
                    ClientName = invoice.Client.ClientName,
                    Subtotal = invoice.SubTotal,
                    Total = invoice.Total,
                    Status = (InvoiceStatus)invoice.Status,
                    InvoiceDate = invoice.Date,
                    CAE = invoice.CAE,
                    DocumentType = invoice.InvoiceType == 1 ? Enums.TipoComprobante.FACTURAS_A : Enums.TipoComprobante.FACTURAS_B
                };
                return invoiceDto;
            }
        }

        /// <summary>
        /// Get invoice by number and if it's in Generated or Printed Status
        /// </summary>
        /// <param name="invoiceNumber">invoice Number</param>
        /// <returns>Invoice</returns>
        public static PendingToPayDto GetInvoiceByNumberPending(string invoiceNumber)
        {
            using (var context = new MedilabEntities())
            {
                var splitNumber = invoiceNumber.Split('-');
                var salePoint = int.Parse(splitNumber[0]);
                var number = int.Parse(splitNumber[1]);
                var invoice = (from h in context.InvoiceHeader
                               where h.SalePoint == salePoint && h.InvoiceNumber == number && (h.Status == (int)InvoiceStatus.Generada || h.Status == (int)InvoiceStatus.Impresa)
                               select new PendingToPayDto
                               {
                                   Id = h.InvoiceHeaderId,
                                   Number = h.SalePoint + "-" + h.InvoiceNumber,
                                   VoucherType = h.InvoiceType == 1 ? Enums.TipoComprobante.FACTURAS_A : Enums.TipoComprobante.FACTURAS_B,
                                   ClientName = h.Client.ClientName,
                                   SubTotal = h.SubTotal,
                                   Total = h.Total,
                                   Status = (InvoiceStatus)h.Status,
                                   CreationDate = h.Date,
                                   CAE = h.CAE,
                                   Balance = h.InvoiceRemainder,
                                   CreatedBy = GetUserName(h.CreateUserId),
                                   UpdatedBy = GetUserName(h.LastUpdateUserId)
                               }).FirstOrDefault();
                return invoice;
            }
        }
        /// <summary>
        /// Get a list of invoice headers
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="invoiceStatus"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static List<InvoiceHeaderDto> GetInvoiceList(Guid clientId, int invoiceStatus, DateTime fromDate, DateTime toDate)
        {
            using (var context = new MedilabEntities())
            {
                var invoiceHeaderList = (from h in context.InvoiceHeader
                                         where
                                             h.Client.ClientId == clientId &&
                                             (invoiceStatus == 0 || h.Status == invoiceStatus) &&
                                             (h.Date >= fromDate && h.Date <= toDate)
                                         select h).ToList();

                return invoiceHeaderList.Select(h => new InvoiceHeaderDto
                {
                    InvoiceId = h.InvoiceHeaderId,
                    InvoiceNumberDisplay = h.SalePoint.ToString("0000") + "-" + h.InvoiceNumber.ToString("00000000"),
                    InvoiceType = (InvoiceType)h.InvoiceType,
                    ClientName = h.Client.ClientName,
                    Subtotal = h.SubTotal,
                    Total = h.Total,
                    Remainer = h.InvoiceRemainder,
                    Status = (InvoiceStatus)h.Status,
                    InvoiceDate = h.Date,
                    CAE = h.CAE,
                    CreateUser = GetUserName(h.CreateUserId),
                    UpdateUser = GetUserName(h.LastUpdateUserId)
                }).ToList();
            }
        }
        /// <summary>
        /// Get a list of invoice headers
        /// </summary>
        /// <param name="clientNumber"></param>
        /// <param name="invoiceStatus"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public static List<InvoiceHeaderDto> GetInvoiceList(int clientNumber, int invoiceStatus, DateTime fromDate, DateTime toDate)
        {
            using (var context = new MedilabEntities())
            {
                var invoiceHeaderList = (from h in context.InvoiceHeader
                                         where
                                             h.Client.ClientNumber == clientNumber &&
                                             (invoiceStatus == 0 || h.Status == invoiceStatus) &&
                                             (h.Date >= fromDate && h.Date <= toDate)
                                         select h).ToList();

                return invoiceHeaderList.Select(h => new InvoiceHeaderDto
                {
                    InvoiceId = h.InvoiceHeaderId,
                    InvoiceNumberDisplay = h.SalePoint.ToString("0000") + "-" + h.InvoiceNumber.ToString("00000000"),
                    InvoiceType = (InvoiceType)h.InvoiceType,
                    ClientName = h.Client.ClientName,
                    Subtotal = h.SubTotal,
                    Total = h.Total,
                    Remainer = h.InvoiceRemainder,
                    Status = (InvoiceStatus)h.Status,
                    InvoiceDate = h.Date,
                    CAE = h.CAE,
                    CreateUser = GetUserName(h.CreateUserId),
                    UpdateUser = GetUserName(h.LastUpdateUserId)
                }).ToList();
            }
        }
        /// <summary>
        /// Get a list of invoice headers where remainer is >0
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public static List<InvoiceHeaderDto> GetInvoiceListWithRemainder(Guid clientId)
        {
            using (var context = new MedilabEntities())
            {
                var invoiceHeaderList = (from h in context.InvoiceHeader
                                         where
                                             h.Client.ClientId == clientId &&
                                             h.InvoiceRemainder > 0
                                         orderby h.InvoiceRemainder descending
                                         select h).ToList();

                return invoiceHeaderList.Select(h => new InvoiceHeaderDto
                {
                    InvoiceId = h.InvoiceHeaderId,
                    InvoiceNumberDisplay = h.SalePoint.ToString("0000") + "-" + h.InvoiceNumber.ToString("00000000"),
                    InvoiceType = (InvoiceType)h.InvoiceType,
                    ClientName = h.Client.ClientName,
                    Subtotal = h.SubTotal,
                    Total = h.Total,
                    Remainer = h.InvoiceRemainder,
                    Status = (InvoiceStatus)h.Status,
                    InvoiceDate = h.Date,
                    CAE = h.CAE,
                    CreateUser = GetUserName(h.CreateUserId),
                    UpdateUser = GetUserName(h.LastUpdateUserId)
                }).ToList();
            }
        }

        /// <summary>
        /// Get a list of invoice headers where remainer is >0
        /// </summary>
        /// <param name="clientNumber"></param>
        /// <returns></returns>
        public static List<InvoiceHeaderDto> GetInvoiceListWithRemainder(int clientNumber)
        {
            using (var context = new MedilabEntities())
            {
                var invoiceHeaderList = (from h in context.InvoiceHeader
                                         where
                                             h.Client.ClientNumber == clientNumber &&
                                             h.InvoiceRemainder > 0
                                         orderby h.InvoiceRemainder descending
                                         select h).ToList();

                return invoiceHeaderList.Select(h => new InvoiceHeaderDto
                {
                    InvoiceId = h.InvoiceHeaderId,
                    InvoiceNumberDisplay = h.SalePoint.ToString("0000") + "-" + h.InvoiceNumber.ToString("00000000"),
                    InvoiceType = (InvoiceType)h.InvoiceType,
                    ClientName = h.Client.ClientName,
                    Subtotal = h.SubTotal,
                    Total = h.Total,
                    Remainer = h.InvoiceRemainder,
                    Status = (InvoiceStatus)h.Status,
                    InvoiceDate = h.Date,
                    CAE = h.CAE,
                    CreateUser = GetUserName(h.CreateUserId),
                    UpdateUser = GetUserName(h.LastUpdateUserId)
                }).ToList();
            }
        }

        /// <summary>
        /// Get a list of invoice headers generated or printed 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public static List<PendingToPayDto> GetInvoiceList(Guid clientId, DateTime fromDate, DateTime toDate)
        {
            using (var context = new MedilabEntities())
            {
                var invoiceHeaderList = (from h in context.InvoiceHeader
                                         where
                                             h.Client.ClientId == clientId && (h.Status == (int)InvoiceStatus.Generada || h.Status == (int)InvoiceStatus.Impresa) &&
                                             (h.Date >= fromDate && h.Date <= toDate) && h.InvoiceRemainder > 0
                                         select h).ToList();

                return invoiceHeaderList.Select(h => new PendingToPayDto
                {
                    Id = h.InvoiceHeaderId,
                    Number = h.SalePoint.ToString("0000") + "-" + h.InvoiceNumber.ToString("00000000"),
                    VoucherType = h.InvoiceType == 1 ? Enums.TipoComprobante.FACTURAS_A : Enums.TipoComprobante.FACTURAS_B,
                    ClientName = h.Client.ClientName,
                    SubTotal = h.SubTotal,
                    Total = h.Total,
                    Status = (InvoiceStatus)h.Status,
                    CreationDate = h.Date,
                    CAE = h.CAE,
                    Balance = h.InvoiceRemainder,
                    CreatedBy = GetUserName(h.CreateUserId),
                    UpdatedBy = GetUserName(h.LastUpdateUserId)
                }).ToList();
            }
        }
        /// <summary>
        /// Get a list of invoice headers generated or printed 
        /// </summary>
        /// <param name="clientNumber"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public static List<InvoiceHeaderDto> GetInvoiceList(int clientNumber, DateTime fromDate, DateTime toDate)
        {
            using (var context = new MedilabEntities())
            {
                var invoiceHeaderList = (from h in context.InvoiceHeader
                                         where
                                             h.Client.ClientNumber == clientNumber && (h.Status == (int)InvoiceStatus.Generada || h.Status == (int)InvoiceStatus.Impresa) &&
                                             (h.Date >= fromDate && h.Date <= toDate)
                                         select h).ToList();

                return invoiceHeaderList.Select(h => new InvoiceHeaderDto
                {
                    InvoiceId = h.InvoiceHeaderId,
                    InvoiceNumberDisplay = h.SalePoint.ToString("0000") + "-" + h.InvoiceNumber.ToString("00000000"),
                    InvoiceType = (InvoiceType)h.InvoiceType,
                    ClientName = h.Client.ClientName,
                    Subtotal = h.SubTotal,
                    Total = h.Total,
                    Remainer = h.InvoiceRemainder,
                    Status = (InvoiceStatus)h.Status,
                    InvoiceDate = h.Date,
                    CAE = h.CAE,
                    CreateUser = GetUserName(h.CreateUserId),
                    UpdateUser = GetUserName(h.LastUpdateUserId)
                }).ToList();
            }
        }
        private static string GetUserName(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return string.Empty;
            }
            else
            {
                var user = User.GetUser(userId);
                return string.Concat(user.LastName, ", ", user.FirstName);
            }

        }

        private static InvoiceDetails LoadDetailData(InvoiceDetail detailDataAcces)
        {
            int? examType = null;
            Guid? patientId = null;
            if (detailDataAcces.PatientId.HasValue)
            {
                patientId = detailDataAcces.PatientId.Value;
            }
            if (detailDataAcces.ExamTypeId.HasValue)
            {
                examType = detailDataAcces.ExamTypeId.Value;
            }
            DataAccess.Patient patient = detailDataAcces.Patient;
            var detailResult = new InvoiceDetails
                                              {
                                                  Id = detailDataAcces.InvoiceDetailId,
                                                  Price = detailDataAcces.ItemPrice,
                                                  InvoiceHeaderId = detailDataAcces.InvoiceHeaderId,
                                                  ItemId = detailDataAcces.ItemId,
                                                  GroupId = detailDataAcces.ItemGroupId,
                                                  Code = detailDataAcces.ItemCode,
                                                  Description = detailDataAcces.ItemDescription,
                                                  Quantity = detailDataAcces.ItemQuantity,
                                                  Observations = detailDataAcces.ItemObservation,
                                                  PatientId = patient != null ? patientId : null,
                                                  PatientFirstName = patient != null ? patient.FirstName : null,
                                                  PatientLastName = patient != null ? patient.LastName : null,
                                                  PatientDocumentNumber = patient != null ? patient.DocumentNumber : null,
                                                  ExamTypeId = examType,
                                                  Date = detailDataAcces.ItemCreationDate
                                              };

            return detailResult;
        }

        private static InvoiceRetention LoadRetentionData(DataAccess.InvoiceRetention retentionDataAcces)
        {
            var detailResult = new InvoiceRetention
            {
                Id = retentionDataAcces.InvoiceRetentionId,
                Value = retentionDataAcces.FiscalRetentionValue,
                InvoiceHeaderId = retentionDataAcces.InvoiceHeaderId,
                FiscalRetentionId = retentionDataAcces.FiscalRetentionId,
                Name = retentionDataAcces.FiscalRetentionName
            };

            return detailResult;
        }

        //Is it possible update an invoice?
        private InvoiceHeader Update()
        {
            UpdateUser = Security.GetCurrentUser();
            using (var context = new MedilabEntities())
            {
                var header = (from h in context.InvoiceHeader where h.InvoiceHeaderId == Id select h).First();
                header.InvoiceObservation = Observation;
                RemovePractices(context, (InvoiceStatus)header.Status, Status);
                header.Status = (int)Status;
                header.LastUpdateUserId = UpdateUser;
                SaveDetails(context);
                SaveRetentions(context);
                var modifiedFields = Utilities.GetModifiedFields(context, header.ToString());
                Audit.Audit.LogAudit(context, UpdateUser, ObjectTypes.Invoice, AuditOperations.Update, Id, modifiedFields);
                context.SaveChanges();
                return this;
            }
        }
        private InvoiceHeader Insert()
        {
            try
            {
                GetCAE();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            using (var context = new MedilabEntities())
            {
                var header = new DataAccess.InvoiceHeader
                {
                    InvoiceHeaderId = Id = Guid.NewGuid(),
                    ClientId = ClientInformation.Id,
                    CompanyInfoId = (from company in context.CompanyInfo where company.CompanyInfoIsActive select company.CompanyInfoId).First(),
                    Date = DateTime.Today,
                    InvoiceType = (int)InvoiceType,
                    SalePoint = SalePoint,
                    InvoiceNumber = InvoiceNumber,
                    Total = _total,
                    InvoiceObservation = Observation,
                    ManualDetailText = ManualDetailText,
                    Status = (int)Status,
                    SubTotal = _subTotal,
                    CAE = CAE,
                    CAEExpirationDate = CAEExpirationDate,
                    CreateUserId = CreateUser,
                    LastUpdateUserId = UpdateUser,
                    InvoiceRemainder = _total,
                    NoTaxedConcept = _notTaxed,
                    IvaPerception = _ivaPerception,
                    OtherPerception = _otherPerception
                };
                context.AddToInvoiceHeader(header);
                SaveDetails(context);
                SaveRetentions(context);
                INextInvoiceNumber nextInvoiceNumber = new NextInvoiceNumber();
                nextInvoiceNumber.AddInvoiceNumber(InvoiceType, context);
                UpdateItems(context);
                Audit.Audit.LogAudit(context, CreateUser, ObjectTypes.Invoice, AuditOperations.Insert, Id, string.Empty);
                context.SaveChanges();
                return this;
            }
        }

        private void GetCAE()
        {
            List<FiscalRetention> fiscalRetentionList = new List<FiscalRetention>();
            foreach (var item in Retentions)
            {
                var retention = FiscalRetention.GetRetention(item.FiscalRetentionId);
                fiscalRetentionList.Add(retention);
            }
            var ProcessCAE = new ProcessCAE(true, false)
            {
                DocumentType = InvoiceType,
                SalePoint = SalePoint,
                Number = InvoiceNumber,
                CreationDate = Date,
                ClientInformation = ClientInformation,
                Total = Total,
                SubTotal = SubTotal,
                Observations = Observation,
                NotTaxed = NotTaxed,
                RetentionList = fiscalRetentionList
            };
            ProcessCAE.GetCAE();
            IvaPerception = ProcessCAE.IvaPerception;
            OtherPerception = ProcessCAE.OtherPerception;
            CAE = ProcessCAE.CAE;
            CAEExpirationDate = ProcessCAE.CAEExpirationDate;
        }
        private void SaveDetails(MedilabEntities context)
        {
            foreach (var invoiceDetail in Items)
            {
                invoiceDetail.InvoiceHeaderId = Id;
                invoiceDetail.Save(context);
            }
        }
        private void SaveRetentions(MedilabEntities context)
        {
            if (Retentions == null) return;
            foreach (var invoiceRetention in Retentions)
            {
                invoiceRetention.InvoiceHeaderId = Id;
                invoiceRetention.Save(context);
            }
        }

        private void RemovePractices(MedilabEntities context, InvoiceStatus oldStatus, InvoiceStatus newStatus)
        {
            if (oldStatus != InvoiceStatus.Anulada && newStatus == InvoiceStatus.Anulada)
            {
                var medicalHistoryPractices = (from h in context.MedicalHistoryPractice where h.InvoiceId == Id select h).ToList();
                foreach (MedicalHistoryPractice medicalHistoryPractice in medicalHistoryPractices)
                {
                    medicalHistoryPractice.InvoiceId = null;
                }
            }
        }

        public static string GetInvoiceNumber(MedilabEntities context, Guid invoiceId)
        {
            var invoiceNumber = (from p in context.InvoiceHeader where p.InvoiceHeaderId == invoiceId select new { p.SalePoint, p.InvoiceNumber }).First();
            return String.Format("{0}-{1}",invoiceNumber.SalePoint.ToString("0000"), invoiceNumber.InvoiceNumber.ToString("00000000"));
        }

        private void UpdateItems(MedilabEntities context)
        {
            IEnumerable<InvoiceDetails> toMarkAsInvoiced = InvoicedPractices ?? Items;
            foreach (var invoiceDetail in toMarkAsInvoiced)
            {
                //If ExamTypeId is null then it is an additional item
                if (invoiceDetail.ExamTypeId.HasValue)
                {
                    if (invoiceDetail.GroupId.HasValue)
                    {
                        var practices =
                            ClinicalHistory.MedicalHistoryPractice.GetPracticesInGroup(invoiceDetail.MedicalHistoryId,
                                invoiceDetail.GroupId.Value);
                        foreach (var item in practices)
                        {
                            ClinicalHistory.MedicalHistoryPractice.MarkAsInvoiced(item.MedicalHistoryId, item.MedicalPracticeId, Id, context);
                        }
                    }
                    else
                    {
                        ClinicalHistory.MedicalHistoryPractice.MarkAsInvoiced(invoiceDetail.MedicalHistoryId, invoiceDetail.ItemId, Id, context);
                    }
                }
            }
        }

        internal static void UpdatePaymentInformation(MedilabEntities context, Guid invoiceId, double paymentAmount)
        {
            var invoice = (from i in context.InvoiceHeader where i.InvoiceHeaderId == invoiceId select i).First();
            double newBalance = Math.Round(invoice.InvoiceRemainder - paymentAmount, 2);
            if (newBalance < 0)
            {
                throw new InvalidOperationException(String.Format("El saldo de la factura Nº {0} es menor que el monto pagado", invoice.InvoiceNumber));
            }
            if (Math.Abs(newBalance) < 0.0001)
            {
                var user = Security.GetCurrentUser();
                Audit.Audit.LogAudit(context, user, ObjectTypes.Invoice, AuditOperations.Update, invoiceId, "Status: " + invoice.Status + " nuevo: Pagada");
                invoice.Status = (int)InvoiceStatus.Pagada;
            }
            invoice.InvoiceRemainder = newBalance;
        }
        #endregion
    }
}
