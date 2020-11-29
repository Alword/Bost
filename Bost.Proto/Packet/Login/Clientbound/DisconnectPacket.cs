using Bost.Proto.Model.ChatObject;
using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Login.Clientbound
{
    public class DisconnectPacket : BasePacket
    {
        public override int PacketId => 0x00;
        public Chat Reason;

        public override void Read(byte[] array)
        {
            McChat.TryParse(ref array, out Reason);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }
    }
}
