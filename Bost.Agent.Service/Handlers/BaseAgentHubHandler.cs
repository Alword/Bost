using Bost.Agent.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bost.Agent.Service.Handlers
{
	public abstract class BaseAgentHubHandler<TRequest> : IRequestHandler<TRequest> where TRequest : IRequest<Unit>
	{
		protected readonly IAgentHub _agentHub;
		public BaseAgentHubHandler(IAgentHub agentHub)
		{
			_agentHub = agentHub;
		}
		public abstract Task<Unit> Handle(TRequest request, CancellationToken cancellationToken);
	}
}
