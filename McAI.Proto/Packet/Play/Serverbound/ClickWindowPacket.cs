using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Serverbound
{
    public class ClickWindowPacket : BasePacket
    {
        public override int PacketId => 0x09;
        public byte WindowID; //Unsigned Byte
        public short Slot;
        public byte Button;
        public short ActionNumber;
        public int Mode; //Varint Enum
        // ClickedItem   Field Type - Slot Data

        public override void Read(byte[] array)
        {
            McUnsignedByte.TryParse(ref array, out WindowID);
            McShort.TryParse(ref array, out Slot);
            McUnsignedByte.TryParse(ref array, out Button);
            McShort.TryParse(ref array, out ActionNumber);
            McVarint.TryParse(ref array, out Mode);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"ClickWindow WindowID:{WindowID} Slot:{Slot} Button:{Button} ActionNumber:{ActionNumber} Mode:{Mode}";
        }
    }
}
