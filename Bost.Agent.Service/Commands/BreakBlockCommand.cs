using Bost.Agent.Model;
using Bost.Proto.Model;
using MediatR;
using System;

namespace Bost.Agent.Service.Commands
{
	public class BreakBlockCommand : IRequest
	{
		public Guid AgentId { get; set; }
		public Int3 Location { get; set; }
	}
}
