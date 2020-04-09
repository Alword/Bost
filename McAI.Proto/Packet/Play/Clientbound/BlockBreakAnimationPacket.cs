using McAI.Proto.Model;
using McAI.Proto.Types;
using System;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class BlockBreakAnimationPacket : BasePacket
    {
        public override int PacketId => 0x09;

        public int EntityID; //Varint
        public Position Location;
        public byte DestroyStage;

        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out EntityID);
            Location = new Position();
            Location.Read(ref array);
            McUnsignedByte.TryParse(ref array, out DestroyStage);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[BlockBreakAnimation] EntityID:{EntityID} Location:{Location} " +
                $"DestroyStage:{DestroyStage}";
        }
    }
}
