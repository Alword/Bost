using McAI.Proto.Commands;
using McAI.Proto.Commands.Client;
using System.Collections.Generic;


namespace McAI.Proto
{
    public class Parser
    {
        public readonly Dictionary<int, Command> Commands;
        public Parser()
        {
            Commands = new Dictionary<int, Command>
            {
                { 0x11, new PlayerPosition() },
                { 0x13, new PlayerRotation() }
            };
        }
    }
}
