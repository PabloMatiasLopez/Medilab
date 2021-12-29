using System;
using System.Windows.Forms;
using Medilab.BusinessObjects.Address;

namespace Medilab.UserInterface.Pacientes
{
    public partial class FrmHistoryAddressList : Form
    {
        #region Properties
        private readonly Guid _patientId;
        #endregion
        #region Events
        // ReSharper disable InconsistentNaming
        public FrmHistoryAddressList(Guid patientId)
        {
            _patientId = patientId;
            InitializeComponent();
        }
        private void FrmHistoryAddressList_Load(object sender, EventArgs e)
        {
            LoadAddresses();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        // ReSharper restore InconsistentNaming
        #endregion
        #region Methods
        private void LoadAddresses()
        {
            var addressList = Address.GetArchiveAddressesByOwner(_patientId);
            gvAddresses.AutoGenerateColumns = false;
            gvAddresses.DataSource = addressList;
        }
        #endregion
    }
}
