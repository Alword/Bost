using Bost.Proto.Types;
using System;
using System.Text;

namespace Bost.Proto.Packet.Play.Clientbound
{
	public class DestroyEntitiesPacket : BasePacket
	{
		public override int PacketId => 0x36;

		public int Count; //Varint
		public int[] EntityIDs; //Array of VarInt

		public override void Read(byte[] array)
		{
			McVarint.TryParse(ref array, out Count);
			EntityIDs = new int[Count];
			for (int i = 0; i < Count; i++)
			{
				McVarint.TryParse(ref array, out EntityIDs[i]);
			}
		}

		public override byte[] Write()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (int entity in EntityIDs)
			{
				stringBuilder.AppendLine(entity.ToString());
			}
			return $"[DestroyEntities] Count:{Count} EntityIDs:{stringBuilder}";
		}
	}
}
