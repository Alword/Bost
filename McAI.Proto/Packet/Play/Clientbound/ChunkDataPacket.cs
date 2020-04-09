using McAI.Proto.Types;
using NbtLib;
using System;
using System.IO;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class ChunkDataPacket : BasePacket
    {
        public override int PacketId => 0x22;

        public int ChunkX; // ing
        public int ChunkZ; // int
        public bool Fullchunk;
        public int PrimaryBitMask; // varint
        public NbtCompoundTag Heightmaps;
        public int[] Biomes; // Not present if full chunk is false. 
        public int Size; // varint
        public byte[] Data;
        public int BlockEntitiesCount;
        public NbtCompoundTag[] BlockEntities;


        public override void Read(byte[] array)
        {
            McInt.TryParse(ref array, out ChunkX); // int 
            McInt.TryParse(ref array, out ChunkZ); // int 
            McBoolean.TryParse(ref array, out Fullchunk); // bool
            McVarint.TryParse(ref array, out PrimaryBitMask); // var int

            var read = new NbtParser();
            Stream stream = new MemoryStream(array);
            Heightmaps = read.ParseNbtStream(stream);
            array = array[(int)(stream.Position)..];

            if (Fullchunk)
            {
                Biomes = new int[1024];
                for (int i = 0; i < 1024; i++)
                {
                    McInt.TryParse(ref array, out Biomes[i]);
                }
            }

            // chunk data
            McVarint.TryParse(ref array, out Size); // size varint
            McByteArray.TryParse(Size, ref array, out Data); // Byte array

            // BlockEntities
            McVarint.TryParse(ref array, out BlockEntitiesCount);

            BlockEntities = new NbtCompoundTag[BlockEntitiesCount];

            var read1 = new NbtParser();
            Stream stream1 = new MemoryStream(array);
            for (int i = 0; i < BlockEntitiesCount; i++)
            {
                BlockEntities[i] = read1.ParseNbtStream(stream1);
            }
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"ChunkData X: {ChunkX} Y: {ChunkZ}";
        }
    }
}