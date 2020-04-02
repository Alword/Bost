using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Serverbound
{
    public class WindowConfirmationPacket : BasePacket
    {
        public override int PacketId => 0x07;
        public byte WindowID;
        public short ActionNumber;
        public bool Accepted;

        public override void Read(byte[] array)
        {
            McUnsignedByte.TryParse(ref array, out WindowID);
            McShort.TryParse(ref array, out ActionNumber);
            McBoolean.TryParse(ref array, out Accepted);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"WindowConfirmation WindowID:{WindowID} ActionNumber:{ActionNumber} Accepted:{Accepted}";
        }
    }
}
