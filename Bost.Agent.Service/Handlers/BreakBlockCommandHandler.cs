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
	public class BreakBlockCommandHandler : IRequestHandler<BreakBlockCommand>
	{
		private readonly IAgentHub _agentHub;

		public BreakBlockCommandHandler(IAgentHub agentHub)
		{
			_agentHub = agentHub;
		}
		public Task<Unit> Handle(BreakBlockCommand request, CancellationToken cancellationToken)
		{
			var agent = _agentHub[request.AgentId];

			BreakBlockJob breakBlockJob = new BreakBlockJob(agent, request.Location);
			breakBlockJob.Handle(cancellationToken);
			return Unit.Task;
		}
	}
}
