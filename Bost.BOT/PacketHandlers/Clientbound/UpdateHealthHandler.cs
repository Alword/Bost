﻿using Bost.Proto.Enum;
using Bost.Proto.Packet.Play.Clientbound;
using Bost.Proto.Packet.Play.Serverbound;

namespace Bost.Agent.PacketHandlers.Clientbound
{
	public class UpdateHealthHandler : BaseAgentEventHandler<UpdateHealthPacket>
	{
		public UpdateHealthHandler(Agent agent) : base(agent) { }

		public override async void OnPacket(UpdateHealthPacket health)
		{
			if (health.Health <= 0)
			{
				var clientStatus = new ClientStatusPacket
				{
					ActionID = ClientStatusActions.PerformPespawn
				};

				await agent.Send(clientStatus);
			}

		}
	}
}
