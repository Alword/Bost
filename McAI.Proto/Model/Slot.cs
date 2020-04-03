using McAI.Proto.Types;
using NbtLib;
using System.IO;

namespace McAI.Proto.Model
{
    public class Slot
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

                var parser = new NbtParser();
                Stream nbtStream = new MemoryStream(array);
                if (array[0] == 0)
                {
                    array = array[1..];
                    NBT = new NbtCompoundTag();
                }
                else
                {
                    NBT = new NbtParser().ParseNbtStream(nbtStream);
                    array = array[(int)nbtStream.Position..];
                }

            }
        }

        public override string ToString()
        {
            if (Present)
            {
                return $"ItemId: {ItemId} Count: {ItemCount} NBT:{NBT.ToJsonString()}";
            }
            else
            {
                return $"Not present";
            }
        }
    }
}
