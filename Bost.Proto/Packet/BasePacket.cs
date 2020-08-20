using Bost.Proto.Types;
using System;
using System.Collections.Generic;

namespace Bost.Proto.Packet
{
    public abstract class BasePacket
    {
        public BasePacket()
        {
        }
        public abstract int PacketId { get; }
        public abstract void Read(byte[] array);
        public abstract byte[] Write();
        public byte[] Stream()
        {
            var data = Write();
            var buffer = new List<byte>(data.Length + 1);
            buffer.AddRange(McVarint.ToBytes(data.Length + 1));
            buffer.AddRange(McVarint.ToBytes(PacketId));
            buffer.AddRange(data);
            return buffer.ToArray();
        }
        public byte[] CompressedStream() { throw new NotImplementedException(); }
        public byte[] EncryptedStream() { throw new NotImplementedException(); }
        public override string ToString()
        {
            return $"0x{PacketId:X02}";
        }
    }
}
