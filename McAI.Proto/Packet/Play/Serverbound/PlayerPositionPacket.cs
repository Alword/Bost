using System;

namespace McAI.Proto.Packet.Play.Serverbound
{
    public class PlayerPositionPacket : BasePacket
    {
        public override int PacketId => 0x11;

        public override void Read(byte[] array)
        {
            throw new NotImplementedException();
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }
    }
}
