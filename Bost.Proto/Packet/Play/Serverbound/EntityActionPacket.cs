using Bost.Proto.Enum;
using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Serverbound
{
	public class EntityActionPacket : BasePacket
	{
		public override int PacketId => 0x1C;

		public int EntityID; //Varint
		public EntityActionType ActionID; //Varint Enum
		public int JumpBoost; //Varint

		public override void Read(byte[] array)
		{
			_ = McVarint.TryParse(ref array, out EntityID);
			if (McVarint.TryParse(ref array, out var actionID)) ActionID = (EntityActionType)actionID;
			_ = McVarint.TryParse(ref array, out JumpBoost);
		}

		public override byte[] Write()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return $"[EntityAction] EntityID:{EntityID} ActionID:{ActionID} JumpBoost:{JumpBoost}";
		}
	}
}
