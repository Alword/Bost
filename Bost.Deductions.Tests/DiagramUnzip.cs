using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xunit;

namespace Bost.Deductions.Tests
{
	public class DiagramUnzip
	{
		[Fact]
		public void Decode_XML()
		{
			// arrange
			XmlDocument xmlDocument = new XmlDocument();
			var xmlString = "drawio.xml".Read();
			xmlDocument.LoadXml(xmlString);
			var compressed = xmlDocument.InnerText;

			// act
			var elem = DiagramsDecompressor.Decompress(ref compressed);
			// assert
		}
	}
}
