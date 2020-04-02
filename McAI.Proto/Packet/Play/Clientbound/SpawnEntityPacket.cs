using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class SpawnEntityPacket : BasePacket
    {
        public override int PacketId => 0x00;

        public int EntityId { get; set; } // Varint
        public Guid UUID { get; set; } // String
        public int Type { get; set; } // Varint
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public byte Pitch { get; set; } // Angle
        public byte Yaw { get; set; } // Angle
        public int Data { get; set; } // int
        public short VelocityX { get; set; }
        public short VelocityY { get; set; }
        public short VelocityZ { get; set; }


        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out int entityId);
            McUUID.TryParse(ref array, out Guid uuid);
            McVarint.TryParse(ref array, out int type);
            McDouble.TryParse(ref array, out double x);
            McDouble.TryParse(ref array, out double y);
            McDouble.TryParse(ref array, out double z);
            McUnsignedByte.TryParse(ref array, out byte pitch);
            McUnsignedByte.TryParse(ref array, out byte yaw);
            McInt.TryParse(ref array, out int data);
            McShort.TryParse(ref array, out short velocityX);
            McShort.TryParse(ref array, out short velocityY);
            McShort.TryParse(ref array, out short velocityZ);
            EntityId = entityId;
            UUID = uuid;
            Type = type;
            X = x;
            Y = y;
            Z = z;
            Pitch = pitch;
            Yaw = yaw;
            Data = data;
            VelocityX = velocityX;
            VelocityY = velocityY;
            VelocityZ = velocityZ;
        }

        public override byte[] Write()
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(McVarint.ToBytes(EntityId));
            bytes.AddRange(McUUID.ToBytes(UUID));
            bytes.AddRange(McVarint.ToBytes(Type));
            bytes.AddRange(McDouble.ToBytes(X));
            bytes.AddRange(McDouble.ToBytes(Y));
            bytes.AddRange(McDouble.ToBytes(Z));
            bytes.AddRange(McUnsignedByte.ToBytes(Pitch));
            bytes.AddRange(McUnsignedByte.ToBytes(Yaw));
            bytes.AddRange(McInt.ToBytes(Data));
            bytes.AddRange(McShort.ToBytes(VelocityX));
            bytes.AddRange(McShort.ToBytes(VelocityY));
            bytes.AddRange(McShort.ToBytes(VelocityZ));
            return bytes.ToArray();
        }
    }
}
