using MediatR;
using System;

namespace Bost.Agent.Service.Commands
{
	public class ChatMessageCommand : IRequest
	{
		public Guid AgentId { get; set; }
		public string? Message { get; set; }
	}
}
