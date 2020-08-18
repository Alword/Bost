using Bost.Proto.Types;

namespace Bost.Proto.Model
{
    public struct Statistic
    {
        public int CateogoryId;
        public int StatisticId;

        public void Parse(ref byte[] array)
        {
            McVarint.TryParse(ref array, out CateogoryId);
            McVarint.TryParse(ref array, out StatisticId);
        }

        public override string ToString()
        {
            return $"CategoryId {CateogoryId} Statistic {StatisticId}";
        }
    }
}
