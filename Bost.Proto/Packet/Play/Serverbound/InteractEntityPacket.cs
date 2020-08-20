using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Serverbound
{
    public class InteractEntityPacket : BasePacket
    {
        public override int PacketId => 0x0E;

        public int EntityID; //Varint
        public int Type; //Varint Enum
        public float TargetX; // Optional Float
        public float TargetY; // Optional Float
        public float TargetZ; // Optional Float
        public int Hand; // Optional Varint Enum

        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out EntityID);
            McVarint.TryParse(ref array, out Type);
            if (Type == 2)
            {
                McFloat.TryParse(ref array, out TargetX);
                McFloat.TryParse(ref array, out TargetY);
                McFloat.TryParse(ref array, out TargetZ);
            }
            if (Type != 1)
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
