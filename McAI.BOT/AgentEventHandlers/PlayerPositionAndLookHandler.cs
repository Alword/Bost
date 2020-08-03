using McAI.Proto.Packet.Play.Clientbound;
using McAI.Proto.Packet.Play.Serverbound;
using System.Collections.Generic;

namespace McAI.BOT.AgentEventHandlers
{
    public class PlayerPositionAndLookHandler : BaseAgentEventHandler<PlayerPositionAndLookPacket>
    {
        public PlayerPositionAndLookHandler(Agent agent) : base(agent) { }

        public async override void OnPacket(PlayerPositionAndLookPacket playerPositionAndLook)
        {
            agent.gameState.Bot.Position.X = playerPositionAndLook.X;
            agent.gameState.Bot.Position.Y = playerPositionAndLook.Y;
            agent.gameState.Bot.Position.Z = playerPositionAndLook.Z;

            var confirmTeleport = new TeleportConfirmPacket()
            {
                TeleportID = playerPositionAndLook.TeleportID
            };

            List<byte> send = new List<byte>();
            agent.Write(confirmTeleport, true, send);
            await agent.Send(send.ToArray());
        }
    }
}
