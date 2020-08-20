using System.Collections.Generic;

namespace Bost.Proto.Types
{
    public static class McStringArray
    {
        public static bool TryParse(int length, ref byte[] buffer, out string[] result)
        {
            result = new string[length];
            for (int i = 0; i < length; i++)
            {
                McString.TryParse(ref buffer, out result[i]);
            }
            return true;
        }
        public static byte[] ToBytes(string[] value)
        {
            List<byte> bytes = new List<byte>();
            foreach (string str in value)
            {
                bytes.AddRange(McString.ToBytes(str));
            }
            return bytes.ToArray();
        }
    }
}
