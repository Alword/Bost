using System;

namespace McAI.Proto.Extentions
{
    public static class ByteExtentions
    {
        public static string ToHexString(this byte[] data)
        {
            return BitConverter.ToString(data);
        }

        public static string ToBitString(this byte[] data)
        {
            string bits = "";
            foreach (byte b in data)
            {
                bits += Convert.ToString(b, 2);
            }
            return bits;
        }

        public static bool IsChecked(this byte data, int index) => (data & (1 << index)) != 0;
    }
}
