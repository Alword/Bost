using McAI.BOT.Model;
using McAI.Proto.Mapping;
using McAI.Proto.Packet;
using McAI.Proto.Packet.Play.Clientbound;
using McAI.Proto.StreamReader.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.BOT.AgentEventHandlers
{
    public class BlockChangeUpdate : BaseAgentEvent
    {
        private readonly World world;
        public BlockChangeUpdate(Agent agent) : base(agent)
        {
            world = agent.gameState.World;
        }

        public override void OnPacket(PacketKey type, BasePacket packet)
        {
            if (type.PacketId == 0x0C)
            {
                var data = (BlockChangePacket)packet;
                Int3 location = new Int3(data.Location.X, data.Location.Y, data.Location.Z);
                world.SetBlockId(location, new BlockId((uint)data.BlocID));
            }
        }
    }
}
