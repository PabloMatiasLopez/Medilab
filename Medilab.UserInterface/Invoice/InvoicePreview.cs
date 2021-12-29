using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.Invoice;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.PrintUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using InvoiceHeader = Medilab.BusinessObjects.Invoice.InvoiceHeader;

namespace Medilab.UserInterface.Invoice
{
    public partial class InvoicePreview : Form
    {
        private readonly InvoiceDisplay _invoice;
        private readonly IDetailPreview _detailPreview;
        private readonly InvoiceProcess _invoiceProcess;
        private readonly Client _client;
        private Guid _savedInvoiceId;
        private readonly bool _printInvoiceDetail;
       
        public InvoicePreview(InvoiceDisplay invoice, IDetailPreview detailPreview, Client client, bool printInvoiceDetail)
        {
            _invoice = invoice;
            _detailPreview = detailPreview;
            InitializeComponent();
            _invoiceProcess = new InvoiceProcess();
            _client = client;
            _printInvoiceDetail = printInvoiceDetail;
        }

        #region Events

        private void InvoicePreview_Load(object sender, EventArgs e)
        {
            LoadHeader();
            LoadPreview();
            LoadFooter();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var printer = new Printer();
            if (printer.PrintInvoice(_savedInvoiceId))
            {
                if(_printInvoiceDetail)
                {
                    PrintDetails.PrintInvoiceDetails(BusinessObjects.Invoice.InvoiceHeader.GetInvoiceById(_savedInvoiceId));
                }
                //Close(); 
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                btnGuardar.Text = "Calculando CAE";
                btnGuardar.Enabled = false;
                _savedInvoiceId = SaveInvoice();
                btnGuardar.Enabled = false;
                btnPrint.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                btnGuardar.Enabled = true;
                btnGuardar.Text = "Guardar";
            }
            
        }

        #endregion

        #region Methods
        private void LoadHeader()
        {
            lblInvoiceDate.Text = _invoice.Header.GetHeader().DisplayDate;
            lblInvoiceType.Text = _invoice.Header.GetHeader().InvoiceType.ToString();
            lblInvoiceNumber.Text = _invoice.Header.GetHeader().InvoiceNumberDisplay;
            lblClientName.Text = _invoice.Header.GetHeader().ClientName;
            lblAddress.Text = _invoice.Header.GetHeader().ClientAddress;
            lblIVA.Text = _invoice.Header.GetHeader().IVACondition;
            lblCUIT.Text = _invoice.Header.GetHeader().ClientCUIT;
            lblSellCondition.Text = _invoice.Header.GetHeader().SellCondition;
            lblClientNumber.Text = _invoice.Header.GetHeader().ClientNumber;
        }

        private void LoadPreview()
        {
            ((Control)_detailPreview).Top = 200;
            ((Control)_detailPreview).Left = 8;
            Controls.Add(((Control) _detailPreview));
        }

        private void LoadFooter()
        {
            lblTotal.Text = _invoice.Footer.GetFooter().Total.ToString("C2");
            if (_invoice.Header.GetHeader().InvoiceType == InvoiceType.B) return;
            lblSubTotal.Text = _invoice.Footer.GetFooter().SubTotal.ToString("C2");
            gvRetentions.AutoGenerateColumns = false;
            gvRetentions.DataSource = _invoice.Footer.GetFooter().InvoiceRetentions;
            gvRetentions.Height = Utilities.UiUtils.GetDataGridViewHeight(gvRetentions) + 2;
            lblSubTotal.Visible = true;
            lblSubTotlaLabel.Visible = true;
        }

        private Guid SaveInvoice()
        {
            var user = Security.GetCurrentUser();
            var numberSplit = _invoice.Header.GetHeader().InvoiceNumberDisplay.Split('-');
            var salePoint = int.Parse(numberSplit[0]);
            var number = int.Parse(numberSplit[1]);
            string freeDetail = string.Empty;

            if (_detailPreview.GetType() == typeof (ucFreeTextPreview))
            {
                freeDetail = ((ucFreeTextPreview) (_detailPreview)).FreeDetail;
            }
             
            var invoice = new InvoiceHeader(Guid.Empty)
            {
                ClientInformation = _client,
                Date = _invoice.Header.GetHeader().Date,
                InvoiceType = _invoice.Header.GetHeader().InvoiceType,
                SalePoint = salePoint,
                InvoiceNumber = number,
                Total = _invoice.Footer.GetFooter().Total,
                SubTotal = _invoice.Footer.GetFooter().SubTotal,
                Observation = "Observaciones",
                ManualDetailText = freeDetail,
                Status = InvoiceStatus.Generada,
                Items = _invoice.InvoiceItems,
                InvoicedPractices = _invoice.InvoicedPractices,
                Retentions = LoadRetentions(),
                CreateUser = user,
                UpdateUser = user

            };
            invoice = invoice.Save();
            Guid invoiceHeaderGuid = invoice.Id;
            return invoiceHeaderGuid;
        }

        private IEnumerable<InvoiceRetention> LoadRetentions()
        {
            return _invoice.Footer.GetFooter().InvoiceRetentions.Select(invoiceRetentionDto => new InvoiceRetention
            {
                FiscalRetentionId = invoiceRetentionDto.FiscalRetentionId,
                Name = invoiceRetentionDto.Name,
                Value = invoiceRetentionDto.Value
            }).ToList();
        }

        #endregion

        private void InvoicePreview_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_savedInvoiceId != Guid.Empty)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
