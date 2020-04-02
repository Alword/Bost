using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class DeclareRecipesPacket : BasePacket
    {
        public override int PacketId => 0x5B;

        public override void Read(byte[] array)
        {
            //throw new NotImplementedException();
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"DeclareRecipes NotImplemented";
        }
    }
}
