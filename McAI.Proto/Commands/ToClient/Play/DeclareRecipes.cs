using McAI.Proto.Packet.Play.Clientbound;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Commands.ToClient.Game
{
    public class DeclareRecipes : Command
    {
        private readonly DeclareRecipesPacket packet;
        public DeclareRecipes(bool isLogging) : base(isLogging)
        {
            packet = new DeclareRecipesPacket();
        }

        public override void Execute(byte[] array)
        {
            packet.Read(array);
            Debug(packet.ToString());
        }
    }
}
