using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class CollectItemPacket : BasePacket
    {
        public override int PacketId => 0x56;

        public int CollectedEntityID; //Varint
        public int CollectorEntityID; //Varint
        public int PickupItemCount; //Varint

        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out CollectedEntityID);
            McVarint.TryParse(ref array, out CollectorEntityID);
            McVarint.TryParse(ref array, out PickupItemCount);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[CollectItem] CollectedEntityID:{CollectedEntityID} " +
                $"CollectorEntityID:{CollectorEntityID} PickupItemCount:{PickupItemCount}";
        }
    }
}
