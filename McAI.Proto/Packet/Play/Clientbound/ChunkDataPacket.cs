using McAI.Proto.Mapping;
using McAI.Proto.Mapping.Palettes;
using McAI.Proto.Types;
using NbtLib;
using System;
using System.Collections.Generic;
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

        public ChunkSection[] ReadChunkColumn()
        {
            byte[] data = new byte[Data.Length];
            Array.Copy(Data, data, data.Length);
            List<ChunkSection> chunkSections = new List<ChunkSection>();
            for (int sectionY = 0; sectionY < (Chunk.SizeY / ChunkSection.SizeY); sectionY++)
            {
                if ((PrimaryBitMask & (1 << sectionY)) != 0)
                {
                    McShort.TryParse(ref data, out short NonAirBlocksCount); // short
                    McUnsignedByte.TryParse(ref data, out byte bitsPerBlock); // byte

                    IPalette palette = Palette.ChoosePalette(bitsPerBlock);
                    palette.Read(ref data);
                    ChunkSection section = new ChunkSection();
                    uint individualValueMask = (uint)((1 << bitsPerBlock) - 1);

                    McVarint.TryParse(ref data, out int dataArrayLength);
                    McULongArray.TryParse(ref data, dataArrayLength, out ulong[] dataArray);


                    for (int y = 0; y < ChunkSection.SizeY; y++)
                    {
                        for (int z = 0; z < ChunkSection.SizeZ; z++)
                        {
                            for (int x = 0; x < ChunkSection.SizeX; x++)
                            {
                                int blockNumber = (((y * ChunkSection.SizeY) + z) * ChunkSection.SizeZ) + x;
                                int startLong = (blockNumber * bitsPerBlock) / 64;
                                int startOffset = (blockNumber * bitsPerBlock) % 64;
                                int endLong = ((blockNumber + 1) * bitsPerBlock - 1) / 64;

                                uint intData;
                                if (startLong == endLong)
                                {
                                    intData = (uint)(dataArray[startLong] >> startOffset);
                                }
                                else
                                {
                                    int endOffset = 64 - startOffset;
                                    intData = (uint)(dataArray[startLong] >> startOffset | dataArray[endLong] << endOffset);
                                }
                                intData &= individualValueMask;

                                BlockState state = palette.StateForId(intData);
                                section.SetState(x, y, z, state);
                            }
                        }
                    }
                    chunkSections.Add(section);
                }
            }


            return chunkSections.ToArray();
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
