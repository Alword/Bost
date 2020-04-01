using McAI.Proto.Model;
using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class TagsPacket : BasePacket
    {
        public override int PacketId => 0x5C;

        public Tags BlockTags;
        public Tags ItemTags;
        public Tags FluidTags;
        public Tags EntityTags;

        public override void Read(byte[] array)
        {
            if (array.Length != 0)
                McTags.TryParse(ref array, out BlockTags);
            if (array.Length != 0)
                McTags.TryParse(ref array, out ItemTags);
            if (array.Length != 0)
                McTags.TryParse(ref array, out FluidTags);
            if (array.Length != 0)
                McTags.TryParse(ref array, out EntityTags);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"<[Tags|{base.ToString()}]: ");
            stringBuilder.AppendLine($"BlockTags: {BlockTags}");
            stringBuilder.AppendLine($"ItemTags: {ItemTags}");
            stringBuilder.AppendLine($"FluidTags: {FluidTags}");
            stringBuilder.AppendLine($"EntityTags: {EntityTags}");
            return stringBuilder.ToString();
        }
    }
}
