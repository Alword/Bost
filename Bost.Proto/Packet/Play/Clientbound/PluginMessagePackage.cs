﻿using Bost.Proto.Extentions;
using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Clientbound
{
	public class PluginMessagePackage : BasePacket
	{
		public override int PacketId => 0x17;
		public string Channel;
		public byte[] Data;

		public override void Read(byte[] array)
		{
			McString.TryParse(ref array, out Channel);
			Data = array;
		}

		public override byte[] Write()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return $"PluginMessage Channel: {Channel} Data:{Data.ToHexString()}";
		}
	}
}
