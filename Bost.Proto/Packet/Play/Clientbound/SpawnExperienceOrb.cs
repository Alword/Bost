﻿using Bost.Proto.Types;
using System.Collections.Generic;

namespace Bost.Proto.Packet.Play.Clientbound
{
	public class SpawnExperienceOrb : BasePacket
	{
		public override int PacketId => 0x01;
		public int EntityId; // varint
		public double X;
		public double Y;
		public double Z;
		public short Count;


		public override void Read(byte[] array)
		{
			McVarint.TryParse(ref array, out EntityId);
			McDouble.TryParse(ref array, out X);
			McDouble.TryParse(ref array, out Y);
			McDouble.TryParse(ref array, out Z);
			McShort.TryParse(ref array, out Count);
		}

		public override byte[] Write()
		{
			List<byte> bytes = new List<byte>();
			bytes.AddRange(McVarint.ToBytes(EntityId)); ;
			bytes.AddRange(McDouble.ToBytes(X));
			bytes.AddRange(McDouble.ToBytes(Y));
			bytes.AddRange(McDouble.ToBytes(Z));
			bytes.AddRange(McShort.ToBytes(Count));
			return bytes.ToArray();
		}

		public override string ToString()
		{
			return $"SpawnExperienceOrb EntityId: {EntityId} XYZ:{X} {Y} {Z} Count: {Count}";
		}
	}
}
