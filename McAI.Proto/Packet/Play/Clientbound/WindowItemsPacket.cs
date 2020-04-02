using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class WindowItemsPacket : BasePacket
    {
        public override int PacketId => 0x15;

        public byte WindowID; // Unsigned Byte
        public short Count;
        // SlotData   Field Type - Array of Slot

        public override void Read(byte[] array)
        {
            McUnsignedByte.TryParse(ref array, out WindowID);
            McShort.TryParse(ref array, out Count);

        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[WindowItems] WindowID:{WindowID} Count:{Count}";
        }
    }
}
