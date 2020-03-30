using McAI.Proto.Abstractions;
using McAI.Proto.Commands;
using McAI.Proto.Commands.Client;
using McAI.Proto.Enum;
using McAI.Proto.Model;
using System;
using System.Collections.Generic;

namespace McAI.Proto.StreamReader.Commands
{
    public class ClientLoginStream : ICommand<int, byte[]>
    {
        private bool handshake = true;
        private readonly GameState gameState;
        protected readonly Dictionary<int, Command> commands;
        public ClientLoginStream(GameState gameState, Dictionary<int, Command> commands)
        {
            this.gameState = gameState;
            this.commands = commands;
        }

        public void Execute(int length, byte[] array)
        {
            Varint.TryParse(ref array, out int packetId);

            if (handshake)
            {
                handshake = false;
                new Handshake(true).Execute(array);
            }
            else if (commands.ContainsKey(packetId))
            {
                commands[packetId].Execute(array);
                gameState.ClientState = GameStates.Game;
            }
            else
            {
                string log = $"->{length}:[{packetId:X02}]:[{BitConverter.ToString(array)}]";
                Program.Log(log);
            }
        }
    }
}
