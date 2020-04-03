using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Mapping
{
    public class Chunk
    {
        public const int SizeX = 16;
        public const int SizeY = 256;
        public const int SizeZ = 16;


        private readonly Block[,,] blocks = new Block[SizeX, SizeY, SizeZ];

        public Block this[int X, int Y, int Z]
        {
            get
            {
                if (X < 0 || X >= SizeX)
                    throw new ArgumentOutOfRangeException("blockX", "Must be between 0 and " + (SizeX - 1) + " (inclusive)");
                if (Y < 0 || Y >= SizeY)
                    throw new ArgumentOutOfRangeException("blockY", "Must be between 0 and " + (SizeY - 1) + " (inclusive)");
                if (Z < 0 || Z >= SizeZ)
                    throw new ArgumentOutOfRangeException("blockZ", "Must be between 0 and " + (SizeZ - 1) + " (inclusive)");
                return blocks[X, Y, Z];
            }
            set
            {
                if (X < 0 || X >= SizeX)
                    throw new ArgumentOutOfRangeException("blockX", "Must be between 0 and " + (SizeX - 1) + " (inclusive)");
                if (Y < 0 || Y >= SizeY)
                    throw new ArgumentOutOfRangeException("blockY", "Must be between 0 and " + (SizeY - 1) + " (inclusive)");
                if (Z < 0 || Z >= SizeZ)
                    throw new ArgumentOutOfRangeException("blockZ", "Must be between 0 and " + (SizeZ - 1) + " (inclusive)");
                blocks[X, Y, Z] = value;
            }
        }

        /// <summary>
        /// Get block at the specified location
        /// </summary>
        /// <param name="location">Location, a modulo will be applied</param>
        /// <returns>The block</returns>
        public Block GetBlock(Location location)
        {
            return this[location.ChunkBlockX, location.ChunkBlockY, location.ChunkBlockZ];
        }
    }
}
