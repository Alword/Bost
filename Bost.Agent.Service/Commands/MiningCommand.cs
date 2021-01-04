using Bost.Agent.Enum;
using Bost.Agent.Model;
using MediatR;

namespace Bost.Agent.Service.Commands
{
	public class MiningCommand : IRequest
	{
		public string? Server { get; set; }
		public MiningMode Mode { get; set; }
		public Int3 Start { get; set; }
		public Int3 End { get; set; }
	}
}
