using System;
using System.Linq;

namespace McAI.Proto.Commands.ToServer.Game
{
    public class PlayerPosition : Command
    {
        public PlayerPosition(bool isLogging = false) : base(isLogging) { }

        public PlayerPosition()
        {

        }

        public override void Execute(byte[] array)
        {
            double x = BitConverter.ToDouble(array[0..8].Reverse().ToArray());
            double y = BitConverter.ToDouble(array[8..16].Reverse().ToArray());
            double z = BitConverter.ToDouble(array[16..24].Reverse().ToArray());
            bool onGound = BitConverter.ToBoolean(array[24..]);

            Debug($"[Player] Position x:{x} y:{y} z:{z} onground:{onGound}");
        }
    }
}
