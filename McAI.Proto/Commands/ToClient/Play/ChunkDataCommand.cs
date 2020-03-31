using McAI.Proto.Packet.Play.Clientbound;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Commands.ToClient.Play
{
    public class ChunkDataCommand : Command
    {
        public ChunkDataCommand(bool isLogging) : base(isLogging)
        {

        }

        public override void Execute(byte[] array)
        {
            ChunkDataPacket chunkDataPacket = new ChunkDataPacket();
            chunkDataPacket.Read(array);

            //throw new NotImplementedException();
        }
    }
}
