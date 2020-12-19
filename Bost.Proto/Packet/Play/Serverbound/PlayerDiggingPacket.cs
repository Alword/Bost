using Bost.Proto.Enum;
using Bost.Proto.Model;
using Bost.Proto.Types;
using System.Collections.Generic;

namespace Bost.Proto.Packet.Play.Serverbound
{
	public class PlayerDiggingPacket : BasePacket
	{
		public override int PacketId => 0x1B;

		public PlayerDiggingStatus Status; //Varint Enum
		public Position Location;
		public Face Face; //Byte Enum

		public override void Read(byte[] array)
		{
			if (McVarint.TryParse(ref array, out int status)) { Status = (PlayerDiggingStatus)status; }
			Location.Read(ref array);
			if (McUnsignedByte.TryParse(ref array, out byte face)) { Face = (Face)face; }
		}

		public override byte[] Write()
		{
			List<byte> bytes = new List<byte>();
			bytes.AddRange(McVarint.ToBytes((int)Status));
			bytes.AddRange(Location.Write());
			bytes.AddRange(McUnsignedByte.ToBytes((byte)Face));
			return bytes.ToArray();
		}

		public override string ToString()
		{
			return $"[{nameof(PlayerDiggingPacket)}] Status:{Status} Location:{Location} Face:{Face}";
		}
	}
}
