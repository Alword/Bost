using Bost.Agent.Service.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bost.Agent.Service.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class PacketsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public PacketsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("PlayerDigging")]
		public Task<Unit> SendMessage(PlayerDiggingCommand chatMessage, CancellationToken cancellationToken)
		{
			return _mediator.Send(chatMessage, cancellationToken);
		}

		[HttpPost("ChatMessage")]
		public Task<Unit> SendMessage(ChatMessageCommand chatMessage, CancellationToken cancellationToken)
		{
			return _mediator.Send(chatMessage, cancellationToken);
		}
	}
}
