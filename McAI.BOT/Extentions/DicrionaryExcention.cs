using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.BOT.Extentions
{
    public static class DicrionaryExcention
    {
        public static void EnsureAdd<T>(this HashSet<T> hash, T hashValue)
        {
            if (hash.Contains(hashValue))
                return;

            hash.Add(hashValue);
        }
    }
}
