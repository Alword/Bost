using McAI.BOT.Model;
using McAI.BOT.Types;
using McAI.Proto.Packet.Play.Clientbound;

namespace McAI.BOT.AgentEventHandlers
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
