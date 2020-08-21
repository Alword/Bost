using Bost.Agent.Model;
using Bost.Agent.Types;
using Bost.Proto.Mapping;
using Bost.Proto.Packet.Play.Clientbound;

namespace Bost.Agent.AgentEventHandlers
{
    public class ChunkDataHandler : BaseAgentEventHandler<ChunkDataPacket>
    {
        private readonly World world;
        public ChunkDataHandler(Agent agent) : base(agent)
        {
            world = agent.gameState.World;
        }

        public override void OnPacket(ChunkDataPacket chunkData)
        {
            byte[] data = chunkData.Data;
            var chunkId = new Int2(chunkData.ChunkX, chunkData.ChunkZ);
            ChunkColumn chunkColumn;

            if (chunkData.Fullchunk)
            {
                chunkColumn = new ChunkColumn();
            }
            else
            {
                chunkColumn = world.Chunks[chunkId];
            }

            chunkColumn.Parse(ref data, chunkData.PrimaryBitMask);

            if (chunkData.Fullchunk)
            {
                if (world.Chunks.ContainsKey(chunkId))
                {
                    world.Chunks.Remove(chunkId);
                }
                world.Chunks.Add(chunkId, chunkColumn);
            }
        }

    }
}
