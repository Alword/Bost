using System.Collections.Generic;

namespace McAI.BOT.AgentEventHandlers
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
            List<byte> send = new List<byte>();
            agent.Write(toServerKeepAlive, true, send);
            await agent.Send(send.ToArray());
        }
    }
}
