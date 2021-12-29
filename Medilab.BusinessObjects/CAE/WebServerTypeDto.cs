using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medilab.BusinessObjects.CAE
{
    /// <summary>
    /// All needed properties to configure the web service to use
    /// </summary>
    public class WebServerTypeDto
    {
        private const int _longitudRegistro = 3;
        /// <summary>
        /// Longitud: 1
        /// </summary>
        public const int TipoRegistro = 0;
        /// <summary>
        /// Longitud: 2
        /// </summary>
        public int WebService { set; get; }
        public override string ToString()
        {
            return TipoRegistro.ToString() + WebService.ToString(Utils.FormatForString.IntNumber(2));
        }
    }
}
