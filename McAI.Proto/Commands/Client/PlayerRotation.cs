using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace McAI.Proto.Commands.Client
{
    public class PlayerRotation : Command
    {
        public override void Execute(byte[] array)
        {
            float yaw = BitConverter.ToSingle(array[0..4].Reverse().ToArray());
            float pitch = BitConverter.ToSingle(array[4..8].Reverse().ToArray());
            bool onGround = BitConverter.ToBoolean(array[8..]);

            //Debug($"Player Rotation: yaw:{yaw} pitch:{pitch} g:{onGround}");
        }
    }
}
