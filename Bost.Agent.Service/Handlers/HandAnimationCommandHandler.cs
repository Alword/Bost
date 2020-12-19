using Bost.Agent.Model;
using Bost.Agent.Service.Commands;
using Bost.Proto.Packet.Play.Serverbound;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bost.Agent.Service.Handlers
{
	public class HandAnimationCommandHandler : IRequestHandler<HandAnimationCommand>
	{
		private readonly IAgentHub _agentHub;

		public HandAnimationCommandHandler(IAgentHub agentHub)
		{
			_agentHub = agentHub;
		}

		public Task<Unit> Handle(HandAnimationCommand request, CancellationToken cancellationToken)
		{
			var agent = _agentHub[request.AgentId];
			AnimationPacket playerDigging = new AnimationPacket()
			{
				Hand = request.Hand
			};
			return agent.Send(playerDigging).ContinueWith((e) => Unit.Value);
		}
	}
}
