using System;
using System.Globalization;
using System.Linq;
using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.Utils;

namespace Medilab.BusinessObjects.Invoice
{
    public class InvoiceAHeader : IHeaderDisplayable
    {
        private INextInvoiceNumber _nextInvoiceNumber;
        public InvoiceHeaderDto HeaderA { private set; get; }

        public InvoiceAHeader(INextInvoiceNumber nextInvoiceNumber)
        {
            _nextInvoiceNumber = nextInvoiceNumber;
        }
        public void LoadHeader(Client client)
        {
            HeaderA = LoadClientInformation(client);
            HeaderA.Date = DateTime.Today;
            HeaderA.InvoiceType = InvoiceType.A;
            HeaderA.InvoiceNumberDisplay = _nextInvoiceNumber.GetNextInvoiceNumberDisplay(InvoiceType.A);
        }

        public InvoiceHeaderDto GetHeader()
        {
            return HeaderA;
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
