using McAI.Proto.Types;
using System;

namespace McAI.Proto.Packet.Login.Clientbound
{
    public class DisconnectaPacket : BasePacket
    {
        public override int PacketId => 0x00;
        public string Reason; //Chat

        public override void Read(byte[] array)
        {
            McString.TryParse(ref array, out Reason);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }
    }
}
