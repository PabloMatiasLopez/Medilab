
namespace Medilab.BusinessObjects.CAE
{
    public class InvoiceDataDto
    {
        private const string _identificadorOriginal = "ORIGINAL";
        /// <summary>
        /// Longitud: 8
        /// </summary>
        public string IdentificadorOriginal
        {
            get
            {
                return _identificadorOriginal;
            }
        }
        /// <summary>
        /// Longitud: 8
        /// Formato AAAAMMDD 
        /// </summary>
        public string FechaComprobante { set; get; }
        /// <summary>
        /// Longitud: 3
        /// </summary>
        public Enums.TipoComprobante TipoDelComprobante { set; get; }
        /// <summary>
        /// Longitud: 1
        /// </summary>
        public Enums.LetraComprobante LetraDelComprobante { set; get; }
        /// <summary>
        /// Longitud: 4
        /// Entre 1 y 9998
        /// </summary>
        public int PuntoVenta { set; get; }
        /// <summary>
        /// Longitud: 8
        /// </summary>
        public int NumeroComprobante { set; get; }
    }
}
