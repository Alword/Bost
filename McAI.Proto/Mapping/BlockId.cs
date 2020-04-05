using McAI.Proto.Mapping.Generator;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Mapping
{
    public struct BlockId
    {
        public uint StateId { get; set; }

        public BlockId(uint id)
        {
            StateId = id;
        }

        public override string ToString()
        {
            return $"{StateId} {GlobalPalette.GetState(StateId).Name}";
        }
    }
}
