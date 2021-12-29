using Medilab.BusinessObjects.CAE;

namespace Medilab.BusinessObjects.Siap
{
    public class ComprobanteIVADto
    {
        private const int _longitudRegistro = 266;
        private const string _importeCero = "000000000000000";
        public int LongitudRegistro
        {
            get
            {
                return _longitudRegistro;
            }
        }
        /// <summary>
        /// Longitud: 8
        /// Formato: AAAAMMDD
        /// </summary>
        public string FechaComprobante { set; get; }
        /// <summary>
        /// Longitud: 3
        /// </summary>
        public Enums.TipoComprobante TipoDelComprobante { set; get; }
        /// <summary>
        /// Longitud: 5
        /// Entre 1 y 9998
        /// </summary>
        public int PuntoVenta { set; get; }
        /// <summary>
        /// Longitud: 20
        /// </summary>
        public int NumeroComprobante { set; get; }
        /// <summary>
        /// Longitud: 20
        /// </summary>
        public int NumeroComprobanteHasta 
        { 
            get
            {
                return NumeroComprobante;
            }
        }
        /// <summary>
        /// Longitud: 2
        /// </summary>
        public Utils.DocumentType CodigoDocumentoComprador { set; get; }
        /// <summary>
        /// Longitud: 20
        /// Formato: completar con 0 a la izquierda
        /// </summary>
        public string NumeroDocumentoComprador { set; get; }
        private string _nombreComprador;
        /// <summary>
        /// Longitud: 30
        /// </summary>
        public string NombreComprador 
        {
            set
            {
                _nombreComprador = value;
            }
            get
            {
                if (string.IsNullOrEmpty( _nombreComprador))
                {
                    return string.Empty;
                }
                if (_nombreComprador.Length > 30)
                {
                    return _nombreComprador.Remove(30);
                }
                return _nombreComprador;
            }
        }
        /// <summary>
        /// Longitud: 15 
        /// Formato: 13 enteros, 2 decimales
        /// </summary>
        public double ImporteTotal { set; get; }
        /// <summary>
        /// Longitud: 15 
        /// Formato: 13 enteros, 2 decimales
        /// Todo cero
        /// </summary>
        public string ImporteConceptosNoNetoGravado
        {
            get
            {
                return _importeCero;
            }
        }
        /// <summary>
        /// Longitud: 15 
        /// Formato: 13 enteros, 2 decimales
        /// Todo cero
        /// </summary>
        public string ImportePercepcionNoCategorizados
        {
            get
            {
                return _importeCero;
            }
        }
        /// <summary>
        /// Longitud: 15 
        /// Formato: 13 enteros, 2 decimales
        /// Todo cero
        /// </summary>
        public string ImporteOperacionesExentas
        {
            get
            {
                return _importeCero;
            }
        }
        /// <summary>
        /// Longitud: 15 
        /// Formato: 13 enteros, 2 decimales
        /// Todo cero
        /// </summary>
        public string ImportePagosACuentaImpuestosNacionales
        {
            get
            {
                return _importeCero;
            }
        }
        /// <summary>
        /// Longitud: 15 
        /// Formato: 13 enteros, 2 decimales
        /// Todo cero
        /// </summary>
        public string ImporteIngresosBrutos
        {
            get
            {
                return _importeCero;
            }
        }
        /// <summary>
        /// Longitud: 15 
        /// Formato: 13 enteros, 2 decimales
        /// Todo cero
        /// </summary>
        public string ImporteImpuestosMunicipales
        {
            get
            {
                return _importeCero;
            }
        }
        /// <summary>
        /// Longitud: 15 
        /// Formato: 13 enteros, 2 decimales
        /// Todo cero
        /// </summary>
        public string ImporteImpuestosInternos
        {
            get
            {
                return _importeCero;
            }
        }
        /// <summary>
        /// Longitud: 3 
        /// </summary>
        public string CodigoMoneda
        {
            get
            {
                return "PES";
            }
        }
        /// <summary>
        /// Longitud: 10
        /// </summary>
        public string TipoCambio
        {
            get
            {
                return "0001000000";
            }
        }
        /// <summary>
        /// Longitud: 1
        /// </summary>
        public string CantidadAlicuotas
        {
            get
            {
                return "1";
            }
        }
        /// <summary>
        /// Longitud: 1
        /// </summary>
        public string CodigoOperacion
        {
            get
            {
                return "0";
            }
        }
        /// <summary>
        /// Longitud: 15 
        /// Formato: 13 enteros, 2 decimales
        /// Todo cero
        /// </summary>
        public string OtrosTributos
        {
            get
            {
                return _importeCero;
            }
        }
        private string _fechaVencimientoPago;
        /// <summary>
        /// Longitud: 8
        /// Formato: AAAAMMDD
        /// </summary>
        public string FechaVencimientoPago
        {
            set
            {
                _fechaVencimientoPago = value;
            }
            get
            {
                return _fechaVencimientoPago ?? string.Empty;
            }
        }
    }
}
