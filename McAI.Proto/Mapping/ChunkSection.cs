using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace McAI.Proto.Mapping
{
    public class ChunkSection
    {
        public const int SizeX = 16;
        public const int SizeY = 16;
        public const int SizeZ = 16;

        public short BlockCount;
        public byte BitsPerBlock; // unsigned byte
        public byte Palette;
        public int DataArrayLength; // Varint 
        public long[] DataArray;

        public void Parse(ref byte[] array)
        {
            McShort.TryParse(ref array, out BlockCount);
            McUnsignedByte.TryParse(ref array, out BitsPerBlock);

            // skip palette

            // Vairnt lentgh
            // long data
        }

        internal void SetState(int x, int y, int z, BlockState state)
        {
            Debug.WriteLine($"Set state {x} {y} {z} {state}");
            // throw new NotImplementedException();
        }

        internal void SetBlockLight(int x, int y, int z, int v)
        {
            Debug.WriteLine($"Set light {x} {y} {z} {v}");
            // throw new NotImplementedException();
        }
    }
}
