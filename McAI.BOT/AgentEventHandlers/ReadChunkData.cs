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

            var PrimaryBitMask = chunkData.PrimaryBitMask;
            byte[] data = new byte[chunkData.Data.Length];
            Array.Copy(chunkData.Data, data, data.Length);
            List<ChunkSection> chunkSections = new List<ChunkSection>();
            for (int sectionY = 0; sectionY < (Chunk.SizeY / ChunkSection.SizeY); sectionY++)
            {
                if ((PrimaryBitMask & (1 << sectionY)) != 0)
                {
                    var chunkSection = new ChunkSection();
                    chunkSection.Parse(ref data);
                    chunkSections.Add(chunkSection);
                }
            }
            chunkSections.ToArray();
        }

    }
}
