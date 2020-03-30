using McAI.Proto.Abstractions;
using McAI.Proto.Commands;
using McAI.Proto.Commands.ToClient.Game;
using McAI.Proto.Commands.ToClient.Login;
using McAI.Proto.Packet.ToClient.Login;
using McAI.Proto.Types;
using System;
using System.Collections.Generic;

namespace McAI.Proto.StreamReader.Commands
{
    public class ToClientCompressedStream : ICommand<int, byte[]>
    {
        protected readonly Dictionary<int, Command> commands;
        public ToClientCompressedStream(GameState gameState)
        {
            this.commands = InitializeCommand(gameState);
        }
        int i = 0;
        public void Execute(int length, byte[] array)
        {
            McVarint.TryParse(ref array, out int compressed);
            McVarint.TryParse(ref array, out int packetId);

            if (commands.ContainsKey(packetId))
            {
                commands[packetId].Execute(array);
            }
            else
            {
                if (i++ < 5)
                {
                    string log = $"->{length}:{compressed}:[{packetId:X02}]:[{BitConverter.ToString(array)}]";
                    Program.Log(log);
                }
            }
        }

        private Dictionary<int, Command> InitializeCommand(GameState gameState)
        {
            return new Dictionary<int, Command>
            {
                {0x02, new LoginSuccess(true)},
                {0x26, new JoinGame(true)}
            };
        }
    }
}
