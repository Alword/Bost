using Bost.Agent.Service.Commands;
using Bost.Agent.Service.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bost.Agent.Service.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class MissionController : ControllerBase
	{
		private readonly IMediator _mediator;

		public MissionController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("Mine")]
		public Task<Unit> Create(MiningCommand mining, CancellationToken cancellationToken)
		{
			return _mediator.Send(mining, cancellationToken);
		}
	}
}
