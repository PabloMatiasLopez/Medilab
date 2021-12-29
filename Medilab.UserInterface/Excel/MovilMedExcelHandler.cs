using System;
using System.Globalization;
using System.Linq;
using System.IO;
using OfficeOpenXml;
using System.Drawing;
using OfficeOpenXml.Drawing;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Utilities;
using Medilab.BusinessObjects.ClinicalHistory;
using System.Configuration;
using Medilab.BusinessObjects.Address;
using Medilab.BusinessObjects.Configuration;
using System.Collections.Generic;

namespace Medilab.UserInterface.Excel
{
    public static class MovilmedExcelnHandler
    {
        public static void GenerateExcel(Guid clinicHistoryId, string filePath, string companyName)
        {
            MSExcel excel = new MSExcel();
            string excelPath = ConfigurationManager.AppSettings["ExcelPath"];
            RemoveFile(string.Concat(excelPath, clinicHistoryId.ToString(), ".xlsx"));
            //// Get the file we are going to process
            File.Copy(filePath,
                      string.Concat(excelPath, clinicHistoryId.ToString(), ".xlsx"));

            var template =
                new FileInfo(string.Concat(excelPath, clinicHistoryId.ToString(), ".xlsx"));

            //// Open and read the XlSX file.
            using (var package = new ExcelPackage(template))
            {
                var clinicHistory = MedicalHistory.GetMedicalHistory(clinicHistoryId);

                //    // Get the work book in the file
                ExcelWorkbook workBook = package.Workbook;
                if (workBook != null)
                {
                    if (workBook.Worksheets.Count > 0)
                    {
                        //            #region FirstPage

                        //            // Get the first worksheet
                        ExcelWorksheet currentWorksheet = workBook.Worksheets.First();

                        //            if (!string.IsNullOrEmpty(clinicHistory.Patient.Photo))
                        //            {
                        //                if (
                        //                    File.Exists(string.Concat(ConfigurationSettings.AppSettings["filePhotoServerPath"],
                        //                                              clinicHistory.Patient.Photo)))
                        //                {
                        //                    AddImage(currentWorksheet, 7, 13,
                        //                             string.Concat(ConfigurationSettings.AppSettings["filePhotoServerPath"],
                        //                                           clinicHistory.Patient.Photo), 170, 185);
                        //                }
                        //            }

                        //            var companyInfoList = CompanyInfo.GetCompanyInfoList();
                        //            var companyInfo = (from cil in companyInfoList
                        //                               where cil.Name == companyName
                        //                               select cil).First();
                        //            if (!string.IsNullOrEmpty(companyInfo.Image))
                        //            {
                        //                if (
                        //                    File.Exists(string.Concat(ConfigurationSettings.AppSettings["fileImagePath"],
                        //                                              companyInfo.Image)))
                        //                {
                        //                    AddImage(currentWorksheet, 2, 0,
                        //                             string.Concat(ConfigurationSettings.AppSettings["fileImagePath"],
                        //                                           companyInfo.Image), 190, 103);
                        //                }
                        //            }

                        //            currentWorksheet.Cells["C6"].Value = string.Concat(companyInfo.Address, " - (",
                        //                                                               companyInfo.PostalCode, ")", ", ",
                        //                                                               companyInfo.Province, " Tels.: ",
                        //                                                               companyInfo.Phone,
                        //                                                               " - Tel/Fax ", companyInfo.Fax, " Email: ",
                        //                                                               companyInfo.Email);

                        //            var clientAddress = clinicHistory.Client.Addresses.First();
                        //            //Header of the first page
                        //            currentWorksheet.Cells["C10"].Value = clinicHistory.Client.Name;
                        //            currentWorksheet.Cells["I10"].Value = clinicHistory.Client.Cuit;
                        //            currentWorksheet.Cells["C11"].Value =
                        //                string.Concat(clientAddress.StreetLineOne, " ",
                        //                              clientAddress.StreetLineTwo, ", ",
                        //                              clientAddress.AddressState.Name);
                        //            currentWorksheet.Cells["I11"].Value = clinicHistory.Client.PhoneNumber;

                        //            currentWorksheet.Cells["E13"].Value = string.Concat(clinicHistory.Patient.LastName, ", ",
                        //                                                                clinicHistory.Patient.FirstName);
                        //            currentWorksheet.Cells["E14"].Value = clinicHistory.Patient.BirthDay.ToShortDateString();
                        //            currentWorksheet.Cells["C15"].Value = UiUtils.GetAge(clinicHistory.Patient.BirthDay).ToString();
                        //            currentWorksheet.Cells["D18"].Value = clinicHistory.Patient.CivilState;
                        //            currentWorksheet.Cells["D19"].Value = clinicHistory.Patient.InstructionLevel;
                        //            currentWorksheet.Cells["C20"].Value = clinicHistory.Patient.InstructionTitle;

                        //            currentWorksheet.Cells["E16"].Value = clinicHistory.Patient.BirthPlace.Name;
                        //            currentWorksheet.Cells["D22"].Value =
                        //                string.Concat(clinicHistory.Patient.DocumentType.ToString(), " ",
                        //                              clinicHistory.Patient.DocumentNumber);

                        //            currentWorksheet.Cells["I6"].Value = clinicHistory.CreatedDate.ToShortDateString();
                        //            Address address = clinicHistory.Patient.Addresses.Where(x => x.Type == AddressType.Casa).First();
                        //            currentWorksheet.Cells["D23"].Value =
                        //                string.Concat(address.StreetLineOne + " " + address.StreetLineTwo);
                        //            currentWorksheet.Cells["G3"].Value = clinicHistory.TypeOfExam.ToString().ToUpper();
                        //            currentWorksheet.Cells["E25"].Value = clinicHistory.TaskToDo;
                        //            currentWorksheet.Cells["D26"].Value = clinicHistory.WorkArea;


                        //            //Records
                        //            currentWorksheet.Cells["d31"].Value = clinicHistory.MedicalExam.HereditaryRecords;
                        //            currentWorksheet.Cells["d33"].Value = clinicHistory.MedicalExam.PathologicalRecords;
                        //            currentWorksheet.Cells["d36"].Value = clinicHistory.MedicalExam.SurgicalRecords;
                        //            currentWorksheet.Cells["d38"].Value = clinicHistory.MedicalExam.TraumaRecors;
                        //            currentWorksheet.Cells["d40"].Value = clinicHistory.MedicalExam.ObstetricalRecords;
                        //            currentWorksheet.Cells["c43"].Value = clinicHistory.MedicalExam.OtherRecords;

                        //            //Habits
                        //            string habits = string.Empty;
                        //            if (clinicHistory.MedicalExam.Smoke)
                        //            {
                        //                habits = string.Concat("Fuma (", clinicHistory.MedicalExam.SmokeCount,
                        //                                       "), ");

                        //            }
                        //            else
                        //            {
                        //                habits = "No fuma, ";
                        //            }
                        //            if (clinicHistory.MedicalExam.Alcohol)
                        //            {
                        //                habits = string.Concat(habits, "Consume bebidas alcoholicas ( ",
                        //                                       clinicHistory.MedicalExam.AlcoholCount, "), ");

                        //            }
                        //            else
                        //            {
                        //                habits = string.Concat(habits, "No consume bebidas alcoholicas, ");
                        //            }
                        //            if (clinicHistory.MedicalExam.NormalSleep)
                        //            {
                        //                habits = string.Concat(habits, "Tiene sueño normal y decansa (",
                        //                                       clinicHistory.MedicalExam.SleepHours, "), ");

                        //            }
                        //            else
                        //            {
                        //                habits = string.Concat(habits, "No tiene sueño normal y no decansa (",
                        //                                       clinicHistory.MedicalExam.SleepHours, "), ");
                        //            }
                        //            if (clinicHistory.MedicalExam.Sports)
                        //            {
                        //                habits = string.Concat(habits, "Realiza actividad física (",
                        //                                       clinicHistory.MedicalExam.SportsDetails, "). ");
                        //            }
                        //            else
                        //            {
                        //                habits = string.Concat(habits, "No realiza actividad física.");
                        //            }
                        //            currentWorksheet.Cells["F45"].Value = habits;

                        //Second Part:
                        currentWorksheet.Cells["C2"].Value = clinicHistory.CreatedDate.ToShortDateString();
                        currentWorksheet.Cells["C3"].Value = clinicHistory.Client.Name;
                        currentWorksheet.Cells["H2"].Value = clinicHistory.Patient.FullName;
                        currentWorksheet.Cells["H3"].Value =
                            string.Concat(clinicHistory.Patient.DocumentType.ToString(), " ",
                                          clinicHistory.Patient.DocumentNumber);

                        //vision EXAM
                        currentWorksheet.Cells["F8"].Value = clinicHistory.MedicalExam.EyeFarNoCorrectionRight;
                        currentWorksheet.Cells["I8"].Value = clinicHistory.MedicalExam.EyeFarNoCorrectionLeft;

                        currentWorksheet.Cells["F9"].Value = clinicHistory.MedicalExam.EyeFarWithCorrectionRight;
                        currentWorksheet.Cells["I9"].Value = clinicHistory.MedicalExam.EyeFarWithCorrectionLeft;

                        currentWorksheet.Cells["F10"].Value = clinicHistory.MedicalExam.EyeNearNoCorrectionRight;
                        currentWorksheet.Cells["I10"].Value = clinicHistory.MedicalExam.EyeNearNoCorrectionLeft;

                        currentWorksheet.Cells["F11"].Value = clinicHistory.MedicalExam.EyeNearWithCorrectionRight;
                        currentWorksheet.Cells["I11"].Value = clinicHistory.MedicalExam.EyeNearWithCorrectionLeft;

                        currentWorksheet.Cells["F13"].Value = clinicHistory.MedicalExam.FunduscopicRight;
                        currentWorksheet.Cells["I13"].Value = clinicHistory.MedicalExam.FunduscopicLeft;

                        currentWorksheet.Cells["E12"].Value = clinicHistory.MedicalExam.ColorVision;
                        currentWorksheet.Cells["D14"].Value = clinicHistory.MedicalExam.ViewObservations;


                        currentWorksheet.Cells["B78"].Value = clinicHistory.ClinicalHistoryObservations;



                        #region SecondPage



                        //Faltan las observaciones de la primera hora de la historia clinica. 
                        //Faltan las observaciones y concluciones del medico.
                        //Faltan los resultados de examenes complementarios.
                        //Faltan los resultados de los examenes de laboratorio.


                        #endregion

                        //Clinical exam header
                        currentWorksheet.Cells["C20"].Value = clinicHistory.MedicalExam.Size.ToString("0.00");
                        currentWorksheet.Cells["E20"].Value = clinicHistory.MedicalExam.Weight.ToString("0.00");
                        currentWorksheet.Cells["G20"].Value =
                            GetICM(clinicHistory.MedicalExam.Weight.ToString("0.00"),
                                   clinicHistory.MedicalExam.Size.ToString("0.00")).ToString("0.00");
                        currentWorksheet.Cells["i20"].Value = clinicHistory.MedicalExam.AbdominalCircunference.HasValue ?
                            clinicHistory.MedicalExam.AbdominalCircunference.Value.ToString("0.00") : string.Empty;
                        currentWorksheet.Cells["C21"].Value = string.Concat(
                            clinicHistory.MedicalExam.BloodPressureLow, "/",
                            clinicHistory.MedicalExam.BloodPressureHight);
                        currentWorksheet.Cells["E21"].Value = string.Concat(clinicHistory.MedicalExam.Pulse.ToString(CultureInfo.InvariantCulture),
                                                                            "PxM");
                        //Clinical exam
                        currentWorksheet.Cells["E23"].Value = clinicHistory.MedicalExam.Head;
                        currentWorksheet.Cells["F23"].Value = clinicHistory.MedicalExam.HeadDetails;
                        currentWorksheet.Cells["E24"].Value = clinicHistory.MedicalExam.Eyes;
                        currentWorksheet.Cells["F24"].Value = clinicHistory.MedicalExam.EyesDetails;
                        currentWorksheet.Cells["E25"].Value = clinicHistory.MedicalExam.Ear;
                        currentWorksheet.Cells["F25"].Value = clinicHistory.MedicalExam.EarDetails;
                        currentWorksheet.Cells["E26"].Value = clinicHistory.MedicalExam.Nose;
                        currentWorksheet.Cells["F26"].Value = clinicHistory.MedicalExam.NoseDetails;
                        currentWorksheet.Cells["E27"].Value = clinicHistory.MedicalExam.Mouth;
                        currentWorksheet.Cells["F27"].Value = clinicHistory.MedicalExam.MouthDetails;
                        currentWorksheet.Cells["E28"].Value = clinicHistory.MedicalExam.Neck;
                        currentWorksheet.Cells["F28"].Value = clinicHistory.MedicalExam.NeckDetails;
                        currentWorksheet.Cells["E29"].Value = clinicHistory.MedicalExam.Chest;
                        currentWorksheet.Cells["F29"].Value = clinicHistory.MedicalExam.ChestDetails;
                        currentWorksheet.Cells["E30"].Value = clinicHistory.MedicalExam.Lung;
                        currentWorksheet.Cells["F30"].Value = clinicHistory.MedicalExam.LungDetails;
                        currentWorksheet.Cells["E31"].Value = clinicHistory.MedicalExam.Heart;
                        currentWorksheet.Cells["F31"].Value = clinicHistory.MedicalExam.HeartDetails;
                        currentWorksheet.Cells["E32"].Value = clinicHistory.MedicalExam.PeripheralVeins;
                        currentWorksheet.Cells["F32"].Value = clinicHistory.MedicalExam.PeripheralVeinsDetails;
                        currentWorksheet.Cells["E33"].Value = clinicHistory.MedicalExam.PeripheralArteries;
                        currentWorksheet.Cells["F33"].Value = clinicHistory.MedicalExam.PeripheralArteriesDetails;

                        currentWorksheet.Cells["E34"].Value = clinicHistory.MedicalExam.Abdomen;
                        currentWorksheet.Cells["F34"].Value = clinicHistory.MedicalExam.AbdomenDetails;
                        currentWorksheet.Cells["E35"].Value = clinicHistory.MedicalExam.Hernia;
                        currentWorksheet.Cells["F35"].Value = clinicHistory.MedicalExam.HerniaDetails;
                        currentWorksheet.Cells["E36"].Value = clinicHistory.MedicalExam.Genitals;
                        currentWorksheet.Cells["F36"].Value = clinicHistory.MedicalExam.GenitalsDetails;
                        currentWorksheet.Cells["E37"].Value = clinicHistory.MedicalExam.SubcutaneousCellularTissue;
                        currentWorksheet.Cells["F37"].Value =
                            clinicHistory.MedicalExam.SubcutaneousCellularTissueDetails;

                        currentWorksheet.Cells["E38"].Value = clinicHistory.MedicalExam.Kidneys;
                        currentWorksheet.Cells["F38"].Value = clinicHistory.MedicalExam.KidneysDetails;
                        currentWorksheet.Cells["E39"].Value = clinicHistory.MedicalExam.Anus;
                        currentWorksheet.Cells["F39"].Value = clinicHistory.MedicalExam.AnusDetails;
                        currentWorksheet.Cells["E40"].Value = clinicHistory.MedicalExam.Tips;
                        currentWorksheet.Cells["F40"].Value = clinicHistory.MedicalExam.TipsDetails;
                        currentWorksheet.Cells["E41"].Value = clinicHistory.MedicalExam.Backbone;
                        currentWorksheet.Cells["F41"].Value = clinicHistory.MedicalExam.BackboneDetails;
                        currentWorksheet.Cells["E42"].Value = clinicHistory.MedicalExam.Skin;
                        currentWorksheet.Cells["F42"].Value = clinicHistory.MedicalExam.SkinDetails;
                        currentWorksheet.Cells["E43"].Value = clinicHistory.MedicalExam.LympNodes;
                        currentWorksheet.Cells["F43"].Value = clinicHistory.MedicalExam.LympNodesDetails;
                        currentWorksheet.Cells["E44"].Value = clinicHistory.MedicalExam.NervousSystem;
                        currentWorksheet.Cells["F44"].Value = clinicHistory.MedicalExam.NervousSystemDetails;
                        currentWorksheet.Cells["E45"].Value = clinicHistory.MedicalExam.Motion;
                        currentWorksheet.Cells["F45"].Value = clinicHistory.MedicalExam.MotionDetails;

                        currentWorksheet.Cells["E46"].Value = clinicHistory.MedicalExam.PsychicTest;
                        currentWorksheet.Cells["F46"].Value = clinicHistory.MedicalExam.PsychicTestDetails;
                        currentWorksheet.Cells["E47"].Value = clinicHistory.MedicalExam.BalanceTest;
                        currentWorksheet.Cells["F47"].Value = clinicHistory.MedicalExam.BalanceTestDetails;
                        currentWorksheet.Cells["E49"].Value = clinicHistory.MedicalExam.Scars;
                        currentWorksheet.Cells["F49"].Value = clinicHistory.MedicalExam.ScarsDetails;

                        currentWorksheet.Cells["C57"].Value = clinicHistory.CreatedDate.ToShortDateString();
                        currentWorksheet.Cells["C58"].Value = clinicHistory.Client.Name;
                        currentWorksheet.Cells["H57"].Value = clinicHistory.Patient.FullName;
                        currentWorksheet.Cells["H58"].Value =
                            string.Concat(clinicHistory.Patient.DocumentType.ToString(), " ",
                                          clinicHistory.Patient.DocumentNumber);

                        int practiceCounter = 0;
                        foreach (var practice in clinicHistory.Practices)
                        {
                            currentWorksheet.Cells[string.Concat("B", 61 + practiceCounter)].Value =
                                Practice.GetPractice(practice.MedicalPracticeId).Name;

                            //Imprimo los resultados de las distintas practicas.
                            MedicalHistoryPracticeDto medicalHistoryPractice = MedicalHistoryPractice.GetPractice(clinicHistoryId, practice.MedicalPracticeId);
                            currentWorksheet.Cells[string.Concat("E", 61 + practiceCounter)].Value = string.Empty; //medicalHistoryPractice.Result.ToString();

                            //if (!string.IsNullOrEmpty(medicalHistoryPractice.Observations))
                            //{
                            //    currentWorksheet.Cells[string.Concat("F", 61 + practiceCounter)].Value =
                            //        medicalHistoryPractice.Observations.Replace("\r\n", " ");
                            //}

                            practiceCounter++;
                        }


                        double columnwidth = 8.43;
                        currentWorksheet.Column(2).Width = columnwidth;
                        currentWorksheet.Column(3).Width = columnwidth;
                        currentWorksheet.Column(4).Width = columnwidth;

                        package.Save();
                        excel.Open(string.Concat(ConfigurationManager.AppSettings["ExcelPath"],
                                                 clinicHistoryId.ToString(), ".xlsx"));
                        excel.Print();
                        excel.Close();
                        excel.Quit();
                        RemoveFile(string.Concat(ConfigurationManager.AppSettings["ExcelPath"],
                                                 clinicHistoryId.ToString(), ".xlsx"));
                    }
                }

            }
        }

        public static void GeneratePartialExcel(Guid clinicHistoryId, string filePath, string companyName)
        {
            MSExcel excel = new MSExcel();
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
                                AddImage(currentWorksheet, 7, 13,
                                         string.Concat(ConfigurationManager.AppSettings["filePhotoServerPath"],
                                                       clinicHistory.Patient.Photo), 170, 185);
                            }
                        }

                        var companyInfoList = CompanyInfo.GetCompanyInfoList();
                        var companyInfo = (from cil in companyInfoList
                                           where cil.Name == companyName
                                           select cil).First();
                        if (!string.IsNullOrEmpty(companyInfo.Image))
                        {
                            if (
                                File.Exists(string.Concat(ConfigurationManager.AppSettings["fileImagePath"],
                                                          companyInfo.Image)))
                            {
                                AddImage(currentWorksheet, 2, 0,
                                         string.Concat(ConfigurationManager.AppSettings["fileImagePath"],
                                                       companyInfo.Image), 190, 103);
                            }
                        }

                        currentWorksheet.Cells["C6"].Value = string.Concat(companyInfo.Address, " - (",
                                                                           companyInfo.PostalCode, ")", ", ",
                                                                           companyInfo.Province, " Tels.: ",
                                                                           companyInfo.Phone,
                                                                           " - Tel/Fax ", companyInfo.Fax, " Email: ",
                                                                           companyInfo.Email);

                        var clientAddress = clinicHistory.Client.Addresses.First();
                        //Header of the first page
                        currentWorksheet.Cells["C10"].Value = clinicHistory.Client.Name;
                        currentWorksheet.Cells["I10"].Value = clinicHistory.Client.Cuit;
                        currentWorksheet.Cells["C11"].Value =
                            string.Concat(clientAddress.StreetLineOne, " ",
                                          clientAddress.Number, ", ",
                                          clientAddress.AddressState.Name);
                        currentWorksheet.Cells["I11"].Value = clinicHistory.Client.PhoneNumber;

                        currentWorksheet.Cells["E13"].Value = clinicHistory.Patient.FullName;
                        currentWorksheet.Cells["E14"].Value = clinicHistory.Patient.BirthDay.ToShortDateString();
                        currentWorksheet.Cells["E15"].Value = UiUtils.GetAge(clinicHistory.Patient.BirthDay).ToString(CultureInfo.InvariantCulture);
                        currentWorksheet.Cells["E18"].Value = clinicHistory.Patient.CivilState;
                        currentWorksheet.Cells["E19"].Value = clinicHistory.Patient.InstructionLevel;
                        currentWorksheet.Cells["E20"].Value = clinicHistory.Patient.InstructionTitle;

                        currentWorksheet.Cells["E16"].Value = clinicHistory.Patient.BirthPlace.Name;
                        currentWorksheet.Cells["E22"].Value =
                            string.Concat(clinicHistory.Patient.DocumentType.ToString(), " ",
                                          clinicHistory.Patient.DocumentNumber);

                        currentWorksheet.Cells["I6"].Value = clinicHistory.CreatedDate.ToShortDateString();
                        Address address = clinicHistory.Patient.Addresses.Where(x => x.Type == AddressType.Legal).First();
                        currentWorksheet.Cells["E23"].Value =
                            string.Concat(address.StreetLineOne, " ", address.Number);
                        currentWorksheet.Cells["G3"].Value = EnumUtils.AddSpaceInCapitalLetter(clinicHistory.TypeOfExam.ToString());
                        currentWorksheet.Cells["E25"].Value = clinicHistory.TaskToDo;
                        currentWorksheet.Cells["E26"].Value = clinicHistory.WorkArea;

                        //Practices
                        int count = 14;
                        List<Guid> addedGroupIds = new List<Guid>();
                        foreach (var medicalPractice in clinicHistory.Practices)
                        {
                            if (medicalPractice.GroupId != null && medicalPractice.GroupId != Guid.Empty)
                            {
                                if (!addedGroupIds.Any(g => g == medicalPractice.GroupId.Value))
                                {
                                    currentWorksheet.Cells["H" + count.ToString()].Value = Group.GetGroup(medicalPractice.GroupId.Value).Description;
                                    addedGroupIds.Add(medicalPractice.GroupId.Value);
                                    count++;
                                }
                            }
                            else
                            {
                                Practice practice = Practice.GetPractice(medicalPractice.MedicalPracticeId);
                                currentWorksheet.Cells["H" + count.ToString()].Value = practice.Name;
                                count++;
                            }
                            if (count > 26)
                            {
                                break;
                            }
                        }


                        //Records
                        currentWorksheet.Cells["d31"].Value = string.IsNullOrEmpty(clinicHistory.MedicalExam.HereditaryRecords) ? Constants.NotAffection : clinicHistory.MedicalExam.HereditaryRecords;
                        currentWorksheet.Cells["d33"].Value = string.IsNullOrEmpty(clinicHistory.MedicalExam.PathologicalRecords) ? Constants.NotAffection : clinicHistory.MedicalExam.PathologicalRecords;
                        currentWorksheet.Cells["d36"].Value = string.IsNullOrEmpty(clinicHistory.MedicalExam.SurgicalRecords) ? Constants.NotAffection : clinicHistory.MedicalExam.SurgicalRecords;
                        currentWorksheet.Cells["d38"].Value = string.IsNullOrEmpty(clinicHistory.MedicalExam.TraumaRecors) ? Constants.NotAffection : clinicHistory.MedicalExam.TraumaRecors;
                        currentWorksheet.Cells["d40"].Value = string.IsNullOrEmpty(clinicHistory.MedicalExam.ObstetricalRecords) ? Constants.NotAffection : clinicHistory.MedicalExam.ObstetricalRecords;
                        currentWorksheet.Cells["c43"].Value = string.IsNullOrEmpty(clinicHistory.MedicalExam.OtherRecords) ? Constants.NotAffection : clinicHistory.MedicalExam.OtherRecords;


                        //Habits
                        string habits = string.Empty;
                        if (clinicHistory.MedicalExam.Smoke)
                        {
                            habits = string.Concat("Fuma (", clinicHistory.MedicalExam.SmokeCount,
                                                   "), ");

                        }
                        else
                        {
                            habits = "No fuma, ";
                        }
                        if (clinicHistory.MedicalExam.Alcohol)
                        {
                            habits = string.Concat(habits, "Consume bebidas alcoholicas ( ",
                                                   clinicHistory.MedicalExam.AlcoholCount, "), ");

                        }
                        else
                        {
                            habits = string.Concat(habits, "No consume bebidas alcoholicas, ");
                        }
                        if (clinicHistory.MedicalExam.NormalSleep)
                        {
                            habits = string.Concat(habits, "Tiene sueño normal y decansa (",
                                                   clinicHistory.MedicalExam.SleepHours, "), ");

                        }
                        else
                        {
                            habits = string.Concat(habits, "No tiene sueño normal y no decansa (",
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
                        currentWorksheet.Cells["F45"].Value = habits;
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
                return convertedWeight / (convertedSize * convertedSize);
            }
            return 0;
        }
    }
}

