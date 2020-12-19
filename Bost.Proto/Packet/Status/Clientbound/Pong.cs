using Bost.Proto.Types;

namespace Bost.Proto.Packet.Status.Clientbound
{
	public class Pong : BasePacket
	{
		public override int PacketId => 0x01;
		/// <summary>
		/// Should be the same as sent by the client
		/// </summary>
		public long Payload;

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
