using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace McAI.Proto.Packet.Login.Clientbound
{
    public class LoginSuccessPacket : BasePacket
    {
        public override int PacketId => 0x02;

        [MaxLength(36)] public string UUID { get; set; }
        [MaxLength(16)] public string Username { get; set; }
        public override void Read(byte[] array)
        {
            McString.TryParse(ref array, out string text);
            UUID = text;

            McString.TryParse(ref array, out text);
            Username = text;
        }

        public override byte[] Write()
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(McString.ToBytes(UUID));
            bytes.AddRange(McString.ToBytes(Username));
            return bytes.ToArray();
        }
    }
}
