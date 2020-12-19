using Bost.Agent.Service.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
		public Task<Unit> SendMessage(PlayerDiggingCommand command, CancellationToken cancellationToken)
		{
			return _mediator.Send(command, cancellationToken);
		}

		[HttpPost("ChatMessage")]
		public Task<Unit> SendMessage(ChatMessageCommand command, CancellationToken cancellationToken)
		{
			return _mediator.Send(command, cancellationToken);
		}
		[HttpPost("Animation")]
		public Task<Unit> SendMessage(HandAnimationCommand command, CancellationToken cancellationToken)
		{
			return _mediator.Send(command, cancellationToken);
		}
	}
}
