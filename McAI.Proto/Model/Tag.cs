using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace McAI.Proto.Model
{
    public struct Tag
    {
        public string TagName { get; set; } // Identifier
        public int Count { get; set; } // varint
        public int[] Entries { get; set; } // Array of VarInt

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Count: {Count} Tag: {TagName} Entries: ");

            if (Entries == null)
                return stringBuilder.ToString();

            foreach (int i in Entries)
            {
                stringBuilder.Append($"{i} ");
            }

            stringBuilder.AppendLine();
            return stringBuilder.ToString();
        }
    }
}
