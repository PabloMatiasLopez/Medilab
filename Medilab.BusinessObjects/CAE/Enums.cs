using Medilab.BusinessObjects.Utils;

namespace Medilab.BusinessObjects.CAE
{
    public class Enums
    {
        public enum TipoComprobante
        {
            FACTURAS_A = 1,
            NOTAS_DE_DEBITO_A = 2,
            NOTAS_DE_CREDITO_A = 3,
            RECIBOS_A = 4,
            NOTAS_DE_VENTA_AL_CONTADO_A = 5,
            FACTURAS_B = 6,
            NOTAS_DE_DEBITO_B = 7,
            NOTAS_DE_CREDITO_B = 8,
            RECIBOS_B = 9,
            NOTAS_DE_VENTA_AL_CONTADO_B = 10,
            FACTURAS_C = 11,
            NOTAS_DE_DEBITO_C = 12,
            NOTAS_DE_CREDITO_C = 13,
            DOCUMENTO_ADUANERO = 14,
            RECIBOS_C = 15,
            NOTAS_DE_VENTA_AL_CONTADO_C = 16,
            COMPROBANTE_NO_VALIDO = 99
        }

        public static TipoComprobante GetTipoComprobante(InvoiceType invoiceType)
        {
            switch (invoiceType)
            {
                case InvoiceType.A:
                    return TipoComprobante.FACTURAS_A;
                case InvoiceType.B:
                    return TipoComprobante.FACTURAS_B;
                case InvoiceType.ReciboA:
                    return TipoComprobante.RECIBOS_A;
                case InvoiceType.NotaCreditoA:
                    return TipoComprobante.NOTAS_DE_CREDITO_A;
                case InvoiceType.NotaCreditoB:
                    return TipoComprobante.NOTAS_DE_CREDITO_B;
                case InvoiceType.NotaDebitoA:
                    return TipoComprobante.NOTAS_DE_DEBITO_A;
                case InvoiceType.NotaDebitoB:
                    return TipoComprobante.NOTAS_DE_DEBITO_B;
                default:
                    return TipoComprobante.COMPROBANTE_NO_VALIDO;
            }
        }
        public static LetraComprobante GetLetraComprobante(InvoiceType invoiceType)
        {
            switch (invoiceType)
            {
                case InvoiceType.A:
                case InvoiceType.ReciboA:
                case InvoiceType.NotaCreditoA:
                case InvoiceType.NotaDebitoA:
                    return LetraComprobante.A;
                case InvoiceType.B:
                case InvoiceType.NotaCreditoB:
                case InvoiceType.NotaDebitoB:
                    return LetraComprobante.B;
                default:
                    return LetraComprobante.C;
            }
        }
        public static InvoiceType GetTipoCreditNote(NoteType creditNoteType)
        {
            switch (creditNoteType)
            {
                case NoteType.A:
                    return InvoiceType.NotaCreditoA;
                default:
                    return InvoiceType.NotaCreditoB;
            }
        }
        public static InvoiceType GetTipoDebitNote(NoteType debitNoteType)
        {
            switch (debitNoteType)
            {
                case NoteType.A:
                    return InvoiceType.NotaDebitoA;
                default:
                    return InvoiceType.NotaDebitoB;
            }
        }
        public static LetraComprobante GetLetraCreditNote(NoteType creditNoteType)
        {
            switch (creditNoteType)
            {
                case NoteType.A:
                   return LetraComprobante.A;
                case NoteType.B:
                    return LetraComprobante.B;
                default:
                    return LetraComprobante.C;
            }
        }
        public enum LetraComprobante
        {
            A,
            B,
            C
        }

        public enum Monedas
        {
            OTRAS_MONEDAS = 0,
            PESOS = 1,
            Dolar_Estadounidense = 999,
            Dolar_EEUU_LIBRE = 2,
            FRANCOS_FRANCESES = 3,
            LIRAS_ITALIANAS = 4,
            PESETAS = 5,
            MARCOS_ALEMANES = 6,
            FLORINES_HOLANDESES = 7,
            FRANCOS_BELGAS = 8,
            FRANCOS_SUIZOS = 9,
            PESOS_MEJICANOS = 10,
            PESOS_URUGUAYOS = 11,
            REAL = 12,
            ESCUDOS_PORTUGUESES = 13,
            CORONAS_DANESAS = 14,
            CORONAS_NORUEGAS = 15,
            CORONAS_SUECAS = 16,
            CHELINES_AUTRIACOS = 17,
            Dolar_CANADIENSE = 18,
            YENS = 19,
            LIBRA_ESTERLINA = 21,
            MARCOS_FINLANDESES = 22,
            BOLIVAR = 23,
            CORONA_CHECA = 24,
            DINAR = 25,
            oDólar_AUSTRALIANO = 26,
            DRACMA = 27,
            FLORIN = 28,
            GUARANI = 29,
            SHEKEL = 30,
            PESO_BOLIVIANO = 31,
            PESO_COLOMBIANO = 32,
            PESO_CHILENO = 33,
            RAND = 34,
            NUEVO_SOL_PERUANO = 35,
            SUCRE = 36,
            LEI_RUMANOS = 40,
            DERECHOS_ESPECIALES_DE_GIRO = 41,
            PESOS_DOMINICANOS = 42,
            BALBOAS_PANAMEÑAS = 43,
            CORDOBAS_NICARAGÛENSES = 44,
            DIRHAM_MARROQUIES = 45,
            LIBRAS_EGIPCIAS = 46,
            RIYALS_SAUDITAS = 47,
            BRANCOS_BELGAS_FINANCIERAS = 48,
            GRAMOS_DE_ORO_FINO = 49,
            LIBRAS_IRLANDESAS = 50,
            Dolar_DE_HONG_KONG = 51,
            Dolar_DE_SINGAPUR = 52,
            Dolar_DE_JAMAICA = 53,
            Dolar_DE_TAIWAN = 54,
            QUETZAL = 55,
            FORINT = 56,
            BAHT = 57,
            ECU = 58,
            DINAR_KUWAITI = 59,
            EURO = 60,
            ZLTYS_POLACOS = 61,
            RUPIAS_HINDUES = 62,
            LEMPIRAS_HONDUREÑAS = 63,
            YUAN = 64
        }

        public enum Concepto
        {
            Productos = 1,
            Servicios = 2,
            Produtos_y_Servicios = 3
        }

        public enum TipoIva
        {
            No_Gravado = 1,
            Exento = 2,
            Cero = 3,
            DiezPuntoCinco = 4,
            Veintiuno = 5,
            Veintisiete = 6
        }

        public enum TipoTributo
        {
            Impuestos_nacionales = 1,
            Impuestos_provinciales = 2,
            Impuestos_municipales = 3,
            Impuestos_internos = 4,
            Otros = 99
        }

        public static string GetDocumentName(TipoComprobante tipoComprobante)
        {
            switch (tipoComprobante)
            {
                    case TipoComprobante.FACTURAS_A:
                        return "Factura A";
                    case TipoComprobante.FACTURAS_B:
                        return "Factura B";
                    case TipoComprobante.NOTAS_DE_DEBITO_A:
                        return "Nota de Débito A";
                    case TipoComprobante.NOTAS_DE_DEBITO_B:
                        return "Nota de Débito B";
                    default: return "Factura A";
            }
        }
    }
}
