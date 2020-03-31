using McAI.Proto.Packet.ToServer.Play;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Commands.ToServer.Play
{
    public class HeldItemChange : Command
    {
        public HeldItemChange(bool isLogging) : base(isLogging)
        {
        }

        public override void Execute(byte[] array)
        {
            HeldItemChangePacket heldItemChangePacket = new HeldItemChangePacket();
            heldItemChangePacket.Read(array);
            Debug(heldItemChangePacket.ToString());
        }
    }
}
