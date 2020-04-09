using McAI.Proto.Model.ChatObject;
using McAI.Proto.Types;
using System;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class ChatMessagePacket : BasePacket
    {
        public override int PacketId => 0x0F;

        public Chat Chat; //Varint
        public byte Position;

        public override void Read(byte[] array)
        {
            McChat.TryParse(ref array, out Chat);
            McUnsignedByte.TryParse(ref array, out Position);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[ChatMessage] {Chat}";
        }
    }
}
