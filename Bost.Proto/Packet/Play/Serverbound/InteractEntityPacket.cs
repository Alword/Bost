using Bost.Proto.Enum;
using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Serverbound
{
	public class InteractEntityPacket : BasePacket
	{
		public override int PacketId => 0x0E;

		public int EntityID; //Varint
		public InteractEntityType Type; //Varint Enum
		public float TargetX; // Optional Float
		public float TargetY; // Optional Float
		public float TargetZ; // Optional Float
		public int Hand; // Optional Varint Enum

		public override void Read(byte[] array)
		{
			McVarint.TryParse(ref array, out EntityID);
			McVarint.TryParse(ref array, out var type);
			Type = (InteractEntityType)type;
			if (Type == InteractEntityType.InteractAt)
			{
				McFloat.TryParse(ref array, out TargetX);
				McFloat.TryParse(ref array, out TargetY);
				McFloat.TryParse(ref array, out TargetZ);
			}
			if (Type != InteractEntityType.Attack)
			{
				McVarint.TryParse(ref array, out Hand);
			}
		}

		public override byte[] Write()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return $"[InteractEntity] EntityID:{EntityID} Type:{Type} TargetX:{TargetX} " +
				$"TargetY:{TargetY} TargetZ:{TargetZ} Hand:{Hand}";
		}
	}
}
