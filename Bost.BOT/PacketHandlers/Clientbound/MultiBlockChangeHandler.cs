using Bost.Agent.Model;
using Bost.Proto.Mapping;
using Bost.Proto.Packet.Play.Clientbound;

namespace Bost.Agent.PacketHandlers.Clientbound
{
	public class MultiBlockChangeHandler : BaseAgentEventHandler<MultiBlockChangePacket>
	{
		private readonly World _world;
		public MultiBlockChangeHandler(Agent agent) : base(agent)
		{
			_world = agent.SharedState.World;
		}

		public override void OnPacket(MultiBlockChangePacket data)
		{
			foreach (var record in data.Records)
			{
				Int3 location = new Int3(
					(record.HorizontalPosition >> 4 & 15) + data.ChunkX * 16,
					record.YCoordinate,
					(record.HorizontalPosition & 15) + data.ChunkZ * 16);
				_world.SetBlockId(location, new BlockId((uint)record.BlockID));
				agent.OnOnBlockChanged(location, _world);
			}
		}
	}
}
