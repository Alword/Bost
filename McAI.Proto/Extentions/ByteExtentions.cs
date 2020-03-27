using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace McAI.Proto.Extentions
{
    public static class ByteExtentions
    {
        public static string ToHexString(this byte[] buffer)
        {
            StringBuilder sb = new StringBuilder(buffer.Length * 2);
            foreach (byte b in buffer)
            {
                sb.AppendFormat("{0} ", b);
            }
            return sb.ToString();
        }

        public static int ReadVarInt(this Queue<byte> queue)
        {
            int numRead = 0;
            int result = 0;

            byte read;
            do
            {
                read = queue.Dequeue();
                int value = (read & 0b01111111);
                result |= (value << (7 * numRead));

                numRead++;
                if (numRead > 5)
                {
                    throw new OutOfMemoryException("VarInt is too big");
                }
            } while ((read & 0b10000000) != 0);

            return result;
        }
    }
}
