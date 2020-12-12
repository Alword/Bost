using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bost.Deductions.Enums
{
	public enum Colors
	{
		White,
		Gray,
		Blue,
		Green,
		Orange,
		Yellow,
		Red,
		Purple
	}

	public static class ColorsSwitch
	{
		public const string Red = "#f8cecc";
		public const string Green = "#d5e8d4";

		public static Colors FromRgb(string rgbColorString) => rgbColorString switch
		{
			Red => Colors.Red,
			Green => Colors.Green,
			_ => Colors.White
		};
	}
}
