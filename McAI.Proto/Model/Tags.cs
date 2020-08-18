using System.Text;

namespace Bost.Proto.Model
{
    public struct Tags
    {
        public int Length { get; set; } // Varint

        public Tag[] TagArray { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Length: {Length}");

            if (TagArray == null)
                return stringBuilder.ToString();

            foreach (var tag in TagArray)
            {
                stringBuilder.AppendLine(tag.ToString());
            }
            return stringBuilder.ToString();
        }
    }
}
