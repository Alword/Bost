﻿using Bost.Proto.Types;

namespace Bost.Proto.Packet.Play.Serverbound
{
	public class KeepAlivePacket : BasePacket
	{
		public override int PacketId => 0x10;
		public long KeepAliveID;

		public override void Read(byte[] array)
		{
			_ = McLong.TryParse(ref array, out KeepAliveID);
		}

		public override byte[] Write()
		{
			return McLong.ToBytes(KeepAliveID);
		}

		public override string ToString()
		{
			return $"KeepAlive KeepAliveID: {KeepAliveID}";
		}
	}
}
