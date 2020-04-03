using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace McAI.Proto.Mapping.Palettes
{
    public class IndirectPalette
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

        public void Read(byte[] data)
        {
            idToState = new Dictionary<uint, BlockState>();
            stateToId = new Dictionary<BlockState, uint>();
            // Palette Length
            McVarint.TryParse(ref data, out int length);
            // Palette
            for (uint id = 0; id < length; id++)
            {
                McVarint.TryParse(ref data, out int stateId);
                BlockState state = GetStateFromGlobalPaletteID(stateId);
                idToState[id] = state;
                stateToId[state] = id;
            }
        }

        private BlockState GetStateFromGlobalPaletteID(int stateId)
        {
            BlockState blockState = new BlockState
            {
                StateId = stateId
            };
            return blockState;
        }
    }
}
