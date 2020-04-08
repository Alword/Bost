using McAI.BOT.Model;
using McAI.BOT.Types;
using McAI.Proto.Mapping;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace McAI.BOT.Extentions
{
    public static class Vector3Extentions
    {
        public static Int3 GetChunk(this Double3 location)
        {
            int x = (int)Math.Floor(location.X / ChunkColumn.SizeX);
            int y = (int)Math.Floor(location.Y / ChunkSection.SizeX);
            int z = (int)Math.Floor(location.Z / ChunkColumn.SizeX);
            return new Int3(x, y, z);
        }

        public static Int3 GetChunk(this Int3 location)
        {
            int x = (location.X / ChunkColumn.SizeX);
            int y = (location.Y / ChunkSection.SizeX);
            int z = (location.Z / ChunkColumn.SizeX);
            return new Int3(x, y, z);
        }

        public static Int3 InChunkBlock(this Double3 location)
        {
            int x = (int)Math.Floor(location.X % ChunkColumn.SizeX);
            int y = (int)Math.Floor(location.Y % ChunkSection.SizeX);
            int z = (int)Math.Floor(location.Z % ChunkColumn.SizeX);
            return new Int3(x, y, z);
        }

        public static Int3 InChunkBlock(this Int3 location)
        {
            int x = Math.Abs(location.X % ChunkColumn.SizeX);
            int y = Math.Abs(location.Y % ChunkSection.SizeY);
            int z = Math.Abs(location.Z % ChunkColumn.SizeZ);
            return new Int3(x, y, z);
        }

        public static Int3 Floor(this Double3 location)
        {
            int x = (int)Math.Floor(location.X);
            int y = (int)Math.Floor(location.Y);
            int z = (int)Math.Floor(location.Z);
            return new Int3(x, y, z);
        }
    }
}
