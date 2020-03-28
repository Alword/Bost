using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace McAI.Proto.Commands.Client
{
    public class PlayerPosition : Command
    {
        public override void Execute(byte[] array)
        {
            double x = BitConverter.ToDouble(array[0..8].Reverse().ToArray());
            double y = BitConverter.ToDouble(array[8..16].Reverse().ToArray());
            double z = BitConverter.ToDouble(array[16..24].Reverse().ToArray());
            bool onGound = BitConverter.ToBoolean(array[24..]);
            //Debug($"[Player] Position x:{x} y:{y} z:{z} onground:{onGound}");
        }
    }
}
