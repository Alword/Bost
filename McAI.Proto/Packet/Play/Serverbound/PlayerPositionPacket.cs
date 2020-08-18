using Bost.Proto.Types;
using System.Collections.Generic;

namespace Bost.Proto.Packet.Play.Serverbound
{
    public class PlayerPositionPacket : BasePacket
    {
        public override int PacketId => 0x11;

        public double X;
        public double FeetY; // Absolute feet position, normally Head Y - 1.62 
        public double Z;
        public bool OnGround;

        public override void Read(byte[] array)
        {
            McDouble.TryParse(ref array, out X);
            McDouble.TryParse(ref array, out FeetY);
            McDouble.TryParse(ref array, out Z);
            McBoolean.TryParse(ref array, out OnGround);
        }

        public override string ToString()
        {
            return $"PlayerPosition X: {X:0.00} FeetY: {FeetY:0.00} Z: {Z:0.00}";
        }

        public override byte[] Write()
        {
            List<byte> tosend = new List<byte>();
            tosend.AddRange(McDouble.ToBytes(X));
            tosend.AddRange(McDouble.ToBytes(FeetY));
            tosend.AddRange(McDouble.ToBytes(Z));
            tosend.AddRange(McBoolean.ToBytes(OnGround));
            return tosend.ToArray();
        }
    }
}
