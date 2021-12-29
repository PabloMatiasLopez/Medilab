
using System.Collections.Generic;
namespace Medilab.BusinessObjects.CAE
{
    public class CAEInputFileDto
    {
        public CAEInputFileDto()
        {
            Iva = new List<IvaDto>();
            OtherTaxes = new List<OtherTaxesDto>();
        }
        public WebServerTypeDto WebServerType { set; get; }
        public InvoiceDataDto InvoiceData { set; get; }
        public HeaderInputDto Header { set; get; }
        public List<IvaDto> Iva { set; get; }
        public List<OtherTaxesDto> OtherTaxes { set; get; }
        public AssociatedReceiptDto AssociatedReceipt { set; get; }
        public OptionalDto Optional { set; get; }
        public string InputFolderPath { set; get; }
    }
}
