using System;
using System.Linq;

namespace McAI.Proto.Commands.ToServer.Game
{
    public class PlayerRotation : Command
    {
        public PlayerRotation(bool isLogging = false) : base(isLogging)
        {

        }

        public override void Execute(byte[] array)
        {
            float yaw = BitConverter.ToSingle(array[0..4].Reverse().ToArray());
            float pitch = BitConverter.ToSingle(array[4..8].Reverse().ToArray());
            bool onGround = BitConverter.ToBoolean(array[8..]);

            Debug($"Player Rotation: yaw:{yaw} pitch:{pitch} g:{onGround}");
        }
    }
}
