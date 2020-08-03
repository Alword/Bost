using McAI.Proto.Model;
using McAI.Proto.Types;
using System;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class SpawnPaintingPacket : BasePacket
    {
        public override int PacketId => 0x04;

        public int EntityID; //Varint
        public Guid EntityUUID; //UUID
        public int Motive; //Varint
        public Position Location;
        public byte Direction; //Byte Enum

        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out EntityID);
            McUUID.TryParse(ref array, out EntityUUID);
            McVarint.TryParse(ref array, out Motive);
            Location = new Position();
            Location.Read(ref array);
            McUnsignedByte.TryParse(ref array, out Direction);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[SpawnPainting] EntityID:{EntityID} EntityUUID:{EntityUUID} " +
                $"Motive:{Motive} Location:{Location} Direction:{Direction}";
        }
    }
}
