using Bost.Proto.Mapping.Generator;
using System;

namespace Bost.Proto.Mapping.Palettes
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
