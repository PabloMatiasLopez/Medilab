using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using Medilab.UserInterface.Excel;

namespace Medilab.UserInterface.PrintUtilities
{
    public class InvoiceDuplicate
    {
        public void InvoiceTemplatePrinter()
        {
             
            var printerSettings = new PrinterSettings();
            
            Process proc = new Process();
            proc.StartInfo = new ProcessStartInfo()
            {
                CreateNoWindow = true,
                Verb = "print",
                FileName =string.Concat(ConfigurationManager.AppSettings["ExcelPathTemplates"],
                ConfigurationManager.AppSettings["DuplicateInvoice"])
            };
            proc.Start();

            //MSExcel excel = new MSExcel();
            //ProcessStartInfo info = new ProcessStartInfo();
            //info.Verb = "print";
            //info.FileName = string.Concat(ConfigurationManager.AppSettings["ExcelPathTemplates"],
            //    ConfigurationManager.AppSettings["DuplicateInvoice"]);
            ////info.CreateNoWindow = true;
            ////info.WindowStyle = ProcessWindowStyle.Hidden;

            //Process p = new Process();
            //p.StartInfo = info;
            //p.Start();

            //p.WaitForInputIdle();
            //System.Threading.Thread.Sleep(3000);
            //if (false == p.CloseMainWindow())
            //    p.Kill();
         
        }
    }
}
