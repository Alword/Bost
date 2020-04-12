using McAI.Proto.Mapping.Enum;
using McAI.Proto.Types;
using NbtLib;

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
                McNbtCompoundTag.TryParse(ref array, out NBT);
            }
        }

        public override string ToString()
        {
            if (Present)
            {
                return $"ItemId: {(MinecraftItem)ItemId} Count: {ItemCount} NBT:{NBT.ToJsonString()}";
            }
            else
            {
                return $"Not present";
            }
        }
    }
}
