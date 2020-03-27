using McAI.Proto.Commands;
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
                //{ 35, new Effect() }
            };
        }
    }
}
