using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Medilab.BusinessObjects.Utils;

namespace Medilab.BusinessObjects.Invoice
{
    public class InvoiceToPrint
    {
        private readonly InvoiceHeader _invoice; 
        public InvoiceDetailType InvoiceDetailType { get; set; }
        public IPrintableInvoiceHeaderDto InvoiceHeader { get; set; }
        public IPrintableInvoiceDetail InvoiceDetail { get; set; }
        public List<InvoiceDetailDto> InvoiceItems { get; set; }
        public IPrintableInvoiceFooterDto InvoiceFooter { get; set; }

        public InvoiceToPrint(InvoiceHeader invoice)
        {
            _invoice = invoice;
            InvoiceDetailType = InvoiceTypeCalculator.CalculateInvoiceType(_invoice);
            LoadInvoiceHeader();
            LoadInvoiceItems();
            LoadInvoiceDetail();
            LoadInvoiceFooter();
        }

        private void LoadInvoiceHeader()
        {
            var headerDto = new InvoiceHeaderDto
                                             {
                                                 Date = _invoice.Date,
                                                 InvoiceId = _invoice.Id,
                                                 InvoiceType = _invoice.InvoiceType,
                                                 InvoiceNumberDisplay = _invoice.SalePoint.ToString("0000") + "-" + _invoice.InvoiceNumber.ToString("00000000"),
                                                 ClientName = _invoice.ClientInformation.Name,
                                                 ClientAddress = _invoice.ClientInformation.Addresses.First(a => a.IsDefault).ToString(),
                                                 IVACondition = EnumUtils.AddSpaceInCapitalLetter(_invoice.ClientInformation.IvaCondition.ToString()),
                                                 ClientCUIT = _invoice.ClientInformation.Cuit,
                                                 ClientNumber = _invoice.ClientInformation.ClientNumber.ToString(CultureInfo.InvariantCulture),
                                                 CAE = _invoice.CAE
                                             };
            InvoiceHeader = headerDto;
        }

        private void LoadInvoiceItems()
        {
            InvoiceItems = new List<InvoiceDetailDto>();
            foreach (InvoiceDetails detail in _invoice.Items)
            {
                InvoiceItems.Add(LoadDetailDto(detail));
            }

            //Load main item
            var mainItem = new InvoiceDetailDto();
            double mainPracticeTotal = _invoice.Items.Sum(detail => detail.Price);
            mainItem.MainPracticeTotal = mainPracticeTotal.ToString("#,###.00");
            //TODO add perceptions to total
            mainItem.MainTotal = mainPracticeTotal.ToString("#,###.00");

            InvoiceItems.Add(mainItem);
        }

        public List<InvoiceDetailDto> LoadInvoiceDetails()
        {
            InvoiceItems = new List<InvoiceDetailDto>();
            foreach (InvoiceDetails detail in _invoice.Items)
            {
                InvoiceItems.Add(LoadDetailDto(detail));
            }

            return InvoiceItems;
        }

        private void LoadInvoiceDetail()
        {
            switch (InvoiceDetailType)
            {
                case InvoiceDetailType.Free:
                    LoadFreeInvoiceDetail();
                    break;
                case InvoiceDetailType.FullDetail:
                    LoadFullInvoiceDetail();
                    break;
                case InvoiceDetailType.Resumed:
                    LoadResumedInvoiceDetail();
                    break;
            }
        }

        private void LoadFullInvoiceDetail()
        {
            var items = new Dictionary<string, List<InvoiceBodyDto>>();

            var itemGroups = _invoice.Items.GroupBy(p => p.PatientId, p => p, (key, g) => new { Items = g.ToList() });

            foreach (var itemGroup in itemGroups)
            {
                string patientFullName = itemGroup.Items[0].FullName;
                string patientName = string.IsNullOrWhiteSpace(patientFullName) ? string.Empty : patientFullName ;
                List<InvoiceBodyDto> bodyList =
                    itemGroup.Items.Select(detail => new InvoiceBodyDto
                                                         {
                                                             Description = detail.Description,
                                                             Quantity = detail.Quantity,
                                                             TotalPrice = ((detail.Quantity != 0 ? detail.Quantity : 1) * detail.Price),
                                                             UnitPrice = detail.Price
                                                         }).ToList();
                items.Add(patientName, bodyList);
            }

            InvoiceDetail = new FullInvoiceBodyDto {Items = items};
        }

        private void LoadFreeInvoiceDetail()
        {
            InvoiceDetail = new FreeInvoiceBodyDto
                                                 {
                                                     Description = _invoice.ManualDetailText,
                                                     Quantity = 1,
                                                     UnitPrice = _invoice.InvoiceType == InvoiceType.A ? _invoice.SubTotal : _invoice.Total,
                                                     TotalPrice = _invoice.InvoiceType == InvoiceType.A ? _invoice.SubTotal : _invoice.Total,
                                                 };
        }

        private void LoadResumedInvoiceDetail()
        {
            var items = new List<InvoiceBodyDto>();
            var groupedDetails = from p in _invoice.Items
                                 group p by p.Code
                                 into g
                                 select new {Code = g.Key, Practices = g.ToList()};

            foreach (var detail in groupedDetails)
            {
                var count = detail.Practices.Count;
                var price = detail.Practices.First().Price;
                items.Add(new InvoiceBodyDto
                              {
                                  Quantity = count,
                                  Description = detail.Practices.First().Description,
                                  UnitPrice = price,
                                  TotalPrice = (count * price)
                              });
            }

            InvoiceDetail = new ResumedInvoiceBodyDto { InvoiceDetails = items };
        }

        public void LoadInvoiceFooter()
        {
            var footer = new InvoiceFullFooterDto
            {
                Total = _invoice.Total.ToString("#,###.00"),
                SubTotal = _invoice.SubTotal.ToString("#,###.00"),
                InvoiceType = _invoice.InvoiceType,
                InvoiceRetentions = new List<InvoiceRetentionDto>()
            };
            foreach (InvoiceRetention invoiceRetention in _invoice.Retentions)
            {
                footer.InvoiceRetentions.Add(new InvoiceRetentionDto
                {
                    Name = invoiceRetention.Name,
                    RetentionValue = Math.Round(invoiceRetention.Value * _invoice.SubTotal / 100, 2),
                    Value = invoiceRetention.Value 
                });
            }

            InvoiceFooter = footer;
        }

        private InvoiceDetailDto LoadDetailDto(InvoiceDetails detail)
        {
            string examType = detail.ExamTypeId != null ? EnumUtils.AddSpaceInCapitalLetter(((ExamType)detail.ExamTypeId).ToString()) : string.Empty;
            var detailResult = new InvoiceDetailDto
                                                {
                                                    Date = detail.Date.ToString(CultureInfo.InvariantCulture), // _invoice.Date.ToString(CultureInfo.InvariantCulture),
                                                    PatientDocumentNumber = detail.PatientDocumentNumber,
                                                    PatientFirstLastName = detail.FullName,
                                                    ClientName = _invoice.ClientInformation.Name,
                                                    PracticePrice = detail.Price.ToString("#,###.00"),
                                                    //TODO add perceptions to total
                                                    PracticeTotal = detail.Price.ToString("#,###.00"),
                                                    InvoiceNumberDisplay = _invoice.SalePoint.ToString("0000") + "-" + _invoice.InvoiceNumber.ToString("00000000"),
                                                    PracticeDescription = detail.Description,
                                                    ExamType = examType
                                                };
            return detailResult;
        }
    }
}
