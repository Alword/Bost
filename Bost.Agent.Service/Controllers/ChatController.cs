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
	[Route("api/[controller]")]
	[ApiController]
	public class ChatController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ChatController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("message")]
		public Task<Unit> SendMessage(ChatMessageCommand chatMessage, CancellationToken cancellationToken)
		{
			return _mediator.Send(chatMessage, cancellationToken);
		}
	}
}
