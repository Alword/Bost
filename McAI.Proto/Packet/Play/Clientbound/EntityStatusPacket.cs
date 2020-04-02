using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class EntityStatusPacket : BasePacket
    {
        public int EntityID;
        public byte EntityStatus;
        public EntityStatusPacket()
        {
        }

        public override int PacketId => 0x1C;

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
