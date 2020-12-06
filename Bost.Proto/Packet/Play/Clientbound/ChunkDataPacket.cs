using Bost.Proto.Types;
using NbtLib;
using System;
using System.IO;

namespace Bost.Proto.Packet.Play.Clientbound
{
	public class ChunkDataPacket : BasePacket
	{
		public override int PacketId => 0x20;

		public int ChunkX; // int
		public int ChunkZ; // int
		public bool Fullchunk;
		public int PrimaryBitMask; // varint
		public NbtCompoundTag Heightmaps;
		public int Biomeslength; //Optional VarInt *
		public int[] Biomes; // Not present if full chunk is false. 
		public int Size; // varint
		public byte[] Data;
		public int NumberOfBlockEntities;
		public NbtCompoundTag[] BlockEntities;

		public override void Read(byte[] array)
		{
			McInt.TryParse(ref array, out ChunkX); // int 
			McInt.TryParse(ref array, out ChunkZ); // int 
			McBoolean.TryParse(ref array, out Fullchunk); // bool
			McVarint.TryParse(ref array, out PrimaryBitMask); // var int

			McNbtCompoundTag.TryParse(ref array, out Heightmaps);

			if (Fullchunk)
			{
				McVarint.TryParse(ref array, out Biomeslength);
				Biomes = new int[Biomeslength];
				for (int i = 0; i < Biomeslength; i++)
				{
					McVarint.TryParse(ref array, out Biomes[i]);
				}
			}

			// chunk data
			McVarint.TryParse(ref array, out Size); // size varint
			McByteArray.TryParse(Size, ref array, out Data); // Byte array

			// BlockEntities
			McVarint.TryParse(ref array, out NumberOfBlockEntities);

			BlockEntities = new NbtCompoundTag[NumberOfBlockEntities];

			var read1 = new NbtParser();
			Stream stream1 = new MemoryStream(array);
			for (int i = 0; i < NumberOfBlockEntities; i++)
			{
				BlockEntities[i] = read1.ParseNbtStream(stream1);
			}
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