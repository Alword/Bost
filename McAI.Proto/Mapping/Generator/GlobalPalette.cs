using Bost.Proto.Extentions;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace Bost.Proto.Mapping.Generator
{
    public static class GlobalPalette
    {
        /// <summary>
        /// Todo generate Blocks enum
        /// </summary>
        private static Dictionary<string, GeneratedBlock> NameToState { get; set; }
        private static Dictionary<BlockId, BlockState> IdToState { get; set; }
        private static Dictionary<BlockState, BlockId> StateToId { get; set; }
        public static readonly uint TotalNumberOfStates;

        static GlobalPalette()
        {
            TotalNumberOfStates = 0;
            string json = "blocks.json".ReadResource();
            Dictionary<string, GeneratedBlock> blocks = JsonConvert.DeserializeObject<Dictionary<string, GeneratedBlock>>(json);

            NameToState = new Dictionary<string, GeneratedBlock>();
            IdToState = new Dictionary<BlockId, BlockState>();
            StateToId = new Dictionary<BlockState, BlockId>();

            foreach (var name in blocks.Keys)
            {
                var blockInfo = blocks[name];
                NameToState.Add(name, blockInfo);
                foreach (var state in blockInfo.States)
                {
                    BlockId id = new BlockId() { StateId = state.Id };
                    BlockState blockState = new BlockState() { Id = state.Id, Name = name };
                    IdToState.Add(id, blockState);
                    StateToId.Add(blockState, id);
                    TotalNumberOfStates += 1;
                }
            }
        }

        public static BlockState GetState(uint blockId)
        {
            return IdToState[new BlockId() { StateId = blockId }];
        }

        public static BlockId GetId(BlockState state)
        {
            return StateToId[state];
        }
    }
}
