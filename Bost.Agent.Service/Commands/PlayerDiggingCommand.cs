using Bost.Proto.Enum;
using Bost.Proto.Model;
using MediatR;
using System;

namespace Bost.Agent.Service.Commands
{
	public class PlayerDiggingCommand : IRequest
	{
		public Guid AgentId { get; set; }
		public PlayerDiggingStatus Status { get; set; }
		public Position Location { get; set; }
		public Face Face { get; set; }
	}
}
