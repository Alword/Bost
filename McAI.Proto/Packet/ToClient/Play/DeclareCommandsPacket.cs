using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.ToClient.Play
{
    public class DeclareCommandsPacket : BasePacket
    {
        public override int PacketId => 0x12;

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
