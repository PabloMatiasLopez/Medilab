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
    public static class AsismedExcelHandler
    {
        public static void GenerateExcel(Guid clinicHistoryId, string filePath, string companyName)
        {
            MSExcel excel = new MSExcel();
            RemoveFile(string.Concat(ConfigurationManager.AppSettings["ExcelPath"], clinicHistoryId.ToString(), ".xlsx"));
            // Get the file we are going to process
            File.Copy(filePath, string.Concat(ConfigurationManager.AppSettings["ExcelPath"], clinicHistoryId.ToString(), ".xlsx"));

            var template = new FileInfo(string.Concat(ConfigurationManager.AppSettings["ExcelPath"], clinicHistoryId.ToString(), ".xlsx"));
            
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
                        #region FirstPage
                        // Get the first worksheet
                        ExcelWorksheet currentWorksheet = workBook.Worksheets.First();

                        if(!string.IsNullOrEmpty(clinicHistory.Patient.Photo))
                        {
                            if (File.Exists(string.Concat(ConfigurationManager.AppSettings["filePhotoServerPath"], clinicHistory.Patient.Photo)))
                            {
                                AddImage(currentWorksheet, 1, 7, string.Concat(ConfigurationManager.AppSettings["filePhotoServerPath"], clinicHistory.Patient.Photo), 180, 190);
                            }
                        }
                        var companyInfoList = CompanyInfo.GetCompanyInfoList();
                        var companyInfo = (from cil in companyInfoList
                                           where cil.Name == companyName
                                           select cil).First();
                        if (!string.IsNullOrEmpty(companyInfo.Image))
                        {
                            if (File.Exists(string.Concat(ConfigurationManager.AppSettings["fileImagePath"], companyInfo.Image)))
                            {
                                AddImage(currentWorksheet, 7, 0, string.Concat(ConfigurationManager.AppSettings["fileImagePath"], companyInfo.Image), 261, 59);
                            }
                        }
                        currentWorksheet.Cells["H4"].Value = string.Concat(companyInfo.Address, " - (",
                                                                           companyInfo.PostalCode, ")", ", ",
                                                                           companyInfo.Province);
                        currentWorksheet.Cells["H5"].Value = string.Concat("Tels.: ", companyInfo.Phone.TrimEnd(' '), " Tel./Fax ", companyInfo.Fax);
                        currentWorksheet.Cells["H6"].Value = string.Concat( "Email: ", companyInfo.Email);
                        //currentWorksheet.Cells["H7"].Value = string.Concat("Email: ", companyInfo.Email);
                        //Header of the first page
                        currentWorksheet.Cells["G8"].Value = clinicHistory.Client.Name;
                        currentWorksheet.Cells["D18"].Value = clinicHistory.Patient.FullName;
                        currentWorksheet.Cells["D19"].Value = clinicHistory.Patient.BirthDay.ToShortDateString();
                        currentWorksheet.Cells["G19"].Value = UiUtils.GetAge(clinicHistory.Patient.BirthDay).ToString(CultureInfo.InvariantCulture);
                        currentWorksheet.Cells["J19"].Value = clinicHistory.Patient.Nationality;
                        currentWorksheet.Cells["D20"].Value = clinicHistory.Patient.BirthPlace.Name;
                        currentWorksheet.Cells["J20"].Value = string.Concat(clinicHistory.Patient.DocumentType.ToString(), " ", clinicHistory.Patient.DocumentNumber);
                        string gender = "Masculino";
                        if (clinicHistory.Patient.Gender.ToString() == "Female")
                        {
                            gender = "Femenino";
                        }
                        currentWorksheet.Cells["C21"].Value = gender;
                        currentWorksheet.Cells["E21"].Value = clinicHistory.Patient.CivilState.ToString();
                        currentWorksheet.Cells["J21"].Value = clinicHistory.Patient.ChildrenNumber.ToString(CultureInfo.InvariantCulture);
                        currentWorksheet.Cells["J22"].Value = clinicHistory.Patient.HomePhone;
                        currentWorksheet.Cells["J23"].Value = clinicHistory.Patient.CellPhone;
                        currentWorksheet.Cells["E27"].Value = clinicHistory.CreatedDate.ToShortDateString();
                        Address address = clinicHistory.Patient.Addresses.Where(x => x.Type == AddressType.Legal).First();
                        currentWorksheet.Cells["C22"].Value = string.Concat(address.StreetLineOne, " ",
                                                                            address.Number);
                        currentWorksheet.Cells["G13"].Value = EnumUtils.AddSpaceInCapitalLetter(clinicHistory.TypeOfExam.ToString()).ToUpper();
                        currentWorksheet.Cells["B44"].Value = clinicHistory.ClinicalHistoryObservations;

                        //i27
                        int practiceCounter = 1;
                        foreach (var practice in clinicHistory.Practices)
                        {
                            currentWorksheet.Cells[string.Concat("i", 31 + practiceCounter)].Value =
                                string.Concat(practiceCounter, "°.");

                            currentWorksheet.Cells[string.Concat("j", 31 + practiceCounter)].Value =
                                Practice.GetPractice(practice.MedicalPracticeId).Name;

                           practiceCounter++;
                        }
                        currentWorksheet.Cells["F63"].Value = clinicHistory.TaskToDo;
                        
                        #endregion
                        #region SecondPage

                        if (!string.IsNullOrEmpty(companyInfo.Image))
                        {
                            if (File.Exists(string.Concat(ConfigurationManager.AppSettings["fileImagePath"], companyInfo.Image)))
                            {
                                AddImage(currentWorksheet, 9, 50, string.Concat(ConfigurationManager.AppSettings["fileImagePath"], companyInfo.Image), 135, 29);
                            }
                        }


                        //currentWorksheet.Cells["G4"].Value = clinicHistory.Client.Name;
                        currentWorksheet.Cells["D55"].Value = clinicHistory.Patient.FullName;
                        currentWorksheet.Cells["D56"].Value = clinicHistory.Patient.BirthDay.ToShortDateString();
                        currentWorksheet.Cells["G56"].Value = UiUtils.GetAge(clinicHistory.Patient.BirthDay).ToString(CultureInfo.InvariantCulture);
                        currentWorksheet.Cells["J56"].Value = clinicHistory.Patient.Nationality;
                        currentWorksheet.Cells["D57"].Value = clinicHistory.Patient.BirthPlace.Name;
                        currentWorksheet.Cells["J57"].Value = string.Concat(clinicHistory.Patient.DocumentType.ToString(), " ", clinicHistory.Patient.DocumentNumber);
                        currentWorksheet.Cells["C58"].Value = gender;
                        currentWorksheet.Cells["E58"].Value = clinicHistory.Patient.CivilState.ToString();
                        currentWorksheet.Cells["J58"].Value = clinicHistory.Patient.ChildrenNumber.ToString(CultureInfo.InvariantCulture);
                        currentWorksheet.Cells["J59"].Value = clinicHistory.Patient.HomePhone;
                        currentWorksheet.Cells["J60"].Value = clinicHistory.Patient.CellPhone;
                        currentWorksheet.Cells["I65"].Value = clinicHistory.CreatedDate.ToShortDateString();
                        currentWorksheet.Cells["C59"].Value = string.Concat(address.StreetLineOne, " ",
                                                                            address.Number);
                        currentWorksheet.Cells["B68"].Value = clinicHistory.MedicalExam.Observations;


                        int practiceCounter2 = 0;
                        string columnIndicator = "B";
                      
                        List<string> labresults = new List<string>();
                        foreach (var practice in clinicHistory.Practices)
                        {
                            MedicalHistoryPracticeDto medicalHistoryPractice = MedicalHistoryPractice.GetPractice(clinicHistoryId, practice.MedicalPracticeId);
                            var specilityId = Practice.GetPractice(practice.MedicalPracticeId).Speciality.Id;
                            if (specilityId == Constants.LabId)
                            {
                                
                                //if (!string.IsNullOrEmpty(practice.Observations))
                                //{
                                //    string replaced = practice.Observations.Replace("\r\n", "*");
                                //    string[] results = replaced.Split('*');
                                //    foreach (var result in results)
                                //    {
                                //        labresults.Add(result);
                                //    }
                                //}
                            }
                            else
                            {
                                if (practiceCounter2 > 7)
                                {
                                    practiceCounter2 = 0;
                                    columnIndicator = "G";
                                }
                                currentWorksheet.Cells[string.Concat(columnIndicator, 87 + practiceCounter2)].Value = string.Concat(Practice.GetPractice(practice.MedicalPracticeId).Name, ": ");//, medicalHistoryPractice.Result.ToString());
                                practiceCounter2++;
                            }
                        }

                        int labCounter = 0;
                        string columnIndicatorlab = "B";
                        foreach (var labresult in labresults)
                        {
                            if (labCounter > 7)
                            {
                                labCounter = 0;
                                columnIndicatorlab = "G";
                            }

                            currentWorksheet.Cells[string.Concat(columnIndicatorlab, 77 + labCounter)].Value =
                                labresult;
                            labCounter++;
                        }

                        #endregion
                        #region 3rd Page
                        if (!string.IsNullOrEmpty(companyInfo.Image))
                        {
                            if (File.Exists(string.Concat(ConfigurationManager.AppSettings["fileImagePath"], companyInfo.Image)))
                            {
                                AddImage(currentWorksheet, 9, 100, string.Concat(ConfigurationManager.AppSettings["fileImagePath"], companyInfo.Image), 135, 29);
                            }
                        }
                        currentWorksheet.Cells["D105"].Value = clinicHistory.Patient.FullName;
                        currentWorksheet.Cells["D106"].Value = clinicHistory.Patient.BirthDay.ToShortDateString();
                        currentWorksheet.Cells["G106"].Value = UiUtils.GetAge(clinicHistory.Patient.BirthDay).ToString(CultureInfo.InvariantCulture);
                        currentWorksheet.Cells["J106"].Value = clinicHistory.Patient.Nationality;
                        currentWorksheet.Cells["D107"].Value = clinicHistory.Patient.BirthPlace.Name;
                        currentWorksheet.Cells["J107"].Value = string.Concat(clinicHistory.Patient.DocumentType.ToString(), " ", clinicHistory.Patient.DocumentNumber);
                        currentWorksheet.Cells["C108"].Value = gender;
                        currentWorksheet.Cells["E108"].Value = clinicHistory.Patient.CivilState.ToString();
                        currentWorksheet.Cells["J108"].Value = clinicHistory.Patient.ChildrenNumber.ToString(CultureInfo.InvariantCulture);
                        currentWorksheet.Cells["J109"].Value = clinicHistory.Patient.HomePhone;
                        currentWorksheet.Cells["J110"].Value = clinicHistory.Patient.CellPhone;
                        currentWorksheet.Cells["C109"].Value = string.Concat(address.StreetLineOne, " ",
                                                                             address.Number);
                        #endregion

                        //Records
                        currentWorksheet.Cells["d115"].Value = string.IsNullOrEmpty(clinicHistory.MedicalExam.HereditaryRecords) ? Constants.NotAffection:clinicHistory.MedicalExam.HereditaryRecords;
                        currentWorksheet.Cells["d117"].Value = string.IsNullOrEmpty(clinicHistory.MedicalExam.PathologicalRecords) ? Constants.NotAffection : clinicHistory.MedicalExam.PathologicalRecords;
                        currentWorksheet.Cells["d120"].Value = string.IsNullOrEmpty(clinicHistory.MedicalExam.SurgicalRecords) ? Constants.NotAffection : clinicHistory.MedicalExam.SurgicalRecords;
                        currentWorksheet.Cells["d122"].Value = string.IsNullOrEmpty(clinicHistory.MedicalExam.TraumaRecors) ? Constants.NotAffection : clinicHistory.MedicalExam.TraumaRecors;
                        currentWorksheet.Cells["d124"].Value = string.IsNullOrEmpty(clinicHistory.MedicalExam.ObstetricalRecords) ? Constants.NotAffection : clinicHistory.MedicalExam.ObstetricalRecords;
                        currentWorksheet.Cells["c127"].Value = string.IsNullOrEmpty(clinicHistory.MedicalExam.OtherRecords) ? Constants.NotAffection : clinicHistory.MedicalExam.OtherRecords;


                        //Habits
                        if (clinicHistory.MedicalExam.Smoke)
                        {
                            currentWorksheet.Cells["f135"].Value = "X";
                            currentWorksheet.Cells["k135"].Value = clinicHistory.MedicalExam.SmokeCount;
                        }
                        else
                        {
                            currentWorksheet.Cells["g135"].Value = "X";
                        }
                        if (clinicHistory.MedicalExam.Alcohol)
                        {
                            currentWorksheet.Cells["f137"].Value = "X";
                            currentWorksheet.Cells["K137"].Value = clinicHistory.MedicalExam.AlcoholCount;
                        }
                        else
                        {
                            currentWorksheet.Cells["g137"].Value = "X";
                        }
                        if (clinicHistory.MedicalExam.NormalSleep)
                        {
                            currentWorksheet.Cells["f139"].Value = "X";
                            currentWorksheet.Cells["K139"].Value = clinicHistory.MedicalExam.SleepHours;
                        }
                        else
                        {
                            currentWorksheet.Cells["g139"].Value = "X";
                        }
                        if (clinicHistory.MedicalExam.Sports)
                        {
                            currentWorksheet.Cells["f141"].Value = "X";
                            currentWorksheet.Cells["K141"].Value = clinicHistory.MedicalExam.SportsDetails;
                        }
                        else
                        {
                            currentWorksheet.Cells["g141"].Value = "X";
                        }

                        #region 4th header
                        if (!string.IsNullOrEmpty(companyInfo.Image))
                        {
                            if (File.Exists(string.Concat(ConfigurationManager.AppSettings["fileImagePath"], companyInfo.Image)))
                            {
                                AddImage(currentWorksheet, 9, 149, string.Concat(ConfigurationManager.AppSettings["fileImagePath"], companyInfo.Image), 135, 29);
                            }
                        }
                        currentWorksheet.Cells["D152"].Value = clinicHistory.Patient.FullName;
                        currentWorksheet.Cells["D153"].Value = clinicHistory.Patient.BirthDay.ToShortDateString();
                        currentWorksheet.Cells["G153"].Value = UiUtils.GetAge(clinicHistory.Patient.BirthDay).ToString(CultureInfo.InvariantCulture);
                        currentWorksheet.Cells["J153"].Value = clinicHistory.Patient.Nationality;
                        currentWorksheet.Cells["D154"].Value = clinicHistory.Patient.BirthPlace.Name;
                        currentWorksheet.Cells["J154"].Value = string.Concat(clinicHistory.Patient.DocumentType.ToString(), " ", clinicHistory.Patient.DocumentNumber);
                        currentWorksheet.Cells["C155"].Value = gender;
                        currentWorksheet.Cells["E155"].Value = clinicHistory.Patient.CivilState.ToString();
                        currentWorksheet.Cells["J155"].Value = clinicHistory.Patient.ChildrenNumber.ToString(CultureInfo.InvariantCulture);
                        currentWorksheet.Cells["J156"].Value = clinicHistory.Patient.HomePhone;
                        currentWorksheet.Cells["J157"].Value = clinicHistory.Patient.CellPhone;
                        currentWorksheet.Cells["C156"].Value = string.Concat(address.StreetLineOne, " ",
                                                                             address.Number);
                        #endregion

                        //Clinical exam header
                        currentWorksheet.Cells["C158"].Value = clinicHistory.MedicalExam.Size.ToString("0.00");
                        currentWorksheet.Cells["E158"].Value = clinicHistory.MedicalExam.Weight.ToString("0.00");
                        currentWorksheet.Cells["G158"].Value = GetICM(clinicHistory.MedicalExam.Weight.ToString("0.00"),clinicHistory.MedicalExam.Size.ToString("0.00")).ToString("0.00");
                        currentWorksheet.Cells["j158"].Value = clinicHistory.MedicalExam.AbdominalCircunference.HasValue ? clinicHistory.MedicalExam.AbdominalCircunference.Value.ToString("0.00") : string.Empty;
                        currentWorksheet.Cells["C159"].Value = string.Concat(
                            clinicHistory.MedicalExam.BloodPressureLow, "/",
                            clinicHistory.MedicalExam.BloodPressureHight);
                        currentWorksheet.Cells["G159"].Value = clinicHistory.MedicalExam.Pulse;
                        //Clinical exam
                        currentWorksheet.Cells["E161"].Value = clinicHistory.MedicalExam.Head;
                        currentWorksheet.Cells["G161"].Value = clinicHistory.MedicalExam.HeadDetails;
                        currentWorksheet.Cells["E162"].Value = clinicHistory.MedicalExam.Eyes;
                        currentWorksheet.Cells["G162"].Value = clinicHistory.MedicalExam.EyesDetails;
                        currentWorksheet.Cells["E163"].Value = clinicHistory.MedicalExam.Ear;
                        currentWorksheet.Cells["G163"].Value = clinicHistory.MedicalExam.EarDetails;
                        currentWorksheet.Cells["E164"].Value = clinicHistory.MedicalExam.Nose;
                        currentWorksheet.Cells["G164"].Value = clinicHistory.MedicalExam.NoseDetails;
                        currentWorksheet.Cells["E165"].Value = clinicHistory.MedicalExam.Mouth;
                        currentWorksheet.Cells["G165"].Value = clinicHistory.MedicalExam.MouthDetails;
                        currentWorksheet.Cells["E166"].Value = clinicHistory.MedicalExam.Neck;
                        currentWorksheet.Cells["G166"].Value = clinicHistory.MedicalExam.NeckDetails;
                        currentWorksheet.Cells["E167"].Value = clinicHistory.MedicalExam.Chest;
                        currentWorksheet.Cells["G167"].Value = clinicHistory.MedicalExam.ChestDetails;
                        currentWorksheet.Cells["E168"].Value = clinicHistory.MedicalExam.Lung;
                        currentWorksheet.Cells["G168"].Value = clinicHistory.MedicalExam.LungDetails;
                        currentWorksheet.Cells["E169"].Value = clinicHistory.MedicalExam.Heart;
                        currentWorksheet.Cells["G169"].Value = clinicHistory.MedicalExam.HeartDetails;
                        currentWorksheet.Cells["E170"].Value = clinicHistory.MedicalExam.PeripheralVeins;
                        currentWorksheet.Cells["G170"].Value = clinicHistory.MedicalExam.PeripheralVeinsDetails;
                        currentWorksheet.Cells["E171"].Value = clinicHistory.MedicalExam.PeripheralArteries;
                        currentWorksheet.Cells["G171"].Value = clinicHistory.MedicalExam.PeripheralArteriesDetails;

                        currentWorksheet.Cells["E172"].Value = clinicHistory.MedicalExam.Abdomen;
                        currentWorksheet.Cells["G172"].Value = clinicHistory.MedicalExam.AbdomenDetails;
                        currentWorksheet.Cells["E173"].Value = clinicHistory.MedicalExam.Hernia;
                        currentWorksheet.Cells["G173"].Value = clinicHistory.MedicalExam.HerniaDetails;
                        currentWorksheet.Cells["E174"].Value = clinicHistory.MedicalExam.Genitals;
                        currentWorksheet.Cells["G174"].Value = clinicHistory.MedicalExam.GenitalsDetails;
                        currentWorksheet.Cells["E175"].Value = clinicHistory.MedicalExam.SubcutaneousCellularTissue;
                        currentWorksheet.Cells["G175"].Value = clinicHistory.MedicalExam.SubcutaneousCellularTissueDetails;
                        
                        currentWorksheet.Cells["E176"].Value = clinicHistory.MedicalExam.Kidneys;
                        currentWorksheet.Cells["G176"].Value = clinicHistory.MedicalExam.KidneysDetails;
                        currentWorksheet.Cells["E177"].Value = clinicHistory.MedicalExam.Anus;
                        currentWorksheet.Cells["G177"].Value = clinicHistory.MedicalExam.AnusDetails;
                        currentWorksheet.Cells["E178"].Value = clinicHistory.MedicalExam.Tips;
                        currentWorksheet.Cells["G178"].Value = clinicHistory.MedicalExam.TipsDetails;
                        currentWorksheet.Cells["E179"].Value = clinicHistory.MedicalExam.Backbone;
                        currentWorksheet.Cells["G179"].Value = clinicHistory.MedicalExam.BackboneDetails;
                        currentWorksheet.Cells["E180"].Value = clinicHistory.MedicalExam.Skin;
                        currentWorksheet.Cells["G180"].Value = clinicHistory.MedicalExam.SkinDetails;
                        currentWorksheet.Cells["E181"].Value = clinicHistory.MedicalExam.LympNodes;
                        currentWorksheet.Cells["G181"].Value = clinicHistory.MedicalExam.LympNodesDetails;
                        currentWorksheet.Cells["E182"].Value = clinicHistory.MedicalExam.NervousSystem;
                        currentWorksheet.Cells["G182"].Value = clinicHistory.MedicalExam.NervousSystemDetails;
                        currentWorksheet.Cells["E183"].Value = clinicHistory.MedicalExam.Motion;
                        currentWorksheet.Cells["G183"].Value = clinicHistory.MedicalExam.MotionDetails;
                        
                        currentWorksheet.Cells["E184"].Value = clinicHistory.MedicalExam.PsychicTest;
                        currentWorksheet.Cells["G184"].Value = clinicHistory.MedicalExam.PsychicTestDetails;
                        currentWorksheet.Cells["E185"].Value = clinicHistory.MedicalExam.BalanceTest;
                        currentWorksheet.Cells["G185"].Value = clinicHistory.MedicalExam.BalanceTestDetails;
                        currentWorksheet.Cells["E187"].Value = clinicHistory.MedicalExam.Scars;
                        currentWorksheet.Cells["G187"].Value = clinicHistory.MedicalExam.ScarsDetails;

                        currentWorksheet.Cells["D193"].Value = clinicHistory.MedicalExam.EyeFarNoCorrectionRight;
                        currentWorksheet.Cells["E193"].Value = clinicHistory.MedicalExam.EyeNearNoCorrectionRight;
                        currentWorksheet.Cells["G193"].Value = clinicHistory.MedicalExam.EyeNearWithCorrectionRight;
                        currentWorksheet.Cells["I193"].Value = clinicHistory.MedicalExam.EyeFarWithCorrectionRight;
                        currentWorksheet.Cells["D194"].Value = clinicHistory.MedicalExam.EyeFarNoCorrectionLeft;
                        currentWorksheet.Cells["E194"].Value = clinicHistory.MedicalExam.EyeNearNoCorrectionLeft;
                        currentWorksheet.Cells["G194"].Value = clinicHistory.MedicalExam.EyeNearWithCorrectionLeft;
                        currentWorksheet.Cells["I194"].Value = clinicHistory.MedicalExam.EyeFarWithCorrectionLeft;
                        double columnwidth = 8.43;
                        currentWorksheet.Column(2).Width = columnwidth;
                        currentWorksheet.Column(3).Width = columnwidth;
                        currentWorksheet.Column(4).Width = columnwidth;

                        package.Save();
                        excel.Open(string.Concat(ConfigurationManager.AppSettings["ExcelPath"], clinicHistoryId.ToString(), ".xlsx"));
                        excel.Print();
                        excel.Close();
                        excel.Quit();
                        RemoveFile(string.Concat(ConfigurationManager.AppSettings["ExcelPath"], clinicHistoryId.ToString(), ".xlsx"));
                    }
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
