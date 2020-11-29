using Bost.Proto.Types;

namespace Bost.Proto.Model
{
    public struct Statistic
    {
        public int CateogoryId;
        public int StatisticId;
        public int Value;

        public void Parse(ref byte[] array)
        {
            McVarint.TryParse(ref array, out CateogoryId);
            McVarint.TryParse(ref array, out StatisticId);
            McVarint.TryParse(ref array, out Value);
        }

        public override string ToString()
        {
            return $"CategoryId {CateogoryId} Statistic {StatisticId}";
        }
    }
}
