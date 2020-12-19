using System.Collections.Generic;

namespace Bost.Proto.Mapping
{
	public class ChunkColumn
	{
		public const int SizeX = 16;
		public const int SizeY = 256;
		public const int SizeZ = 16;

		Dictionary<int, ChunkSection> chunkSections;

		public ChunkSection this[int y]
		{
			get {
				if (chunkSections.ContainsKey(y))
				{
					return chunkSections[y];
				}
				else
				{
					return null;
				}
			}
		}

		public void Parse(ref byte[] data, int PrimaryBitMask)
		{
			chunkSections = new Dictionary<int, ChunkSection>(SizeY / ChunkSection.SizeY);
			for (int sectionY = 0; sectionY < (ChunkColumn.SizeY / ChunkSection.SizeY); sectionY++)
			{
				if ((PrimaryBitMask & (1 << sectionY)) != 0)
				{
					var chunkSection = new ChunkSection();
					chunkSection.Parse(ref data);
					chunkSections.Add(sectionY, chunkSection);
				}
			}
		}
	}
}
