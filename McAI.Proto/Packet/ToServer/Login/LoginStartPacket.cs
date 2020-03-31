﻿using McAI.Proto.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace McAI.Proto.Packet.ToServer.Login
{
    public class LoginStartPacket : BasePacket
    {
        [MaxLength(16)] public string Name { get; set; } // Player's Username 
        public override int PacketId => 0x00;

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