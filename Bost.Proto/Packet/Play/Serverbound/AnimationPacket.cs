using Bost.Proto.Enum;
using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Serverbound
{
	public class AnimationPacket : BasePacket
	{
		public override int PacketId => 0x2C;
		public HandType Hand; //Varint

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
			return $"[Animation] Hand:{Hand}";
		}
	}
}
