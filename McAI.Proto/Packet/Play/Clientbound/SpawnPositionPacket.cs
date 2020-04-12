using McAI.Proto.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class SpawnPositionPacket : BasePacket
    {
        public override int PacketId => 0x4E;
        public Position Location;

        public override void Read(byte[] array)
        {
            Location = new Position();
            Location.Read(ref array);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[SpawnPosition] Location:{Location}";
        }
    }
}
