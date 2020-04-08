using McAI.BOT.Extentions;
using McAI.BOT.Types;
using McAI.Proto.Mapping;
using McAI.Proto.Mapping.Generator;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.BOT.Model
{
    public class World
    {
        public Dictionary<Int2, ChunkColumn> Chunks { get; private set; }
        public World()
        {
            Chunks = new Dictionary<Int2, ChunkColumn>();
        }

        public BlockState this[Double3 location]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public BlockState this[Int3 location]
        {
            get
            {
                Int3 chunkSectionKey = location.GetChunk();
                Int2 chunkKey = new Int2(chunkSectionKey.X, chunkSectionKey.Z);
                if (Chunks.ContainsKey(chunkKey))
                {
                    ChunkColumn chunk = Chunks[chunkKey];
                    ChunkSection section = chunk[chunkSectionKey.Y];
                    if (section == null)
                    {
                        return new BlockState();
                    }
                    else
                    {
                        Int3 bp = location.InChunkBlock();
                        BlockId id = section.GetBlock(bp.X, bp.Y, bp.Z);
                        return GlobalPalette.GetState(id.StateId);
                    }
                }
                else
                {
                    return new BlockState();
                }
            }
        }

        public void SetBlockId(Int3 location, BlockId state)
        {
            Int3 chunkSectionKey = location.GetChunk();
            Int2 chunkKey = new Int2(chunkSectionKey.X, chunkSectionKey.Z);
            if (Chunks.ContainsKey(chunkKey))
            {
                ChunkColumn chunk = Chunks[chunkKey];
                ChunkSection section = chunk[chunkSectionKey.Y];
                if (section != null)
                {
                    Int3 bp = location.InChunkBlock();
                    section.SetState(bp.X, bp.Y, bp.Z, state);
                }
            }
        }
    }
}
