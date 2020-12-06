using Bost.Proto.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Bost.BOT.Tests.PacketErrors
{
	public class ChunkSectionError
	{
		[Fact]
		public void ReadError()
		{
			ChunkSection chunkSection = new ChunkSection();

			var data = Convert.FromBase64String(ResourseReader.Read("ChunkSectionError1.txt"));
			chunkSection.Parse(ref data);
		}
	}
}
