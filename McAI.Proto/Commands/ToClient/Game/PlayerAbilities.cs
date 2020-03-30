using McAI.Proto.Packet.ToClient.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Commands.ToClient.Game
{
    public class PlayerAbilities : Command
    {
        private readonly PlayerAbilitiesPacket packet;
        public PlayerAbilities(bool isLogging) : base(isLogging)
        {
            packet = new PlayerAbilitiesPacket();
        }

        public override void Execute(byte[] array)
        {
            packet.Read(array);
            Debug(packet.ToString());
        }
    }
}
