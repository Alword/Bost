using Bost.Agent.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bost.Agent.Service.Commands
{
	public class ReachTargetPointJobCommand : BaseAgentCommand
	{
		public Double3 To { get; set; }
		public int SkipFromEnd { get; set; }
	}
}
