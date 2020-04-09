using System;
using System.Linq;

namespace McAI.Proto.Types
{
    public class McUUID
    {
        public static bool TryParse(ref byte[] buffer, out Guid result)
        {
            result = new Guid(buffer[0..16].Reverse().ToArray());
            buffer = buffer[16..];
            return true;
        }
        public static byte[] ToBytes(Guid value)
        {
            byte[] result = value.ToByteArray().Reverse().ToArray();
            return result;
        }
    }
}
