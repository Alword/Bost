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

            if (type.PacketId == 0x10)
            {
                var data = (MultiBlockChangePacket)packet;
                foreach (var record in data.Records)
                {
                    Int3 location = new Int3(
                        (record.HorizontalPosition >> 4 & 15) + (data.ChunkX * 16),
                        record.YCoordinate,
                        (record.HorizontalPosition & 15) + (data.ChunkZ * 16));
                    world.SetBlockId(location, new BlockId((uint)record.BlockID));
                }
            }
        }
    }
}
