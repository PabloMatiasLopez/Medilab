using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using Medilab.BusinessObjects.DebitCreditNote;

namespace Medilab.UserInterface.DebitNote
{
    public partial class frmDebitNoteList : Form
    {
        public frmDebitNoteList()
        {
            InitializeComponent();
            LoadDropdowns();
            FilterList();
        }
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
        #endregion
        #region Methods
        private void LoadDropdowns()
        {
            //Companies   
            cbClient.Items.Clear();
            cbClient.DataSource = null;
            var companies = Client.GetClients().ToList();
            cbClient.DataSource = companies;
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            var creditNoteId = Guid.Parse(gvDebitNotes.SelectedRows[0].Cells[0].Value.ToString());
            //DebitNoteDto creditNote = BusinessObjects.DebitCreditNote.DebitNote.GetDebitNoteToPrint(creditNoteId);
            //TODO: Hay que implemetar el Handler para manejar la impresion
            //CreditNoteExcelHandler.GenerateExcel(creditNote);
        }
        private void FilterList()
        {
            gvDebitNotes.DataSource = null;
            gvDebitNotes.Refresh();
            List<BusinessObjects.DebitCreditNote.DebitNote> debitNoteHeaderList;
            if (!string.IsNullOrWhiteSpace(txtClientNumber.Text))
            {
                int number;
                int.TryParse(txtClientNumber.Text, out number);
                debitNoteHeaderList = BusinessObjects.DebitCreditNote.DebitNote.GetDebitNoteByClient(number);
            }
            else
            {
                debitNoteHeaderList = BusinessObjects.DebitCreditNote.DebitNote.GetDebitNoteByClient(((ListItemDto<Guid>)(cbClient.SelectedItem)).Id);
            }

            if (debitNoteHeaderList.Count > 0)
            {
                BindGrid(debitNoteHeaderList);
            }
        }

        private void BindGrid(List<BusinessObjects.DebitCreditNote.DebitNote> debitNoteHeader)
        {
            gvDebitNotes.AutoGenerateColumns = false;
            gvDebitNotes.DataSource = debitNoteHeader;
            gvDebitNotes.Visible = true;
        }
        #endregion
    }
}
