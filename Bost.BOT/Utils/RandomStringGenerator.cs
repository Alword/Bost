using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bost.Agent.Utils
{
	public class RandomStringGenerator
	{
		private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
		private static readonly Random _random = new Random();
		private static readonly TextInfo _textInfo = CultureInfo.CurrentCulture.TextInfo;
		public static string RandomString(int length)
		{
			var nick = new string(Enumerable.Repeat(_chars, length)
			  .Select(s => s[_random.Next(s.Length)]).ToArray());
			return _textInfo.ToTitleCase(nick);
		}

		public static string RandomString(int from, int to)
		{
			var length = _random.Next(from, to);
			return RandomString(length);
		}
	}
}
