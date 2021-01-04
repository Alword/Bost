using MediatR;
using System;

namespace Bost.Agent.Service.Commands
{
	public class BaseAgentCommand : IRequest
	{
		public Guid AgentId { get; set; }
	}
}
