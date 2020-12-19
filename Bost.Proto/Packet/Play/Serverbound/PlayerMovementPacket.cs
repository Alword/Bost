using Bost.Proto.Types;

namespace Bost.Proto.Packet.Play.Serverbound
{
	public class PlayerMovementPacket : BasePacket
	{
		public override int PacketId => 0x15;

		/// <summary>
		/// True if the client is on the ground, false otherwise 
		/// </summary>
		public bool OnGround;

		public override void Read(byte[] array)
		{
			McBoolean.TryParse(ref array, out OnGround);
		}

		public override byte[] Write()
		{
			return McBoolean.ToBytes(OnGround);
		}

		public override string ToString()
		{
			return $"PlayerMovement OnGround: {OnGround}";
		}
	}
}
