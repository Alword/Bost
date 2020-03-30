using McAI.Proto.Commands.Client;
using System.Collections.Generic;

namespace McAI.Proto.Commands
{
    public class ClientParser
    {
        public readonly Dictionary<int, Command> Commands;
        public ClientParser()
        {
            Commands = new Dictionary<int, Command>
            {

            };
        }
    }
}
