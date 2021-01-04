using Bost.Agent.Jobs;
using Bost.Agent.Model;
using Bost.Agent.Service.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bost.Agent.Service.Handlers
{
	public class ReachTargetPointHandler : BaseAgentHubHandler<ReachTargetPointJobCommand>
	{
		public ReachTargetPointHandler(IAgentHub agentHub) : base(agentHub)
		{
		}

		public override Task<Unit> Handle(ReachTargetPointJobCommand request, CancellationToken cancellationToken)
		{
			var agent = _agentHub[request.AgentId];
			new ReachTargetPointJob(agent, request.To, request.SkipFromEnd).Handle(cancellationToken);
			return Unit.Task;
		}
	}
}
