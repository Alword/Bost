using Bost.Proto.Enum;
using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Clientbound
{
	public class EntityStatusPacket : BasePacket
	{
		public override int PacketId => 0x1A;
		public int EntityID;
		public StatusTable EntityStatus;
		public EntityStatusPacket() { }

		public override void Read(byte[] array)
		{
			_ = McInt.TryParse(ref array, out EntityID);
			if (McByte.TryParse(ref array, out var entityStatus)) EntityStatus = (StatusTable)entityStatus;
		}

		public override byte[] Write()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return $"EntityStatus EntityID: {EntityID} EntityStatus: {EntityStatus}";
		}
	}
}
