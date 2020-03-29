using McAI.Proto.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace McAI.Proto.Model.Packet.ToServer
{
    public class HandshakePacket : BasePacket
    {
        public int ProtocolVersion { get; set; } = 578; // VarInt See protocol version numbers (currently 578 in Minecraft 1.15.2)  
        public string Address { get; set; } // String (255) Hostname or IP, e.g. localhost or 127.0.0.1 
        public ushort Port { get; set; } // Unsigned Short 
        public LoginStates LoginState { get; set; } // VarInt Enum 1 for status, 2 for login
        public override int PacketId => 0x00;

        public override void Read(byte[] array)
        {
            //Name = Encoding.UTF8.GetString(array);
        }

        public override byte[] Write()
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(Varint.ToBytes(ProtocolVersion));
            bytes.AddRange(Encoding.UTF8.GetBytes(Address));
            bytes.AddRange(BitConverter.GetBytes(Port));
            bytes.AddRange(Varint.ToBytes((int)LoginState));
            return bytes.ToArray();
        }
    }
}
