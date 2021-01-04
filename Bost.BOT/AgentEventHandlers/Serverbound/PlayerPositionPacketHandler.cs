using Bost.Proto.Packet.Play.Serverbound;

namespace Bost.Agent.AgentEventHandlers.Serverbound
{
	public class PlayerPositionPacketHandler : BaseAgentEventHandler<PlayerPositionPacket>
	{
		public PlayerPositionPacketHandler(Agent agent) : base(agent)
		{
		}

		public override void OnPacket(PlayerPositionPacket packet)
		{
			agent.Position = new Types.Double3(packet.X, packet.FeetY, packet.Z);
		}
	}
}
