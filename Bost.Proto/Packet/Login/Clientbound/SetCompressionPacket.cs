using Bost.Proto.Types;

namespace Bost.Proto.Packet.Login.Clientbound
{
	public class SetCompressionPacket : BasePacket
	{
		public override int PacketId => 0x03;
		/// <summary>VarInt. Maximum size of a packet before it is compressed</summary>
		public int Threshold { get; set; }
		public override void Read(byte[] array)
		{
			McVarint.TryParse(ref array, out int result);
			Threshold = result;
		}

		public override byte[] Write()
		{
			return McVarint.ToBytes(Threshold);
		}
	}
}
