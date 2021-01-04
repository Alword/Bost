using Bost.Agent.Model;
using Bost.Agent.Model.PlayerContext;
using Bost.Proto.Packet.Play.Clientbound;
using System.Collections.Generic;

namespace Bost.Agent.PacketHandlers.Clientbound
{
	public class SpawnPlayerHandler : BaseAgentEventHandler<SpawnPlayerPacket>
	{

		private readonly Players players;
		private readonly Dictionary<int, Transform> Entitys;
		public SpawnPlayerHandler(Agent agent) : base(agent)
		{
			Entitys = agent.SharedState.Entitys;
			players = agent.SharedState.Players;
		}

		public override void OnPacket(SpawnPlayerPacket data)
		{
			players.Link(data.EntityID, data.PlayerUUID);

			bool isExist = Entitys.ContainsKey(data.EntityID);

			Transform transform;
			if (isExist)
				transform = Entitys[data.EntityID];
			else
				transform = new Transform();

			transform.Position.X = data.X;
			transform.Position.Y = data.Y;
			transform.Position.Z = data.Z;
			transform.Rotation.Yaw = data.Yaw;
			transform.Rotation.Pitch = data.Pitch;

			if (!isExist)
				Entitys.Add(data.EntityID, transform);
		}
	}
}
