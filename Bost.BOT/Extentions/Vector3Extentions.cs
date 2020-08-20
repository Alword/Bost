using Bost.BOT.Model;
using Bost.BOT.Types;
using Bost.Proto.Mapping;
using System;

namespace Bost.BOT.Extentions
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

            int x = (location.X / ChunkSection.SizeX);
            int y = (location.Y / ChunkSection.SizeY);
            int z = (location.Z / ChunkSection.SizeZ);
            if (location.X % ChunkSection.SizeX < 0)
                x -= 1;
            if (location.Z % ChunkSection.SizeZ < 0)
                z -= 1;
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
            int x = location.X % ChunkSection.SizeX;
            if (x < 0)
                x = ChunkSection.SizeX + x;
            int y = location.Y % ChunkSection.SizeY;
            int z = location.Z % ChunkSection.SizeZ;
            if (z < 0)
                z = ChunkSection.SizeZ + z;
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
