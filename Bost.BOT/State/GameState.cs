using Bost.Agent.Model;
using Bost.Agent.Model.PlayerContext;
using System.Collections.Generic;

namespace Bost.Agent.State
{
    public class GameState
    {
        public Player Bot { get; private set; }
        public World World { get; private set; }
        public Dictionary<int, Transform> Entitys { get; private set; }
        public Players Players { get; private set; }
        public GameState()
        {
            World = new World();
            Bot = new Player();
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
