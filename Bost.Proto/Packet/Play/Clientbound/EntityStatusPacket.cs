using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Clientbound
{
    public class EntityStatusPacket : BasePacket
    {
        public int EntityID;
        public byte EntityStatus;
        public EntityStatusPacket()
        {
        }

        public override int PacketId => 0x1A;

        public override void Read(byte[] array)
        {
            McInt.TryParse(ref array, out EntityID);
            McUnsignedByte.TryParse(ref array, out EntityStatus);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"EntityStatus EntityID: {EntityID} EntityStatus: {EntityStatus}";
        }
    }
}
