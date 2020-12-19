using Bost.Proto.Enum;
using Bost.Proto.Types;

namespace Bost.Proto.Packet.Play.Serverbound
{
	public class ClientStatusPacket : BasePacket
	{
		public override int PacketId => 0x04;
		public ClientStatusActions ActionID; //Varint Enum 

		public override void Read(byte[] array)
		{
			McVarint.TryParse(ref array, out int actionId);
			ActionID = (ClientStatusActions)actionId;
		}

		public override byte[] Write()
		{
			return McVarint.ToBytes((int)ActionID);
		}

		public override string ToString()
		{
			return $"ClientStatus ActionID: {ActionID}";
		}
	}
}
