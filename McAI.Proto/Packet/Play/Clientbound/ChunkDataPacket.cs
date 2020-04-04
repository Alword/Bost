using McAI.Proto.Mapping;
using McAI.Proto.Mapping.Palettes;
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
            List<ChunkSection> chunkSections = new List<ChunkSection>();
            var data = Data;
            for (int sectionY = 0; sectionY < (Chunk.SizeY / ChunkSection.SizeY); sectionY++)
            {
                if ((PrimaryBitMask & (1 << sectionY)) != 0)
                {
                    McShort.TryParse(ref data, out short NonAirBlocksCount);
                    McUnsignedByte.TryParse(ref data, out byte bitsPerBlock);
                    IPalette palette = Palette.ChoosePalette(bitsPerBlock);
                    palette.Read(data);


                    // A bitmask that contains bitsPerBlock set bits
                    uint valueMask = (uint)((1 << bitsPerBlock) - 1);

                    McVarint.TryParse(ref data, out int dataArrayLength);
                    McULongArray.TryParse(ref data, dataArrayLength, out ulong[] dataArray);

                    ChunkSection section = new ChunkSection();

                    // теория струнь
                    List<byte> array = new List<byte>();

                    for (int blockY = 0; blockY < Chunk.SizeY; blockY++)
                    {
                        for (int blockZ = 0; blockZ < Chunk.SizeZ; blockZ++)
                        {
                            for (int blockX = 0; blockX < Chunk.SizeX; blockX++)
                            {
                                

                                //BlockState state = palette.StateForId(blockId);
                                section.SetState(blockX, blockY, blockZ, new BlockState());
                            }
                        }
                    }

                    for (int y = 0; y < ChunkSection.SizeY; y++)
                    {
                        for (int z = 0; z < ChunkSection.SizeZ; z++)
                        {
                            for (int x = 0; x < ChunkSection.SizeX; x += 2)
                            {
                                // Note: x += 2 above; we read 2 values along x each time
                                McUnsignedByte.TryParse(ref data, out byte value);

                                section.SetBlockLight(x, y, z, value & 0xF);
                                section.SetBlockLight(x + 1, y, z, (value >> 4) & 0xF);
                            }
                        }
                    }

                    //if (currentDimension.HasSkylight())
                    //{ // IE, current dimension is overworld / 0
                    //    for (int y = 0; y < SECTION_HEIGHT; y++)
                    //    {
                    //        for (int z = 0; z < SECTION_WIDTH; z++)
                    //        {
                    //            for (int x = 0; x < SECTION_WIDTH; x += 2)
                    //            {
                    //                // Note: x += 2 above; we read 2 values along x each time
                    //                byte value = ReadByte(data);

                    //                section.SetSkyLight(x, y, z, value & 0xF);
                    //                section.SetSkyLight(x + 1, y, z, (value >> 4) & 0xF);
                    //            }
                    //        }
                    //    }
                    //}

                    // May replace an existing section or a null one
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
