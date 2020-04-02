using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Serverbound
{
    public class PlayerPositionAndRotationPacket : BasePacket
    {
        public override int PacketId => 0x12;
        public double X;
        public double FeetY;
        public double Z;
        public float Yaw;
        public float Pitch;
        public bool OnGround;

        public override void Read(byte[] array)
        {
            McDouble.TryParse(ref array, out X);
            McDouble.TryParse(ref array, out FeetY);
            McDouble.TryParse(ref array, out Z);
            McFloat.TryParse(ref array, out Yaw);
            McFloat.TryParse(ref array, out Pitch);
            McBoolean.TryParse(ref array, out OnGround);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $">[PlayerPositionAndRotation{base.ToString()}] X:{X} FeetY:{FeetY} Z:{Z} " +
                $"Yaw:{Yaw} Pitch:{Pitch} OnGround:{OnGround}";
        }
    }
}
