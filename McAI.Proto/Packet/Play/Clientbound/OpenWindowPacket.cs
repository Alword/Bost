using McAI.Proto.Model.ChatObject;
using McAI.Proto.Types;
using System;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class OpenWindowPacket : BasePacket
    {
        public override int PacketId => 0x2F;

        public int WindowID; //Varint
        public int WindowType; //Varint
        public Chat WindowTitle;

        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out WindowID);
            McVarint.TryParse(ref array, out WindowType);
            McChat.TryParse(ref array, out WindowTitle);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[OpenWindow] WindowID:{WindowID} WindowType:{WindowType} WindowTitle:{WindowTitle}";
        }
    }
}
