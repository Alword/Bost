using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Model
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
    }
}
