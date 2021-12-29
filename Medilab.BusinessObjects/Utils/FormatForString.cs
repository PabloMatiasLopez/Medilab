
using System.Text;
namespace Medilab.BusinessObjects.Utils
{
    public static class FormatForString
    {
        public static string IntNumber(int count)
        {
            return new string('0', count);
        }
        public static string FloatNumberTwoDecimals(int totalLenght)
        {
            if (totalLenght < 3)
            {
                return "0.00";
            }
            var format = new string('0', totalLenght - 3);
            return format + ".00";
        }
        public static string FloatNumberFiveDecimals(int totalLenght)
        {
            if (totalLenght < 5)
            {
                return "0.0000";
            }
            var format = new string('0', totalLenght - 5);
            return format + ".0000";
        }
        public static string CleanText(string text, bool replaceEnies = false)
        {
            var cleanText = text;
            //replace 
            cleanText = cleanText.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u");
            cleanText = cleanText.Replace("Á", "A").Replace("É", "E").Replace("Í", "I").Replace("Ó", "O").Replace("Ú", "U");
            if (replaceEnies)
            {
                cleanText = cleanText.Replace("Ñ", "N").Replace("ñ", "n");
            }
            //remove
            var finalText = new StringBuilder();
            foreach (char c in cleanText)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_' || c == ' ')
                {
                    finalText.Append(c);
                }
            }
            return finalText.ToString();
        }
    }
}
