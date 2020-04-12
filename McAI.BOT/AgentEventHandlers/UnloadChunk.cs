using McAI.BOT.Model;
using McAI.BOT.Types;
using McAI.Proto.Mapping;
using McAI.Proto.Packet;
using McAI.Proto.Packet.Play.Clientbound;
using McAI.Proto.StreamReader.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.BOT.AgentEventHandlers
{
    public class UnloadChunk : BaseAgentEvent
    {
        private readonly World world;
        public UnloadChunk(Agent agent) : base(agent)
        {
            world = agent.gameState.World;
        }

        public override void OnPacket(PacketKey type, BasePacket packet)
        {
            if (type.PacketId == 0x1E)
            {
                var data = (UnloadChunkPacket)packet;
                world.Chunks.Remove(new Int2(data.ChunkX, data.ChunkZ));
            }
        }
    }
}
