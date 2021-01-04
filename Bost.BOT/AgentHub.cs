using Bost.Agent.Missions;
using Bost.Agent.Server;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bost.Agent.Model
{
	/// <summary>
	/// Сборник всех агентов. Начальная точка вызова библиотеки. Как правило Singleton на службу.
	/// </summary>
	public class AgentHub : IAgentHub
	{
		private readonly ServersHub _serversHub;
		private readonly Dictionary<Guid, Agent> agents;
		public AgentHub()
		{
			agents = new Dictionary<Guid, Agent>();
			_serversHub = new ServersHub();
		}

		public Agent this[Guid key] => agents[key];

		public Task<Agent> CreateAgent(string server, ushort port, string nickname)
		{
			var sharedGameSate = _serversHub.Get(server, port);
			var agent = new Agent(server, port, nickname, sharedGameSate);
			agents.Add(agent.Id, agent);
			return Task.FromResult(agent);
		}

		public void SubmitMission(string server, BaseMission baseMission)
		{
			var sharedState = _serversHub.Get(server);
			sharedState.Missions.AddMission(baseMission);
		}
	}
}
