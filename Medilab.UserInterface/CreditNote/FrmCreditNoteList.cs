using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.DebitCreditNote;
using Medilab.BusinessObjects.DTOs;
using Medilab.UserInterface.PrintUtilities;
using Medilab.UserInterface.Excel;

namespace Medilab.UserInterface.CreditNote
{
    public partial class FrmCreditNoteList : Form
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
        private void btnPrint_Click(object sender, EventArgs e)
        {
            var creditNoteId = Guid.Parse(gvCreditNotes.SelectedRows[0].Cells[0].Value.ToString());
            CreditNoteDto creditNote = BusinessObjects.DebitCreditNote.CreditNote.GetCreditNoteToPrint(creditNoteId);
            CreditNoteExcelHandler.GenerateExcel(creditNote,true);
        }
        #endregion
        #region Methods
        public FrmCreditNoteList()
        {
            InitializeComponent();
            LoadDropdowns();
            FilterList();
        }
        private void LoadDropdowns()
        {
            //Companies   
            cbClient.Items.Clear();
            cbClient.DataSource = null;
            var companies = Client.GetClients().ToList();
            cbClient.DataSource = companies;
        }
        private void BindGrid(List<BusinessObjects.DebitCreditNote.CreditNote> creditNoteHeader)
        {
            gvCreditNotes.AutoGenerateColumns = false;
            gvCreditNotes.DataSource = creditNoteHeader;
            gvCreditNotes.Visible = true;
        }

        private void FilterList()
        {
            gvCreditNotes.DataSource = null;
            gvCreditNotes.Refresh();
            List<BusinessObjects.DebitCreditNote.CreditNote> creditNoteHeaderList;
            if (!string.IsNullOrWhiteSpace(txtClientNumber.Text))
            {
                int number;
                int.TryParse(txtClientNumber.Text, out number);
                creditNoteHeaderList = BusinessObjects.DebitCreditNote.CreditNote.GetCreditNoteByClient(number);
            }
            else
            {
                creditNoteHeaderList = BusinessObjects.DebitCreditNote.CreditNote.GetCreditNoteByClient(((ListItemDto<Guid>)(cbClient.SelectedItem)).Id);
            }
            
            if (creditNoteHeaderList.Count > 0)
            {
                BindGrid(creditNoteHeaderList);
            }
        }
        #endregion
    }
}
