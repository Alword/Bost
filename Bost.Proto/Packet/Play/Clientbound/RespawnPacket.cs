using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Clientbound
{
    public class RespawnPacket : BasePacket
    {
        public override int PacketId => 0x39;

        public NbtLib.NbtCompoundTag Dimension; //*NBT Tag Compound
        public string WorldName; //*
        public long HashedSeed;
        public byte Gamemode; //Unsigned Byte
        public byte PreviousGamemode; //*
        public bool IsDebug; //*
        public bool IsFlat; //*
        public bool CopyMetadata; //*

        public override void Read(byte[] array)
        {
            McNbtCompoundTag.TryParse(ref array, out Dimension);
            McString.TryParse(ref array, out WorldName);
            McLong.TryParse(ref array, out HashedSeed);
            McUnsignedByte.TryParse(ref array, out Gamemode);
            McUnsignedByte.TryParse(ref array, out PreviousGamemode);
            McBoolean.TryParse(ref array, out IsDebug);
            McBoolean.TryParse(ref array, out IsFlat);
            McBoolean.TryParse(ref array, out CopyMetadata);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[Respawn] Dimension:{Dimension} HashedSeed:{HashedSeed} " +
                $"Gamemode:{Gamemode}";
        }
    }
}
