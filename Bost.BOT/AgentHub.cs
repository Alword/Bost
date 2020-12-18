using Bost.Agent.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bost.Agent.Model
{
	public class AgentHub : IAgentHub
	{
		private readonly Dictionary<Guid, Agent> agents;
		public AgentHub()
		{
			agents = new Dictionary<Guid, Agent>();
		}

		public Agent this[Guid key] => agents[key];

		public Task<Agent> CreateAgent(string server, ushort port)
		{
			var agent = new Agent(server, port);
			agents.Add(agent.Id, agent);
			return Task.FromResult(agent);
		}
	}
}
