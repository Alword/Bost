using Bost.Agent.Missions;
using Bost.Agent.Model;
using Bost.Agent.Service.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bost.Agent.Service.Handlers
{
	public class MineBlockCommandHandler : BaseAgentHubHandler<MiningCommand>
	{
		public MineBlockCommandHandler(IAgentHub agentHub) : base(agentHub)
		{
		}

		public override Task<Unit> Handle(MiningCommand request, CancellationToken cancellationToken)
		{
			_agentHub.SubmitMission(request.Server, new BlockMiningMission(request.Start, request.End, request.Mode));
			return Unit.Task;
		}
	}
}
