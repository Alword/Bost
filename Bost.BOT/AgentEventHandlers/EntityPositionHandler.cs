using Bost.Agent.Model;
using Bost.Proto.Packet.Play.Clientbound;
using System.Collections.Generic;

namespace Bost.Agent.AgentEventHandlers
{
    public class EntityPositionHandler : BaseAgentEventHandler<EntityPositionPacket>
    {
        private readonly Dictionary<int, Transform> Entitys;

        public EntityPositionHandler(Agent agent) : base(agent)
        {
            Entitys = agent.gameState.Entitys;
        }

        public override void OnPacket(EntityPositionPacket data)
        {
            if (Entitys.ContainsKey(data.EntityID))
            {
                Transform transform = Entitys[data.EntityID];
                transform.Position.X = (transform.Position.X * 4096 + data.DeltaX) / 4096;
                transform.Position.Y = (transform.Position.Y * 4096 + data.DeltaY) / 4096;
                transform.Position.Z = (transform.Position.Z * 4096 + data.DeltaZ) / 4096;
                transform.OnGround = data.OnGround;
            }
        }
    }
}
