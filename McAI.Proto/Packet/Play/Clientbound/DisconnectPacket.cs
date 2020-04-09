using McAI.Proto.Model.ChatObject;
using McAI.Proto.Types;
using System;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class DisconnectPacket : BasePacket
    {
        public override int PacketId => 0x1B;
        public Chat Reason;

        public override void Read(byte[] array)
        {
            McChat.TryParse(ref array, out Reason);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[Disconnect] Reason:{Reason}";
        }
    }
}
