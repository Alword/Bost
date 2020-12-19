using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Serverbound
{
	public class PlayerAbilitiesPacket : BasePacket
	{
		public override int PacketId => 0x1A;

		public byte Flags;

		public override void Read(byte[] array)
		{
			McUnsignedByte.TryParse(ref array, out Flags);
		}

		public override byte[] Write()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return $"[PlayerAbilities] Flags:{Flags}";
		}
	}
}
