using McAI.Proto.Enum;
using McAI.Proto.Packet;
using McAI.Proto.Packet.Play.Clientbound;
using McAI.Proto.Packet.Play.Serverbound;
using McAI.Proto.StreamReader.Abstractions;
using McAI.Proto.StreamReader.Model;
using System.Collections.Generic;

namespace McAI.BOT.AgentEventHandlers
{
    public class Respawn : IPacketEventHandler
    {
        private readonly Agent agent;
        public Respawn(Agent agent)
        {
            this.agent = agent;
        }
        public async void OnPacket(PacketKey state, BasePacket packet)
        {
            var health = (UpdateHealthPacket)packet;

            if (health.Health <= 0)
            {
                var clientStatus = new ClientStatusPacket
                {
                    ActionID = ClientStatusActions.PerformPespawn
                };

                List<byte> send = new List<byte>();
                agent.Write(clientStatus, true, send);
                await agent.Send(send.ToArray());
            }

        }
    }
}
