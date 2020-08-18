using Bost.Proto.Model;
using Bost.Proto.Types;
using System;

namespace Bost.Proto.Packet.Play.Clientbound
{
    public class EffectPacket : BasePacket
    {
        public override int PacketId => 0x23;

        public int EffectID;
        public Position Positions;
        public int Data;
        public bool DisableRelativeVolume;

        public override void Read(byte[] array)
        {
            McInt.TryParse(ref array, out EffectID);
            Positions = new Position();
            Positions.Read(ref array);
            McInt.TryParse(ref array, out Data);
            McBoolean.TryParse(ref array, out DisableRelativeVolume);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[Effect] EffectID:{EffectID} Positions:{Positions} " +
                $"Data:{Data} DisableRelativeVolume:{DisableRelativeVolume}";
        }
    }
}
