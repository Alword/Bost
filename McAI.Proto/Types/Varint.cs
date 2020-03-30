using System.Collections.Generic;
using System.Linq;

namespace McAI.Proto.Types
{
    public static class Varint
    {
        public static bool TryParse(byte[] buffer, out int numRead, out int result)
        {
            numRead = 0;
            result = 0;

            byte read;
            do
            {
                read = buffer[numRead];
                int value = read & 0b01111111;
                result |= value << 7 * numRead;

                numRead++;
                if (numRead > 5)
                {
                    return false;
                }
            } while ((read & 0b10000000) != 0);

            return true;
        }

        public static bool TryParse(ref byte[] buffer, out int result)
        {
            bool parsed = TryParse(buffer, out int numRead, out result);
            if (parsed)
            {
                buffer = buffer[numRead..];
            }
            return parsed;
        }

        public static byte[] ToBytes(int value)
        {
            List<byte> bytes = new List<byte>(1);
            do
            {
                byte temp = (byte)(value & 0b01111111);
                // Note: >>> means that the sign bit is shifted with the rest of the number rather than being left alone
                value >>= 7;
                if (value != 0)
                {
                    temp |= 0b10000000;
                }
                bytes.Add(temp);
            } while (value != 0);
            return bytes.ToArray();
        }
    }
}
