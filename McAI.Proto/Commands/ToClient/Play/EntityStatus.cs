using McAI.Proto.Packet.ToClient.Play;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Commands.ToClient.Play
{
    public class EntityStatus : Command
    {
        private readonly EntityStatusPacket entityStatusPacket;
        public EntityStatus(bool isLogging) : base(isLogging)
        {
            entityStatusPacket = new EntityStatusPacket();
        }

        public override void Execute(byte[] array)
        {
            entityStatusPacket.Read(array);
            Debug(entityStatusPacket.ToString());
        }
    }
}
