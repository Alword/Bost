using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Clientbound
{
    public class KeepAlivePacket : BasePacket
    {
        public override int PacketId => 0x1F;
        public long KeepAliveID;

        public override void Read(byte[] array)
        {
            McLong.TryParse(ref array, out KeepAliveID);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"KeepAlive KeepAliveID: {KeepAliveID}";
        }
    }
}
