using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPS64Simulator.Helper
{
    public static class BaseConverter
    {
        public static string BinToHex(this string value)
        {
            return Convert.ToInt32(value, 2).ToString("X4").PadLeft(8,'0');
        }

        public static string HexToBin(this string value)
        {
            return Convert.ToString(Convert.ToInt32(value, 16), 2).PadLeft(32,'0');
        }
    }
}
