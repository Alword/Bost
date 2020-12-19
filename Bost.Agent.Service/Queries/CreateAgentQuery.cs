using MediatR;
using System;

namespace Bost.Agent.Service.Queries
{
	public class CreateAgentQuery : IRequest<Guid>
	{
		public string? ServerIp { get; set; }
		public ushort ServerPort { get; set; }
		public string? NickName { get; set; }
	}
}
