using Bost.Proto.Enum;
using MediatR;
using System;

namespace Bost.Agent.Service.Commands
{
	public class HandAnimationCommand : IRequest
	{
		public Guid AgentId { get; set; }
		public HandType Hand { get; set; }
	}
}
