using McAI.Proto.Packet.Play.Clientbound;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Commands.ToClient.Game
{
    public class JoinGame : Command
    {
        private readonly JoinGamePacket joinGamePacket;
        public JoinGame(bool isLogging) : base(isLogging)
        {
            joinGamePacket = new JoinGamePacket();
        }

        public override void Execute(byte[] array)
        {
            joinGamePacket.Read(array);
            Debug(joinGamePacket.ToString());
        }
    }
}
