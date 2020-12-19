using System;
using System.Linq;

namespace Bost.Proto.Types
{
	public class McInt
	{
		// bytes = 4
		public static bool TryParse(ref byte[] buffer, out int result)
		{
			result = BitConverter.ToInt32(buffer[0..4].Reverse().ToArray());
			buffer = buffer[4..];
			return true;
		}
		public static byte[] ToBytes(int value)
		{
			byte[] result = BitConverter.GetBytes(value);
			return result.Reverse().ToArray();
		}
	}
}
