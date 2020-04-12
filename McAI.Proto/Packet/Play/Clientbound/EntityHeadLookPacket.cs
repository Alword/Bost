using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class EntityHeadLookPacket : BasePacket
    {
        public override int PacketId => 0x3C;

        public int EntityID; //Varint
        public byte HeadYaw; //Angle

        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out EntityID);
            McUnsignedByte.TryParse(ref array, out HeadYaw);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[EntityHeadLook] EntityID:{EntityID} HeadYaw:{HeadYaw}";
        }
    }
}
