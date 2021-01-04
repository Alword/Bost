using Bost.Agent.Model;
using Bost.Agent.Types;
using Bost.Proto.Mapping;
using Bost.Proto.Packet.Play.Clientbound;
using System;
using System.IO;

namespace Bost.Agent.AgentEventHandlers
{
	public class ChunkDataHandler : BaseAgentEventHandler<ChunkDataPacket>
	{
		private readonly World world;
		public ChunkDataHandler(Agent agent) : base(agent)
		{
			world = agent.SharedState.World;
		}

		public override void OnPacket(ChunkDataPacket chunkData)
		{
			byte[] data = chunkData.Data;
			var chunkId = new Int2(chunkData.ChunkX, chunkData.ChunkZ);
			ChunkColumn chunkColumn;

			if (chunkData.Fullchunk)
			{
				chunkColumn = new ChunkColumn();
			}
			else
			{
				chunkColumn = world.Chunks[chunkId];
			}
			try
			{
				chunkColumn.Parse(ref data, chunkData.PrimaryBitMask);
			}
			catch (Exception e)
			{
				var guid = Guid.NewGuid();
				Console.WriteLine($"Error: Chunk column read error on chunk {guid}) with {e.StackTrace}");
				File.WriteAllText($"{guid}.txt", Convert.ToBase64String(chunkData.Data));
			}

			lock (chunkData)
			{
				if (chunkData.Fullchunk)
				{
					if (world.Chunks.ContainsKey(chunkId))
					{
						world.Chunks.Remove(chunkId);
					}
					world.Chunks.Add(chunkId, chunkColumn);
				}
			}
		}

	}
}
