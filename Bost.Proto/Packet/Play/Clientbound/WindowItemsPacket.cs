using Bost.Proto.Model;
using Bost.Proto.Types;
using System;
using System.Text;

namespace Bost.Proto.Packet.Play.Clientbound
{
	public class WindowItemsPacket : BasePacket
	{
		public override int PacketId => 0x13;

		public byte WindowID; // Unsigned Byte
		public short Count;
		public Slot[] SlotData; //Field Type - Array of Slot

		public override void Read(byte[] array)
		{
			McUnsignedByte.TryParse(ref array, out WindowID);
			McShort.TryParse(ref array, out Count);
			SlotData = new Slot[Count];
			for (int i = 0; i < Count; i++)
			{
				SlotData[i] = new Slot();
				SlotData[i].Parse(ref array);
			}
		}

		public override byte[] Write()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();

			for (int i = 0; i < SlotData.Length; i++)
			{
				if (i % 4 == 0)
				{
					stringBuilder.AppendLine($"[{i}] {SlotData[i]} ");
				}
				else
				{
					stringBuilder.Append($"[{i}] {SlotData[i]} ");
				}
			}

			return $"[WindowItems] WindowID:{WindowID} Count:{Count} {stringBuilder}";
		}
	}
}
