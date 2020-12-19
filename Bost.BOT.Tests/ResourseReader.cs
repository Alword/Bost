using System.IO;
using System.Linq;
using System.Reflection;

namespace Bost.BOT.Tests
{
	public class ResourseReader
	{
		public static string Read(string name)
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
