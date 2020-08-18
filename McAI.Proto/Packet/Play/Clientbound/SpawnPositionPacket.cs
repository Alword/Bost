using Bost.Proto.Model;
using System;

namespace Bost.Proto.Packet.Play.Clientbound
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
