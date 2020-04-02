using McAI.Proto.Packet;
using McAI.Proto.StreamReader.Enum;
using McAI.Proto.StreamReader.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace McAI.Proto.StreamReader.Abstractions
{
    public interface IPacketEventHandler
    {
        public void OnPacket(PacketKey type, BasePacket packet);
    }
}
