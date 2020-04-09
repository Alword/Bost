using McAI.Proto.Types;
using System;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class SetExperiencePacket : BasePacket
    {
        public override int PacketId => 0x48;

        public float ExperienceBar;
        public int Level; // Varint
        public int TotalExperience; // Varint

        public override void Read(byte[] array)
        {
            McFloat.TryParse(ref array, out ExperienceBar);
            McVarint.TryParse(ref array, out Level);
            McVarint.TryParse(ref array, out TotalExperience);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[SetExperience] ExperienceBar:{ExperienceBar} Level:{Level} TotalExperience:{TotalExperience}";
        }
    }
}
