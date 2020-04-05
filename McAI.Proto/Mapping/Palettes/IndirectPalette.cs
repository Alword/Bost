using McAI.Proto.Mapping.Generator;
using McAI.Proto.Types;
using System;
using System.Collections.Generic;

namespace McAI.Proto.Mapping.Palettes
{
    public class IndirectPalette : IPalette
    {
        Dictionary<uint, BlockState> idToState;
        Dictionary<BlockState, uint> stateToId;
        byte bitsPerBlock;

        public IndirectPalette(byte palBitsPerBlock)
        {
            bitsPerBlock = palBitsPerBlock;
        }

        public uint IdForState(BlockState state)
        {
            return stateToId[state];
        }

        public byte GetBitsPerBlock()
        {
            return bitsPerBlock;
        }

        public void Read(ref byte[] data)
        {
            idToState = new Dictionary<uint, BlockState>();
            stateToId = new Dictionary<BlockState, uint>();
            // Palette Length
            McVarint.TryParse(ref data, out int length);
            // Palette
            for (uint id = 0; id < length; id++)
            {
                McVarint.TryParse(ref data, out int stateId);
                BlockState state = GlobalPalette.GetState((uint)stateId);
                idToState[id] = state;
                stateToId[state] = id;
            }
        }

        public BlockState StateForId(uint id)
        {
            return idToState[id];
        }

        public void Write(byte[] data)
        {
            throw new NotImplementedException();
        }
    }
}
