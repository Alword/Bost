using McAI.Proto.Mapping.Generator;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace McAI.Proto.Mapping.Palettes
{
    public class DirectPalette : IPalette
    {
        public byte GetBitsPerBlock()
        {
            return (byte)Math.Ceiling(Math.Log2(GlobalPalette.TotalNumberOfStates)); // currently 14
        }

        public uint IdForState(BlockState state)
        {
            return GlobalPalette.GetId(state).StateId;
        }

        public void Read(ref byte[] data)
        {
            // no data
        }

        public BlockState StateForId(uint id)
        {
            return GlobalPalette.GetState(id);
        }

        public void Write(byte[] data)
        {
            throw new NotImplementedException();
        }
    }
}
