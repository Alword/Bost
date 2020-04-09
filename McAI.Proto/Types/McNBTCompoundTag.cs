using NbtLib;
using System;
using System.IO;

namespace McAI.Proto.Types
{
    public class McNbtCompoundTag
    {
        public static bool TryParse(ref byte[] buffer, out NbtCompoundTag result)
        {
            var parser = new NbtParser();
            Stream nbtStream = new MemoryStream(buffer);
            if (buffer[0] == 0)
            {
                buffer = buffer[1..];
                result = new NbtCompoundTag();
            }
            else
            {
                result = new NbtParser().ParseNbtStream(nbtStream);
                buffer = buffer[(int)nbtStream.Position..];
            }
            return true;
        }
        public static byte[] ToBytes(long value)
        {
            throw new NotImplementedException();
        }
    }
}
