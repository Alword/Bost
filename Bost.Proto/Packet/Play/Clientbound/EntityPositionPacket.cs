using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Clientbound
{
	public class EntityPositionPacket : BasePacket
	{
		public override int PacketId => 0x27;

		public int EntityID; //Varint

		/// <summary>
		/// Change in X position as (currentX * 32 - prevX * 32) * 128
		/// </summary>
		public short DeltaX;
		/// <summary>
		/// Change in Y position as (currentY * 32 - prevY * 32) * 128
		/// </summary>
		public short DeltaY;
		/// <summary>
		/// Change in Z position as (currentZ * 32 - prevY * 32) * 128
		/// </summary>
		public short DeltaZ;
		public bool OnGround;

		public override void Read(byte[] array)
		{
			McVarint.TryParse(ref array, out EntityID);
			McShort.TryParse(ref array, out DeltaX);
			McShort.TryParse(ref array, out DeltaY);
			McShort.TryParse(ref array, out DeltaZ);
			McBoolean.TryParse(ref array, out OnGround);
		}

		public override byte[] Write()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return $"[EntityPosition] EntityID:{EntityID} DeltaXYZ:{DeltaX} {DeltaY} {DeltaZ} OnGround:{OnGround}";
		}
	}
}
