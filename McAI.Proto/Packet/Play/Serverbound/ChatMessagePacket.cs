using McAI.Proto.Types;
using System;

namespace McAI.Proto.Packet.Play.Serverbound
{
    public class ChatMessagePacket : BasePacket
    {
        public override int PacketId => 0x03;
        public string Message; //string(256)

        public override void Read(byte[] array)
        {
            McString.TryParse(ref array, out Message);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"ChatMessage Message: {Message}";
        }
    }
}
