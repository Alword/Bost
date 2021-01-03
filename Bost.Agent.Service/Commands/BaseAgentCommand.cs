using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bost.Agent.Service.Commands
{
	public class BaseAgentCommand : IRequest
	{
		public Guid AgentId { get; set; }
	}
}
