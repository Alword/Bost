using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class CloseWindowPacket : BasePacket
    {
        public override int PacketId => 0x14;
        public byte WindowID; //Unsigned Byte

        public override void Read(byte[] array)
        {
            McUnsignedByte.TryParse(ref array, out WindowID);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[CloseWindow] WindowID:{WindowID}";
        }
    }
}
