using System;

namespace Bost.Proto.Packet.Status.Serverbound
{
	public class Request : BasePacket
	{
		public override int PacketId => 0x00;

		public override void Read(byte[] array) { }

		public override byte[] Write() => Array.Empty<byte>();
	}
}
