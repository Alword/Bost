using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bost.Agent.Commands
{
	public abstract class BaseAgentCommand<T>
	{
		public Agent Agent { get; }
		public BaseAgentCommand(Agent agent)
		{
			Agent = agent;
		}
		public abstract void Handle(T value);
	}
}
