using Bost.Agent.Model;
using Bost.Agent.Types;
using Bost.Proto.Packet.Play.Clientbound;

namespace Bost.Agent.PacketHandlers.Clientbound
{
	public class UnloadChunkHandler : BaseAgentEventHandler<UnloadChunkPacket>
	{
		private readonly World world;
		public UnloadChunkHandler(Agent agent) : base(agent)
		{
			world = agent.SharedState.World;
		}
		public override void OnPacket(UnloadChunkPacket data)
		{
			world.Chunks.Remove(new Int2(data.ChunkX, data.ChunkZ));
		}
	}
}
