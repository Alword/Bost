using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Mapping
{
    public class ChunkColumn
    {
        public const int SizeX = 16;
        public const int SizeY = 256;
        public const int SizeZ = 16;

        List<ChunkSection> chunkSections = new List<ChunkSection>(SizeY / ChunkSection.SizeY);

        public void Parse(ref byte[] data, int PrimaryBitMask)
        {
            chunkSections = new List<ChunkSection>();
            for (int sectionY = 0; sectionY < (ChunkColumn.SizeY / ChunkSection.SizeY); sectionY++)
            {
                if ((PrimaryBitMask & (1 << sectionY)) != 0)
                {
                    var chunkSection = new ChunkSection();
                    chunkSection.Parse(ref data);
                    chunkSections.Add(chunkSection);
                }
            }
        }
    }
}
