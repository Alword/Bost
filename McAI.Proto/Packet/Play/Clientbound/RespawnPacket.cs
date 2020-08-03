using McAI.Proto.Types;
using System;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class RespawnPacket : BasePacket
    {
        public override int PacketId => 0x3B;

        public int Dimension; //Int Enum
        public long HashedSeed;
        public byte Gamemode; //Unsigned Byte
        public string LevelType; //String (16)

        public override void Read(byte[] array)
        {
            McInt.TryParse(ref array, out Dimension);
            McLong.TryParse(ref array, out HashedSeed);
            McUnsignedByte.TryParse(ref array, out Gamemode);
            McString.TryParse(ref array, out LevelType);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[Respawn] Dimension:{Dimension} HashedSeed:{HashedSeed} " +
                $"Gamemode:{Gamemode} LevelType:{LevelType}";
        }
    }
}
