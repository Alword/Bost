using McAI.Proto.Types;
using System;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class AttachEntityPacket : BasePacket
    {
        public override int PacketId => 0x45;

        public int AttachedEntityID;
        public int HoldingEntityID;

        public override void Read(byte[] array)
        {
            McInt.TryParse(ref array, out AttachedEntityID);
            McInt.TryParse(ref array, out HoldingEntityID);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[AttachEntity] AttachedEntityID:{AttachedEntityID} HoldingEntityID:{HoldingEntityID}";
        }
    }
}
