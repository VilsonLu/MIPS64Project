using System;

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

        public static int BinToDec(this string value)
        {
            return Convert.ToInt32(value, 2);
        }

        public static string DecToHex(this int value, int digit)
        {
            return value.ToString("X" + digit.ToString());
        }
    }
}
