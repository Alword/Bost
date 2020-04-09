using McAI.Proto.Model;
using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class BlockEntityDataPacket : BasePacket
    {
        public override int PacketId => 0x0A;

        public Position Location;
        public byte Action; //Unsigned Byte
        public Tags NBTData; //NBT Tag


        public override void Read(byte[] array)
        {
            Location = new Position();
            Location.Read(ref array);
            McUnsignedByte.TryParse(ref array, out Action);
            McTags.TryParse(ref array, out NBTData);
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
