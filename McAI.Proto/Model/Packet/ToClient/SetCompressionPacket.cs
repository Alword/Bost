using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Model.Packet.ToClient
{
    public class SetCompressionPacket : BasePacket
    {
        public override int PacketId => 0x03;

        public override void Read(byte[] array)
        {
            throw new NotImplementedException();
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }
    }
}
