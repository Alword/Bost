using McAI.BOT.Model;
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
        public GameState()
        {
            World = new World();
            Bot = new Player();
            Entitys = new Dictionary<int, Transform>();
        }
    }
}
