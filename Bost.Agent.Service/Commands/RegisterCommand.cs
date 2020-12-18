using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bost.Agent.Service.Commands
{
	public class RegisterCommand : IRequest
	{
		public Guid AgentId { get; set; }
		public string? Password { get; set; }
	}
}
