using McAI.Proto.Packet;
using McAI.Proto.StreamReader.Model;
using System.Collections.Generic;

namespace McAI.BOT.AgentEventHandlers
{
    public class KeepAlive : BaseAgentEvent
    {
        public KeepAlive(Agent agent) : base(agent) { }
        public async override void OnPacket(PacketKey state, BasePacket packet)
        {
            var toclientKeepAlive = (Proto.Packet.Play.Clientbound.KeepAlivePacket)packet;

            var toServerKeepAlive = new Proto.Packet.Play.Serverbound.KeepAlivePacket
            {
                KeepAliveID = toclientKeepAlive.KeepAliveID
            };
            List<byte> send = new List<byte>();
            agent.Write(toServerKeepAlive, true, send);
            await agent.Send(send.ToArray());
        }
    }
}
