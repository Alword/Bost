using Bost.Proto.Types;

namespace Bost.Proto.Packet.Status.Serverbound
{
	public class Ping : BasePacket
	{
		/// <summary>
		///  May be any number. Notchian clients use a system-dependent 
		///  time value which is counted in milliseconds.
		/// </summary>
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
