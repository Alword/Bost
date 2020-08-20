using Bost.BOT.Model;
using Bost.BOT.Types;
using Bost.Proto.Packet.Play.Clientbound;

namespace Bost.BOT.AgentEventHandlers
{
    public class UnloadChunkHandler : BaseAgentEventHandler<UnloadChunkPacket>
    {
        private readonly World world;
        public UnloadChunkHandler(Agent agent) : base(agent)
        {
            world = agent.gameState.World;
        }
        public override void OnPacket(UnloadChunkPacket data)
        {
            world.Chunks.Remove(new Int2(data.ChunkX, data.ChunkZ));
        }
    }
}
