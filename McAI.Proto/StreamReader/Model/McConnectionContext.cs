using McAI.Proto.StreamReader.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.StreamReader.Model
{
    public class McConnectionContext
    {
        public bool IsCompressed { get; set; }
        public bool Encryption { get; set; }
        public string EncryptionPrivatekey { get; set; }
        public string EncryptionPuivatekey { get; set; }
        
        public int Length { get; set; }
        public int CompressionLength { get; set; }
        public int PacketId { get; set; }
        public ConnectionStates ConnectionState { get; set; }
        public Bounds BoundTo { get; set; }
        public byte[] Data { get; set; }
    }
}
