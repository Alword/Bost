﻿using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Clientbound
{
	public class HeldItemChangePacket : BasePacket
	{
		public override int PacketId => 0x3F;
		/// <summary>
		/// The slot which the player has selected (0–8) 
		/// </summary>
		public sbyte Slot;
		public override void Read(byte[] array)
		{
			McByte.TryParse(ref array, out Slot);
		}

		public override byte[] Write()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return $"HeldItemChange Slot: {Slot}";
		}
	}
}
