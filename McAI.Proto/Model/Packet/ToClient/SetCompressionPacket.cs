using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Model.Packet.ToClient
{
    public class SetCompressionPacket : BasePacket
    {
        public override int PacketId => 0x03;
        public int Threshold { get; set; }
        public override void Read(byte[] array)
        {
            Varint.TryParse(ref array, out int result);
            Threshold = result;
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }
    }
}
