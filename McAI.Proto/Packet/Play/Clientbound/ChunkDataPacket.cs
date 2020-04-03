using McAI.Proto.Mapping;
using McAI.Proto.Types;
using NbtLib;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;

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
            McInt.TryParse(ref array, out ChunkX);
            McInt.TryParse(ref array, out ChunkZ);
            McBoolean.TryParse(ref array, out Fullchunk);
            McVarint.TryParse(ref array, out PrimaryBitMask);
            
            // heightmap
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
            McVarint.TryParse(ref array, out Size);
            McByteArray.TryParse(Size, ref array, out Data);


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

        public ChunkSection[] ReadChunkColumn()
        {
            //for (int sectionY = 0; sectionY < (Chunk.SizeY / ChunkSection.SizeY); y++)
            //{
            //    if ((PrimaryBitMask & (1 << sectionY)) != 0)
            //    {  // Is the given bit set in the mask?
            //        byte bitsPerBlock = ReadByte(data);
            //        Palette palette = ChoosePalette(bitsPerBlock);
            //        palette.Read(data);
            //    }
            //}
            throw new NotImplementedException();
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
