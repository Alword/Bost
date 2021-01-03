using Bost.Proto.Packet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Bost.BOT.Tests.PaletteParser
{
	public class ReadAllBlocksTest
	{
		[Fact]
		public void BlocksJsonReader()
		{
			var resourse = ResourseReader.Read("blocks.json", typeof(BasePacket).Assembly);
			var objet = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(resourse);
			File.WriteAllText("blocks.txt", string.Join(Environment.NewLine, objet.Keys));
		}
	}
}
