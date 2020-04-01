using McAI.Proto.Packet.Play.Clientbound;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Commands.ToClient.Game
{
    public class ServerDifficulty : Command
    {
        private readonly ServerDifficultyPacket packet;
        public ServerDifficulty(bool isLogging = false) : base(isLogging)
        {
            this.packet = new ServerDifficultyPacket();
        }

        public override void Execute(byte[] array)
        {
            packet.Read(array);
            Debug(packet.ToString());
        }
    }
}
