using McAI.Proto.Enum;

namespace McAI.Proto
{
    public class GameState
    {
        public GameStates ClientState { get; set; }
        public GameStates ServerState { get; set; }

        public GameState()
        {
            ClientState = GameStates.Login;
            ServerState = GameStates.Login;
        }

    }
}
