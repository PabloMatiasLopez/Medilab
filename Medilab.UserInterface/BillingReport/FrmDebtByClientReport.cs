using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Medilab.BusinessObjects.BillingReport;
using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.DTOs;

namespace Medilab.UserInterface.BillingReport
{
    public partial class FrmDebtByClientReport : Form
    {
        #region Events
        private void btnCombinedSearch_Click(object sender, EventArgs e)
        {
            FilterList();
        }
        private void txtClientNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }
        private void cbOnlyPending_CheckStateChanged(object sender, EventArgs e)
        {
            dtmDateTo.Enabled = !cbOnlyPending.Checked;
            dtpDateFrom.Enabled = !cbOnlyPending.Checked;
        }
        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (gvBillingMovements.DataSource != null)
            {
                foreach (DataGridViewRow row in gvBillingMovements.Rows)
                {
                    row.Cells[0].Value = chkSelectAll.Checked;
                }
            }
        }
        #endregion
        #region Methods
        public FrmDebtByClientReport()
        {
            InitializeComponent();
            LoadDropdowns();
            dtmDateTo.Value = DateTime.Now;
            dtpDateFrom.Value = DateTime.Now.AddMonths(-3);
        }
        private void LoadDropdowns()
        {
            //Companies   
            cbClient.Items.Clear();
            cbClient.DataSource = null;
            var companies = Client.GetClients().ToList();
            cbClient.DataSource = companies;
        }
        private void BindGrid(List<DebtByClientItemDto> billingMovements)
        {
            DataGridViewColumn dataGridViewColumn = gvBillingMovements.Columns["Column1"];
            if (dataGridViewColumn != null)
            {
                dataGridViewColumn.Visible = cbOnlyPending.Checked;
            }
            chkSelectAll.Visible = cbOnlyPending.Checked;
            chkSelectAll.Checked = false;
            gvBillingMovements.AutoGenerateColumns = false;
            gvBillingMovements.DataSource = billingMovements;
            gvBillingMovements.Visible = true;
        }

        private void FilterList()
        {
            gvBillingMovements.DataSource = null;
            gvBillingMovements.Refresh();
            var criteria = new DebtReportCriteriaDto
            {
                OnlyPending = cbOnlyPending.Checked,
                DateFrom = dtpDateFrom.Value,
                DateTo = dtmDateTo.Value
            };
            if (!string.IsNullOrWhiteSpace(txtClientNumber.Text))
            {
                criteria.SearchByClientNumber = true;
                int number;
                Int32.TryParse(txtClientNumber.Text, out number);
                criteria.ClientNumber = number;
            }
            else
            {
                criteria.ClientId = ((ListItemDto<Guid>) (cbClient.SelectedItem)).Id;
            }

            DebtReportResultDto reportResult = DebtReport.DebtByClientReport(criteria);

            if (reportResult.Items.Count > 0)
            {
                lblTotal.Text = string.Format("TOTAL: {0}", reportResult.Total.ToString("C2"));

                reportResult.Items.Add(new DebtByClientItemDto
                {
                    Type = "TOTAL",
                    Date = DateTime.Today,
                    Total = reportResult.Total
                });

                BindGrid(reportResult.Items);

                for (int i = 0; i < gvBillingMovements.Rows[gvBillingMovements.Rows.Count - 1].Cells.Count; i++)
                {
                    gvBillingMovements.Rows[gvBillingMovements.Rows.Count - 1].Cells[i].Style.BackColor =
                        Color.LawnGreen;
                    gvBillingMovements.Rows[gvBillingMovements.Rows.Count - 1].Cells[i].Style.Font =
                        new Font(gvBillingMovements.Font, FontStyle.Bold);
                }
            }
            else
            {
                lblTotal.Text = string.Empty;
            }
        }
        
        #endregion
    }
}
