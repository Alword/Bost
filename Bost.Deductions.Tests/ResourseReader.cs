﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bost.Deductions.Tests
{
	public static class ResourseReader
	{
		public static string Read(this string name)
		{
			var assembly = Assembly.GetExecutingAssembly();
			string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith(name));
			using Stream stream = assembly.GetManifestResourceStream(resourceName);
			using StreamReader reader = new StreamReader(stream);
			string result = reader.ReadToEnd();
			return result;
		}
	}
}
