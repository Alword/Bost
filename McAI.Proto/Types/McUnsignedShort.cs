using System;
using System.Linq;

namespace McAI.Proto.Types
{
    public class McUnsignedShort
    {
        public static bool TryParse(ref byte[] buffer, out ushort result)
        {
            result = BitConverter.ToUInt16(buffer[0..2].Reverse().ToArray());
            buffer = buffer[2..];
            return true;
        }
        public static byte[] ToBytes(ushort value)
        {
            return BitConverter.GetBytes(value).Reverse().ToArray(); ;
        }
    }
}
