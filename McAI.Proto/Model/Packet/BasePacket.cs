using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Model.Packet
{
    public abstract class BasePacket
    {
        public abstract int PacketId { get; }
        public abstract void Read(byte[] array);
        public abstract byte[] Write();
    }
}
