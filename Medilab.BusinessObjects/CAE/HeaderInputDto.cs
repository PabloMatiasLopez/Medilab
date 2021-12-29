using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medilab.BusinessObjects.CAE;

namespace Medilab.BusinessObjects.CAE
{
    /// <summary>
    /// All needed fields for invoice header
    /// </summary>
    public class HeaderInputDto
    {
        private const int _longitudRegistro = 3116;
        public int LongitudRegistro
        {
            get
            {
                return _longitudRegistro;
            }
        }
        private const int _tipoRegistro = 1;
        /// <summary>
        /// Longitud: 1
        /// </summary>
        public int TipoRegistro
        {
            get { return _tipoRegistro; }
        }
        /// <summary>
        /// Informacion de los datos comunes de la factura
        /// </summary>
        public InvoiceDataDto InvoiceData { set; get; }
        private const string _codigoTipoAutorizacion = "E";
        /// <summary>
        /// Longitud: 1
        /// </summary>
        public string CodigoTipoAutorizacion
        {
            get
            {
                return _codigoTipoAutorizacion;
            }
        }
        /// <summary>
        /// Longitud: 2
        /// </summary>
        public Utils.DocumentType CodigoDocumentoComprador { set; get; }
        /// <summary>
        /// Longitud: 11
        /// </summary>
        public long NumeroDocumentoComprador { set; get; }
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
        /// Longitud: 2
        /// </summary>
        public int CondicionIVAComprador { set; get; }
        private string _calleComprador;
        /// <summary>
        /// Longitud: 30
        /// </summary>
        public string CalleComprador
        {
            set
            {
                _calleComprador = value;
            }
            get
            {
                if (string.IsNullOrEmpty(_calleComprador))
                {
                    return string.Empty;
                }
                if (_calleComprador.Length > 30)
                {
                    return _calleComprador.Remove(30);
                }
                return _calleComprador;
            }
        }
        private string _numeroCalleComprador;
        /// <summary>
        /// Longitud: 6
        /// </summary>
        public string NumeroCalleComprador
        {
            set
            {
                _numeroCalleComprador = value;
            }
            get
            {
                if (string.IsNullOrEmpty(_numeroCalleComprador))
                {
                    return string.Empty;
                }
                if (_numeroCalleComprador.Length > 6)
                {
                    return _numeroCalleComprador.Remove(6);
                }
                return _numeroCalleComprador;
            }
        }
        private string _pisoDomicilioComprador;
        /// <summary>
        /// Longitud: 5
        /// </summary>
        public string PisoDomicilioComprador
        {
            set
            {
                _pisoDomicilioComprador = value;
            }
            get
            {
                if (string.IsNullOrEmpty(_pisoDomicilioComprador))
                {
                    return string.Empty;
                }
                if (_pisoDomicilioComprador.Length > 5)
                {
                    return _pisoDomicilioComprador.Remove(5);
                }
                return _pisoDomicilioComprador;
            }
        }
        private string _departamentoDomicilioComprador;
        /// <summary>
        /// Longitud: 5
        /// </summary>
        public string DepartamentoDomicilioComprador 
        {
            set
            {
                _departamentoDomicilioComprador = value;
            }
            get
            {
                if (string.IsNullOrEmpty(_departamentoDomicilioComprador))
                {
                    return string.Empty;
                }
                if (_departamentoDomicilioComprador.Length > 5)
                {
                    return _departamentoDomicilioComprador.Remove(5);
                }
                return _departamentoDomicilioComprador;
            }
        }
        private string _sectorDomicilioComprador;
        /// <summary>
        /// Longitud: 5
        /// </summary>
        public string SectorDomicilioComprador 
        {
            set
            {
                _sectorDomicilioComprador = value;
            }
            get
            {
                if (string.IsNullOrEmpty(_sectorDomicilioComprador))
                {
                    return string.Empty;
                }
                if (_sectorDomicilioComprador.Length > 5)
                {
                    return _sectorDomicilioComprador.Remove(5);
                }
                return _sectorDomicilioComprador;
            }
        }
        private string _torreDomicilioComprador;
        /// <summary>
        /// Longitud: 5
        /// </summary>
        public string TorreDomicilioComprador 
        {

            set
            {
                _torreDomicilioComprador = value;
            }
            get
            {
                if (string.IsNullOrEmpty(_torreDomicilioComprador))
                {
                    return string.Empty;
                }
                if (_torreDomicilioComprador.Length > 5)
                {
                    return _torreDomicilioComprador.Remove(5);
                }
                return _torreDomicilioComprador;
            }
        }
        private string _manzanaDomicilioComprador;
        /// <summary>
        /// Longitud: 5
        /// </summary>
        public string ManzanaDomicilioComprador 
        {
            set
            {
                _manzanaDomicilioComprador = value;
            }
            get
            {
                if (string.IsNullOrEmpty(_manzanaDomicilioComprador))
                {
                    return string.Empty;
                }
                if (_manzanaDomicilioComprador.Length > 5)
                {
                    return _manzanaDomicilioComprador.Remove(5);
                }
                return _manzanaDomicilioComprador;
            }
        }
        /// <summary>
        /// Longitud: 2
        /// </summary>
        public int ProvinciaDomicilioComprador { set; get; }
        private string _codigoPostalComprador;
        /// <summary>
        /// Longitud: 8
        /// </summary>
        public string CodigoPostalComprador 
        {
            set
            {
                _codigoPostalComprador = value;
            }
            get
            {
                if (string.IsNullOrEmpty(_codigoPostalComprador))
                {
                    return string.Empty;
                }
                if (_codigoPostalComprador.Length > 8)
                {
                    return _codigoPostalComprador.Remove(8);
                }
                return _codigoPostalComprador;
            }
        }
        private string _localidadDomicilioComprador;
        /// <summary>
        /// Longitud: 25
        /// </summary>
        public string LocalidadDomicilioComprador 
        {
            set
            {
                _localidadDomicilioComprador = value;
            }
            get
            {
                if (string.IsNullOrEmpty(_localidadDomicilioComprador))
                {
                    return string.Empty;
                }
                if (_localidadDomicilioComprador.Length > 25)
                {
                    return _localidadDomicilioComprador.Remove(25);
                }
                return _localidadDomicilioComprador;
            }
        }
        /// <summary>
        /// Longitud: 15
        /// </summary>
        public double ImporteTotalOperacion { set; get; }
        /// <summary>
        /// Longitud: 15
        /// </summary>
        public double ImporteNetoNoGravado { set; get; }
        /// <summary>
        /// Longitud: 15
        /// </summary>
        public double ImporteNetoGravado { set; get; }
        /// <summary>
        /// Longitud: 15
        /// </summary>
        public double ImpuestoOtrosTributos { set; get; }
        /// <summary>
        /// Longitud: 15
        /// </summary>
        public double ImporteOperacionesExternas { set; get; }
        /// <summary>
        /// Longitud: 15
        /// </summary>
        public double ImporteSubtotal { set; get; }
        /// <summary>
        /// Longitud: 15
        /// </summary>
        public double ImporteIVA { set; get; }
        private string _fechaDesdeServicio;
        /// <summary>
        /// Longitud: 8
        /// Formato: AAAAMMDD
        /// </summary>
        public string FechaDesdeServicio 
        {
            set
            {
                _fechaDesdeServicio = value;
            }
            get
            {
                return _fechaDesdeServicio ?? string.Empty;
            }
        }
        private string _fechaHastaServicio;
        /// <summary>
        /// Longitud: 8
        /// Formato: AAAAMMDD
        /// </summary>
        public string FechaHastaServicio 
        {
            set
            {
                _fechaHastaServicio = value;
            }
            get
            {
                return _fechaHastaServicio ?? string.Empty;
            }
        }
        /// <summary>
        /// Longitud: 3
        /// </summary>
        public Enums.Monedas TipoMoneda { set; get; }
        public string TipoMonedaArchivo
        {
            get
            {
                switch (TipoMoneda)
                {
                    case Enums.Monedas.PESOS:
                        return "PES";
                    case Enums.Monedas.Dolar_Estadounidense:
                        return "DOL";
                    default:
                        return ((int)TipoMoneda).ToString(Utils.FormatForString.IntNumber(3));
                }
            }
        }
        /// <summary>
        /// Longitud: 10
        /// </summary>
        public double TipoCambio { set; get; }
        /// <summary>
        /// Longitud: 2
        /// </summary>
        public Enums.Concepto CodigoConcepto { set; get; }
        /// <summary>
        /// Longitud: 8
        /// Formato: AAAAMMDD
        /// </summary>
        private string _fechaVencimientoComprobante;
        public string FechaVencimietoComprobante 
        {
            set 
            {
                _fechaVencimientoComprobante = value;
            }
            get
            {
                return _fechaVencimientoComprobante ?? string.Empty;
            }
        }
        private string _emailCliente;
        /// <summary>
        /// Longitud: 170
        /// </summary>
        public string EmailCliente 
        {
            set
            {
                _emailCliente = value;
            }
            get
            {
                if (string.IsNullOrEmpty(_emailCliente))
                {
                    return string.Empty;
                }
                if (_emailCliente.Length > 170)
                {
                    return _emailCliente.Remove(170);
                }
                return _emailCliente;
            }
        }
        private string _observaciones;
        /// <summary>
        /// Longitud: 2000
        /// </summary>
        public string Observaciones 
        {
            set
            {
                _observaciones = value;
            }
            get
            {
                if (string.IsNullOrEmpty(_observaciones))
                {
                    return string.Empty;
                }
                if (_observaciones.Length > 200)
                {
                    return _observaciones.Remove(200);
                }
                return _observaciones;
            }
        }
        private const int _webService = 2;
        /// <summary>
        /// Longitud: 2
        /// </summary>
        public int WebService
        {
            get
            {
                return _webService;
            }
        }

        private string _codigoAutorizacion = new string(' ', 14);
        /// <summary>
        /// Longitud: 14
        /// </summary>
        public string CodigoAutorizacion
        {
            get { return _codigoAutorizacion; }
        }
        private string _codigoAutorizacionElectronica;
        /// <summary>
        /// Longitud: 14
        /// </summary>
        public string CodigoAutorizacionElectronica 
        {
            set
            {
                _codigoAutorizacionElectronica = value;
            }
            get
            {
                return _codigoAutorizacionElectronica ?? string.Empty;
            }
        }
        private string _fechaVencimientoCAE;
        /// <summary>
        /// Longitud: 8
        /// Formato: AAAAMMDD
        /// </summary>
        public string FechaVencimientoCAE 
        {
            set
            {
                _fechaVencimientoCAE = value;
            }
            get
            {
                return _fechaVencimientoCAE ?? string.Empty;
            }
        }
        /// <summary>
        /// No se usan
        /// </summary>
        private string _codigoCreditoFiscal = new string(' ', 8);
        private string _codigoError = new string(' ', 30);
        private string _descripcionError = new string(' ', 550);
        private string _reprocesar = new string(' ', 1);
        public string Filler
        {
            get
            {
                return _codigoCreditoFiscal + _codigoError + _descripcionError + _reprocesar;
            }
        }
        
    }
}
