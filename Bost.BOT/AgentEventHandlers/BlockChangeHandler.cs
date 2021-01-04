using Bost.Agent.Model;
using Bost.Proto.Mapping;
using Bost.Proto.Packet.Play.Clientbound;

namespace Bost.Agent.AgentEventHandlers
{
	public class BlockChangeHandler : BaseAgentEventHandler<BlockChangePacket>
	{
		private readonly World _world;
		public BlockChangeHandler(Agent agent) : base(agent)
		{
			_world = agent.SharedState.World;
		}

		public override void OnPacket(BlockChangePacket data)
		{
			Int3 location = new Int3(data.Location.X, data.Location.Y, data.Location.Z);
			_world.SetBlockId(location, new BlockId((uint)data.BlocID));
			agent.OnOnBlockChanged(location, _world);
		}
	}
}
