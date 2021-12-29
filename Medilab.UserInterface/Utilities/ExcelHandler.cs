using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Medilab.UserInterface.Utilities
{
    public static class ExcelHandler
    {
        public static void AddBorders(ExcelWorksheet worksheet, string range)
        {
            var row = worksheet.Cells[range];
            row.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            row.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            row.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            row.Style.Border.Right.Style = ExcelBorderStyle.Thin;
        }
    }
}
