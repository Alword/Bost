using System;
using System.Linq;

namespace McAI.Proto.Commands.Client
{
    public class VehicleMove : Command
    {
        public VehicleMove(bool isLogging = false) : base(isLogging)
        {

        }
        public override void Execute(byte[] array)
        {
            var reverse = array.Reverse().ToArray();
            double x = BitConverter.ToDouble(reverse[24..32]);
            double y = BitConverter.ToDouble(reverse[16..24]);
            double z = BitConverter.ToDouble(reverse[8..16]);
            float yaw = BitConverter.ToSingle(reverse[4..8]);
            float pitch = BitConverter.ToSingle(reverse[0..4]);

            Debug($"VehicleMove x:{x} x:{y} x:{z} yaw:{yaw} pitch:{pitch}");
        }
    }
}
