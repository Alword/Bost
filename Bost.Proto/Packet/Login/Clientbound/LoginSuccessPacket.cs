using Bost.Proto.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bost.Proto.Packet.Login.Clientbound
{
	public class LoginSuccessPacket : BasePacket
	{
		public override int PacketId => 0x02;

		[MaxLength(36)] public Guid UUID { get; set; }
		[MaxLength(16)] public string Username { get; set; }
		public override void Read(byte[] array)
		{
			if (McUUID.TryParse(ref array, out Guid uuid)) UUID = uuid;
			McString.TryParse(ref array, out var text);
			Username = text;
		}

		public override byte[] Write()
		{
			List<byte> bytes = new List<byte>();
			bytes.AddRange(McUUID.ToBytes(UUID));
			bytes.AddRange(McString.ToBytes(Username));
			return bytes.ToArray();
		}
	}
}
