using Bost.Agent.Model;
using Bost.Proto.Packet.Play.Clientbound;
using System.Collections.Generic;

namespace Bost.Agent.AgentEventHandlers
{
    public class EntityPositionAndRotationHandler : BaseAgentEventHandler<EntityPositionAndRotationPacket>
    {
        private readonly Dictionary<int, Transform> Entitys;

        public EntityPositionAndRotationHandler(Agent agent) : base(agent)
        {
            Entitys = agent.gameState.Entitys;
        }

        public override void OnPacket(EntityPositionAndRotationPacket data)
        {
            if (Entitys.ContainsKey(data.EntityId))
            {
                Transform transform = Entitys[data.EntityId];
                transform.Position.X = (transform.Position.X * 4096 + data.DeltaX) / 4096;
                transform.Position.Y = (transform.Position.Y * 4096 + data.DeltaY) / 4096;
                transform.Position.Z = (transform.Position.Z * 4096 + data.DeltaZ) / 4096;
                transform.Rotation.Yaw = data.Yaw;
                transform.Rotation.Pitch = data.Pitch;
                transform.OnGround = data.OnGround;
            }
        }
    }
}
