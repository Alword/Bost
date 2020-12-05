using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Clientbound
{
    public class VehicleMovePacket : BasePacket
    {
        public override int PacketId => 0x2B;

        public double X;
        public double Y;
        public double Z;
        public float Yaw;
        public float Pitch;

        public override void Read(byte[] array)
        {
            McDouble.TryParse(ref array, out X);
            McDouble.TryParse(ref array, out Y);
            McDouble.TryParse(ref array, out Z);
            McFloat.TryParse(ref array, out Yaw);
            McFloat.TryParse(ref array, out Pitch);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[VehicleMove] X:{X} Y:{Y} Z:{Z} Yaw:{Yaw} Pitch:{Pitch}";
        }
    }
}
