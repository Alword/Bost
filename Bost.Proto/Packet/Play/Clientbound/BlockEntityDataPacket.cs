using Bost.Proto.Model;
using Bost.Proto.Types;
using NbtLib;
using System;

namespace Bost.Proto.Packet.Play.Clientbound
{
    public class BlockEntityDataPacket : BasePacket
    {
        public override int PacketId => 0x09;

        public Position Location;
        public byte Action; //Unsigned Byte
        public NbtCompoundTag NBTData; //NBT Tag


        public override void Read(byte[] array)
        {
            Location = new Position();
            Location.Read(ref array);
            McUnsignedByte.TryParse(ref array, out Action);
            McNbtCompoundTag.TryParse(ref array, out NBTData);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[BlockEntityData] Location:{Location} Action:{Action} NBTData:{NBTData}";
        }
    }
}
