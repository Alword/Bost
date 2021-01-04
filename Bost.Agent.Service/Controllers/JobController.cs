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
	public class JobController : ControllerBase
	{
		private readonly IMediator _mediator;

		public JobController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpPost("breakBlock")]
		public Task<Unit> Create(BreakBlockCommand createAgentQuery, CancellationToken cancellationToken)
		{
			return _mediator.Send(createAgentQuery, cancellationToken);
		}
		
		[HttpPost("ReachTarget")]
		public Task<Unit> Create(ReachTargetPointJobCommand target, CancellationToken cancellationToken)
		{
			return _mediator.Send(target, cancellationToken);
		}
	}
}
