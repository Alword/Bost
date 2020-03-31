using McAI.Proto.Abstractions;
using McAI.Proto.Commands;
using McAI.Proto.Commands.ToServer.Login;
using McAI.Proto.Enum;
using McAI.Proto.Types;
using System;
using System.Collections.Generic;

namespace McAI.Proto.StreamReader.Commands
{
    public class ToServerUncompressedStream : ICommand<int, byte[]>
    {
        private bool handshake = true;
        private readonly GameState gameState;
        protected readonly Dictionary<int, Command> commands;
        public ToServerUncompressedStream(GameState gameState)
        {
            // todo command set state
            this.gameState = gameState;
            this.commands = InitializeCommand(gameState);
        }

        public void Execute(int length, byte[] array)
        {
            McVarint.TryParse(ref array, out int packetId);

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
                string log = $"ToServer-{length}:[{packetId:X02}]:[{BitConverter.ToString(array)}]";
                //Program.Log(log);
            }
        }

        public Dictionary<int, Command> InitializeCommand(GameState gameState)
        {
            return new Dictionary<int, Command>
            {
                { 0x00, new LoginStart(true) },
            };
        }
    }
}
