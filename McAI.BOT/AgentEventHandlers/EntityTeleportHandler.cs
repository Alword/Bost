using McAI.BOT.Model;
using McAI.Proto.Packet.Play.Clientbound;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.BOT.AgentEventHandlers
{
    public class EntityTeleportHandler : BaseAgentEventHandler<EntityTeleportPacket>
    {
        private readonly Dictionary<int, Transform> Entitys;

        public EntityTeleportHandler(Agent agent) : base(agent)
        {
            Entitys = agent.gameState.Entitys;
        }

        public override void OnPacket(EntityTeleportPacket packet)
        {
            if (Entitys.ContainsKey(packet.EntityId))
            {
                Transform transform = Entitys[packet.EntityId];
                transform.Position.X = packet.X;
                transform.Position.Y = packet.Y;
                transform.Position.Z = packet.Z;
                transform.Rotation.Yaw = packet.Yaw;
                transform.Rotation.Pitch = packet.Pitch;
                transform.OnGround = packet.OnGround;
            }
        }
    }
}
