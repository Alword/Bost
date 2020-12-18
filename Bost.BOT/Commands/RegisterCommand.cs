using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bost.Agent.Commands
{
	public class RegisterCommand : BaseAgentCommand<string>
	{
		public RegisterCommand(Agent agent) : base(agent)
		{
		}

		public override void Handle(string value)
		{
			
		}
	}
}
