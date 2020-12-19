using System;

namespace Bost.Proto.Packet.Play.Clientbound
{
	public class DeclareCommandsPacket : BasePacket
	{
		public override int PacketId => 0x10;

		public override void Read(byte[] array)
		{
			//throw new NotImplementedException();
		}

		public override string ToString()
		{
			return $"DeclareCommands NotImplemented";
		}

		public override byte[] Write()
		{
			throw new NotImplementedException();
		}
	}
}
