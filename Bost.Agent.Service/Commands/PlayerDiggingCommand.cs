using Bost.Proto.Enum;
using Bost.Proto.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
