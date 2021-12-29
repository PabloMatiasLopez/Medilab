using System;
using System.Windows.Forms;
using Medilab.UserInterface.PrintUtilities;

namespace Medilab.UserInterface
{
    public partial class TestPrintForm : Form
    {
       

        public TestPrintForm()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Printer printer = new Printer();
            printer.PrintInvoice();
        }
        
        
    }
}
