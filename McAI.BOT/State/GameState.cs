using McAI.BOT.Model;
using McAI.BOT.Model.PlayerContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.BOT.State
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
