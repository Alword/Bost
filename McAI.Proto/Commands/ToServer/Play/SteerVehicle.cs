using System;
using System.Linq;

namespace McAI.Proto.Commands.ToServer.Game
{
    public class SteerVehicle : Command
    {
        public SteerVehicle(bool isLogging = false) : base(isLogging)
        {

        }
        public override void Execute(byte[] array)
        {
            var reverse = array.Reverse().ToArray();
            float sideways = BitConverter.ToSingle(reverse[5..9]);
            float forward = BitConverter.ToSingle(reverse[1..5]);
            byte flags = reverse[0];

            Debug($"SteerVehicle sideways:{sideways} forward:{forward} flags:{flags}");
        }
    }
}
