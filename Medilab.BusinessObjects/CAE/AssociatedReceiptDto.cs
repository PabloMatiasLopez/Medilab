using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medilab.BusinessObjects.CAE
{
    public class AssociatedReceiptDto
    {
        private const int _longitudRegistro = 48;
        public int LongitudRegistro
        {
            get
            {
                return _longitudRegistro;
            }
        }
        private const int _tipoRegistro = 5;
        /// <summary>
        /// Longitud: 1
        /// </summary>
        public int TipoRegistro
        {
            get
            {
                return _tipoRegistro;
            }
        }
        /// <summary>
        /// Informacion de los datos comunes de la factura
        /// </summary>
        public InvoiceDataDto InvoiceData { set; get; }
        /// <summary>
        /// Longitud: 3
        /// </summary>
        public Enums.TipoComprobante TipoDelComprobanteAsociado { set; get; }
        /// <summary>
        /// Longitud: 4
        /// Entre 1 y 9998
        /// </summary>
        public int PuntoVentaAsociado { set; get; }
        /// <summary>
        /// Longitud: 8
        /// </summary>
        public int NumeroComprobanteAsociado { set; get; }
    }
}
