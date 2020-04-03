using McAI.BOT.Jobs;
using McAI.Proto.Packet;
using McAI.Proto.Packet.Play.Clientbound;
using McAI.Proto.Packet.Play.Serverbound;
using McAI.Proto.StreamReader.Abstractions;
using McAI.Proto.StreamReader.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.BOT.AgentEventHandlers
{
    public class TeleportConfirm : IPacketEventHandler
    {
        private readonly Agent agent;
        public TeleportConfirm(Agent agent)
        {
            this.agent = agent;
        }
        public async void OnPacket(PacketKey type, BasePacket packet)
        {
            var playerPositionAndLook = (PlayerPositionAndLookPacket)packet;

            agent.gameState.X = playerPositionAndLook.X;
            agent.gameState.Y = playerPositionAndLook.Y;
            agent.gameState.Z = playerPositionAndLook.Z;

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
