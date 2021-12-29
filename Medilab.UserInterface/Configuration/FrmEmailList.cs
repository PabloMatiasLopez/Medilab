using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Medilab.UserInterface.Configuration
{
    public partial class FrmEmailList : Form
    {
        public FrmEmailList(IEnumerable<string> emailList)
        {
            InitializeComponent();
            txtEmailList.Text = GetEmailListString(emailList);
        }

        private static string GetEmailListString(IEnumerable<string> emailList)
        {
            return string.Join("; ", emailList.ToArray());
        }
    }
}
