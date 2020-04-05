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
            throw new NotImplementedException();
        }

        public uint IdForState(BlockState state)
        {
            throw new NotImplementedException();
        }

        public void Read(ref byte[] data)
        {
            //throw new NotImplementedException();
        }

        public BlockState StateForId(uint id)
        {
            // todo
            // from global palette
            return new BlockState() { StateId = 0 };
        }

        public void Write(byte[] data)
        {
            throw new NotImplementedException();
        }
    }
}
