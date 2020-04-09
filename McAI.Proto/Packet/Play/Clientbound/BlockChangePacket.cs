using McAI.Proto.Model;
using McAI.Proto.Types;
using System;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class BlockChangePacket : BasePacket
    {
        public override int PacketId => 0x0C;

        public Position Location;
        public int BlocID; //Varint

        public override void Read(byte[] array)
        {
            Location.Read(ref array);
            McVarint.TryParse(ref array, out BlocID);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[BlockChange] Location:{Location} BlocID:{BlocID}";
        }
    }
}
