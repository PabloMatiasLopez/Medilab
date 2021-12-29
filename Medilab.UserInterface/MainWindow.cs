using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.DTOs;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Attention;
using Medilab.UserInterface.BillingReport;
using Medilab.UserInterface.ClinicalHistory;
using Medilab.UserInterface.Configuration;
using Medilab.UserInterface.Invoice;
using Medilab.UserInterface.Login;
using Medilab.UserInterface.Pacientes;
using Medilab.UserInterface.Practices;
using Medilab.UserInterface.Receipt;
using Medilab.UserInterface.Utilities;
using Medilab.UserInterface.Reports;
using Medilab.BusinessObjects.CAE;
using System.Configuration;
using Medilab.UserInterface.CreditNote;
using Medilab.UserInterface.DebitNote;
using Medilab.BusinessObjects.Siap;

namespace Medilab.UserInterface
{
    public partial class MainWindow : Form
    {
        public BusinessObjects.Login.Login LoggedUser { set; get; }
        public CompanyInfo CompanyInfo { set; get; }
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Events

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmRole>(this);
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmUserList>(this);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            tsLoggedUser.Text = string.Format("Usuario: {0} {1}", LoggedUser.FirstName, LoggedUser.LastName);
            ConfigureMenu();
        }

        #region MenuEvents
        private void cambiarClaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmChangePassword>(this, true);
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmCompanyInformation>(this);
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmAddEditPatient>(this);
        }

        private void obraSocialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmPrivateMedicineCompany>(this);
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmClient>(this);
        }
        private void listaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmPatientList>(this);
        }
        private void aRTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmWorkRiskInsurance>(this);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void historiaClinicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmAddClinicalHistory>(this);
        }

        private void listaHistoriasClinicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmClinicalHistoryGrid>(this);
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmSpeciality>(this);
        }

        private void listaDePracticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmPractices>(this);
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmGroupMedicalPractice>(this);
        }

        private void pendientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<PendingPatientList>(this);
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<frmReportTemplate>(this);
        }
        private void crearFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var invoice = FormHandler.GetInstance<CreateInvoice>(this, InvoiceType.A);
            invoice.MdiParent = this;
            invoice.Show();
        }
        private void crearFacturaBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var invoice = FormHandler.GetInstance<CreateInvoice>(this, InvoiceType.B);
            invoice.MdiParent = this;
            invoice.Show();
        }
        private void nextInvoiceNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmNextInvoiceNumber>(this, true);
        }
        private void pacientesAtendidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<PracticesBySpeciality>(this);
        }
        private void reporteDeLaboratorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<LaboratoryReport>(this);
        }
        private void toolStripMenuIPracticasPorCliente_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<PracticesByClient>(this);
        }
        private void adicionalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmAditionalItem>(this);
        }
        private void retencionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmFiscalRetention>(this);
        }
        private void perfilesDeRetencionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmFiscalRetentionProfile>(this);
        }
        private void listaDeFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmInvoiceList>(this);
        }
        private void registrarPagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmInvoiceListPaidRecord>(this);
        }
        private void listaDeRecibosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmReceiptList>(this);
        }
        
        private void listaDeFacturasConSaldoPendienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmInvoicePendingList>(this);
        }
        private void numeroNotaDeCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<frmNextCreditNoteNumber>(this);
        }
        private void notasDeCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<frmCreditNote>(this);
        }
        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string version = "Versión: " + Application.ProductVersion;
            MessageBox.Show(version, "Versión", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void notasDeCréditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmCreditNoteList>(this);
        }
        private void cAEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<frmCAEConfiguration>(this, true);
        }
        private void deudaPorClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmDebtByClientReport>(this);
        }
        private void crearNotaDeDebitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<frmDebitNote>(this);
        }
        private void numeroNotaDeDebitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<frmNextDebitNoteNumber>(this, true);
        }
        private void notasDeDébitoPorClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<frmDebitNoteList>(this);
        }
        #endregion
        #region ToolBarEvents
        private void toolbtnClient_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmClient>(this);
        }
        private void toolbtnPracticeList_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmPractices>(this);
        }
        private void toolbtnPracticeGroup_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmGroupMedicalPractice>(this);
        }
        private void toolbtnAddPatient_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmAddEditPatient>(this);
        }
        private void toolbtnNewClinicalHistory_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmAddClinicalHistory>(this);
        }
        private void toolbtnClinicalHistoryList_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmClinicalHistoryGrid>(this);
        }
        private void toolbtnPendingPatients_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<PendingPatientList>(this);
        }
        private void listaDePreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHandler.ShowForm<FrmPriceList>(this);
        }
        #endregion
        #endregion

        #region Methods
        private void ConfigureMenu()
        {
            var showClinicalHistory = Security.IsAuthozired(SecurityAreas.MedicalAttention);
            var showPatient = Security.IsAuthozired(SecurityAreas.Administration);
            var showMedicalHistory = Security.IsAuthozired(SecurityAreas.ClinicalHistory);
            var showPatientMenu = showClinicalHistory || showPatient || showMedicalHistory;

            pacientesToolStripMenuItem.Visible = showPatientMenu;
            toolbtnAddPatient.Visible = showPatient;
            toolbtnNewClinicalHistory.Visible = showMedicalHistory;
            toolbtnClinicalHistoryList.Visible = showMedicalHistory;
            toolbtnPendingPatients.Visible = showClinicalHistory;
            if (showPatientMenu)
            {
                pendientesToolStripMenuItem.Visible = showClinicalHistory;
                listaToolStripMenuItem.Visible = showPatient;
                agregarToolStripMenuItem.Visible = showPatient;
                historiaClinicaToolStripMenuItem.Visible = showMedicalHistory;
                listaHistoriasClinicasToolStripMenuItem.Visible = showMedicalHistory;
                pacientesAtendidosToolStripMenuItem.Visible = showClinicalHistory;
            }

            var showConfigurationOptions = Security.IsAuthozired(SecurityAreas.Configuration);
            var showCommonOption = Security.IsAuthozired(SecurityAreas.Administration);
            var showToolsMenu = toolsMenu.Visible = showConfigurationOptions || showCommonOption;
            toolbtnClient.Visible = showCommonOption;
            if (showToolsMenu)
            {
                configurationToolStripMenuItem.Visible = true;
                rolesToolStripMenuItem.Visible = showConfigurationOptions;
                usersToolStripMenuItem.Visible = showConfigurationOptions;
                empresaToolStripMenuItem.Visible = showCommonOption;
                obraSocialToolStripMenuItem.Visible = showCommonOption;
                clientesToolStripMenuItem.Visible = showCommonOption;
                aRTToolStripMenuItem.Visible = showCommonOption;
                especialidadesToolStripMenuItem.Visible = showConfigurationOptions;
            }
            var showPracticeMenu = Security.IsAuthozired(SecurityAreas.Administration);
            practicasToolStripMenuItem.Visible = showPracticeMenu;
            toolbtnPracticeList.Visible = showPracticeMenu;
            toolbtnPracticeGroup.Visible = showPracticeMenu;
            adicionalesToolStripMenuItem.Visible = showPracticeMenu;
            if (showPracticeMenu)
            {
                listaDePracticasToolStripMenuItem.Visible = true;
                gruposToolStripMenuItem.Visible = true;
                reporteToolStripMenuItem.Visible = true;
            }

            var showInvoiceMenu = Security.IsAuthozired(SecurityAreas.Invoice);
            crearFacturaToolStripMenuItem.Visible = showInvoiceMenu;
            facturacionToolStripMenuItem.Visible = showInvoiceMenu;
            crearFacturaBToolStripMenuItem.Visible = showInvoiceMenu;
            listaDePreciosToolStripMenuItem.Visible = showInvoiceMenu;
            retencionesToolStripMenuItem.Visible = showInvoiceMenu;
            perfilesDeRetencionesToolStripMenuItem.Visible = showInvoiceMenu;
            notasDeCreditoToolStripMenuItem.Visible = showInvoiceMenu;

            var showToolBar = false;
            foreach (var item in toolBar.Items)
            {
                var btn = (ToolStripItem)item;
                if (!btn.Visible) continue;
                showToolBar = true;
                break;
            }
            toolBar.Visible = showToolBar;
        }
        #endregion

        private void button1_Click_1(object sender, EventArgs e)
        {
            var iva = new ProcessIVA();
            iva.StartDate = new DateTime(2015, 8, 3);
            iva.EndDate = new DateTime(2015, 8, 3);
            iva.GetIVAFiles();
            MessageBox.Show("Listo");
        }
    }
}
