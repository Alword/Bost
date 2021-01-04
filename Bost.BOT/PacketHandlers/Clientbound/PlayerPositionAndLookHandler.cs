using Bost.Agent.Types;
using Bost.Proto.Packet.Play.Clientbound;
using Bost.Proto.Packet.Play.Serverbound;

namespace Bost.Agent.PacketHandlers.Clientbound
{
	public class PlayerPositionAndLookHandler : BaseAgentEventHandler<PlayerPositionAndLookPacket>
	{
		public PlayerPositionAndLookHandler(Agent agent) : base(agent) { }

		public async override void OnPacket(PlayerPositionAndLookPacket postionAndLook)
		{
			agent.Position = new Double3(postionAndLook.X, postionAndLook.Y, postionAndLook.Z);

			var confirmTeleport = new TeleportConfirmPacket()
			{
				TeleportID = postionAndLook.TeleportID
			};

			await agent.Send(confirmTeleport);
		}
	}
}
