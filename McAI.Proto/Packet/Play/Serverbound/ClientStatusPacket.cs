using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Serverbound
{
    public class ClientStatusPacket : BasePacket
    {
        public override int PacketId => 0x04;
        public int ActionID; //Varint Enum 
       
        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out ActionID);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"<[ClientStatus|{base.ToString()}] ActionID: {ActionID}";
        }
    }
}
