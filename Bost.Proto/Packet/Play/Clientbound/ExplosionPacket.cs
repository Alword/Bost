using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Clientbound
{
	public class ExplosionPacket : BasePacket
	{
		public override int PacketId => 0x1B;

		public float X;
		public float Y;
		public float Z;
		public float Strength;
		public int RecordCount;
		public byte[] Records; //Array of (Byte, Byte, Byte)
		public float PlayerMotionX;
		public float PlayerMotionY;
		public float PlayerMotionZ;

		public override void Read(byte[] array)
		{
			McFloat.TryParse(ref array, out X);
			McFloat.TryParse(ref array, out Y);
			McFloat.TryParse(ref array, out Z);
			McFloat.TryParse(ref array, out Strength);
			McInt.TryParse(ref array, out RecordCount);
			McByteArray.TryParse(ref array, out Records);
			McFloat.TryParse(ref array, out PlayerMotionX);
			McFloat.TryParse(ref array, out PlayerMotionY);
			McFloat.TryParse(ref array, out PlayerMotionZ);
		}

		public override byte[] Write()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return $"[Explosion] X:{X} Y:{Y} Z:{Z} Strength:{Strength} " +
				$"RecordCount:{RecordCount} Records:{Records} " +
				$"PlayerMotionX:{PlayerMotionX} PlayerMotionY:{PlayerMotionY} PlayerMotionZ:{PlayerMotionZ}";
		}
	}
}
