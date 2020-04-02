using McAI.Proto.Types;
using System;

namespace McAI.Proto.Packet.Play.Serverbound
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
            return $"PlayerPosition {base.ToString()} X: {X} FeetY: {FeetY} Z: {Z}";
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }
    }
}
