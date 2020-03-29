using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace McAI.Proto.Model.Packet.ToServer
{
    public class LoginStartPacket : BasePacket
    {
        [MaxLength(16)] public string Name { get; set; } // Player's Username 
        public override int PacketId => 0x00;

        public override void Read(byte[] array)
        {
            Name = Encoding.UTF8.GetString(array);
        }

        public override byte[] Write()
        {
            return Encoding.UTF8.GetBytes(Name);
        }
    }
}
