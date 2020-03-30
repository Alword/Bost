using McAI.Proto.Commands;
using McAI.Proto.Commands.Client;
using System.Collections.Generic;


namespace McAI.Proto
{
    public class ToClientParser
    {
        public readonly Dictionary<int, Command> LoginCommands;
        public readonly Dictionary<int, Command> GameCommands;
        public ToClientParser(GameState gameState)
        {
            LoginCommands = new Dictionary<int, Command>
            {

            };
            GameCommands = new Dictionary<int, Command>
            {
                
            };
        }
    }
}
