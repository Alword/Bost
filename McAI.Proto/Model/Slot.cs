using McAI.Proto.Types;
using NbtLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace McAI.Proto.Model
{
    public struct Slot
    {
        public bool Present;
        public int ItemId; // varint
        public byte ItemCount;
        public NbtCompoundTag NBT;

        public void Parse(ref byte[] array)
        {
            McBoolean.TryParse(ref array, out Present);
            if (Present)
            {
                McVarint.TryParse(ref array, out ItemId);
                McUnsignedByte.TryParse(ref array, out ItemCount);
                Stream nbtStream = new MemoryStream(array);
                NBT = new NbtParser().ParseNbtStream(nbtStream);
                array = array[(int)nbtStream.Position..];
            }
        }

        public override string ToString()
        {
            if (Present)
            {
                return $"Not present";
            }
            else
            {
                return $"ItemId: {ItemId} Count: {ItemCount} NBT:{NBT.ToJsonString()}";
            }
        }
    }
}
