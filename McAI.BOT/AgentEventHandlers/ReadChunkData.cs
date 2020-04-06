using McAI.Proto.Mapping;
using McAI.Proto.Mapping.Palettes;
using McAI.Proto.Packet;
using McAI.Proto.Packet.Play.Clientbound;
using McAI.Proto.StreamReader.Abstractions;
using McAI.Proto.StreamReader.Model;
using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace McAI.BOT.AgentEventHandlers
{
    public class ReadChunkData : BaseAgentEvent
    {
        public ReadChunkData(Agent agent) : base(agent) { }

        public override void OnPacket(PacketKey type, BasePacket packet)
        {
            var chunkData = (ChunkDataPacket)packet;
            byte[] data = chunkData.Data;
            ChunkColumn chunkColumn = new ChunkColumn();
            chunkColumn.Parse(ref data, chunkData.PrimaryBitMask);

            agent.gameState.World.Chunks.Add((chunkData.ChunkX, chunkData.ChunkZ), chunkColumn);
        }

    }
}
