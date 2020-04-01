using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Login.Clientbound
{
    public class EncryptionRequestPacket : BasePacket
    {
        public override int PacketId => 0x01;
        public string ServerID; // String(20)
        public int PublicKeyLength; // Varint
        public byte[] PublicKey; // Byte Array
        public int VerifyTokenLength; // Varint
        public byte[] VerifyToken; // Byte Array

        public override void Read(byte[] array)
        {
            McString.TryParse(ref array, out ServerID);
            McVarint.TryParse(ref array, out PublicKeyLength);
            McByteArray.TryParse(ref array, out PublicKey);
            McVarint.TryParse(ref array, out VerifyTokenLength);
            McByteArray.TryParse(ref array, out VerifyToken);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }
    }
}
