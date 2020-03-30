using McAI.Proto.Abstractions;
using McAI.Proto.Commands;
using McAI.Proto.Commands.ToClient.Game;
using McAI.Proto.Commands.ToClient.Login;
using McAI.Proto.Packet.ToClient.Login;
using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;

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
            array = Uncompress(array, compressed);
            McVarint.TryParse(ref array, out int packetId);

            if (commands.ContainsKey(packetId))
            {
                commands[packetId].Execute(array);
            }
            else
            {
                if (i++ < 5)
                {
                    string log = $"<-{length}:{compressed}:[{packetId:X02}]:[{BitConverter.ToString(array)}]";
                    Program.Log(log);
                }
            }
        }

        private byte[] Uncompress(byte[] array, int length)
        {
            if (length == 0)
            {
                return array;
            }
            else
            {
                return Ionic.Zlib.ZlibStream.UncompressBuffer(array);
            }
        }

        private Dictionary<int, Command> InitializeCommand(GameState gameState)
        {
            return new Dictionary<int, Command>
            {
                {0x02, new LoginSuccess(true)},
                {0x26, new JoinGame(true)},
                {0x19, new PluginMessage(true)},
                {0x0E, new ServerDifficulty(true) },
                {0x32, new PlayerAbilities(true) },
                {0x40, new HeldItemChange(true)},
                {0x5B ,new DeclareRecipes(true) }
            };
        }
    }
}
