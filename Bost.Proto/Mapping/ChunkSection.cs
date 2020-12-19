﻿using Bost.Proto.Mapping.Palettes;
using Bost.Proto.Types;

namespace Bost.Proto.Mapping
{
	public class ChunkSection
	{
		public const int SizeX = 16;
		public const int SizeY = 16;
		public const int SizeZ = 16;

		public IPalette palette; // palette

		public BlockId[,,] blockIds = new BlockId[16, 16, 16];

		public void Parse(ref byte[] data)
		{
			McShort.TryParse(ref data, out short NonAirBlocksCount); // short
			McUnsignedByte.TryParse(ref data, out byte bitsPerBlock); // byte

			IPalette palette = Palette.ChoosePalette(bitsPerBlock);
			palette.Read(ref data);
			uint individualValueMask = (uint)((1 << bitsPerBlock) - 1);

			McVarint.TryParse(ref data, out int dataArrayLength);
			McULongArray.TryParse(ref data, dataArrayLength, out ulong[] dataArray);


			//Parallel.For(0, SizeY, (y) =>
			for (int y = 0; y < SizeY; y++)
			{
				for (int z = 0; z < SizeZ; z++)
				{
					for (int x = 0; x < SizeX; x++)
					{
						int blockNumber = (((y * SizeY) + z) * SizeZ) + x;
						int startLong = blockNumber / (64 / bitsPerBlock);
						int startOffset = (blockNumber - startLong * (64 / bitsPerBlock)) * bitsPerBlock;

						uint intData;
						intData = (uint)(dataArray[startLong] >> startOffset);

						intData &= individualValueMask;

						BlockId state = new BlockId(palette.StateForId(intData).Id);
						SetState(x, y, z, state);
					}
				}
			}
			//});
		}

		public void SetState(int x, int y, int z, BlockId state)
		{
			blockIds[x, y, z] = state;
		}

		public BlockId GetBlock(int x, int y, int z)
		{
			return blockIds[x, y, z];
		}

		public void SetBlockLight(int x, int y, int z, int v)
		{
			// Debug.WriteLine($"Set light {x} {y} {z} {v}");
			// throw new NotImplementedException();
		}
	}
}
