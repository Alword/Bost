using System;
using System.Linq;

namespace McAI.Proto.Types
{
    public class McDouble
    {
        public static bool TryParse(ref byte[] buffer, out double result)
        {
            result = BitConverter.ToDouble(buffer[0..8].Reverse().ToArray());
            buffer = buffer[8..];
            return true;
        }
        public static byte[] ToBytes(double value)
        {
            byte[] result = BitConverter.GetBytes(value);
            return result.Reverse().ToArray();
        }
    }
}
