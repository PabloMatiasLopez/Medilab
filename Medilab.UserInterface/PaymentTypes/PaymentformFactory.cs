using Medilab.BusinessObjects.Utils;

namespace Medilab.UserInterface.PaymentTypes
{
    public class PaymentFormFactory
    {
        private static PaymentFormFactory _instance;
        public static PaymentFormFactory Instace {
            get { return _instance ?? (_instance = new PaymentFormFactory()); }
        }

        public frmPayment GetPaymentForm(PaymentType type, bool readOnly = false)
        {
            switch (type)
            {
                case PaymentType.Efectivo:
                    return new frmCash(readOnly);
                case PaymentType.Cheque:
                    return new frmCheck(readOnly);
                case PaymentType.TransferenciaElectrónica:
                    return new frmElectronicTransfer(readOnly);
                case PaymentType.CertificadoRetención:
                    return new frmRetention(readOnly);
                case PaymentType.NotaCredito:
                    return new frmCreditNotePayment(readOnly);
                default:
                    return new frmCash(readOnly);
            }
        }
    }
}
