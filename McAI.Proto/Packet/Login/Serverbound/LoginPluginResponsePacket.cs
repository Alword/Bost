using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Login.Serverbound
{
    public class LoginPluginResponsePacket : BasePacket
    {
        public override int PacketId => 0x02;

        public int MessageID; //Varint
        public bool Successful;
        public byte[] Data; //Optional Byte Array

        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out MessageID);
            McBoolean.TryParse(ref array, out Successful);
            if (Successful)
            {
                McByteArray.TryParse(ref array, out Data);
            }
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }
    }
}
