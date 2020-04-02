using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class EntityPositionAndRotationPacket : BasePacket
    {
        public override int PacketId => 0x2A;

        public int EntityID; //Varint
        public short DeltaX;
        public short DeltaY;
        public short DeltaZ;
        public byte Yaw; //Angle
        public byte Pitch; //Angle
        public bool OnGround;

        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out EntityID);
            McShort.TryParse(ref array, out DeltaX);
            McShort.TryParse(ref array, out DeltaY);
            McShort.TryParse(ref array, out DeltaZ);
            McUnsignedByte.TryParse(ref array, out Yaw);
            McUnsignedByte.TryParse(ref array, out Pitch);
            McBoolean.TryParse(ref array, out OnGround);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[EntityPositionAndRotation] EntityID:{EntityID} DeltaX:{DeltaX} DeltaY:{DeltaY} " +
                $"DeltaZ:{DeltaZ} Yaw:{Yaw} Pitch:{Pitch} OnGround:{OnGround}";
        }
    }
}
