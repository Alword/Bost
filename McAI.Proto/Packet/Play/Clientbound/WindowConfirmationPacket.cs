using McAI.Proto.Types;
using System;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class WindowConfirmationPacket : BasePacket
    {
        public override int PacketId => 0x13;

        public sbyte WindowID;
        public short ActionNumber;
        public bool Accepted;

        public override void Read(byte[] array)
        {
            McByte.TryParse(ref array, out WindowID);
            McShort.TryParse(ref array, out ActionNumber);
            McBoolean.TryParse(ref array, out Accepted);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[WindowConfirmation] WindowID:{WindowID} " +
                $"ActionNumber:{ActionNumber} Accepted:{Accepted}";
        }
    }
}
