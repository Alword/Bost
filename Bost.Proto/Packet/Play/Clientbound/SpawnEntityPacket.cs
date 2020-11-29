using Bost.Proto.Types;
using System;
using System.Collections.Generic;

namespace Bost.Proto.Packet.Play.Clientbound
{
	public class SpawnEntityPacket : BasePacket
	{
		public override int PacketId => 0x00;

		public int EntityId { get; set; } // Varint
		public Guid UUID { get; set; } // UUID
		public int Type { get; set; } // Varint
		public double X { get; set; } // Double
		public double Y { get; set; } // Double
		public double Z { get; set; } // Double
		public byte Pitch { get; set; } // Angle
		public byte Yaw { get; set; } // Angle
		public int Data { get; set; } // int
		public short VelocityX { get; set; } // Short
		public short VelocityY { get; set; } // Short
		public short VelocityZ { get; set; } // Short


		public override void Read(byte[] array)
		{
			if (McVarint.TryParse(ref array, out int entityId)) EntityId = entityId;
			if (McUUID.TryParse(ref array, out Guid uuid)) UUID = uuid;
			if (McVarint.TryParse(ref array, out int type)) Type = type;
			if (McDouble.TryParse(ref array, out double x)) X = x;
			if (McDouble.TryParse(ref array, out double y)) Y = y;
			if (McDouble.TryParse(ref array, out double z)) Z = z;
			if (McUnsignedByte.TryParse(ref array, out byte pitch)) Pitch = pitch;
			if (McUnsignedByte.TryParse(ref array, out byte yaw)) Yaw = yaw;
			if (McInt.TryParse(ref array, out int data)) Data = data;
			if (McShort.TryParse(ref array, out short velocityX)) VelocityX = velocityX;
			if (McShort.TryParse(ref array, out short velocityY)) VelocityY = velocityY;
			if (McShort.TryParse(ref array, out short velocityZ)) VelocityZ = velocityZ;
		}

		public override string ToString()
		{
			return $"SpawnEntity EntityId: {EntityId} UUID: {UUID} Type:{Type} " +
				$"XYZ:{X:0.00} {Y:0.00} {Z:0.00} P:{Pitch} Y:{Yaw} " +
				$"Data:{Data} V:{VelocityX}:{VelocityY}:{VelocityZ}";
		}

		public override byte[] Write()
		{
			List<byte> bytes = new List<byte>();
			bytes.AddRange(McVarint.ToBytes(EntityId));
			bytes.AddRange(McUUID.ToBytes(UUID));
			bytes.AddRange(McVarint.ToBytes(Type));
			bytes.AddRange(McDouble.ToBytes(X));
			bytes.AddRange(McDouble.ToBytes(Y));
			bytes.AddRange(McDouble.ToBytes(Z));
			bytes.AddRange(McUnsignedByte.ToBytes(Pitch));
			bytes.AddRange(McUnsignedByte.ToBytes(Yaw));
			bytes.AddRange(McInt.ToBytes(Data));
			bytes.AddRange(McShort.ToBytes(VelocityX));
			bytes.AddRange(McShort.ToBytes(VelocityY));
			bytes.AddRange(McShort.ToBytes(VelocityZ));
			return bytes.ToArray();
		}
	}
}
