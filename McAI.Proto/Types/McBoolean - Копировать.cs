using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Types
{
    public static class McBoolean
    {
        public static bool TryParse(ref byte[] buffer, out bool result)
        {
            result = buffer[0] == 1;
            buffer = buffer[1..];
            return true;
        }
        public static byte[] ToBytes(bool value)
        {
            byte[] result = new byte[] { value ? (byte)1 : (byte)0 };
            return result;
        }
    }
}
