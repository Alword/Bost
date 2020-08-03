using McAI.BOT.Model;
using McAI.Proto.Mapping;
using McAI.Proto.Packet;
using McAI.Proto.Packet.Play.Clientbound;
using McAI.Proto.StreamReader.Abstractions;
using McAI.Proto.StreamReader.Model;

namespace McAI.BOT.AgentEventHandlers
{
    public class BlockChangeHandler : BaseAgentEventHandler<BlockChangePacket>
    {
        private readonly World world;
        public BlockChangeHandler(Agent agent) : base(agent)
        {
            world = agent.gameState.World;
        }

        public override void OnPacket(BlockChangePacket data)
        {
            Int3 location = new Int3(data.Location.X, data.Location.Y, data.Location.Z);
            world.SetBlockId(location, new BlockId((uint)data.BlocID));
        }
    }
}
