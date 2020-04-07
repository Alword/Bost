using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.BOT.Types
{
    public struct Int2
    {
        public int X { get; set; }
        public int Y { get; set; }
        public static Int2 Zero => new Int2(0, 0);
        public Int2(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
