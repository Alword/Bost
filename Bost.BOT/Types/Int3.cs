using Bost.Agent.Types;
using System;

namespace Bost.Agent.Model
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

		public override bool Equals(object obj)
		{
			return obj is Int3 @int &&
				   X == @int.X &&
				   Y == @int.Y &&
				   Z == @int.Z;
		}

		internal int Distance(Int3 b)
		{
			return (int)Math.Sqrt(Math.Pow(X - b.X, 2) + Math.Pow(Y - b.Y, 2) + Math.Pow(Z - b.Z, 2));
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(X, Y, Z);
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

		public override string ToString()
		{
			return $"X:{X} Y:{Y} Z:{Z}";
		}

		public static implicit operator Proto.Model.Position(Int3 int3)
		{
			return new Proto.Model.Position { X = int3.X, Y = int3.Y, Z = int3.Z };
		}
		public static implicit operator Int3(Proto.Model.Position position)
		{
			return new Int3(position.X, position.Y, position.Z);
		}

		public static explicit operator Int3(Double3 int3)
		{
			return new Int3 { X = (int)int3.X, Y = (int)int3.Y, Z = (int)int3.Z };
		}
		public static implicit operator Double3(Int3 position)
		{
			return new Double3(position.X, position.Y, position.Z);
		}

		public static int Volume(Int3 a, Int3 b)
		{
			var vector = a - b;
			return Math.Abs(vector.X * vector.Y * vector.Z);
		}
	}
}
