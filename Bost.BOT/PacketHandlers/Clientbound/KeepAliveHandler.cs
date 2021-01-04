namespace Bost.Agent.PacketHandlers.Clientbound
{
	public class KeepAliveHandler : BaseAgentEventHandler<Proto.Packet.Play.Clientbound.KeepAlivePacket>
	{
		public KeepAliveHandler(Agent agent) : base(agent) { }
		public async override void OnPacket(Proto.Packet.Play.Clientbound.KeepAlivePacket packet)
		{
			var toServerKeepAlive = new Proto.Packet.Play.Serverbound.KeepAlivePacket
			{
				KeepAliveID = packet.KeepAliveID
			};
			await agent.Send(toServerKeepAlive);
		}
	}
}
