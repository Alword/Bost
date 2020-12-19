using Bost.Proto.Model;
using System;
using System.Linq;

namespace Bost.Proto.Types
{
	public static class McStatistic
	{
		public static bool TryParse(ref byte[] buffer, int count, out Statistic[] result)
		{
			result = new Statistic[count];
			for (int i = 0; i < count; i++)
			{
				result[i].Parse(ref buffer);
			}
			return true;
		}
		public static byte[] ToBytes(short value)
		{
			return BitConverter.GetBytes(value).Reverse().ToArray(); ;
		}
	}
}
