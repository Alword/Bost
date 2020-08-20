using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Clientbound
{
    public class PlayerPositionAndLookPacket : BasePacket
    {
        public override int PacketId => 0x36;

        public double X;
        public double Y;
        public double Z;
        public float Yaw;
        public float Pitch;
        public byte Flags;
        public int TeleportID; // Varint

        public override void Read(byte[] array)
        {
            McDouble.TryParse(ref array, out X);
            McDouble.TryParse(ref array, out Y);
            McDouble.TryParse(ref array, out Z);
            McFloat.TryParse(ref array, out Yaw);
            McFloat.TryParse(ref array, out Pitch);
            McUnsignedByte.TryParse(ref array, out Flags);
            McVarint.TryParse(ref array, out TeleportID);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[PlayerPositionAndLook] X:{X} Y:{Y} Z:{Z} Yaw:{Yaw} Pitch{Pitch} " +
                $"Flags:{Flags} TeleportID:{TeleportID}";
        }
    }
}
