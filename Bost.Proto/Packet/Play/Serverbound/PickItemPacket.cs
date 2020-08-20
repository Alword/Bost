using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Serverbound
{
    public class PickItemPacket : BasePacket
    {
        public override int PacketId => 0x17;
        public int SlotToUse; //Varint

        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out SlotToUse);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[PickItem] SlotToUse:{SlotToUse}";
        }
    }
}
