using Bost.Proto.Enum;
using Bost.Proto.Model.ChatObject;
using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Clientbound
{
	public class ChatMessagePacket : BasePacket
	{
		public override int PacketId => 0x0E;

		public Chat Chat; //Varint
		public ChatPosition Position;
		public Guid Sender;

		public override void Read(byte[] array)
		{
			McChat.TryParse(ref array, out Chat);
			if (McByte.TryParse(ref array, out sbyte position)) Position = (ChatPosition)position;
			McUUID.TryParse(ref array, out Sender);
		}

		public override byte[] Write()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return $"[ChatMessage] {Position} {Sender}:{Chat}";
		}
	}
}
