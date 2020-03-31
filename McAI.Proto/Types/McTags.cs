using McAI.Proto.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Types
{
    public static class McTags
    {
        public static bool TryParse(ref byte[] buffer, out Tags result)
        {
            result = new Tags();
            McVarint.TryParse(ref buffer, out int length);
            result.Length = length;

            result.TagArray = new Tag[length];
            for (int i = 0; i < length && buffer.Length > 0; i++)
            {
                if (buffer.Length == 0)
                {
                    break;
                }

                McString.TryParse(ref buffer, out string tagName);
                result.TagArray[i].TagName = tagName;
                McVarint.TryParse(ref buffer, out int count);
                result.TagArray[i].Count = count;
                int[] entries = new int[count];
                for (int j = 0; j < count; j++)
                {
                    if (buffer.Length == 0)
                    {
                        break;
                    }

                    McVarint.TryParse(ref buffer, out int entry);
                    entries[j] = entry;
                }
                result.TagArray[i].Entries = entries;
            }
            return true;
        }
        public static byte[] ToBytes(Tags value)
        {
            throw new NotImplementedException();
        }
    }
}
