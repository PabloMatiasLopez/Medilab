using System;
using System.Globalization;
using System.Linq;
using System.IO;
using Medilab.BusinessObjects.Configuration;
using OfficeOpenXml;
using System.Drawing;
using OfficeOpenXml.Drawing;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Utilities;
using Medilab.BusinessObjects.ClinicalHistory;
using System.Configuration;
using Medilab.BusinessObjects.Address;
using System.Collections.Generic;

namespace Medilab.UserInterface.Excel
{
    public static class LaboMedExcelnHandler
    {
        public static void GenerateExcel(Guid clinicHistoryId, string filePath, string companyName)
        {
            MSExcel excel = new MSExcel();
            string excelPath = ConfigurationManager.AppSettings["ExcelPath"];
            RemoveFile(string.Concat(excelPath, clinicHistoryId.ToString(), ConfigurationManager.AppSettings["ExcelExtention"]));
            //// Get the file we are going to process
            File.Copy(filePath,
                      string.Concat(excelPath, clinicHistoryId.ToString(), ConfigurationManager.AppSettings["ExcelExtention"]));

            var template =
                new FileInfo(string.Concat(excelPath, clinicHistoryId.ToString(),ConfigurationManager.AppSettings["ExcelExtention"]));

            //// Open and read the XlSX file.
            using (var package = new ExcelPackage(template))
            {
                var clinicHistory = MedicalHistory.GetMedicalHistory(clinicHistoryId);
                var medicalHistoryResult = new MedicalHistoryResult().GetMedicalHistory(clinicHistoryId);

            //    // Get the work book in the file
                ExcelWorkbook workBook = package.Workbook;
                if (workBook != null)
                {
                    if (workBook.Worksheets.Count > 0)
                    {
           
                        ExcelWorksheet currentWorksheet = workBook.Worksheets.First();

                        //Second Part:
                        currentWorksheet.Cells["A2"].Value = string.Concat(clinicHistory.Patient.LastName.ToUpper(),
                            ", ", clinicHistory.Patient.FirstName);
                        currentWorksheet.Cells["G2"].Value = string.Concat(clinicHistory.Patient.DocumentType.ToString(), " ",
                                          clinicHistory.Patient.DocumentNumber);


                        currentWorksheet.Cells["D6"].Value = medicalHistoryResult.ChestXRay;
                        currentWorksheet.Cells["E6"].Value = medicalHistoryResult.ChestXRayDetails;
                        currentWorksheet.Cells["D8"].Value = medicalHistoryResult.ColumnXRay;
                        currentWorksheet.Cells["E8"].Value = medicalHistoryResult.ColumnXRayDetails;
                        currentWorksheet.Cells["D10"].Value = medicalHistoryResult.Laboratory;
                        currentWorksheet.Cells["E10"].Value = medicalHistoryResult.LaboratoryDetails;
                        currentWorksheet.Cells["D12"].Value = medicalHistoryResult.Electrocardiogram;
                        currentWorksheet.Cells["E12"].Value = medicalHistoryResult.ElectrocardiogramDetails;
                        currentWorksheet.Cells["D14"].Value = medicalHistoryResult.Audiometry;
                        currentWorksheet.Cells["E14"].Value = medicalHistoryResult.AudiometryDetails;
                        currentWorksheet.Cells["D16"].Value = medicalHistoryResult.Spirometry;
                        currentWorksheet.Cells["E16"].Value = medicalHistoryResult.SpirometryDetails;
                        currentWorksheet.Cells["D18"].Value = medicalHistoryResult.PsychologicalExam;
                        currentWorksheet.Cells["E18"].Value = medicalHistoryResult.PsychologicalExamDetails;
                        currentWorksheet.Cells["D20"].Value = medicalHistoryResult.Electroencephalogram;
                        currentWorksheet.Cells["E20"].Value = medicalHistoryResult.ElectroencephalogramDetails;
                        currentWorksheet.Cells["D22"].Value = medicalHistoryResult.Ergometry;
                        currentWorksheet.Cells["E22"].Value = medicalHistoryResult.ErgometryDetails;
                        currentWorksheet.Cells["D24"].Value = medicalHistoryResult.Ophthalmology;
                        currentWorksheet.Cells["E24"].Value = medicalHistoryResult.OphthalmologyDetails;
                        currentWorksheet.Cells["D26"].Value = medicalHistoryResult.Cardiology;
                        currentWorksheet.Cells["E26"].Value = medicalHistoryResult.CardiologyDetails;
                        currentWorksheet.Cells["D28"].Value = medicalHistoryResult.NeurologicalConsultation;
                        currentWorksheet.Cells["E28"].Value = medicalHistoryResult.NeurologicalConsultationDetails;
                        currentWorksheet.Cells["D30"].Value = medicalHistoryResult.Neumonology;
                        currentWorksheet.Cells["E30"].Value = medicalHistoryResult.NeumonologyDetails;
                        currentWorksheet.Cells["D32"].Value = medicalHistoryResult.Dental;
                        currentWorksheet.Cells["E32"].Value = medicalHistoryResult.DentalDetails;
                        currentWorksheet.Cells["D34"].Value = medicalHistoryResult.ORL;
                        currentWorksheet.Cells["E34"].Value = medicalHistoryResult.ORLDetails;
                        currentWorksheet.Cells["D36"].Value = medicalHistoryResult.VestibularExam;
                        currentWorksheet.Cells["E36"].Value = medicalHistoryResult.VestibularExamDetails;
                        currentWorksheet.Cells["D38"].Value = medicalHistoryResult.MagneticResonance;
                        currentWorksheet.Cells["E38"].Value = medicalHistoryResult.MagneticResonanceDetails;
                        currentWorksheet.Cells["D40"].Value = medicalHistoryResult.Ultrasound;
                        currentWorksheet.Cells["E40"].Value = medicalHistoryResult.UltrasoundDetails;
                        currentWorksheet.Cells["D42"].Value = medicalHistoryResult.Others;

                        currentWorksheet.Cells["A46"].Value = clinicHistory.ResultObservations;

                        currentWorksheet.Cells["E55"].Value = (EnumUtils.AddSpaceInCapitalLetter(clinicHistory.TypeOfExam.ToString())).ToUpper();
                        currentWorksheet.Cells["G55"].Value =
                            (EnumUtils.AddSpaceInCapitalLetter(clinicHistory.Result.ToString())).ToUpper();
                        currentWorksheet.Cells["A60"].Value = string.Concat("Fecha: ", clinicHistory.LastUpdatedDate.ToShortDateString());
                       
                        package.Save();
                        excel.Open(string.Concat(ConfigurationManager.AppSettings["ExcelPath"],
                                                 clinicHistoryId.ToString(), ConfigurationManager.AppSettings["ExcelExtention"]));
                        excel.Print();
                        excel.Close();
                        excel.Quit();
                        RemoveFile(string.Concat(ConfigurationManager.AppSettings["ExcelPath"],
                                                 clinicHistoryId.ToString(), ConfigurationManager.AppSettings["ExcelExtention"]));
                    }
                }

            }
        }

        public static void GeneratePartialExcel(Guid clinicHistoryId, string filePath, string companyName)
        {
            var excel = new MSExcel();
            string excelPath = ConfigurationManager.AppSettings["ExcelPath"];
            RemoveFile(string.Concat(excelPath, clinicHistoryId.ToString(), "1.xlsx"));
            // Get the file we are going to process
            File.Copy(filePath,
                      string.Concat(excelPath, clinicHistoryId.ToString(), "1.xlsx"));

            var template =
                new FileInfo(string.Concat(excelPath, clinicHistoryId.ToString(),
                                           "1.xlsx"));

            // Open and read the XlSX file.
            using (var package = new ExcelPackage(template))
            {
                var clinicHistory = MedicalHistory.GetMedicalHistory(clinicHistoryId);

                // Get the work book in the file
                ExcelWorkbook workBook = package.Workbook;
                if (workBook != null)
                {
                    if (workBook.Worksheets.Count > 0)
                    {
                        // Get the first worksheet
                        ExcelWorksheet currentWorksheet = workBook.Worksheets.First();

                        if (!string.IsNullOrEmpty(clinicHistory.Patient.Photo))
                        {
                            if (
                                File.Exists(string.Concat(ConfigurationManager.AppSettings["filePhotoServerPath"],
                                                          clinicHistory.Patient.Photo)))
                            {
                                AddImage(currentWorksheet, 7, 1,
                                         string.Concat(ConfigurationManager.AppSettings["filePhotoServerPath"],
                                                       clinicHistory.Patient.Photo), 190, 140);
                            }
                        }

                        var companyInfoList = CompanyInfo.GetCompanyInfoList();
                        var companyInfo = (from cil in companyInfoList
                                           where cil.ExcelFormat == companyName
                                           select cil).First();
                        string fileName = string.Empty;
                        if (!string.IsNullOrEmpty(clinicHistory.Client.Logo))
                        {
                            fileName =
                                string.Concat(
                                    ConfigurationManager.AppSettings["fileClientLogoServerPath"],
                                    clinicHistory.Client.Logo);
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(companyInfo.Image))
                            {
                                fileName = string.Concat(ConfigurationManager.AppSettings["fileImagePath"],
                                    companyInfo.Image);
                            }
                        }
                        

                        if (File.Exists(fileName))
                        {
                            AddImage(currentWorksheet, 1, 0,fileName, 135, 90);
                        }
                        

                        currentWorksheet.Cells["A6"].Value = string.Concat(companyInfo.Address, " - (",
                                                                           companyInfo.PostalCode, ")", ", ",
                                                                           companyInfo.Province, " Tels.: ",
                                                                           companyInfo.Phone,
                                                                           " - Tel/Fax ", companyInfo.Fax, " Email: ",
                                                                           companyInfo.Email);

                        var clientAddress = clinicHistory.Client.Addresses.First();

                        currentWorksheet.Cells["G9"].Value = (EnumUtils.AddSpaceInCapitalLetter(clinicHistory.TypeOfExam.ToString())).ToUpper();
                        currentWorksheet.Cells["G10"].Value = clinicHistory.CreatedDate.ToShortDateString();
                            

                        //Header of the first page
                        currentWorksheet.Cells["B9"].Value = clinicHistory.Client.Name;
                        currentWorksheet.Cells["B10"].Value = string.Concat(clientAddress.StreetLineOne, " ",
                            clientAddress.Number);
                        currentWorksheet.Cells["B11"].Value =
                            string.Concat(clientAddress.City,", " ,clientAddress.AddressState.Name);
                        currentWorksheet.Cells["B12"].Value = clinicHistory.Client.Cuit;
                        currentWorksheet.Cells["E12"].Value = clinicHistory.Client.PhoneNumber;

                        //Practices
                        int count = 15;
                        List<Guid> addedGroupIds = new List<Guid>();
                        char position = 'G';
                        foreach (var medicalPractice in clinicHistory.Practices)
                        {
                           
                                Practice practice = Practice.GetPractice(medicalPractice.MedicalPracticeId);
                                currentWorksheet.Cells[position + count.ToString()].Value = practice.ReportName;
                                count++;
                           
                            if (count > 33)
                            {
                                position = 'K';
                                count = 15;
                            }
                            if (position == 'k' && count == 33)
                            {
                                break;
                            }
                        }

                        //The patient data
                        currentWorksheet.Cells["B15"].Value = clinicHistory.Patient.LastName.ToUpper();
                        currentWorksheet.Cells["B16"].Value = clinicHistory.Patient.FirstName;
                        currentWorksheet.Cells["B17"].Value =
                            string.Concat(clinicHistory.Patient.DocumentType.ToString(), " ",
                                          clinicHistory.Patient.DocumentNumber);

                        currentWorksheet.Cells["B19"].Value = clinicHistory.Patient.BirthDay.ToShortDateString();
                        currentWorksheet.Cells["B20"].Value =
                            UiUtils.GetAge(clinicHistory.Patient.BirthDay).ToString(CultureInfo.InvariantCulture);
                        currentWorksheet.Cells["B21"].Value = clinicHistory.Patient.BirthPlace.Name;
                        currentWorksheet.Cells["B22"].Value = clinicHistory.Patient.CivilState;

                        Address address = clinicHistory.Patient.Addresses.First(x => x.IsDefault);
                        currentWorksheet.Cells["B24"].Value =
                           string.Concat(address.StreetLineOne, " ", address.Number);
                        currentWorksheet.Cells["B25"].Value =
                           string.Concat(address.City, ", ", address.AddressState.Name);

                        var phones = string.Empty;

                        if (!string.IsNullOrEmpty(clinicHistory.Patient.HomePhone) && !string.IsNullOrEmpty(clinicHistory.Patient.CellPhone))
                        {
                            phones = string.Concat(clinicHistory.Patient.HomePhone, " - ", clinicHistory.Patient.CellPhone);
                        }
                        else if (!string.IsNullOrEmpty(clinicHistory.Patient.HomePhone))
                        {
                            phones = clinicHistory.Patient.HomePhone;
                        }
                        else
                        {
                            phones = clinicHistory.Patient.CellPhone;
                        }

                        currentWorksheet.Cells["B26"].Value = phones;
                          string.Concat(clinicHistory.Patient.HomePhone," - " ,clinicHistory.Patient.CellPhone);


                        currentWorksheet.Cells["B28"].Value = clinicHistory.Patient.InstructionLevel;
                        currentWorksheet.Cells["B29"].Value = clinicHistory.Patient.InstructionTitle;

                        currentWorksheet.Cells["B32"].Value = clinicHistory.TaskToDo;
                        currentWorksheet.Cells["B33"].Value = clinicHistory.WorkArea;


                        /////////////////////////////////////////////////////////////////////////////////////////////
                        //currentWorksheet.Cells["B9"].Value = clinicHistory.CreatedDate.ToShortDateString();
                        currentWorksheet.Cells["F4"].Value = clinicHistory.AnotherTypeDescription;
                       ////////////////////////////////////////////////////////////////////////////////////////////

                        
                      

                        currentWorksheet.Cells["C38"].Value =
                            string.IsNullOrEmpty(clinicHistory.MedicalExam.HereditaryRecords)
                                ? Constants.NotAffection
                                : clinicHistory.MedicalExam.HereditaryRecords;
                        currentWorksheet.Cells["C41"].Value =
                            string.IsNullOrEmpty(clinicHistory.MedicalExam.PathologicalRecords)
                                ? Constants.NotAffection
                                : clinicHistory.MedicalExam.PathologicalRecords;
                        currentWorksheet.Cells["C44"].Value =
                            string.IsNullOrEmpty(clinicHistory.MedicalExam.SurgicalRecords)
                                ? Constants.NotAffection
                                : clinicHistory.MedicalExam.SurgicalRecords;
                        currentWorksheet.Cells["C47"].Value =
                            string.IsNullOrEmpty(clinicHistory.MedicalExam.TraumaRecors)
                                ? Constants.NotAffection
                                : clinicHistory.MedicalExam.TraumaRecors;
                        currentWorksheet.Cells["C50"].Value =
                            string.IsNullOrEmpty(clinicHistory.MedicalExam.ObstetricalRecords)
                                ? Constants.NotAffection
                                : clinicHistory.MedicalExam.ObstetricalRecords;
                        currentWorksheet.Cells["C53"].Value =
                            string.IsNullOrEmpty(clinicHistory.MedicalExam.OtherRecords)
                                ? Constants.NotAffection
                                : clinicHistory.MedicalExam.OtherRecords;
                        //Habits
                        //TODO: Reemplazar conun string builder
                        string habits = string.Empty;
                        if (clinicHistory.MedicalExam.Smoke)
                        {
                            habits = string.Concat("Fuma (", clinicHistory.MedicalExam.SmokeCount,
                                                   "), ");

                        }
                        else
                        {
                            habits = "No fuma. ";
                        }
                        if (clinicHistory.MedicalExam.Alcohol)
                        {
                            habits = string.Concat(habits, "Consume bebidas alcohólicas (",
                                                   clinicHistory.MedicalExam.AlcoholCount, "). ");

                        }
                        else
                        {
                            habits = string.Concat(habits, "No consume bebidas alcohólicas. ");
                        }
                        if (clinicHistory.MedicalExam.NormalSleep)
                        {
                            habits = string.Concat(habits, "Sueño normal. ");

                            if (!string.IsNullOrEmpty(clinicHistory.MedicalExam.SleepHours))
                            {
                                habits = string.Concat(habits + " Descansa (",clinicHistory.MedicalExam.SleepHours,"). ");
                            }
                        }
                        else
                        {
                            habits = string.Concat(habits, "No tiene sueño normal y no descansa (",
                                                   clinicHistory.MedicalExam.SleepHours, "), ");
                        }
                        if (clinicHistory.MedicalExam.Sports)
                        {
                            habits = string.Concat(habits, "Realiza actividad física (",
                                                   clinicHistory.MedicalExam.SportsDetails, "). ");
                        }
                        else
                        {
                            habits = string.Concat(habits, "No realiza actividad física.");
                        }
                        currentWorksheet.Cells["C56"].Value = habits;
                       
                        currentWorksheet.Cells["C59"].Value =
                               string.IsNullOrEmpty(clinicHistory.MedicalExam.VaccinesRecords)
                                   ? Constants.NotAffection
                                   : clinicHistory.MedicalExam.VaccinesRecords;

                        //Header 2do page
                        currentWorksheet.Cells["A67"].Value = string.Concat(clinicHistory.Patient.LastName.ToUpper(), ", ", clinicHistory.Patient.FirstName);
                        currentWorksheet.Cells["G67"].Value = string.Concat(clinicHistory.Patient.DocumentType.ToString(), " ",
                                          clinicHistory.Patient.DocumentNumber);

                        //vision EXAM
                        //currentWorksheet.Cells["I13"].Value = (clinicHistory.MedicalExam.UseEyeglasses == true ? "SI" : "NO");
                        
                        currentWorksheet.Cells["D75"].Value = clinicHistory.MedicalExam.EyeFarNoCorrectionRight;
                        currentWorksheet.Cells["H75"].Value = clinicHistory.MedicalExam.EyeFarNoCorrectionLeft;

                        currentWorksheet.Cells["D77"].Value = clinicHistory.MedicalExam.EyeFarWithCorrectionRight;
                        currentWorksheet.Cells["H77"].Value = clinicHistory.MedicalExam.EyeFarWithCorrectionLeft;

                        currentWorksheet.Cells["D79"].Value = clinicHistory.MedicalExam.EyeNearNoCorrectionRight.HasValue ? clinicHistory.MedicalExam.EyeNearNoCorrectionRight.Value.ToString("0.00") : string.Empty;
                        currentWorksheet.Cells["H79"].Value = clinicHistory.MedicalExam.EyeNearNoCorrectionLeft.HasValue ? clinicHistory.MedicalExam.EyeNearNoCorrectionLeft.Value.ToString("0.00") : string.Empty;

                        currentWorksheet.Cells["D81"].Value = clinicHistory.MedicalExam.EyeNearWithCorrectionRight.HasValue ? clinicHistory.MedicalExam.EyeNearWithCorrectionRight.Value.ToString("0.00") : string.Empty;
                        currentWorksheet.Cells["H81"].Value = clinicHistory.MedicalExam.EyeNearWithCorrectionLeft.HasValue ? clinicHistory.MedicalExam.EyeNearWithCorrectionLeft.Value.ToString("0.00") : string.Empty;

                        currentWorksheet.Cells["C83"].Value = clinicHistory.MedicalExam.ColorVision;

                        currentWorksheet.Cells["D85"].Value = clinicHistory.MedicalExam.FunduscopicRight;
                        currentWorksheet.Cells["H85"].Value = clinicHistory.MedicalExam.FunduscopicLeft;

                        currentWorksheet.Cells["C87"].Value = clinicHistory.MedicalExam.ViewObservations;

                        /////////////////////////////////////////////////////////////////////////////////////////////
                        //urrentWorksheet.Cells["B86"].Value = clinicHistory.ClinicalHistoryObservations;
                        //////////////////////////////////////////////////////////////////////////////////////////////

                        //Clinical exam header
                        currentWorksheet.Cells["B91"].Value = clinicHistory.MedicalExam.Size.ToString();
                        currentWorksheet.Cells["D91"].Value = clinicHistory.MedicalExam.Weight.ToString();
                        currentWorksheet.Cells["F91"].Value =
                            GetICM(clinicHistory.MedicalExam.Weight.ToString("0.00"),
                                   clinicHistory.MedicalExam.Size.ToString("0.00")).ToString("0.00");
                        currentWorksheet.Cells["K91"].Value = string.Concat(clinicHistory.MedicalExam.Pulse.ToString(CultureInfo.InvariantCulture),
                                                                            " puls. x min.");
                        currentWorksheet.Cells["B93"].Value = clinicHistory.MedicalExam.AbdominalCircunference.HasValue ?
                            clinicHistory.MedicalExam.AbdominalCircunference.Value.ToString() : string.Empty;
                        currentWorksheet.Cells["E93"].Value = clinicHistory.MedicalExam.CervicalPerimeter;
                        currentWorksheet.Cells["J93"].Value = string.Concat(
                             clinicHistory.MedicalExam.BloodPressureHight, "/", clinicHistory.MedicalExam.BloodPressureLow);

                        //Clinical exam
                        currentWorksheet.Cells["D97"].Value = clinicHistory.MedicalExam.Head;
                        currentWorksheet.Cells["E97"].Value = clinicHistory.MedicalExam.HeadDetails.TrimEnd();
                        currentWorksheet.Cells["D99"].Value = clinicHistory.MedicalExam.Eyes;
                        currentWorksheet.Cells["E99"].Value = clinicHistory.MedicalExam.EyesDetails;
                        currentWorksheet.Cells["D101"].Value = clinicHistory.MedicalExam.Ear;
                        currentWorksheet.Cells["E101"].Value = clinicHistory.MedicalExam.EarDetails;
                        currentWorksheet.Cells["D103"].Value = clinicHistory.MedicalExam.Nose;
                        currentWorksheet.Cells["E103"].Value = clinicHistory.MedicalExam.NoseDetails;
                        currentWorksheet.Cells["D105"].Value = clinicHistory.MedicalExam.Mouth;
                        currentWorksheet.Cells["E105"].Value = clinicHistory.MedicalExam.MouthDetails;
                        currentWorksheet.Cells["D107"].Value = clinicHistory.MedicalExam.Neck;
                        currentWorksheet.Cells["E107"].Value = clinicHistory.MedicalExam.NeckDetails;
                        currentWorksheet.Cells["D109"].Value = clinicHistory.MedicalExam.Chest;
                        currentWorksheet.Cells["E109"].Value = clinicHistory.MedicalExam.ChestDetails;
                        currentWorksheet.Cells["D111"].Value = clinicHistory.MedicalExam.Lung;
                        currentWorksheet.Cells["E111"].Value = clinicHistory.MedicalExam.LungDetails;
                        currentWorksheet.Cells["D113"].Value = clinicHistory.MedicalExam.Heart;
                        currentWorksheet.Cells["E113"].Value = clinicHistory.MedicalExam.HeartDetails;
                        currentWorksheet.Cells["D115"].Value = clinicHistory.MedicalExam.BloodPressureStatus;
                        currentWorksheet.Cells["E115"].Value = clinicHistory.MedicalExam.BloodPressureStatusDetail;
                        currentWorksheet.Cells["D117"].Value = clinicHistory.MedicalExam.PeripheralVeins;
                        currentWorksheet.Cells["E117"].Value = clinicHistory.MedicalExam.PeripheralVeinsDetails;
                        currentWorksheet.Cells["D119"].Value = clinicHistory.MedicalExam.PeripheralArteries;
                        currentWorksheet.Cells["E119"].Value = clinicHistory.MedicalExam.PeripheralArteriesDetails;

                        currentWorksheet.Cells["D121"].Value = clinicHistory.MedicalExam.Abdomen;
                        currentWorksheet.Cells["E121"].Value = clinicHistory.MedicalExam.AbdomenDetails;
                        currentWorksheet.Cells["D123"].Value = clinicHistory.MedicalExam.Hernia;
                        currentWorksheet.Cells["E123"].Value = clinicHistory.MedicalExam.HerniaDetails;
                        currentWorksheet.Cells["D125"].Value = clinicHistory.MedicalExam.Genitals;
                        currentWorksheet.Cells["E125"].Value = clinicHistory.MedicalExam.GenitalsDetails; 
                        currentWorksheet.Cells["D127"].Value = clinicHistory.MedicalExam.IMCStatus;       
                        currentWorksheet.Cells["E127"].Value = clinicHistory.MedicalExam.IMCStatusDetails; 
                        currentWorksheet.Cells["D129"].Value = clinicHistory.MedicalExam.Kidneys;
                        currentWorksheet.Cells["E129"].Value = clinicHistory.MedicalExam.KidneysDetails;
                        currentWorksheet.Cells["D131"].Value = clinicHistory.MedicalExam.Tips;
                        currentWorksheet.Cells["E131"].Value = clinicHistory.MedicalExam.TipsDetails;
                        currentWorksheet.Cells["D133"].Value = clinicHistory.MedicalExam.Backbone;
                        currentWorksheet.Cells["E133"].Value = clinicHistory.MedicalExam.BackboneDetails;
                        currentWorksheet.Cells["D135"].Value = clinicHistory.MedicalExam.Skin;
                        currentWorksheet.Cells["E135"].Value = clinicHistory.MedicalExam.SkinDetails;
                        currentWorksheet.Cells["D137"].Value = clinicHistory.MedicalExam.Scars;
                        currentWorksheet.Cells["E137"].Value = clinicHistory.MedicalExam.ScarsDetails;
                        currentWorksheet.Cells["D139"].Value = clinicHistory.MedicalExam.LympNodes;
                        currentWorksheet.Cells["E139"].Value = clinicHistory.MedicalExam.LympNodesDetails;
                        currentWorksheet.Cells["D141"].Value = clinicHistory.MedicalExam.NervousSystem;
                        currentWorksheet.Cells["E141"].Value = clinicHistory.MedicalExam.NervousSystemDetails;
                        currentWorksheet.Cells["D143"].Value = clinicHistory.MedicalExam.Motion;
                        currentWorksheet.Cells["E143"].Value = clinicHistory.MedicalExam.MotionDetails;

                        currentWorksheet.Cells["D145"].Value = clinicHistory.MedicalExam.PsychicTest;
                        currentWorksheet.Cells["E145"].Value = clinicHistory.MedicalExam.PsychicTestDetails;
                        currentWorksheet.Cells["D147"].Value = clinicHistory.MedicalExam.BalanceTest;    
                        currentWorksheet.Cells["E147"].Value = clinicHistory.MedicalExam.BalanceTestDetails; 
                    }
                    
                    package.Save();
                    excel.Open(string.Concat(ConfigurationManager.AppSettings["ExcelPath"],
                                             clinicHistoryId.ToString(), "1.xlsx"));
                    excel.Print();
                    excel.Close();
                    excel.Quit();
                    RemoveFile(string.Concat(ConfigurationManager.AppSettings["ExcelPath"],
                                             clinicHistoryId.ToString(), "1.xlsx"));
                }
               
            }
        }

        public static void GenerateComplementaryExams(Guid medicalHistoryId)
        {
            GenerateExcel(medicalHistoryId,
                string.Concat(ConfigurationManager.AppSettings["ExcelPathTemplates"],
                    ConfigurationManager.AppSettings["ComplementaryPractices"]), "Labomed");
        }

        private static void RemoveFile(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
        }
        
        private static void AddImage(ExcelWorksheet ws, int columnIndex, int rowIndex, string filePath, int x, int y)
        {
            //How to Add a Image using EP Plus
            Bitmap image = new Bitmap(filePath);
            ExcelPicture picture = null;
            if (image != null)
            {
                picture = ws.Drawings.AddPicture("pic" + rowIndex.ToString() + columnIndex.ToString(), image);
                picture.From.Column = columnIndex;
                picture.From.Row = rowIndex;
                picture.From.ColumnOff = 0;
                picture.From.RowOff = 0;
                picture.Border.Width = 0;
                picture.SetSize(x, y);
            }
        }
        private static double GetICM(string weight, string size)
        {
            double convertedWeight;
            double convertedSize;
            if (double.TryParse(weight, out convertedWeight) && double.TryParse(size, out convertedSize))
            {
                convertedSize /= 100;
                return convertedWeight / (convertedSize * convertedSize);
            }
            return 0;
        }
    }
    }

