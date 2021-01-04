using Bost.Agent.Types;

namespace Bost.Agent.Service.Commands
{
	public class ReachTargetPointJobCommand : BaseAgentCommand
	{
		public Double3 To { get; set; }
		public int SkipFromEnd { get; set; }
	}
}
