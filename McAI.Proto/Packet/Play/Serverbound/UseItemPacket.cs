using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Serverbound
{
    public class UseItemPacket : BasePacket
    {
        public override int PacketId => 0x2D;
        public int Hand; //Varint Enum

        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out Hand);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[UseItem] Hand:{Hand}";
        }
    }
}
