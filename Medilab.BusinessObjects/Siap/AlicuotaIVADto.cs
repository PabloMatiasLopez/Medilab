using Medilab.BusinessObjects.CAE;

namespace Medilab.BusinessObjects.Siap
{
    public class AlicuotaIVADto
    {
        private const int _longitudRegistro = 62;
        public int LongitudRegistro
        {
            get
            {
                return _longitudRegistro;
            }
        }
        /// <summary>
        /// Longitud: 15
        /// Formato: 13 enteros, 2 decimales sin punto
        /// </summary>
        public double ImporteNetoGravado { set; get; }
        /// <summary>
        /// Longitud: 4
        /// </summary>
        public Enums.TipoIva AlicuotaIVA { set; get; }
        /// <summary>
        /// Longitud: 15
        /// Mismo valor que HeaderInput.ImporteIVA
        /// </summary>
        public double ImporteIva { set; get; }
    }
}
