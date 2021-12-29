using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medilab.BusinessObjects.CAE
{
    /// <summary>
    /// All information needed for IVA details
    /// </summary>
    public class IvaDto
    {
        private const int _longitudRegistro = 65;
        public int LongitudRegistro
        {
            get
            {
                return _longitudRegistro;
            }
        }
        private const int _tipoRegistro = 3;
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
        public Enums.TipoIva CodigoIva { set; get; }
        /// <summary>
        /// Longitud: 15
        /// Mismo valor que HeaderInput.ImporteIVA
        /// </summary>
        public double ImporteIva { set; get; }
        /// <summary>
        /// Longitud: 15
        /// Mismo valor que HeaderInput.ImporteNetoGravado
        /// </summary>
        public double ImporteNetoGravado { set; get; }
    }
}
