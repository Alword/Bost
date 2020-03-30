using McAI.Proto.Abstractions;
using McAI.Proto.Commands;
using McAI.Proto.Commands.ToServer.Game;
using McAI.Proto.Types;
using System;
using System.Collections.Generic;

namespace McAI.Proto.StreamReader.Commands
{
    public class ToServerGameStream : ICommand<int, byte[]>
    {
        protected readonly Dictionary<int, Command> commands;
        public ToServerGameStream(GameState gameState)
        {
            this.commands = InitializeCommand(gameState);
        }

        public void Execute(int length, byte[] array)
        {
            Varint.TryParse(ref array, out int compressed);
            Varint.TryParse(ref array, out int packetId);

            if (commands.ContainsKey(packetId))
            {
                commands[packetId].Execute(array);
            }
            else
            {
                string log = $"->{length}:{compressed}:[{packetId:X02}]:[{BitConverter.ToString(array)}]";
                //Program.Log(log);
            }
        }

        public Dictionary<int, Command> InitializeCommand(GameState gameState)
        {
            return new Dictionary<int, Command>
            {
                { 0x11, new PlayerPosition() },
                { 0x12, new PlayerPositionAndRotation() },
                { 0x13, new PlayerRotation() },
                { 0x15, new VehicleMove()},
                { 0x1C, new SteerVehicle()},
            };
        }
    }
}
