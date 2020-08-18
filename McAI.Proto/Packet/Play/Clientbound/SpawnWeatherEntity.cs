using Bost.Proto.Types;
using System.Collections.Generic;

namespace Bost.Proto.Packet.Play.Clientbound
{
    public class SpawnWeatherEntity : BasePacket
    {
        public override int PacketId => 0x02;

        public int EntityId; // varing
        public byte Type;
        public double X;
        public double Y;
        public double Z;


        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out EntityId);
            McUnsignedByte.TryParse(ref array, out Type);
            McDouble.TryParse(ref array, out X);
            McDouble.TryParse(ref array, out Y);
            McDouble.TryParse(ref array, out Z);
        }

        public override byte[] Write()
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(McVarint.ToBytes(EntityId));
            bytes.AddRange(McUnsignedByte.ToBytes(Type));
            bytes.AddRange(McDouble.ToBytes(X));
            bytes.AddRange(McDouble.ToBytes(Y));
            bytes.AddRange(McDouble.ToBytes(Z));
            return bytes.ToArray();
        }

        public override string ToString()
        {
            return $"SpawnExperienceOrb EntityId: {EntityId} Type: {Type} XYZ: {X} {Y} {Z}";
        }
    }
}
