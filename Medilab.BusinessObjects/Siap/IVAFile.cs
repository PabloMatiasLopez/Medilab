using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Medilab.BusinessObjects.Siap
{
    public class IVAFile
    {
        private IEnumerable<RegistroIvaDto> _registrosIVA;
        public IVAFile(IEnumerable<RegistroIvaDto> registrosIVA)
        {
            _registrosIVA = registrosIVA;
        }

        private string ProcessComprobante(ComprobanteIVADto comprobante)
        {
            var line = new StringBuilder();
            line.Append(comprobante.FechaComprobante);
            line.Append(((int)comprobante.TipoDelComprobante).ToString(Utils.FormatForString.IntNumber(3)));
            line.Append(comprobante.PuntoVenta.ToString(Utils.FormatForString.IntNumber(5)));
            line.Append(comprobante.NumeroComprobante.ToString(Utils.FormatForString.IntNumber(20)));
            line.Append(comprobante.NumeroComprobanteHasta.ToString(Utils.FormatForString.IntNumber(20)));
            line.Append(((int)comprobante.CodigoDocumentoComprador).ToString(Utils.FormatForString.IntNumber(2)));
            line.Append(comprobante.NumeroDocumentoComprador.Trim().PadLeft(20, '0'));
            line.Append(FormatForString.CleanText(comprobante.NombreComprador, true).PadLeft(30));
            line.Append(comprobante.ImporteTotal.ToString(Utils.FormatForString.FloatNumberTwoDecimals(15)).Replace(".", "").Replace(",", "").PadLeft(15, '0'));
            line.Append(comprobante.ImporteConceptosNoNetoGravado);
            line.Append(comprobante.ImportePercepcionNoCategorizados);
            line.Append(comprobante.ImporteOperacionesExentas);
            line.Append(comprobante.ImportePagosACuentaImpuestosNacionales);
            line.Append(comprobante.ImporteIngresosBrutos);
            line.Append(comprobante.ImporteImpuestosMunicipales);
            line.Append(comprobante.ImporteImpuestosInternos);
            line.Append(comprobante.CodigoMoneda);
            line.Append(comprobante.TipoCambio);
            line.Append(comprobante.CantidadAlicuotas);
            line.Append(comprobante.CodigoOperacion);
            line.Append(comprobante.OtrosTributos);
            line.Append(comprobante.FechaVencimientoPago.PadLeft(8, '0'));
            if (line.Length == comprobante.LongitudRegistro)
            {
                return line.ToString();
            }
            throw new Exception("Comprobante: La longitud no coincide: " + line.Length);
        }
        private string ProcessAlicuota(RegistroIvaDto registro)
        {
            var comprobante = registro.Comprobante;
            var alicuota = registro.Alicuota;

            var line = new StringBuilder();
            line.Append(((int)comprobante.TipoDelComprobante).ToString(Utils.FormatForString.IntNumber(3)));
            line.Append(comprobante.PuntoVenta.ToString(Utils.FormatForString.IntNumber(5)));
            line.Append(comprobante.NumeroComprobante.ToString(Utils.FormatForString.IntNumber(20)));
            line.Append(alicuota.ImporteNetoGravado.ToString(Utils.FormatForString.FloatNumberTwoDecimals(15)).Replace(".", "").Replace(",", "").PadLeft(15, '0')); ;
            line.Append(((int)alicuota.AlicuotaIVA).ToString(Utils.FormatForString.IntNumber(4)));
            line.Append(alicuota.ImporteIva.ToString(Utils.FormatForString.FloatNumberTwoDecimals(15)).Replace(".", "").Replace(",", "").PadLeft(15, '0'));

            if (line.Length == alicuota.LongitudRegistro)
            {
                return line.ToString();
            }
            throw new Exception("Comprobante: La longitud no coincide: " + line.Length);
        }

        public void CreateFiles()
        {
            var comprobanteFileName = @"D:\Temp\ComprobateIVA.txt";
            var alicuotaFileName = @"D:\Temp\AlicuotaIVA.txt";
            try
            {
                var comprobanteFile = new StreamWriter(comprobanteFileName, true);
                var alicuotaFile = new StreamWriter(alicuotaFileName, true);
                foreach (var registro in _registrosIVA)
                {
                    comprobanteFile.WriteLine(ProcessComprobante(registro.Comprobante));
                    alicuotaFile.WriteLine(ProcessAlicuota(registro));
                }
                comprobanteFile.Close();
                alicuotaFile.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
