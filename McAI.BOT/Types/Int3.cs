namespace McAI.BOT.Model
{
    public struct Int3
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public static Int3 Zero => new Int3(0, 0, 0);
        public static Int3 Forward => new Int3(1, 0, 0);
        public static Int3 Backward => new Int3(-1, 0, 0);
        public static Int3 Right => new Int3(0, 0, 1);
        public static Int3 Left => new Int3(0, 0, -1);
        public static Int3 Up => new Int3(0, 1, 0);
        public static Int3 Down => new Int3(0, -1, 0);
        public Int3(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            this.Z = 0;
        }
        public Int3(int X, int Y, int Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public Int3 AsXZVector()
        {
            Int3 result = Zero;

            if (X > 0)
                result += Forward;
            if (X < 0)
                result += Backward;

            if (Y > 0)
                result += Right;
            if (Y < 0)
                result += Left;

            return result;
        }

        public static Int3 operator +(Int3 a, Int3 b)
        {
            a.X += b.X;
            a.Y += b.Y;
            a.Z += b.Z;
            return a;
        }

        public static Int3 operator *(Int3 a, int b)
        {
            a.X *= b;
            a.Y *= b;
            a.Z *= b;
            return a;
        }

        public static Int3 operator -(Int3 a, Int3 b)
        {
            a.X -= b.X;
            a.Y -= b.Y;
            a.Z -= b.Z;
            return a;
        }

        public static bool operator ==(Int3 a, Int3 b)
        {
            return (a.X == b.X) && (a.Z == b.Z) && (a.Y == b.Y);
        }

        public static bool operator !=(Int3 a, Int3 b)
        {
            return !(a == b);
        }
    }
}
