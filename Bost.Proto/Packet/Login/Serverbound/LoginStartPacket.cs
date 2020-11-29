using Bost.Proto.Types;
using System.ComponentModel.DataAnnotations;

namespace Bost.Proto.Packet.Login.Serverbound
{
    public class LoginStartPacket : BasePacket
    {
        public override int PacketId => 0x00;
        [MaxLength(16)] public string Name { get; set; } // Player's Username 

        public override void Read(byte[] array)
        {
            McString.TryParse(ref array, out string name);
            Name = name;
        }

        public override byte[] Write()
        {
            return McString.ToBytes(Name);
        }
    }
}
