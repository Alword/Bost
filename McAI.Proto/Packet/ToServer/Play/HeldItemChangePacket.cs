using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.ToServer.Play
{
    public class HeldItemChangePacket : BasePacket
    {
        public override int PacketId => 0x23;
        public short Slot;

        public override void Read(byte[] array)
        {
           McShort.TryParse(ref array, out Slot);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"<[HeldItemChange{base.ToString()}] Slot: {Slot}";
        }
    }
}
