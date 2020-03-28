using System;

namespace McAI.Proto.Extentions
{
    public static class ByteExtentions
    {
        public static string ToHexString(this byte[] data)
        {
            string hex = BitConverter.ToString(data);
            return hex;
        }
    }
}
