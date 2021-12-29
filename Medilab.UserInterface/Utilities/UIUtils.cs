using System;
using System.Linq;
using System.Windows.Forms;
using Medilab.BusinessObjects.Utils;
using System.Globalization;

namespace Medilab.UserInterface.Utilities
{
    public static class UiUtils
    {
        public static int GetAge(DateTime birthday)
        {
            if (birthday > DateTime.Now)
            {
                return 0;
            }
            return new DateTime(DateTime.Now.Subtract(birthday).Ticks).Year - 1;
        }

        public static ClinicalExamResult GetCheckedResult(Control containerPanel)
        {
            var radioButton = containerPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (radioButton != null)
            {
                var selectedResult = radioButton.Tag.ToString();
                switch (selectedResult)
                {
                    case "Normal":
                        return ClinicalExamResult.Normal;
                    case "Patológico":
                        return ClinicalExamResult.Patológico;
                    default:
                        return ClinicalExamResult.NoEvaluado;
                }
            }
            return ClinicalExamResult.NoEvaluado;
        }

        public static void CheckExamResult(Control container, ClinicalExamResult result)
        {
            var radioButton =
                container.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Tag.ToString() == result.ToString());
            if (radioButton != null)
            {
                radioButton.Checked = true;
            }
        }

        public static int GetDataGridViewHeight(DataGridView dataGridView)
        {
            var header = dataGridView.ColumnHeadersVisible ? dataGridView.ColumnHeadersHeight : 0;
            var rows = dataGridView.Rows.OfType<DataGridViewRow>().Sum(r => r.Height);
            return header + rows;
        }

        public static string GetDecimalSeparator()
        {
            return CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
        }
    }
}
