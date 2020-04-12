using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class TimeUpdatePacket : BasePacket
    {
        public override int PacketId => 0x4F;

        public long WorldAge;
        public long TimeOfDay;

        public override void Read(byte[] array)
        {
            McLong.TryParse(ref array, out WorldAge);
            McLong.TryParse(ref array, out TimeOfDay);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[TimeUpdate] WorldAge:{WorldAge} TimeOfDay:{TimeOfDay}";
        }
    }
}
