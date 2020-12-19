﻿using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Clientbound
{
	public class EntityRotationPacket : BasePacket
	{
		public override int PacketId => 0x29;

		public int EntityID; //Varint
		public byte Yaw; //Angle
		public byte Pitch; //Angle
		public bool OnGround;

		public override void Read(byte[] array)
		{
			McVarint.TryParse(ref array, out EntityID);
			McUnsignedByte.TryParse(ref array, out Yaw);
			McUnsignedByte.TryParse(ref array, out Pitch);
			McBoolean.TryParse(ref array, out OnGround);
		}

		public override byte[] Write()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return $"[EntityRotation] EntityID:{EntityID} Yaw:{Yaw} Pitch:{Pitch} OnGround:{OnGround}";
		}
	}
}
