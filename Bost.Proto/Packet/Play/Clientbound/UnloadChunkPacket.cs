using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Clientbound
{
	public class UnloadChunkPacket : BasePacket
	{
		public override int PacketId => 0x1C;
		public int ChunkX;
		public int ChunkZ;

		public override void Read(byte[] array)
		{
			McInt.TryParse(ref array, out ChunkX);
			McInt.TryParse(ref array, out ChunkZ);
		}

		public override byte[] Write()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return $"UnloadChunk ChunkX: {ChunkX} ChunkZ: {ChunkZ}";
		}
	}
}
