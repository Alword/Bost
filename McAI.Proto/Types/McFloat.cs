using System;
using System.Linq;

namespace McAI.Proto.Types
{
    public static class McFloat
    {
        public static bool TryParse(ref byte[] buffer, out float result)
        {
            result = BitConverter.ToSingle(buffer[0..4].Reverse().ToArray());
            buffer = buffer[4..];
            return true;
        }
        public static byte[] ToBytes(float value)
        {
            return BitConverter.GetBytes(value).Reverse().ToArray();
        }
    }
}
