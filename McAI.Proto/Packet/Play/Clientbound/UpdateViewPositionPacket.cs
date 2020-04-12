using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class UpdateViewPositionPacket : BasePacket
    {
        public override int PacketId => 0x41;

        public int ChunkX; //Varint
        public int ChunkZ; //Varint

        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out ChunkX);
            McVarint.TryParse(ref array, out ChunkZ);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[UpdateViewPosition] ChunkX:{ChunkX} ChunkZ:{ChunkZ}";
        }
    }
}
