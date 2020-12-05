using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Clientbound
{
    public class EntityMovementPacket : BasePacket
    {
        public override int PacketId => 0x2A;
        public int EntityID; //Varint

        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out EntityID);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[EntityMovement] EntityID:{EntityID}";
        }
    }
}
