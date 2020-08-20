using Bost.Proto.Model;
using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Serverbound
{
    public class PlayerBlockPlacementPacket : BasePacket
    {
        public override int PacketId => 0x2C;

        public int Hand; //Varint Enum
        public Position Location;
        public int Face; //Varint Enum
        public float CursorPositionX;
        public float CursorPositionY;
        public float CursorPositionZ;
        public bool InsideBlock;

        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out Hand);
            Location = new Position();
            Location.Read(ref array);
            McVarint.TryParse(ref array, out Face);
            McFloat.TryParse(ref array, out CursorPositionX);
            McFloat.TryParse(ref array, out CursorPositionY);
            McFloat.TryParse(ref array, out CursorPositionZ);
            McBoolean.TryParse(ref array, out InsideBlock);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[PlayerBlockPlacement] Hand:{Hand} Location:{Location} Face:{Face} " +
                $"CursorPositionX:{CursorPositionX} CursorPositionY:{CursorPositionY} " +
                $"CursorPositionZ:{CursorPositionZ} InsideBlock:{InsideBlock}";
        }
    }
}
