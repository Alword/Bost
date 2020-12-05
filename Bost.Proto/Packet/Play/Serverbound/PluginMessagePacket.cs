﻿using Bost.Proto.Extentions;
using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Serverbound
{
	public class PluginMessagePacket : BasePacket
	{
		public override int PacketId => 0x0B;
		public string Channel; //Identifier
		public byte[] Data; //Byte Array

		public override void Read(byte[] array)
		{
			McString.TryParse(ref array, out Channel);
			McByteArray.TryParse(ref array, out Data);
		}

		public override byte[] Write()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return $"PluginMessage Channel: {Channel} Data: {Data.ToHexString()}";
		}
	}
}
