﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace McAI.Proto.Types
{
    public static class McULong
    {
        // 8 
        public static bool TryParse(ref byte[] buffer, out ulong result)
        {
            result = BitConverter.ToUInt64(buffer[0..8].Reverse().ToArray());
            buffer = buffer[8..];
            return true;
        }
        public static byte[] ToBytes(ulong value)
        {
            byte[] reuslt = BitConverter.GetBytes(value);
            reuslt = reuslt.Reverse().ToArray();
            return reuslt;
        }
    }
}