using Bost.Agent.Enum;
using Bost.Agent.Model;
using MediatR;
using System;

namespace Bost.Agent.Service.Commands
{
	public class MiningCommand : IRequest
	{
		public Guid AgentId { get; set; }
		public MiningMode Mode { get; set; }
		public Int3 Start { get; set; }
		public Int3 End { get; set; }
	}
}
