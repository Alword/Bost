using Bost.Proto.Types;

namespace Bost.Proto.Packet.Play.Serverbound
{
	public class HeldItemChangePacket : BasePacket
	{
		public override int PacketId => 0x25;
		public short Slot;

		public override void Read(byte[] array)
		{
			McShort.TryParse(ref array, out Slot);
		}

		public override byte[] Write()
		{
			return McShort.ToBytes(Slot);
		}

		public override string ToString()
		{
			return $"[{nameof(HeldItemChangePacket)}] Slot: {Slot}";
		}
	}
}
