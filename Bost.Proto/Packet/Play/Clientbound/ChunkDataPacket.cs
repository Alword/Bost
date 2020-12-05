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
		public int BlockEntitiesCount;
		public NbtCompoundTag[] BlockEntities;

		public override void Read(byte[] array)
		{
			_ = McInt.TryParse(ref array, out ChunkX); // int 
			_ = McInt.TryParse(ref array, out ChunkZ); // int 
			_ = McBoolean.TryParse(ref array, out Fullchunk); // bool
			_ = McVarint.TryParse(ref array, out PrimaryBitMask); // var int

			_ = McNbtCompoundTag.TryParse(ref array, out Heightmaps);

			if (Fullchunk)
			{
				Biomes = new int[1024];
				for (int i = 0; i < 1024; i++)
				{
					_ = McInt.TryParse(ref array, out Biomes[i]);
				}
			}

			// chunk data
			_ = McVarint.TryParse(ref array, out Size); // size varint
			_ = McByteArray.TryParse(Size, ref array, out Data); // Byte array

			// BlockEntities
			_ = McVarint.TryParse(ref array, out BlockEntitiesCount);

			BlockEntities = new NbtCompoundTag[BlockEntitiesCount];

			for (int i = 0; i < BlockEntitiesCount; i++)
			{
				_ = McNbtCompoundTag.TryParse(ref array, out var result);
				BlockEntities[i] = result;
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