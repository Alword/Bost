using Bost.Agent.Missions;
using System.Collections.Generic;
using System.Linq;

namespace Bost.Agent.Server
{
	public class MissionControl
	{
		private readonly List<IAgent> _agents;

		private readonly List<BaseMission> _missions;

		public MissionControl()
		{
			_agents = new List<IAgent>();
			_missions = new List<BaseMission>();
		}

		public void Attach(IAgent agent)
		{
			_agents.Add(agent);
			var mission = _missions.FirstOrDefault();
			if (mission != null) mission.SendJob(agent);
		}

		public void Detach(IAgent agent)
		{
			_agents.Remove(agent);
		}

		public void AddMission(BaseMission baseMission)
		{
			_missions.Add(baseMission);
			foreach (var agent in _agents.ToArray())
			{
				Detach(agent);
				baseMission.SendJob(agent);
			}
		}
	}
}
