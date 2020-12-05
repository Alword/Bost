using System;

namespace Bost.Proto.Packet.Play.Clientbound
{
    public class DeclareRecipesPacket : BasePacket
    {
        public override int PacketId => 0x5A;

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
