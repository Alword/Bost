using McAI.Proto.Packet;
using McAI.Proto.Packet.Play.Clientbound;
using McAI.Proto.StreamReader.Abstractions;
using McAI.Proto.StreamReader.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.BOT.AgentEventHandlers
{
    public class ReadChunkData : BaseAgentEvent
    {
        public ReadChunkData(Agent agent) : base(agent) { }

        public override void OnPacket(PacketKey type, BasePacket packet)
        {
            var chunkData = (ChunkDataPacket)packet;
            //var positions = chunkData.GetHeightmapsPositions();
        }
    }
}
