using McAI.Proto.Commands.ToServer.Game;
using McAI.Proto.Commands.ToServer.Login;
using System.Collections.Generic;


namespace McAI.Proto.Commands.ToServer
{
    public class ToServerParser
    {
        public readonly Dictionary<int, Command> Commands;
        public ToServerParser()
        {
            Commands = new Dictionary<int, Command>
            {
                { 0x00, new LoginStart(true) },
                { 0x11, new PlayerPosition() },
                { 0x12, new PlayerPositionAndRotation() },
                { 0x13, new PlayerRotation() },
                { 0x15, new VehicleMove()},
                { 0x1C, new SteerVehicle()},
            };
        }
    }
}
