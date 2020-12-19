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
	public class AgentsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public AgentsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpPost("create")]
		public Task<Guid> Create(CreateAgentQuery createAgentQuery, CancellationToken cancellationToken)
		{
			return _mediator.Send(createAgentQuery, cancellationToken);
		}
	}
}
