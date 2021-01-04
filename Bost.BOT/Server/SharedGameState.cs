using Bost.Agent.Model;
using Bost.Agent.Model.PlayerContext;
using Bost.Agent.Server;
using System.Collections.Generic;

namespace Bost.Agent.GameState
{
	public class SharedGameState
	{
		public World World { get; }
		public MissionControl Missions { get; }
		public Dictionary<int, Transform> Entitys { get; private set; }
		public Players Players { get; private set; }

		public SharedGameState()
		{
			World = new World();
			Missions = new MissionControl();
			Entitys = new Dictionary<int, Transform>();
			Players = new Players();
			Players.OnRemovePlayer += Players_OnRemovePlayer;
			Players.OnLinkPlayer += Players_OnLinkPlayer; ;
		}

		private void Players_OnLinkPlayer(object sender, Player e)
		{
			if (Entitys.ContainsKey(e.CurrentEntityId))
				Entitys.Remove(e.CurrentEntityId);
			Entitys.Add(e.CurrentEntityId, e);
		}

		private void Players_OnRemovePlayer(object sender, Player e)
		{
			if (Entitys.ContainsKey(e.CurrentEntityId))
			{
				Entitys.Remove(e.CurrentEntityId);
			}
		}
	}
}
