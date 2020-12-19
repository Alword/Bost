using Bost.Proto.Types;
using System.ComponentModel.DataAnnotations;

namespace Bost.Proto.Packet.Play.Serverbound
{
	public class ChatMessagePacket : BasePacket
	{
		public override int PacketId => 0x03;
		[MaxLength(256)] public string Message; //string(256)

		public override void Read(byte[] array)
		{
			McString.TryParse(ref array, out Message);
		}

		public override byte[] Write()
		{
			return McString.ToBytes(Message);
		}

		public override string ToString()
		{
			return $"ChatMessage Message: {Message}";
		}
	}
}
