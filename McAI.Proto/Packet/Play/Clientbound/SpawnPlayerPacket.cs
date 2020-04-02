using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class SpawnPlayerPacket : BasePacket
    {
        public override int PacketId => 0x05;
        public int EntityID; //Varint
        public Guid PlayerUUID; //UUID
        public double X;
        public double Y;
        public double Z;
        public byte Yaw; //Angle
        public byte Pitch; //Angle

        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out EntityID);
            McUUID.TryParse(ref array, out PlayerUUID);
            McDouble.TryParse(ref array, out X);
            McDouble.TryParse(ref array, out Y);
            McDouble.TryParse(ref array, out Z);
            McUnsignedByte.TryParse(ref array, out Yaw);
            McUnsignedByte.TryParse(ref array, out Pitch);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"<[SpawnPlayer|{base.ToString()}] EntityID:{EntityID} PlayerUUID:{PlayerUUID} X:{X} Y:{Y} Z:{Z} Yaw:{Yaw} Pitch:{Pitch}";
        }
    }
}
