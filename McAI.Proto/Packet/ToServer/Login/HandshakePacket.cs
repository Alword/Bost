using McAI.Proto.Enum;
using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace McAI.Proto.Packet.ToServer.Login
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
            McVarint.TryParse(ref array, out int protocolVersion);
            ProtocolVersion = protocolVersion;

            McVarint.TryParse(ref array, out int addressLength);

            Address = Encoding.UTF8.GetString(array[0..addressLength]);
            array = array[addressLength..];

            Port = BitConverter.ToUInt16(array[0..2].Reverse().ToArray());
            array = array[2..];

            McVarint.TryParse(ref array, out int loginState);
            LoginState = (LoginStates)loginState;
        }

        public override byte[] Write()
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(McVarint.ToBytes(ProtocolVersion));
            bytes.AddRange(McVarint.ToBytes(Address.Length));
            bytes.AddRange(Encoding.UTF8.GetBytes(Address));
            bytes.AddRange(BitConverter.GetBytes(Port).Reverse());
            bytes.AddRange(McVarint.ToBytes((int)LoginState));
            return bytes.ToArray();
        }
    }
}
