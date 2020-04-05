using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Types
{
    public class McUnsignedByte
    {
        public static bool TryParse(ref byte[] buffer, out byte result)
        {
            result = buffer[0];
            buffer = buffer[1..];
            return true;
        }
        public static byte[] ToBytes(byte value)
        {
            byte[] result = new byte[1];
            result[0] = value;
            return result;
        }
    }
}
