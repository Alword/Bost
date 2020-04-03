using McAI.Proto.Packet;
using McAI.Proto.StreamReader.Abstractions;
using McAI.Proto.StreamReader.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.BOT.AgentEventHandlers
{
    public class ReadChunkData : IPacketEventHandler
    {
        public void OnPacket(PacketKey type, BasePacket packet)
        {
            throw new NotImplementedException();
        }
    }
}
