using McAI.Proto.Packet.ToClient.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Commands.ToClient.Game
{
    public class Tags : Command
    {
        private readonly TagsPacket tagsPacket;
        public Tags(bool isLogging) : base(isLogging)
        {
            tagsPacket = new TagsPacket();
        }

        public override void Execute(byte[] array)
        {
            tagsPacket.Read(array);
            Debug(tagsPacket.ToString());
        }
    }
}
