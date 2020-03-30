﻿using McAI.Proto.Abstractions;
using McAI.Proto.Commands;
using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.StreamReader.Commands
{
    public class ServerLoginStream : ICommand<int, byte[]>
    {
        protected readonly Dictionary<int, Command> commands;
        public ServerLoginStream(Dictionary<int, Command> commands)
        {
            this.commands = commands;
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
    }
}
