using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace McAI.Proto.Types
{
    public class McShort
    {
        public static bool TryParse(ref byte[] buffer, out short result)
        {
            result = BitConverter.ToInt16(buffer[0..2].Reverse().ToArray());
            buffer = buffer[2..];
            return true;
        }
        public static byte[] ToBytes(short value)
        {
            return BitConverter.GetBytes(value).Reverse().ToArray(); ;
        }
    }
}
