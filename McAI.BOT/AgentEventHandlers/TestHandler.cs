using McAI.Proto.Packet.Play.Clientbound;
using McAI.Proto.StreamReader.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.BOT.AgentEventHandlers
{
    class TestHandler : IPacketEventHandler<BlockChangePacket>
    {
        public void OnPacket(BlockChangePacket packet)
        {
            Console.WriteLine(packet);
        }
    }
}
