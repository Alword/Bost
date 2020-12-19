﻿using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Serverbound
{
	class PlayerRotationPacket : BasePacket
	{
		public override int PacketId => 0x14;
		public float Yaw;
		public float Pitch;
		public bool OnGround;

		public override void Read(byte[] array)
		{
			McFloat.TryParse(ref array, out Yaw);
			McFloat.TryParse(ref array, out Pitch);
			McBoolean.TryParse(ref array, out OnGround);
		}

		public override byte[] Write()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return $"[PlayerRotation] Yaw:{Yaw} Pitch:{Pitch} OnGround:{OnGround}";
		}
	}
}
