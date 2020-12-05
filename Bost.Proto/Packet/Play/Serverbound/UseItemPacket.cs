using Bost.Proto.Enum;
using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Serverbound
{
	public class UseItemPacket : BasePacket
	{
		public override int PacketId => 0x2F;
		public HandType Hand; //Varint Enum

		public override void Read(byte[] array)
		{
			if (McVarint.TryParse(ref array, out var hand)) Hand = (HandType)hand;
		}

		public override byte[] Write()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return $"[UseItem] Hand:{Hand}";
		}
	}
}
