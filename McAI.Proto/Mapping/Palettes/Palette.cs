using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Mapping.Palettes
{
    public class Palette
    {
        public static IPalette ChoosePalette(byte bitsPerBlock)
        {

            if (bitsPerBlock <= 4)
            {
                return new IndirectPalette(4);
            }
            else if (bitsPerBlock <= 8)
            {
                return new IndirectPalette(bitsPerBlock);
            }
            else
            {
                return new DirectPalette();
            }

        }
    }
}
