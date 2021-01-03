using Bost.Agent.Model;
using Bost.Agent.Service.Commands;
using Bost.Proto.Packet.Play.Serverbound;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bost.Agent.Service.Handlers
{
	public class PlayerDiggingCommandHandler : IRequestHandler<PlayerDiggingCommand>
	{
		private readonly IAgentHub _agentHub;

		public PlayerDiggingCommandHandler(IAgentHub agentHub)
		{
			_agentHub = agentHub;
		}

		public Task<Unit> Handle(PlayerDiggingCommand request, CancellationToken cancellationToken)
		{
			var agent = _agentHub[request.AgentId];
			PlayerDiggingPacket playerDigging = new PlayerDiggingPacket()
			{
				Face = request.Face,
				Location = request.Location,
				Status = request.Status
			};
			return agent.Send(playerDigging).ContinueWith((e) => Unit.Value);
		}
	}
}
