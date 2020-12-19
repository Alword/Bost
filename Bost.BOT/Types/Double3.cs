using System;

namespace Bost.Agent.Types
{
	public struct Double3
	{
		public double X { get; set; }
		public double Y { get; set; }
		public double Z { get; set; }

		public static Double3 Zero => new Double3(0, 0, 0);

		public Double3(double x, double y, double z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public double Distance(Double3 b)
		{
			return Math.Sqrt(Math.Pow(X - b.X, 2) + Math.Pow(Y - b.Y, 2) + Math.Pow(Z - b.Z, 2));
		}

		public override bool Equals(object obj)
		{
			return obj is Double3 @double &&
				   X == @double.X &&
				   Y == @double.Y &&
				   Z == @double.Z;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(X, Y, Z);
		}

		public override string ToString()
		{
			return $"X:{X} Y:{Y} Z:{Z}";
		}
	}
}
