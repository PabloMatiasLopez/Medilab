using System;
using System.Globalization;
using System.Linq;
using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.Utils;

namespace Medilab.BusinessObjects.Invoice
{
    public class InvoiceBHeader : IHeaderDisplayable
    {
        private INextInvoiceNumber _nextInvoiceNumber;
        public InvoiceHeaderDto HeaderB { private set; get; }

        public InvoiceBHeader(INextInvoiceNumber nextInvoiceNumber)
        {
            _nextInvoiceNumber = nextInvoiceNumber;
        }

        public void LoadHeader(Client client)
        {
            HeaderB = LoadClientInformation(client);
            HeaderB.Date = DateTime.Today;
            HeaderB.InvoiceType = InvoiceType.B;
            HeaderB.InvoiceNumberDisplay = _nextInvoiceNumber.GetNextInvoiceNumberDisplay(InvoiceType.B);
        }

        public InvoiceHeaderDto GetHeader()
        {
            return HeaderB;
        }
        private InvoiceHeaderDto LoadClientInformation(Client client)
        {
            var headerDto = new InvoiceHeaderDto
            {
                ClientName = client.Name,
                ClientNumber = client.ClientNumber.ToString(CultureInfo.InvariantCulture),
                ClientCUIT = client.Cuit,
                IVACondition = EnumUtils.AddSpaceInCapitalLetter(client.IvaCondition.ToString()),
                SellCondition = @"Contado"
            };
            var defaultAddres = (from ad in client.Addresses where ad.IsDefault select ad).First();
            headerDto.ClientAddress = defaultAddres.ToString();
            return headerDto;
        }
    }
}
