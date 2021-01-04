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
			if (mission != null)
			{
				StartMission(agent, mission);
			}
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
				StartMission(agent, baseMission);
			}
		}

		private void StartMission(IAgent agent, BaseMission mission)
		{
			Detach(agent);
			bool hasNext = mission.SendJob(agent);
			if (!hasNext) _missions.Remove(mission);
		}
	}
}
