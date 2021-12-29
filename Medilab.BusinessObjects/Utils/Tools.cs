using System;

namespace Medilab.BusinessObjects.Utils
{
    public class Tools
    {
        internal static bool IsRecordChanged(byte[] current, byte[] last)
        {
            return BitConverter.ToInt64(current, 0) != BitConverter.ToInt64(last, 0);
        }
    }
}
