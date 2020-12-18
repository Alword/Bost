using Bost.Agent.Model;
using Bost.Agent.Service.Commands;
using Bost.Proto.Packet.Play.Serverbound;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bost.Agent.Service.Handlers
{
	public class ChatMessageCommandHandler : IRequestHandler<ChatMessageCommand>
	{
		private readonly IAgentHub _agentHub;

		public ChatMessageCommandHandler(IAgentHub agentHub)
		{
			_agentHub = agentHub;
		}

		public Task<Unit> Handle(ChatMessageCommand request, CancellationToken cancellationToken)
		{
			var agent = _agentHub[request.AgentId];
			ChatMessagePacket chanMessagePacket = new ChatMessagePacket()
			{
				Message = request.Message
			};
			return agent.Send(chanMessagePacket).ContinueWith((e) => Unit.Value);
		}
	}
}
