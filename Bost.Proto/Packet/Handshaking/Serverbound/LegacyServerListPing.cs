using Bost.Proto.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bost.Proto.Packet.Handshaking.Serverbound
{
	public class LegacyServerListPing : BasePacket
	{
		public sbyte Payload;

		public override int PacketId => 0xFE;

		public override void Read(byte[] array)
		{
			McByte.TryParse(ref array, out Payload);
		}

		public override byte[] Write()
		{
			return McByte.ToBytes(Payload);
		}
	}
}
