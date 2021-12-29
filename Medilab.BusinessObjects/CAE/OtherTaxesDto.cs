using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medilab.BusinessObjects.CAE
{
    public class OtherTaxesDto
    {
        private const int _longitudRegistro = 150;
        public int LongitudRegistro
        {
            get
            {
                return _longitudRegistro;
            }
        }
        private const int _tipoRegistro = 4;
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
        /// Longitud: 2
        /// </summary>
        public Enums.TipoTributo CodigoTributo { set; get; }
        /// <summary>
        /// Longitud: 80
        /// </summary>
        public string DescripcionTributo { set; get; }
        /// <summary>
        /// Longitud: 15
        /// </summary>
        public double BaseImponible { set; get; }
        /// <summary>
        /// Longitud: 15
        /// Mismo valor que HeaderInput.ImpuestoOtrosTributos
        /// </summary>
        public double ImpuestoOtrosTributos { set; get; }
        /// <summary>
        /// Longitud: 5
        /// </summary>
        public double Alicuota { set; get; }
    }
}
