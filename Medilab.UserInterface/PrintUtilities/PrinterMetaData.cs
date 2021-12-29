using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Medilab.UserInterface.PrintUtilities
{
    public struct PrinterMetaData
    {
        public string Data;
        public Font printFont;
        public bool isBold;
        public float xPos;
        public float yPos;
        public int maxLineLength;

        public float UnitConvertion(double centimeter)
        {
            return (float)(36.36 * centimeter);  //37.36
        }
        public float UnitConvertion2(double centimeter)
        {
            return (float)(37.36 * centimeter);  //37.36
        }
    }

   

}
