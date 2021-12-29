using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Medilab.BusinessObjects.ClinicalHistory;

namespace Medilab.UserInterface.ClinicalHistory
{
    public partial class FrmGroupPractices : Form
    {
        public FrmGroupPractices(PracticeListDto group)
        {
            InitializeComponent();
            this.Text = group.Name;
            List<MedicalHistoryPracticeDto> practicesList = MedicalHistoryPractice.GetPracticesDtoInGroup(group.MedicalHistoryId, group.Id).ToList();
            var practiceListDto = practicesList.Select(medicalHistoryPractice => new PracticeListDto
            {
                Name = medicalHistoryPractice.Name,
                Description = medicalHistoryPractice.Description,
                Status = medicalHistoryPractice.Status,
                Code = medicalHistoryPractice.Code
            }).ToList();
            var data = new BindingSource { DataSource = practiceListDto };
            gvPractices.AutoGenerateColumns = false;
            gvPractices.DataSource = data;
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
