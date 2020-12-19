using Bost.Proto.Model.ChatObject;
using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Clientbound
{
	public class DisconnectPacket : BasePacket
	{
		public override int PacketId => 0x19;
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
