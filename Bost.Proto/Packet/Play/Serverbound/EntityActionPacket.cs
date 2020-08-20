using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Serverbound
{
    public class EntityActionPacket : BasePacket
    {
        public override int PacketId => 0x1B;

        public int EntityID; //Varint
        public int ActionID; //Varint Enum
        public int JumpBoost; //Varint

        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out EntityID);
            McVarint.TryParse(ref array, out ActionID);
            McVarint.TryParse(ref array, out JumpBoost);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[EntityAction] EntityID:{EntityID} ActionID:{ActionID} JumpBoost:{JumpBoost}";
        }
    }
}
