using McAI.Proto.Abstractions;
using McAI.Proto.Commands;
using McAI.Proto.Commands.ToClient.Login;
using McAI.Proto.Types;
using System;
using System.Collections.Generic;

namespace McAI.Proto.StreamReader.Commands
{
    public class ToClientLoginStream : ICommand<int, byte[]>
    {
        protected readonly Dictionary<int, Command> commands;
        public ToClientLoginStream(GameState gameState)
        {
            this.commands = InitializeCommands(gameState);
        }
        public void Execute(int length, byte[] array)
        {
            Varint.TryParse(ref array, out int packetId);

            if (commands.ContainsKey(packetId))
            {
                commands[packetId].Execute(array);
            }
            else
            {
                string log = $"<-{length}:[{packetId:X02}]:[{BitConverter.ToString(array)}]";
                Program.Log(log);
            }
        }

        private Dictionary<int, Command> InitializeCommands(GameState gameState)
        {
            return new Dictionary<int, Command>
            {
                {0x03, new SetCompression(gameState,true) }
            };
        }
    }
}
