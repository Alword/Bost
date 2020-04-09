using System;
using System.Linq;

namespace McAI.Proto.Types
{
    public static class McLong
    {
        // 8 
        public static bool TryParse(ref byte[] buffer, out long result)
        {
            result = BitConverter.ToInt64(buffer[0..8].Reverse().ToArray());
            buffer = buffer[8..];
            return true;
        }
        public static byte[] ToBytes(long value)
        {
            byte[] reuslt = BitConverter.GetBytes(value);
            reuslt = reuslt.Reverse().ToArray();
            return reuslt;
        }
    }
}
