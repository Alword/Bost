using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Clientbound
{
	public class SpawnLivingEntityPacket : BasePacket
	{
		public override int PacketId => 0x02;

		public int EntityID; //Varint
		public Guid EntityUUID; //UUID
		public int Type; //Varint
		public double X;
		public double Y;
		public double Z;
		public byte Yaw; //Angle
		public byte Pitch; //Angle
		public byte HeadPitch; //Angle
		public short VelocityX;
		public short VelocityY;
		public short VelocityZ;

		public override void Read(byte[] array)
		{
			McVarint.TryParse(ref array, out EntityID);
			McUUID.TryParse(ref array, out EntityUUID);
			McVarint.TryParse(ref array, out Type);
			McDouble.TryParse(ref array, out X);
			McDouble.TryParse(ref array, out Y);
			McDouble.TryParse(ref array, out Z);
			McUnsignedByte.TryParse(ref array, out Yaw);
			McUnsignedByte.TryParse(ref array, out Pitch);
			McUnsignedByte.TryParse(ref array, out HeadPitch);
			McShort.TryParse(ref array, out VelocityX);
			McShort.TryParse(ref array, out VelocityY);
			McShort.TryParse(ref array, out VelocityZ);
		}

		public override byte[] Write()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return $"[SpawnLivingEntity] EntityID:{EntityID} EntityUUID:{EntityUUID} Type:{Type} " +
				$"X:{X} Y:{Y} Z:{Z} Yaw:{Yaw} Pitch:{Pitch} HeadPitch:{HeadPitch} " +
				$"VelocityX:{VelocityX} VelocityY:{VelocityY} VelocityZ:{VelocityZ}";
		}
	}
}
