using Bost.Proto.Types;

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
