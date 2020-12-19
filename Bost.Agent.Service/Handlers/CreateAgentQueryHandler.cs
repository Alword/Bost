using Bost.Agent.Model;
using Bost.Agent.Service.Queries;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bost.Agent.Service.Handlers
{
	public class CreateAgentQueryHandler : IRequestHandler<CreateAgentQuery, Guid>
	{
		private readonly IAgentHub _agentHub;

		public CreateAgentQueryHandler(IAgentHub agentHub)
		{
			_agentHub = agentHub;
		}

		public async Task<Guid> Handle(CreateAgentQuery request, CancellationToken cancellationToken)
		{
			var createAgentTask = _agentHub.CreateAgent(request.ServerIp, request.ServerPort, request.NickName);

			if (string.IsNullOrWhiteSpace(request.NickName))
				request.NickName = Utils.RandomStringGenerator.RandomString(6, 12);

			var agent = await createAgentTask;
			return agent.Id;
		}
	}
}
