using McAI.Proto.Packet.ToServer.Play;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Commands.ToServer.Play
{
    public class PlayerMovement : Command
    {
        private readonly PlayerMovementPacket playerMovementPacket;
        public PlayerMovement(bool isLogging) : base(isLogging)
        {
            playerMovementPacket = new PlayerMovementPacket();
        }

        public override void Execute(byte[] array)
        {
            playerMovementPacket.Read(array);
            Debug(playerMovementPacket.ToString());
        }
    }
}
