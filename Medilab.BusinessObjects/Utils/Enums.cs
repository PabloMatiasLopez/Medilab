
using Medilab.BusinessObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medilab.BusinessObjects.Utils
{
    public enum ObjectTypes
    {
        User = 1,
        Role = 2,
        CompanyInfo = 3,
        Patient = 4,
        MedicalHistory = 5,
        Client = 6,
        PrivateMedicineCompany = 7,
        Address = 8,
        WorkRiskInsurance = 9,
        ClinicalExam = 10,
        Speciality = 11,
        MedicalPractice = 12,
        Group = 13,
        ClientArea = 14,
        PracticeGroupPrice = 15,
        AditionalItem = 16,
        FiscalRetention = 17,
        InvoiceProfile = 18,
        Invoice = 19,
        Receipt = 20
    }

    public enum AuditOperations
    {
        Insert,
        Update,
        Delete,
        Authorize
    }

    public enum Privileges
    {
        Configuracion,
        Administracion,
        AtencionPacientes,
        HistoriasClinicas,
        Facturacion,
        EditarFactura
        //Pacientes
        //Empresas,
        //Estudios
    }

    public enum Gender
    {
        Male = 1,
        Female = 2
    }

    public enum CivilState
    {
        Soltero = 1,
        Casado = 2,
        Divorciado = 3,
        Viudo = 4
    }

    public enum Instruction
    {
        Primario = 1,
        Secundario = 2,
        Terciario = 3,
        Universitario = 4
    }

    public enum DocumentType
    {
        CI_Policia_Federal = 0,
        CI_Buenos_Aires = 1,
        CI_Catamarca = 2,
        CI_Cordoba = 3,
        CI_Corrientes = 4,
        CI_Entre_Rios = 5,
        CI_Jujuy = 6,
        CI_Mendoza = 7,
        CI_La_Rioja = 8,
        CI_Salta = 9,
        CI_San_Juan = 10,
        CI_San_Luis = 11,
        CI_Santa_Fe = 12,
        CI_Santiago_del_Estero = 13,
        CI_Tucuman = 15,
        CI_Chaco = 16,
        CI_Chubut = 17,
        CI_Formosa = 18,
        CI_Misiones = 19,
        CI_Neuquen = 20,
        CI_La_Pampa = 21,
        CI_Rio_Negro = 22,
        CI_Santa_Cruz = 23,
        CI_Tierra_del_Fuego = 24,
        CUIT = 80,
        CUIL = 86,
        CDI = 87,
        LE = 89,
        LC = 90,
        CI_extranjera = 91,
        en_tramite = 92,
        Acta_nacimiento = 93,
        Pasaporte = 94,
        CI_Buenos_Aires_RNP = 95,
        DNI = 96,
        Sin_identificar_venta_global_diaria = 99,
        Certificado_de_Migración = 30,
        Usado_por_Anses_para_Padron = 88
    }

    public enum AddressType
    {
        Legal = 1,
        Casa = 2,
        Trabajo = 3
    }

    public enum ExamType
    {
        PreIngreso = 1,
        Egreso = 2,
        Periódico = 3,
        PreTransferencial = 4,
        LibretaSanitaria = 5,
        Otros = 6
    }

    public enum ClinicalExamResult
    {
        Normal = 1,
        Patológico = 2,
        NoEvaluado = 3 //no efectuado
    }

    public enum ClinicalHistoryStatus
    {
        Incompleta = 1,
        Realizada = 2,
        Completa = 3,
        Evaluada = 4
    }

    public enum ClinicalExamStatus
    {
        Incompleto = 1,
        Realizada = 2,
        Completa = 3,
        //CompletaManual = 4,
        Cancelada = 5
    }

    public enum ClinicaHistoryResult
    {
        Periodico = 0,
        Apto = 1,
        AptoConPreExistencia = 2,
        NoAptoParaLaTareaPropuesta = 3,
        NoEvaluado = 4,
        SinPatologíaPrevia = 5,
        ConPatologíaPrevia = 6,
        ConPatologíaAdquiridaEnElTrabajo = 7
    }

    public enum CompanyName
    {
        Formato = 0,
        Asismed = 1,
        Labomed = 2,
        Movilmed = 3
    }

    public enum HashType
    {
        // ReSharper disable InconsistentNaming
        SHA1 = 0,
        SHA256 = 1,
        SHA384 = 2,
        SHA512 = 4,
        MD5 = 5
        // ReSharper restore InconsistentNaming
    }

    public enum SecurityAreas
    {
        Configuration,
        MedicalAttention,
        ClinicalHistory,
        Administration,
        Invoice,
        EditInvoice
    }

    public enum Iva
    {
        IVA_Responsable_Inscripto = 1,
        IVA_Responsable_No_Inscripto = 2,
        IVA_No_Responsable = 3,
        IVA_Sujeto_Exento = 4,
        Consumidor_Final = 5,
        Responsable_Monotributo = 6,
        Sujeto_No_Categorizado = 7,
        Proveedor_del_Exterior = 8,
        Cliente_del_Exterior = 9,
        IVA_Liberado_Ley_19640 = 10,
        IVA_Responsable_Inscripto_Agente_de_Percepcion = 11,
        Pequeño_Contribuyente_Eventual = 12,
        Monotributista_Social = 13,
        Pequeño_Contribuyente_Eventual_Social = 14
    }

    public enum InvoiceType
    {
        A = 1,
        B = 2,
        C = 3,
        ReciboA = 4,
        NotaCreditoA = 5,
        NotaCreditoB = 6,
        NotaDebitoA = 7,
        NotaDebitoB = 8
    }
    public enum NoteType
    {
        A = 1,
        B = 2
    }
    public enum InvoiceStatus
    {
        Generada = 1,
        Pagada = 2,
        Anulada = 3,
        Impresa = 4
    }
    public enum InvoiceDetailType
    {
        FullDetail,
        Resumed,
        Free
    }

    public enum PaymentType
    {
        Efectivo = 1,
        Cheque = 2,
        TransferenciaElectrónica = 3,
        CertificadoRetención = 4,
        NotaCredito = 5
    }
    public enum RetentionType
    {
        IVA = 1,
        IngresosBrutos = 2,
        Ganancias = 3,
        SUSS = 4
    }
    public enum CrediDebitNoteState
    {
        Nueva = 1,
        Usada = 2
    }
    public static class EnumUtils
    {
        /// <summary>
        /// Return the names with spaces before capital letter on EnumNames, for instance PreIngreso, return Pre Ingreso
        /// </summary>
        /// <param name="enumNames">Names on the enum</param>
        /// <returns>List of display names</returns>
        public static IEnumerable<string> GetDisplayNames(IEnumerable<string> enumNames)
        {
            var displayNames = new List<string>();
            foreach (var name in enumNames)
            {
                displayNames.Add(AddSpaceInCapitalLetter(name));
            }
            return displayNames;
        }

        public static string AddSpaceInCapitalLetter(string input)
        {
            var returnArray = new StringBuilder[1];
            returnArray[0] = new StringBuilder(input.Length);
            const string cupper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int arrayCount = 0;
            for (int index = 0; index < input.Length; index++)
            {
                var sChar = input.Substring(index, 1); // get a char
                if ((cupper.Contains(sChar)) && (index > 0))
                {
                    arrayCount++;
                    var sTemp = new StringBuilder[arrayCount + 1];
                    Array.Copy(returnArray, 0, sTemp, 0, arrayCount);
                    sTemp[arrayCount] = new StringBuilder(input.Length);
                    returnArray = sTemp;
                }
                returnArray[arrayCount].Append(sChar);
            }
            var sReturnString = new string[arrayCount + 1];
            for (int index = 0; index < returnArray.Length; index++)
            {
                sReturnString[index] = returnArray[index].ToString();
            }
            return string.Join(" ", sReturnString);
        }

        public static IEnumerable<ListItemDto<int>> GetDocumentTypeNames()
        {
            var names = new List<ListItemDto<int>>();
            var values = Enum.GetValues(typeof(DocumentType));

            foreach (DocumentType val in values)
            {
                names.Add(new ListItemDto<int>
                {
                    Id = (int)val,
                    Value = Enum.GetName(typeof(DocumentType), val).Replace('_', ' ')
                });
            }
            return names;
        }

        public static IEnumerable<ListItemDto<int>> GetIvaNames()
        {
            var names = new List<ListItemDto<int>>();
            var values = Enum.GetValues(typeof(Iva));

            foreach (Iva val in values)
            {
                names.Add(new ListItemDto<int>
                {
                    Id = (int)val,
                    Value = Enum.GetName(typeof(Iva), val).Replace('_', ' ')
                });
            }
            return names;
        }

    }
}
