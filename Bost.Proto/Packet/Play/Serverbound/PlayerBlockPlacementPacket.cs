using Bost.Proto.Enum;
using Bost.Proto.Model;
using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Serverbound
{
	public class PlayerBlockPlacementPacket : BasePacket
	{
		public override int PacketId => 0x2E;

		public HandType Hand; //Varint Enum
		public Position Location;
		public int Face; //Varint Enum
		public float CursorPositionX;
		public float CursorPositionY;
		public float CursorPositionZ;
		public bool InsideBlock;

		public override void Read(byte[] array)
		{
			if (McVarint.TryParse(ref array, out var hand)) Hand = (HandType)hand;
			Location = new Position();
			Location.Read(ref array);
			_ = McVarint.TryParse(ref array, out Face);
			_ = McFloat.TryParse(ref array, out CursorPositionX);
			_ = McFloat.TryParse(ref array, out CursorPositionY);
			_ = McFloat.TryParse(ref array, out CursorPositionZ);
			_ = McBoolean.TryParse(ref array, out InsideBlock);
		}

		public override byte[] Write()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return $"[PlayerBlockPlacement] Hand:{Hand} Location:{Location} Face:{Face} " +
				$"CursorPositionX:{CursorPositionX} CursorPositionY:{CursorPositionY} " +
				$"CursorPositionZ:{CursorPositionZ} InsideBlock:{InsideBlock}";
		}
	}
}
