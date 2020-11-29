using Bost.Proto.Model;
using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Clientbound
{
    public class BlockActionPacket : BasePacket
    {
        public override int PacketId => 0x0A;

        public Position Location;
        public byte ActionID; //Unsigned Byte
        public byte ActionParam; //Unsigned Byte
        public int BlockType; //Varint

        public override void Read(byte[] array)
        {
            Location = new Position();
            Location.Read(ref array);
            McUnsignedByte.TryParse(ref array, out ActionID);
            McUnsignedByte.TryParse(ref array, out ActionParam);
            McVarint.TryParse(ref array, out BlockType);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[BlockAction] Location:{Location} ActionID:{ActionID} " +
                $"ActionParam:{ActionParam} BlockType:{BlockType}";
        }
    }
}
