using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Login.Clientbound
{
    public class LoginPluginRequestPacket : BasePacket
    {
        public override int PacketId => 0x04;

        public int MessageID; //Varint
        public string Channel; //Identifier
        public byte[] Data; //Byte Array

        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out MessageID);
            McString.TryParse(ref array, out Channel);
            McByteArray.TryParse(ref array, out Data);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }
    }
}
