using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Clientbound
{
	public class CloseWindowPacket : BasePacket
	{
		public override int PacketId => 0x12;
		public byte WindowID; //Unsigned Byte

		public override void Read(byte[] array)
		{
			McUnsignedByte.TryParse(ref array, out WindowID);
		}

		public override byte[] Write()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return $"[CloseWindow] WindowID:{WindowID}";
		}
	}
}
