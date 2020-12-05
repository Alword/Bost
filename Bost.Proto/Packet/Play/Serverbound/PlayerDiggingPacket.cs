using Bost.Proto.Model;
using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Serverbound
{
    public class PlayerDiggingPacket : BasePacket
    {
        public override int PacketId => 0x1B;

        public int Status; //Varint Enum
        public Position Location;
        public byte Face; //Byte Enum

        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out Status);
            Location.Read(ref array);
            McUnsignedByte.TryParse(ref array, out Face);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[PlayerDigging] Status:{Status} Location:{Location} Face:{Face}";
        }
    }
}
