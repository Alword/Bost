using System.Collections.Generic;

namespace Bost.Proto.Types
{
    public static class McULongArray
    {
        // 8 
        public static bool TryParse(ref byte[] buffer, int size, out ulong[] result)
        {
            result = new ulong[size];
            for (int i = 0; i < size; i++)
            {
                McULong.TryParse(ref buffer, out result[i]);
            }
            return true;
        }
        public static byte[] ToBytes(ulong[] value)
        {
            List<byte> result = new List<byte>(value.Length * sizeof(ulong));
            for (int i = 0; i < value.Length; i++)
            {
                result.AddRange(McULong.ToBytes(value[i]));
            }
            return result.ToArray();
        }
    }
}
