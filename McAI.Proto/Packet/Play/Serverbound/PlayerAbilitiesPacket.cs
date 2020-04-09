using McAI.Proto.Types;
using System;

namespace McAI.Proto.Packet.Play.Serverbound
{
    public class PlayerAbilitiesPacket : BasePacket
    {
        public override int PacketId => 0x19;

        public byte Flags;
        public float FlyingSpeed;
        public float WalkingSpeed;

        public override void Read(byte[] array)
        {
            McUnsignedByte.TryParse(ref array, out Flags);
            McFloat.TryParse(ref array, out FlyingSpeed);
            McFloat.TryParse(ref array, out WalkingSpeed);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[PlayerAbilities] Flags:{Flags} FlyingSpeed:{FlyingSpeed} WalkingSpeed:{WalkingSpeed}";
        }
    }
}
