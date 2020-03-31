using McAI.Proto.Abstractions;
using McAI.Proto.Commands;
using McAI.Proto.Commands.ToClient.Game;
using McAI.Proto.Commands.ToClient.Login;
using McAI.Proto.Commands.ToClient.Play;
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
            int compressed;
            int packetId;

            McVarint.TryParse(ref array, out compressed);
            array = Uncompress(array, compressed);

            McVarint.TryParse(ref array, out packetId);

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
                {0x02, new LoginSuccess(false)},
                {0x26, new JoinGame(false)},
                {0x19, new PluginMessage(false)},
                {0x0E, new ServerDifficulty(false) },
                {0x32, new PlayerAbilities(false) },
                {0x40, new HeldItemChange(false)},
                {0x5B ,new DeclareRecipes(false) },
                {0x5C, new Tags(false)},
                {0x1C, new EntityStatus(true) }
            };
        }
    }
}
