using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Medilab.UserInterface.Utils;
using System.Configuration;

namespace Medilab.UserInterface.Pacientes
{
    public partial class FrmAddEditPatient : Form
    {
        #region Properties
        public UcAddEditPatient UcPatient { get; set; }
        #endregion
        #region Events
        void ucAddEditPatient_CancelButtonPressed(object sender, EventArgs e)
        {
            var parent = ((UserControl)sender).Parent as Form;
            if (parent != null)
            {
                parent.Close();
            }
        }
        void ucAddEditPatient_SaveButtonPressed(object sender, EventArgs e)
        {
            var parent = ((UserControl)sender).Parent as Form;
            if (parent != null)
            {
                parent.DialogResult = DialogResult.OK;
                parent.Close();
            }
        }
        void observer_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                UcPatient.ImageLocation = e.FullPath;
                UcPatient.NewCreatedPhotoName = e.Name;
            }
            catch (Exception exception)
            {
                throw exception;

            }
            

        }
        #endregion
        #region Methods
        public FrmAddEditPatient()
        {
            Initialize(Guid.Empty);
        }
        public FrmAddEditPatient(Guid patientId)
        {
            Initialize(patientId);
        }
        private void Initialize(Guid patientId)
        {
            InitializeComponent();
            DirectoryActivityObserver();
            var ucAddEditPatient = new UcAddEditPatient(patientId)
            {
                Location = new Point(13, 13),
                Name = "ucAddEditPatient",
                Size = new Size(940, 530),
                TabIndex = 0
            };
            ucAddEditPatient.CancelButtonPressed += ucAddEditPatient_CancelButtonPressed;
            ucAddEditPatient.SaveButtonPressed += ucAddEditPatient_SaveButtonPressed;
            UcPatient = ucAddEditPatient;
            Controls.Add(ucAddEditPatient);
        }
        public void DirectoryActivityObserver()
        {
            var observer = new FileSystemWatcher();
            if (!FileDirectoryHandler.CheckIfDirectoryExist(ConfigurationManager.AppSettings["filePhotoPath"]))
            {
                FileDirectoryHandler.CreateDirectory(ConfigurationManager.AppSettings["filePhotoPath"]);
            }
            string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            if (Environment.OSVersion.Version.Major >= 6)
            {
                path = Directory.GetParent(path).FullName;
            }
            var filePath = path + ConfigurationManager.AppSettings["filePhotoPath"];
            observer.Path = filePath;
            observer.Filter = ConfigurationManager.AppSettings["filePhotoExtention"];
            observer.NotifyFilter = NotifyFilters.FileName;
            observer.Created += observer_Created;
            observer.EnableRaisingEvents = true;
        }
        #endregion

    }
}
