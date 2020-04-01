using McAI.Proto.Packet.Play.Clientbound;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Commands.ToClient.Play
{
    public class UnlockRecipes : Command
    {

        public UnlockRecipes(bool isLogging = false) : base(isLogging)
        {
        }
        public override void Execute(byte[] array)
        {
            UnlockRecipesPacket packet = new UnlockRecipesPacket();
            packet.Read(array);
            Debug(packet.ToString());
        }
    }
}
