using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Serverbound
{
    public class CloseWindowPacket : BasePacket
    {
        public override int PacketId => 0x0A;
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
            return $"<[CloseWindow|{base.ToString()}] WindowID:{WindowID}";
        }
    }
}
