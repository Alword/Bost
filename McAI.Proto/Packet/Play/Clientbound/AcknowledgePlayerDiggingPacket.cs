using Bost.Proto.Model;
using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Clientbound
{
    public class AcknowledgePlayerDiggingPacket : BasePacket
    {
        public override int PacketId => 0x08;

        public Position Location;
        public int Block; //Varint
        public int Status; //Varint Enum
        public bool Successful;

        public override void Read(byte[] array)
        {
            Location = new Position();
            Location.Read(ref array);
            McVarint.TryParse(ref array, out Block);
            McVarint.TryParse(ref array, out Status);
            McBoolean.TryParse(ref array, out Successful);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[{nameof(AcknowledgePlayerDiggingPacket)}] Location:{Location} Block:{Block} " +
                $"Status:{Status} Successful:{Successful}";
        }
    }
}
