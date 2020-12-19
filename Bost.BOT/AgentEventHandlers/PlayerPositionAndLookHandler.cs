using Bost.Proto.Packet.Play.Clientbound;
using Bost.Proto.Packet.Play.Serverbound;

namespace Bost.Agent.AgentEventHandlers
{
	public class PlayerPositionAndLookHandler : BaseAgentEventHandler<PlayerPositionAndLookPacket>
	{
		public PlayerPositionAndLookHandler(Agent agent) : base(agent) { }

		public async override void OnPacket(PlayerPositionAndLookPacket playerPositionAndLook)
		{
			agent.GameState.Bot.Position.X = playerPositionAndLook.X;
			agent.GameState.Bot.Position.Y = playerPositionAndLook.Y;
			agent.GameState.Bot.Position.Z = playerPositionAndLook.Z;

			var confirmTeleport = new TeleportConfirmPacket()
			{
				TeleportID = playerPositionAndLook.TeleportID
			};

			await agent.Send(confirmTeleport);
		}
	}
}
