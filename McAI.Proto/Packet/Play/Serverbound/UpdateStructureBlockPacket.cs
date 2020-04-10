using McAI.Proto.Model;
using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Serverbound
{
    public class UpdateStructureBlockPacket : BasePacket
    {
        public override int PacketId => 0x28;

        public Position Location;
        public int Action; //Varint Enum
        public int Mode; //Varint Enum
        public string Name;
        public sbyte OffsetX; //Between -32 and 32
        public sbyte OffsetY; //Between -32 and 32
        public sbyte OffsetZ; //Between -32 and 32
        public byte SizeX;
        public byte SizeY;
        public byte SizeZ;
        public int Mirror; //Varint Enum
        public int Rotation; //Varint Enum
        public string Metadata;
        public float Integrity;
        public long Seed; //VarLong
        public byte Flags;

        public override void Read(byte[] array)
        {
            Location = new Position();
            Location.Read(ref array);
            McVarint.TryParse(ref array, out Action);
            McVarint.TryParse(ref array, out Mode);
            McString.TryParse(ref array, out Name);
            McByte.TryParse(ref array, out OffsetX);
            McByte.TryParse(ref array, out OffsetY);
            McByte.TryParse(ref array, out OffsetZ);
            McUnsignedByte.TryParse(ref array, out SizeX);
            McUnsignedByte.TryParse(ref array, out SizeY);
            McUnsignedByte.TryParse(ref array, out SizeZ);
            McVarint.TryParse(ref array, out Mirror);
            McVarint.TryParse(ref array, out Rotation);
            McString.TryParse(ref array, out Metadata);
            McFloat.TryParse(ref array, out Integrity);
            McVarlong.TryParse(ref array, out Seed);
            McUnsignedByte.TryParse(ref array, out Flags);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[UpdateStructureBlock] Location:{Location} Action:{Action} Mode:{Mode} Name:{Name} " +
                $"OffsetX:{OffsetX} OffsetY:{OffsetY} OffsetZ:{OffsetZ} SizeX:{SizeX} SizeY:{SizeY} " +
                $"SizeZ:{SizeZ} Mirror:{Mirror} Rotation:{Rotation} Metadata:{Metadata} " +
                $"Integrity:{Integrity} Seed:{Seed} Flags:{Flags}";
        }
    }
}
