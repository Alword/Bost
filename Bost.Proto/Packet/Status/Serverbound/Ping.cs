using Bost.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bost.Proto.Packet.Status.Serverbound
{
	public class Ping : BasePacket
	{
		public long Payload;
		public override int PacketId => 0x01;

		public override void Read(byte[] array)
		{
			McLong.TryParse(ref array, out Payload);
		}

		public override byte[] Write()
		{
			return McLong.ToBytes(Payload);
		}
	}
}
