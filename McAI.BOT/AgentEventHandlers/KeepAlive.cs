using McAI.Proto.Packet;
using System.Collections.Generic;

namespace McAI.BOT.AgentEventHandlers
{
    public class KeepAlive
    {
        public async void OnPacket(object sender, BasePacket packet)
        {
            var agent = (Agent)sender;
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
