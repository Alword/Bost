using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.ToClient.Play
{
    public class EntityStatusPacket : BasePacket
    {
        public int EntityID;
        public byte EntityStatus;
        public EntityStatusPacket()
        {
        }

        public override int PacketId => throw new NotImplementedException();

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
            return $"<[EntityStatus|{base.ToString()}] EntityID: {EntityID} EntityStatus: {EntityStatus}";
        }
    }
}
