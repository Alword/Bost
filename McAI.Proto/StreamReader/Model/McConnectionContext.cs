using McAI.Proto.Extentions;
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

        public int Length;
        public int CompressionLength;
        public int PacketId;
        public ConnectionStates ConnectionState { get; set; }
        public Bounds BoundTo { get; set; }
        public byte[] Data;

        public override string ToString()
        {
            return $"Error: 0x{PacketId:X02} |{ConnectionState} | {BoundTo} | {CompressionLength} | {Data.ToHexString()}";
        }
    }
}
