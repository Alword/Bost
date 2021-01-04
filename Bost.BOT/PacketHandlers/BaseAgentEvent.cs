using Bost.Proto.Packet;
using Bost.Proto.StreamReader.Abstractions;

namespace Bost.Agent.PacketHandlers
{
	public abstract class BaseAgentEventHandler<T> : IPacketEventHandler<T> where T : BasePacket
	{
		protected readonly Agent agent;
		public BaseAgentEventHandler(Agent agent)
		{
			this.agent = agent;
		}
		public abstract void OnPacket(T packet);
	}
}
