using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Model
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
                int value = (read & 0b01111111);
                result |= (value << (7 * numRead));

                numRead++;
                if (numRead > 5)
                {
                    return false;
                }
            } while ((read & 0b10000000) != 0);

            return true;
        }
    }
}
