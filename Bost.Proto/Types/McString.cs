using System.Collections.Generic;
using System.Text;

namespace Bost.Proto.Types
{
    public class McString
    {
        public static bool TryParse(ref byte[] buffer, out string result)
        {
            var isParsed = McVarint.TryParse(ref buffer, out int length);
            result = Encoding.UTF8.GetString(buffer[0..length]);
            buffer = buffer[length..];
            return isParsed;
        }
        public static byte[] ToBytes(string value)
        {
            var buffer = new List<byte>();
            buffer.AddRange(McVarint.ToBytes(value.Length));
            buffer.AddRange(Encoding.UTF8.GetBytes(value));
            return buffer.ToArray();
        }
    }
}
