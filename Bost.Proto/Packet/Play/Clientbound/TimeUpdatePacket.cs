using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Clientbound
{
	public class TimeUpdatePacket : BasePacket
	{
		public override int PacketId => 0x4E;

		public long WorldAge;
		public long TimeOfDay;

		public override void Read(byte[] array)
		{
			McLong.TryParse(ref array, out WorldAge);
			McLong.TryParse(ref array, out TimeOfDay);
		}

		public override byte[] Write()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return $"[TimeUpdate] WorldAge:{WorldAge} TimeOfDay:{TimeOfDay}";
		}
	}
}
