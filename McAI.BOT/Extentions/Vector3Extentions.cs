using McAI.BOT.Model;
using McAI.BOT.Types;
using McAI.Proto.Mapping;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace McAI.BOT.Extentions
{
    public static class Vector3Extentions
    {
        public static Int3 GetChunk(this Double3 location)
        {
            int x = (int)Math.Floor(location.X / ChunkSection.SizeX);
            int y = (int)Math.Floor(location.Y / ChunkSection.SizeX);
            int z = (int)Math.Floor(location.Z / ChunkSection.SizeX);
            return new Int3(x, y, z);
        }

        public static Int3 GetChunk(this Int3 location)
        {
            if (location.X < 0)
                location.X -= 1;
            if (location.Y < 0)
                location.Y -= 1;

            int x = (location.X / ChunkSection.SizeX);
            int y = (location.Y / ChunkSection.SizeY);
            int z = (location.Z / ChunkSection.SizeZ);
            return new Int3(x, y, z);
        }

        public static Int3 InChunkBlock(this Double3 location)
        {
            int x = (int)Math.Floor(location.X % ChunkSection.SizeX);
            int y = (int)Math.Floor(location.Y % ChunkSection.SizeX);
            int z = (int)Math.Floor(location.Z % ChunkSection.SizeX);
            return new Int3(x, y, z);
        }

        public static Int3 InChunkBlock(this Int3 location)
        {
            int x = Math.Abs(location.X % ChunkSection.SizeX);
            int y = Math.Abs(location.Y % ChunkSection.SizeY);
            int z = Math.Abs(location.Z % ChunkSection.SizeZ);
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
