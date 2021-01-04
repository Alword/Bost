using Bost.Agent.Model;

namespace Bost.Agent.Extentions
{
	public static class Сompare
	{
		public static (int min, int max) MinMax(int a, int b)
		{
			if (a <= b)
				return (a, b);
			else
				return (b, a);
		}

		/// <summary>
		/// Возвращает новые координаты где у min все координаты меньше чем у max
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static (Int3 min, Int3 max) MinMax(Int3 a, Int3 b)
		{
			(var minX, var maxX) = MinMax(a.X, b.X);
			(var minY, var maxY) = MinMax(a.Y, b.Y);
			(var minZ, var maxZ) = MinMax(a.Z, b.Z);
			return (new Int3(minX, minY, minZ), new Int3(maxX, maxY, maxZ));
		}
	}
}
