using Bost.Agent.Jobs;
using Bost.Agent.Model;
using Bost.Agent.Service.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
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
			var agent = _agentHub[request.AgentId];

			new MiningJob(agent,request.Start).Handle(cancellationToken);

			return Unit.Task;
		}
	}
}
