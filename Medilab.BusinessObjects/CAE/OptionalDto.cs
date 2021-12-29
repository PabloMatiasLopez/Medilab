using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medilab.BusinessObjects.CAE
{
    public class OptionalDto
    {
        private const int _longitudRegistro = 136;
        public int LongitudRegistro
        {
            get
            {
                return _longitudRegistro;
            }
        }
        private const int _tipoRegistro = 6;
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
        public int CodigoOpcional { set; get; }
        /// <summary>
        /// Longitud: 100
        /// </summary>
        public double Valor { set; get; }
    }
}
